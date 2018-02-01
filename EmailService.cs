using System;
using SL.Interfaces;

namespace Web.Api.Client.Services
{
    public class EmailService : IEmailService

    {
        private readonly JsonServiceClient _client;

        public EmailService(string siteCode)
        {
            _client = new JsonServiceClient(WebConnectionUriBuilder.GetFor(siteCode), WebConnectionUriBuilder.GetApiKey());
        }

        public EmailService(string siteCode, string companyCode)
        {
            _client = new JsonServiceClient(WebConnectionUriBuilder.GetFor(siteCode, companyCode), WebConnectionUriBuilder.GetApiKey(), siteCode);
        }


        public SendEmailResponse Send(SendEmailRequest request)
        {
            return _client.PostResult<SendEmailRequest, SendEmailResponse>("api/email/send", request);
        }

        public ViewEmailResponse GetViewOnline(ViewEmailRequest request)
        {
            return _client.PostResult<ViewEmailRequest, ViewEmailResponse>("api/email/getviewonline", request);
        }

        public AddContactResponse AddContact(AddContactRequest request)
        {
            return _client.PostResult<AddContactRequest, AddContactResponse>("api/email/addcontact", request);
        }

        public BaseResponse UpdateContact(UpdateContactRequest request)
        {
            return _client.PostResult<UpdateContactRequest, BaseResponse>("api/email/updatecontact", request);
        }

        public GetContactResponse GetContact(GetContactRequest request)
        {
            return _client.PostResult<GetContactRequest, GetContactResponse>("api/email/getcontact", request);
        }
        public ValidateEmailResponse ValidateEmail(ValidateEmailRequest request)
        {
            return _client.PostResult<ValidateEmailRequest, ValidateEmailResponse>("api/email/validateemail", request);
        }
        public UpdateEmailResponse UpdateEmail(UpdateEmailRequest request)
        {
            return _client.PostResult<UpdateEmailRequest, UpdateEmailResponse>("api/email/updateemail", request);
        }

        public BaseResponse UpdateContactFields(UpdateContactFieldsRequest request)
        {
            return _client.PostResult<UpdateContactFieldsRequest, BaseResponse>("api/email/updatecontactfields", request);
        }
    }
}
