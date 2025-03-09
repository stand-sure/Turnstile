namespace Service.Person;

using JetBrains.Annotations;

using Service.Data;

[UsedImplicitly]
internal class AddressType : ObjectType<Address>
{
    protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
    {
        descriptor.Field(address => address.Id).ID();
    }
}