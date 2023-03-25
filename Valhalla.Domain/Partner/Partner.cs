using Okala.Core.Abstraction.Aggregates;
using Okala.Core.Domain.Entities;
using Valhalla.Domain.Partner.Fields;

namespace Valhalla.Domain.Partner;

public class Partners : Entity<long>, IAggregateRoot
{
    #region [ Properties ]

    public string PartnerName { get; private set; }
    public string PartnerBrand { get; private set; }
    public PersonType PersonType { get; private set; }
    public string NationalId { get; private set; }
    public string PartnerAddress { get; private set; }
    public string PartnerPhoneNo { get; private set; }
    public string ManagerName { get; private set; }
    public string ContactName { get; private set; }
    public string ContactPhoneNo { get; private set; }
    public string PostalCode { get; private set; }
    public string RegistrationNo { get; private set; }
    public string Description { get; private set; }
    public string Logo { get; private set; }
    public string Fax { get; private set; }
    public PartnerState PartnerState { get; private set; }
    public string Email { get; private set; }
    public string EconomicalCode { get; private set; }
    public string RegistrationRejectReason { get; } = string.Empty;
    public long IdentityId { get; private set; }
    public long CityId { get; set; }
    public string CityName { get; set; }

    #endregion

    #region [ Partner ]

    private Partners()
    {
    }

    public static Partners Create(long id, string partnerName,
        string economicalCode, string nationalId)
    {
        var entity = new Partners
        {
            Id = id,
            PartnerName = partnerName,
            EconomicalCode = economicalCode,
            NationalId = nationalId
        };


        return entity;
    }

    public void SetAddressInfo(string partnerAddress, string partnerPhoneNo, string postalCode,
        string registrationNo)
    {
        PartnerPhoneNo = partnerPhoneNo;
        PartnerAddress = partnerAddress;
        PostalCode = postalCode;
        RegistrationNo = registrationNo;
    }

    public void SetContactInfo(string contactPhoneNo, string email, string fax)
    {
        Fax = fax;
        ContactPhoneNo = contactPhoneNo;
        Email = email;
    }

    public void SetState(PartnerState partnerState)
    {
        PartnerState = partnerState;
    }

    public void SetLogo(string logo)
    {
        Logo = logo;
    }

    public void Update(string partnerName, string economicalCode, string nationalId)
    {
        PartnerName = partnerName;
        EconomicalCode = economicalCode;
        NationalId = nationalId;
    }

    public void SetIdentityId(long identityId)
    {
        IdentityId = identityId;
    }

    #endregion
}