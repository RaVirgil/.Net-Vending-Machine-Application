using CreditCardValidator;
using iQuest.Business.ViewInterfaces;

namespace iQuest.Business.PaymentMethods
{
    public class CardPaymentMethod : IPaymentMethod
    {
        public string Name => "Card";
        public float PriceToPay { get; set; }
        private readonly ICardPaymentView cardPaymentView;

        public CardPaymentMethod(ICardPaymentView cardPaymentView)
        {
            this.cardPaymentView = cardPaymentView;
        }

        public void Execute()
        {
            string cardNumber = cardPaymentView.AskCardNumber();
            while (!VerifyCardNumber(cardNumber))
            {
                cardNumber = cardPaymentView.AskCardNumber();
            }
            return;
        }

        private bool VerifyCardNumber(string cardNumber)
        {
            CreditCardDetector detector = new CreditCardDetector(cardNumber);
            return detector.IsValid();
        }
    }
}