using Microsoft.AspNetCore.Mvc;
using Noxy.NET.Test.Application.Interfaces.Services;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Forms.Schemas.JunctionForms;

namespace Noxy.NET.Test.API.Controllers;

[ApiController]
[Route("[controller]")]
public class JunctionController(IJunctionService serviceJunction) : ControllerBase
{
    [HttpPost("Schema/Action/ActionStep")]
    public async Task<ActionResult<EntitySchemaAction>> RelateActionWithActionStepList(FormModelJunctionSchemaActionHasActionStep model)
    {
        return await serviceJunction.Relate(model);
    }

    [HttpPost("Schema/Action/DynamicValueCode")]
    public async Task<ActionResult<EntitySchemaAction>> RelateActionWithDynamicValueCodeList(FormModelJunctionSchemaActionHasDynamicValueCode model)
    {
        return await serviceJunction.Relate(model);
    }

    [HttpPost("Schema/ActionStep/ActionInput")]
    public async Task<ActionResult<EntitySchemaActionStep>> RelateActionStepWithActionInputList(FormModelJunctionSchemaActionStepHasActionInput model)
    {
        return await serviceJunction.Relate(model);
    }

    [HttpPost("Schema/Context/Action")]
    public async Task<ActionResult<EntitySchemaContext>> RelateActionWithContextWithActionList(FormModelJunctionSchemaContextHasAction model)
    {
        return await serviceJunction.Relate(model);
    }

    [HttpPost("Schema/Context/Element")]
    public async Task<ActionResult<EntitySchemaContext>> RelateActionWithContextWithElementList(FormModelJunctionSchemaContextHasElement model)
    {
        return await serviceJunction.Relate(model);
    }

    [HttpPost("Schema/Element/Property")]
    public async Task<ActionResult<EntitySchemaElement>> RelateElementWithPropertyList(FormModelJunctionSchemaElementHasProperty model)
    {
        return await serviceJunction.Relate(model);
    }
}
