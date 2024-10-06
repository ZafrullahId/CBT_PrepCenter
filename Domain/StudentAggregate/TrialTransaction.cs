using Blogger.BuildingBlocks.Domain;
using CBTPreparation.BuildingBlocks.Domain;

namespace CBTPreparation.Domain.StudentAggregate;


public class TrialTransaction : Entity<TrialTransactionId>
{
    public StudentId StudentId { get; set; }
    public DateTimeOffset PurchaseDate { get; set; } = DateTime.UtcNow;
    public decimal TrialPrice { get; set; }
    public int Quantity { get; set; }
    private decimal _totalAmount;
    public decimal TotalAmount
    {
        get => TrialPrice * Quantity;
        private set => _totalAmount = value;
    }
    public string PaymentMethod { get; set; }
    private TrialTransaction(TrialTransactionId trialTransactionId) : base(trialTransactionId)
    {
        _totalAmount = TrialPrice * Quantity;
    }
    private TrialTransaction() : base(null!) { }
    //private TrialTransaction(,
    //                         StudentId studentId,
    //                         decimal trialPrice,
    //                         string paymentMethod,
    //                         int quantity) : base(trialTransactionId)
    //{
    //    TrialPrice = trialPrice;
    //    PaymentMethod = paymentMethod;
    //    Quantity = quantity;
    //    StudentId = studentId;
    //}
    public static TrialTransaction Create(StudentId studentId, int quantity, decimal trialPrice, string paymentMethod)
    {
        // check if the trial price is equal to the price in the DB this is to be done in the command handler
        // check if quantity is greater than zero
        var transaction = new TrialTransaction(TrialTransactionId.CreateUniqueId())
        {
            StudentId = studentId,
            TrialPrice = trialPrice,
            PaymentMethod = paymentMethod,
            Quantity = quantity
        };

        return transaction;
    }

}
