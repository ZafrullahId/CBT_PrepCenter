using System.Net;

namespace CBTPreparation.BuildingBlocks.Domain.Exceptions
{
    public class PriceLessThanMinimumTrialPriceException : DomainException
    {
        private const string _message = "New Price `{NewPrice}` Cannot be less than the minimum trial price `{MinimumPrice}`";
        public PriceLessThanMinimumTrialPriceException(decimal newPrice, decimal minimumPrice, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(string.Format(_message, newPrice, minimumPrice), statusCode)
        {
        }
    }
}
