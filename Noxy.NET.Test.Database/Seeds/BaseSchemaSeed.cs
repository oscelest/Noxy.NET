using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Database.Builders;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Domain.Enums;
using Noxy.NET.Test.Persistence;
using Noxy.NET.Test.Persistence.Tables.Schemas;
using Noxy.NET.Test.Presentation.Components.Controls;

namespace Noxy.NET.Test.Database.Seeds;

public class BaseSchemaSeed(DataContext context)
{
    public const string IdentifierContextCase = "ContextCase";

    public const string IdentifierDynamicValueCodeCreateCase = "CodeCreateCase";
    public const string IdentifierDynamicValueCodeCurrentDateAsHTMLValue = "CodeCurrentDateAsHTMLValue";
    public const string IdentifierDynamicValueCodeCurrentDateNextYearAsHTMLValue = "CodeCurrentDateNextYearAsHTMLValue";

    public const string IdentifierDynamicValueTextParameterCreateCaseTitle = "TextParameterCreateCaseTitle";
    public const string IdentifierDynamicValueTextParameterLabelYes = "TextParameterLabelYes";
    public const string IdentifierDynamicValueTextParameterLabelNo = "TextParameterLabelNo";
    
    public const string IdentifierAttributeIntegerMinLength = "AttributeIntegerMinLength";
    public const string IdentifierAttributeIntegerMaxLength = "AttributeIntegerMaxLength";

    public const string IdentifierAttributeStringHTMLAutoComplete = "AttributeStringHTMLAutoComplete";

    public const string IdentifierAttributeDynamicValueTextParameterLabelSingular = "AttributeDynamicValueTextParameterLabelSingular";
    public const string IdentifierAttributeDynamicValueTextParameterLabelMultiple = "AttributeDynamicValueTextParameterLabelMultiple";

    public const string IdentifierActionInputCaseNumber = "ActionInputCaseNumber";
    public const string IdentifierActionInputIsCompleted = "ActionInputIsCompleted";
    public const string IdentifierActionInputCreatedAt = "ActionInputCreatedAt";

    public const string IdentifierPropertyStringCaseNumber = "PropertyStringCaseNumber";
    public const string IdentifierPropertyBooleanCompleted = "PropertyBooleanCompleted";
    public const string IdentifierPropertyDateTimeCreated = "PropertyDateTimeCreated";

    public const string IdentifierElementCase = "ElementCase";
    public const string IdentifierElementJournal = "ElementJournal";

    public const string IdentifierActionCreateCase = "ActionCreateCase";

    public const string IdentifierActionCreateCaseActionStepAddData = "ActionCreateCaseActionStepAddData";

