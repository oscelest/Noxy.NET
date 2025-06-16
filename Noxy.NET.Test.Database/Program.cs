using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Noxy.NET.Test.Database.Seeds;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddPersistence(x => x.UseSqlite(@"Data Source=..\..\..\..\Data\Database.sqlite").EnableSensitiveDataLogging());
builder.Services.AddBaseToPersistence();

using IHost app = builder.Build();

await app.UsePersistence(async (context, isFirstMigration) =>
{
    await app.UseBaseWithPersistence();
    if (isFirstMigration)
    {
        await new BaseSchemaSeed(context).Apply();
        await new BaseTextSeed(context).Apply();
        await new BaseDataSeed(context).Apply();
    }
});
