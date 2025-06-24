using System.IO.Hashing;
using System.Reflection;
using System.Text;
using Microsoft.JSInterop;

namespace Noxy.NET.UI.Extensions;

public static class JSRuntimeExtensions
{
    private static readonly HashSet<string> LoadedScripts = [];
    private static readonly HashSet<string> LoadedResources = [];

    public static async Task LoadScript(this IJSRuntime self, string code)
    {
        byte[] byteCode = Encoding.UTF8.GetBytes(code);
        byte[] byteHash = XxHash128.Hash(byteCode);
        string hexHash = Convert.ToHexString(byteHash);
        if (LoadedScripts.Add(hexHash)) await self.InvokeVoidAsync("eval", code);
    }

    public static async Task LoadScriptResource(this IJSRuntime self, string path, Assembly? assembly = null)
    {
        if (!LoadedResources.Add(path)) return;

        try
        {
            IJSObjectReference response = await self.InvokeAsync<IJSObjectReference>("fetch", path);
            string code = await response.InvokeAsync<string>("text");
            await LoadScript(self, code);
        }
        catch
        {
            LoadedResources.Remove(path);
            throw;
        }
    }

    public static string GetComponentPath(this IJSRuntime self, Type componentType, bool local = false)
    {
        string? nameComponent = componentType.FullName;
        ArgumentException.ThrowIfNullOrWhiteSpace(nameComponent);

        string? nameAssembly = Assembly.GetCallingAssembly().GetName().Name;
        ArgumentException.ThrowIfNullOrWhiteSpace(nameAssembly);

        string nameClassFull = nameComponent[(nameAssembly.Length + 1)..];
        string nameClassPartial = nameClassFull.Split('`').First();
        string path = nameClassPartial.Replace('.', '/');

        return local ? $"./{path}.razor.js" : $"./_content/{nameAssembly}/{path}.razor.js";
    }
}
