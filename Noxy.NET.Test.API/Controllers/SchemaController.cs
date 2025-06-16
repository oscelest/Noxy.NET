using Microsoft.AspNetCore.Mvc;
using Noxy.NET.Test.Application.Interfaces.Services;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Forms.Schemas.Forms;

namespace Noxy.NET.Test.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SchemaController(ISchemaService serviceSchema) : ControllerBase
{
    [HttpPost("Action")]
    public async Task<ActionResult<EntitySchemaAction>> Create(FormModelSchemaAction model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPut("Action")]
    public async Task<ActionResult<EntitySchemaAction>> Update(FormModelSchemaAction model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPost("ActionInput")]
    public async Task<ActionResult<EntitySchemaActionInput>> Create(FormModelSchemaActionInput model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPut("ActionInput")]
    public async Task<ActionResult<EntitySchemaActionInput>> Update(FormModelSchemaActionInput model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPost("ActionStep")]
    public async Task<ActionResult<EntitySchemaActionStep>> Create(FormModelSchemaActionStep model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPut("ActionStep")]
    public async Task<ActionResult<EntitySchemaActionStep>> Update(FormModelSchemaActionStep model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPost("Attribute")]
    public async Task<ActionResult<EntitySchemaAttribute>> Create(FormModelSchemaAttribute model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPut("Attribute")]
    public async Task<ActionResult<EntitySchemaAttribute>> Update(FormModelSchemaAttribute model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }
    
    [HttpPost("Context")]
    public async Task<ActionResult<EntitySchemaContext>> Create(FormModelSchemaContext model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPut("Context")]
    public async Task<ActionResult<EntitySchemaContext>> Update(FormModelSchemaContext model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPost("DynamicValue/Code")]
    public async Task<ActionResult<EntitySchemaDynamicValue.Discriminator>> Create(FormModelSchemaDynamicValueCode model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPut("DynamicValue/Code")]
    public async Task<ActionResult<EntitySchemaDynamicValue.Discriminator>> Update(FormModelSchemaDynamicValueCode model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPost("DynamicValue/SystemParameter")]
    public async Task<ActionResult<EntitySchemaDynamicValue.Discriminator>> Create(FormModelSchemaDynamicValueSystemParameter model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPut("DynamicValue/SystemParameter")]
    public async Task<ActionResult<EntitySchemaDynamicValue.Discriminator>> Update(FormModelSchemaDynamicValueSystemParameter model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPost("DynamicValue/TextParameter")]
    public async Task<ActionResult<EntitySchemaDynamicValue.Discriminator>> Create(FormModelSchemaDynamicValueTextParameter model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPut("DynamicValue/TextParameter")]
    public async Task<ActionResult<EntitySchemaDynamicValue.Discriminator>> Update(FormModelSchemaDynamicValueTextParameter model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }
    
    [HttpPost("Element")]
    public async Task<ActionResult<EntitySchemaElement>> Create(FormModelSchemaElement model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPut("Element")]
    public async Task<ActionResult<EntitySchemaElement>> Update(FormModelSchemaElement model)
    {
        return await serviceSchema.CreateOrUpdate(model);
    }

    [HttpPost("Property/Boolean")]
    public async Task<ActionResult<EntitySchemaPropertyBoolean>> Create(FormModelSchemaPropertyBoolean model)
    {
        return (await serviceSchema.CreateOrUpdate(model)).Boolean ?? throw new();
    }

    [HttpPut("Property/Boolean")]
    public async Task<ActionResult<EntitySchemaPropertyBoolean>> Update(FormModelSchemaPropertyBoolean model)
    {
        return (await serviceSchema.CreateOrUpdate(model)).Boolean ?? throw new();
    }

    [HttpPost("Property/DateTime")]
    public async Task<ActionResult<EntitySchemaPropertyDateTime>> Create(FormModelSchemaPropertyDateTime model)
    {
        return (await serviceSchema.CreateOrUpdate(model)).DateTime ?? throw new();
    }

    [HttpPut("Property/DateTime")]
    public async Task<ActionResult<EntitySchemaPropertyDateTime>> Update(FormModelSchemaPropertyDateTime model)
    {
        return (await serviceSchema.CreateOrUpdate(model)).DateTime ?? throw new();
    }

    [HttpPost("Property/String")]
    public async Task<ActionResult<EntitySchemaPropertyString>> Create(FormModelSchemaPropertyString model)
    {
        return (await serviceSchema.CreateOrUpdate(model)).String ?? throw new();
    }

    [HttpPut("Property/String")]
    public async Task<ActionResult<EntitySchemaPropertyString>> Update(FormModelSchemaPropertyString model)
    {
        return (await serviceSchema.CreateOrUpdate(model)).String ?? throw new();
    }
}
