using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVenueRegistrationService" in both code and config file together.
[ServiceContract]
public interface IVenueRegistrationService
{
	[OperationContract]
	bool RegisteVenue(VanueLite v);

    [OperationContract]
    int VenueLogin(string userName, string password);
}

[DataContract]
public class VanueLite
{
    [DataMember]
    public string VenueName{ set; get; }
    [DataMember]
    public string VenueAddress { set; get; }
    [DataMember]
    public string VenueCity { set; get; }
    [DataMember]
    public string VenueState { set; get; }
    [DataMember]
    public string VenueZipCode { set; get; }
    [DataMember]
    public string VenuePhone { set; get; }
    [DataMember]
    public string VenueEmail { set; get; }
    [DataMember]
    public string VenueWebPage { set; get; }
    [DataMember]
    public int VenueAgeRestriction { set; get; }
    [DataMember]
    public string UserName { set; get; }
    [DataMember]
    public string Password { set; get; }
}