    public async Task Apply()
    {
        TableSchema tableSchema = await context.Schema.FirstAsync();
        SchemaSeedBuilder builder = new(context, tableSchema);
        DataSeedBuilder builderData = new(context);

        // Add attributes
        TableSchemaAttribute tableSchemaAttributeDynamicValueTextParameterLabelSingular = builder.AddAttribute(IdentifierAttributeDynamicValueTextParameterLabelSingular, "Label (singular, dynamic)", type: AttributeTypeEnum.DynamicValue);
        TableSchemaAttribute tableSchemaAttributeDynamicValueTextParameterLabelMultiple = builder.AddAttribute(IdentifierAttributeDynamicValueTextParameterLabelMultiple, "Label (multiple, dynamic)", type: AttributeTypeEnum.DynamicValue, isList: true);

        TableSchemaAttribute tableSchemaAttributeIntegerDynamicMinDate = builder.AddAttribute(SchemaActionInputConstants.SchemaIdentifierAttributeDynamicValueMinDate, "Min date (dynamic)", type: AttributeTypeEnum.DynamicValue);
        TableSchemaAttribute tableSchemaAttributeIntegerDynamicMaxDate = builder.AddAttribute(SchemaActionInputConstants.SchemaIdentifierAttributeDynamicValueMaxDate, "Max date (dynamic)", type: AttributeTypeEnum.DynamicValue);

        TableSchemaAttribute tableSchemaAttributeIntegerMinLength = builder.AddAttribute(IdentifierAttributeIntegerMinLength, "Min length (static)", type: AttributeTypeEnum.Integer);
        TableSchemaAttribute tableSchemaAttributeIntegerMaxLength = builder.AddAttribute(IdentifierAttributeIntegerMaxLength, "Max length (static)", type: AttributeTypeEnum.Integer);

        TableSchemaAttribute tableSchemaAttributeStringHTMLAutoComplete = builder.AddAttribute(IdentifierAttributeStringHTMLAutoComplete, "HTML AutoComplete (static)", type: AttributeTypeEnum.String);

        // Add Inputs
        TableSchemaInput tableSchemaInputCheckbox = await context.SchemaInput.FirstAsync(x => x.SchemaIdentifier == nameof(ActionInputCheckbox));
        builder.Relate(tableSchemaInputCheckbox, tableSchemaAttributeDynamicValueTextParameterLabelSingular);

        TableSchemaInput tableSchemaInputSingleChoice = await context.SchemaInput.FirstAsync(x => x.SchemaIdentifier == nameof(ActionInputSingleChoice));
        builder.Relate(tableSchemaInputSingleChoice, tableSchemaAttributeDynamicValueTextParameterLabelMultiple);

        TableSchemaInput tableSchemaInputDate = await context.SchemaInput.FirstAsync(x => x.SchemaIdentifier == nameof(ActionInputDate));
        builder.Relate(tableSchemaInputDate, tableSchemaAttributeIntegerDynamicMinDate);
        builder.Relate(tableSchemaInputDate, tableSchemaAttributeIntegerDynamicMaxDate);

        TableSchemaInput tableSchemaInputText = await context.SchemaInput.FirstAsync(x => x.SchemaIdentifier == nameof(ActionInputText));
        builder.Relate(tableSchemaInputText, tableSchemaAttributeIntegerMinLength);
        builder.Relate(tableSchemaInputText, tableSchemaAttributeIntegerMaxLength);
        builder.Relate(tableSchemaInputText, tableSchemaAttributeStringHTMLAutoComplete);

        // Add Code snippets

        const string codeDynamicValueCodeCurrentDateAsHTMLValue =
            """
            return DateTime.UtcNow.ToString("yyyy-MM-dd");
            """;
        TableSchemaDynamicValueCode tableDynamicValueCodeCurrentDateAsHTMLValue = builder.AddDynamicValueCode(IdentifierDynamicValueCodeCurrentDateAsHTMLValue, "Current date as HTML value", codeDynamicValueCodeCurrentDateAsHTMLValue);

        const string codeDynamicValueCodeCurrentDateNextYearAsHTMLValue =
            """
            return DateTime.UtcNow.AddYears(1).ToString("yyyy-MM-dd");
            """;
        TableSchemaDynamicValueCode tableDynamicValueCodeCurrentDateNextYearAsHTMLValue =
            builder.AddDynamicValueCode(IdentifierDynamicValueCodeCurrentDateNextYearAsHTMLValue, "Current date next year as HTML value", codeDynamicValueCodeCurrentDateNextYearAsHTMLValue);

        const string codeCreateCase =
            $$"""
              Dictionary<string, object?> properties = new()
              {
                  { "{{IdentifierPropertyStringCaseNumber}}", data.{{IdentifierActionInputCaseNumber}} },
                  { "{{IdentifierPropertyBooleanCompleted}}", data.{{IdentifierActionInputIsCompleted}} ?? false },
                  { "{{IdentifierPropertyDateTimeCreated}}", data.{{IdentifierActionInputCreatedAt}} ?? DateTime.UtcNow },
              };
              return await API.CreateElement("{{IdentifierElementCase}}", properties);
              """;
        TableSchemaDynamicValueCode tableDynamicValueCodeCreateCase = builder.AddDynamicValueCode(IdentifierDynamicValueCodeCreateCase, "Create case logic", codeCreateCase, isAsynchronous: true);

        // Add Text Parameters
        TableSchemaDynamicValueTextParameter tableDynamicValueTextParameterCreateCase = builder.AddDynamicValueTextParameter(IdentifierDynamicValueTextParameterCreateCaseTitle, "Create case");
        builderData.AddTextParameter(IdentifierDynamicValueTextParameterCreateCaseTitle, "Create case");

        TableSchemaDynamicValueTextParameter tableDynamicValueTextParameterLabelYes = builder.AddDynamicValueTextParameter(IdentifierDynamicValueTextParameterLabelYes, "Label: Yes");
        builderData.AddTextParameter(IdentifierDynamicValueTextParameterLabelYes, "Yes");

        TableSchemaDynamicValueTextParameter tableDynamicValueTextParameterLabelNo = builder.AddDynamicValueTextParameter(IdentifierDynamicValueTextParameterLabelNo, "Label: No");
        builderData.AddTextParameter(IdentifierDynamicValueTextParameterLabelNo, "No");

        // Add Properties
        TableSchemaPropertyString tablePropertyStringCaseNumber = builder.AddPropertyString(IdentifierPropertyStringCaseNumber, "Case number", "Case number");
        TableSchemaPropertyBoolean tablePropertyBooleanIsCompleted = builder.AddPropertyBoolean(IdentifierPropertyBooleanCompleted, "Is completed?", "Is completed?");
        TableSchemaPropertyDateTime tablePropertyDateTimeCreatedAt = builder.AddPropertyDateTime(IdentifierPropertyDateTimeCreated, "Created at", "Created at");

        // Add action input to CaseData Action
        TableSchemaActionInput tableActionInputCaseNumber = builder.AddActionInput(IdentifierActionInputCaseNumber, tableSchemaInputText, "Case number", "Case number");
        builder.Relate(tableActionInputCaseNumber, tableSchemaAttributeIntegerMinLength, 8);
        builder.Relate(tableActionInputCaseNumber, tableSchemaAttributeIntegerMaxLength, 12);
        
        TableSchemaActionInput tableActionInputIsCompleted = builder.AddActionInput(IdentifierActionInputIsCompleted, tableSchemaInputSingleChoice, "Is completed?", "Is completed?");
        builder.Relate(tableActionInputIsCompleted, tableSchemaAttributeDynamicValueTextParameterLabelMultiple, tableDynamicValueTextParameterLabelYes);
        builder.Relate(tableActionInputIsCompleted, tableSchemaAttributeDynamicValueTextParameterLabelMultiple, tableDynamicValueTextParameterLabelNo);

        TableSchemaActionInput tableActionInputCreatedAt = builder.AddActionInput(IdentifierActionInputCreatedAt, tableSchemaInputDate, "Created at", "Created at");
        builder.Relate(tableActionInputCreatedAt, tableSchemaAttributeIntegerDynamicMinDate, tableDynamicValueCodeCurrentDateAsHTMLValue);
        builder.Relate(tableActionInputCreatedAt, tableSchemaAttributeIntegerDynamicMaxDate, tableDynamicValueCodeCurrentDateNextYearAsHTMLValue);

        // Add action step to CaseData Action
        TableSchemaActionStep tableActionCreateCaseActionStepAddData = builder.AddActionStep(IdentifierActionCreateCaseActionStepAddData, "Add case data", "Add case data");
        builder.Relate(tableActionCreateCaseActionStepAddData, tableActionInputIsCompleted);
        builder.Relate(tableActionCreateCaseActionStepAddData, tableActionInputCaseNumber);
        builder.Relate(tableActionCreateCaseActionStepAddData, tableActionInputCreatedAt);

        // Add CaseData Action
        TableSchemaAction tableActionCreateCase = builder.AddAction(IdentifierActionCreateCase, tableDynamicValueTextParameterCreateCase, "Create case", "Create case");
        builder.Relate(tableActionCreateCase, tableDynamicValueCodeCreateCase);
        builder.Relate(tableActionCreateCase, tableActionCreateCaseActionStepAddData);

        // Add case element
        TableSchemaElement tableElementCase = builder.AddElement(IdentifierElementCase, "Case", "Case");
        builder.Relate(tableElementCase, tablePropertyStringCaseNumber);
        builder.Relate(tableElementCase, tablePropertyBooleanIsCompleted);
        builder.Relate(tableElementCase, tablePropertyDateTimeCreatedAt);

        // Add journal element
        TableSchemaElement tableElementJournal = builder.AddElement(IdentifierElementJournal, "Journal", "Journal");

        // Add case context
        TableSchemaContext tableContextCase = builder.AddContext(IdentifierContextCase, "Case context", "Case context");
        builder.Relate(tableContextCase, tableActionCreateCase);
        builder.Relate(tableContextCase, tableElementCase);
        builder.Relate(tableContextCase, tableElementJournal);

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
