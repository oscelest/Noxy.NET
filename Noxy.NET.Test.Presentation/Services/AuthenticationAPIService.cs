using Noxy.NET.Test.Domain.Forms.Authentication;
using Noxy.NET.Test.Presentation.Abstractions;

namespace Noxy.NET.Test.Presentation.Services;

public class AuthenticationAPIService(HttpClient http, UserAuthenticationStateProvider serviceAuthentication) : BaseServiceAPI(http, serviceAuthentication)
{
    public async Task<string> SignUpUser(SignUpUserFormModel model)
    {
        HttpRequestMessage requestMessage = CreateRequest(HttpMethod.Post, "User", model);
        HttpContent response = HandleResponse(await SendRequest(requestMessage));
        return await response.ReadAsStringAsync();
    }

    public async Task<string> SignInUser(SignInUserFormModel model)
    {
        HttpRequestMessage requestMessage = CreateRequest(HttpMethod.Post, "User/LogIn", model);
        HttpContent response = HandleResponse(await SendRequest(requestMessage));
        return await response.ReadAsStringAsync();
    }

    public async Task<string> RenewUser()
    {
        HttpRequestMessage requestMessage = CreateRequest(HttpMethod.Post, "User/Renew");
        HttpContent response = HandleResponse(await SendRequest(requestMessage));
        return await response.ReadAsStringAsync();
    }
}
