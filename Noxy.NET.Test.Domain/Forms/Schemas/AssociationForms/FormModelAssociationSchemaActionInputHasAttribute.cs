using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Models;

namespace Noxy.NET.Test.Domain.Forms.Schemas.AssociationForms;

public abstract class FormModelAssociationSchemaActionInputHasAttribute(EntitySchemaActionInput? entity, EntitySchemaAttribute? relation) : BaseFormModelEntityAssociation(entity, relation)
{
    public class Discriminator
    {
        public Guid ID { get; set; }
        public Guid EntityID { get; set; }
        public Guid RelationID { get; set; }

        public FormModelAssociationSchemaActionInputHasAttribute<string?>? String { get; init; }
        public FormModelAssociationSchemaActionInputHasAttribute<int?>? Integer { get; init; }
        public FormModelAssociationSchemaActionInputHasAttribute<decimal?>? Decimal { get; init; }
        public FormModelAssociationSchemaActionInputHasAttribute<GenericUUID<EntitySchemaDynamicValue>?>? DynamicValue { get; init; }

        [JsonConstructor]
        public Discriminator()
        {
        }

        public Discriminator(FormModelAssociationSchemaActionInputHasAttribute? entity)
        {
            switch (entity)
            {
                case FormModelAssociationSchemaActionInputHasAttribute<string?> value:
                    String = value;
                    break;
                case FormModelAssociationSchemaActionInputHasAttribute<int?> value:
                    Integer = value;
                    break;
                case FormModelAssociationSchemaActionInputHasAttribute<decimal?> value:
                    Decimal = value;
                    break;
                case FormModelAssociationSchemaActionInputHasAttribute<GenericUUID<EntitySchemaDynamicValue>?> value:
                    DynamicValue = value;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            ID = entity.ID;
            EntityID = entity.EntityID;
            RelationID = entity.RelationID;
        }

        public FormModelAssociationSchemaActionInputHasAttribute GetValue()
        {
            if (String != null) return String;
            if (Integer != null) return Integer;
            if (Decimal != null) return Decimal;
            if (DynamicValue != null) return DynamicValue;
            throw new();
        }
    }
}

public class FormModelAssociationSchemaActionInputHasAttribute<T>(EntitySchemaActionInput? entity, EntitySchemaAttribute? relation, IEnumerable<T> value) : FormModelAssociationSchemaActionInputHasAttribute(entity, relation)
{
    [JsonConstructor]
    public FormModelAssociationSchemaActionInputHasAttribute() : this(null, null, [])
    {
    }

    public override string APIEndpoint => "Association/Schema/ActionInput/Attribute/" + typeof(T) switch
    {
        { } t when t == typeof(int?) => "Integer",
        { } t when t == typeof(string) => "String",
        { } t when t == typeof(decimal?) => "Decimal",
        { } t when t == typeof(GenericUUID<EntitySchemaDynamicValue>) => "DynamicValue",
        _ => "Unknown"
    };

    public List<T> Value { get; set; } = value.ToList();
}
