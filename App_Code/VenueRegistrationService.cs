using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

public class VenueRegistrationService : IVenueRegistrationService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();

    public bool RegisterVenue(VenueLite v)
    {
        bool result = true;
        try
        {
            PasswordHash ph = new PasswordHash();
            KeyCode kc = new KeyCode();
            int code = kc.GetHashCode();
            byte[] hashed = ph.HashIt(v.Password, code.ToString());

            Venue vne = new Venue();
            vne.VenueName = v.VenueName;
            vne.VenueAddress = v.VenueAddress;
            vne.VenueCity = v.VenueCity;
            vne.VenueState = v.VenueState;
            vne.VenueZipCode = v.VenueZipCode;
            vne.VenuePhone = v.VenuePhone;
            vne.VenueEmail = v.VenueEmail;
            vne.VenueWebPage = v.VenueWebPage;
            vne.VenueAgeRestriction = v.VenueAgeRestriction;
            vne.VenueDateAdded = DateTime.Now;

            ste.Venues.Add(vne);

            VenueLogin vl = new VenueLogin();
            vl.VenueLoginUserName = v.UserName;
            vl.VenueLoginPasswordPlain = v.Password;
            vl.VenueLoginRandom = code;
            vl.VenueLoginHashed = hashed;
            vl.VenueLoginDateAdded = DateTime.Now;
            vl.Venue = vne;

            ste.VenueLogins.Add(vl);
            ste.SaveChanges();
        }
        catch
        {
            result = false;
        }
        return result;
    }

    public int VenueLogin(string userName, string password)
    {
        int id = 0;
        Login li = new Login(userName, password);
        id = li.ValidateLogin();

        return id;
    }
}
