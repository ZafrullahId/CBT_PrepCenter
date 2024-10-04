using CBTPreparation.BuildingBlocks.Domain;
using CBTPreparation.Domain.StudentAggregate;

namespace CBTPreparation.Domain.TrialTransactionAggregate;


public class TrialTransaction : AggregateRoot<TrialTransactionId>
{
    public DateTimeOffset PurchaseDate { get; set; } = DateTime.UtcNow;
    public decimal TrialPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount => TrialPrice * Quantity;
    public string PaymentMethod { get; set; }
    public StudentId StudentId { get; set; }
    private TrialTransaction(TrialTransactionId trialTransactionId,
                             StudentId studentId,
                             decimal trialPrice,
                             string paymentMethod,
                             int quantity) : base(trialTransactionId)
    {
        TrialPrice = trialPrice;
        PaymentMethod = paymentMethod;
        Quantity = quantity;
        StudentId = studentId;
    }
    public static TrialTransaction Create(StudentId studentId, int quantity, decimal trialPrice, string paymentMethod)
    {
        // check if the trial price is equal to the price in the DB this is to be done in the command handler
        // check if quantity is greater than zero
        var transaction = new TrialTransaction(TrialTransactionId.CreateUniqueId(),
                                               studentId,
                                               trialPrice,
                                               paymentMethod,
                                               quantity);
        return transaction;
    }

}
