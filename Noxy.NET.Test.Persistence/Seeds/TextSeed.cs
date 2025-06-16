using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Persistence.Abstractions;
using Noxy.NET.Test.Persistence.Tables.Schemas;

namespace Noxy.NET.Test.Persistence.Seeds;

public class TextSeed(ModelBuilder builder, TableSchema refSchema) : BaseSeed(builder, refSchema)
{
    public void Apply()
    {
        HasSchemaDynamicValueTextParameter("019764ca-25c4-7785-bd02-daa168ae477d", TextConstants.ButtonActivate);
        HasSchemaDynamicValueTextParameter("019764ca-25c4-7785-bd02-de67a804e592", TextConstants.ButtonCreate);
        HasSchemaDynamicValueTextParameter("019764ca-25c4-7785-bd02-e26550fa3aa9", TextConstants.ButtonUpdate);
        HasSchemaDynamicValueTextParameter("019764ca-25c4-7785-bd02-e5902e766443", TextConstants.ButtonSubmit);

        HasTableDataTextParameter("019764ca-25c4-7785-bd02-ebdc5a27fb39", TextConstants.ButtonActivate, "Activate");
        HasTableDataTextParameter("019764ca-25c4-7785-bd02-efa276b57b62", TextConstants.ButtonCreate, "Create");
        HasTableDataTextParameter("019764ca-25c4-7785-bd02-f1e439a3bb07", TextConstants.ButtonUpdate, "Update");
        HasTableDataTextParameter("019764ca-25c4-7785-bd02-f7c5260cb82d", TextConstants.ButtonSubmit, "Submit");
    }
}
