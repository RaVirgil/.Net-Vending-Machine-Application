namespace iQuest.Business.PaymentMethods
{
    public interface IPaymentMethod
    {
        public string Name { get; }
        public float PriceToPay { get; set; }

        void Execute();
    }
}