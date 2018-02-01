using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7
{
    public class Client
    {
        private void SetContactAtBronto(ContactStatus contactStatus, string email, string guid)
        {
            try
            {
                var service = new Web.Api.Client.Services.EmailService(primarySiteCode, company);
                var response = service.GetContact(new GetContactRequest(){Email = email});
                    if (response.Contact != null)
                    {
                        service.AddContact(new AddContactRequest() { Contact = new ContactView() {Id = response.Contact.Id, Email = email, ContactStatus = contactStatus }});
                    }
                    else
                     {
                         service.AddContact(new AddContactRequest() { Contact = new ContactView() { SiteCode = primarySiteCode, Email = email, ContactStatus = contactStatus, GUID = guid } });
                     }

             }
        catch (Exception ex)
            {
                string strMsg = string.Format("PHEProfileSync.NET Thread {0} failed to create Bronto contact {1}:{2} {3}", m_strCompany, email, ex.Message, ex.StackTrace);
                if (ProfileSyncService.Debug)
                {
                    Console.WriteLine(strMsg);
                }

                ProfileSyncService.WriteToEventLog(strMsg,EventLogEntryType.Error);
            }

        }
    }
}
