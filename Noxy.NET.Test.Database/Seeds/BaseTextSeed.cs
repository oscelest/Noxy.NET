using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Database.Builders;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Persistence;
using Noxy.NET.Test.Persistence.Tables.Schemas;

namespace Noxy.NET.Test.Database.Seeds;

public class BaseTextSeed(DataContext context)
{
    public async Task Apply()
    {
        TableSchema tableSchema = await context.Schema.FirstAsync();
        SchemaSeedBuilder builder = new(context, tableSchema);
        DataSeedBuilder builderData = new(context);
        
        builder.AddDynamicValueTextParameter(TextConstants.ActionPanelHeader, "ActionPanel header");
        builderData.AddTextParameter(TextConstants.ActionPanelHeader, "Actions");
        
        try
        {
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
