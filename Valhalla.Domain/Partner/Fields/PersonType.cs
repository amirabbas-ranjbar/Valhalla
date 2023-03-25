using System.ComponentModel;

namespace Valhalla.Domain.Partner.Fields
{
    public enum PersonType
    {
        [Description("شخص حقیقی")]
        PrivatePerson = 1,
        [Description("شخص حقوقی")]
        LegalPerson = 2,
    }
}
