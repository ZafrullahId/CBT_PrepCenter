using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.TrialTransactionAggregate;


public class TrialTransaction : AggregateRoot<TrialTransactionId>
{
    public DateTimeOffset PurchaseDate { get; set; } = DateTime.UtcNow;
    public decimal TrialPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount => TrialPrice * Quantity;
    public string PaymentMethod { get; set; }
    private TrialTransaction(TrialTransactionId trialTransactionId,
                             decimal trialPrice,
                             string paymentMethod,
                             int quantity) : base(trialTransactionId)
    {
        TrialPrice = trialPrice;
        PaymentMethod = paymentMethod;
        Quantity = quantity;
    }
    public static TrialTransaction Create(int quantity, decimal trialPrice, string paymentMethod)
    {
        // check if the trial price is equal to the price in the DB this is to be done in the command handler
        var transaction = new TrialTransaction(TrialTransactionId.CreateUniqueId(),
                                               trialPrice,
                                               paymentMethod,
                                               quantity);
        return transaction;
    }

}
