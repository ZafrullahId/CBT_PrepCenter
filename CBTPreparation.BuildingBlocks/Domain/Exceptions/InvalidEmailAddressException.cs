using System.Net.Mail;

namespace CBTPreparation.BuildingBlocks.Domain.Exceptions
{
    public class InvalidEmailAddressException : DomainException
    {
        private const string _messages = "Invalid Email Address `{0}`.";
        public InvalidEmailAddressException(string email) : base(string.Format(_messages, email))
        {
        }
        public static void Throw(string email)
        {
            if (!MailAddress.TryCreate(email, out _))
            {
                throw new InvalidEmailAddressException(email);
            }
        }
    }
}
