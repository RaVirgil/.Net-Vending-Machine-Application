using iQuest.Business.ViewInterfaces;

namespace iQuest.Business.PaymentMethods
{
    public class CashPaymentMethod : IPaymentMethod
    {
        public string Name => "Cash";
        public float PriceToPay { get; set; }
        private readonly ICashPaymentView cashPaymentView;

        public CashPaymentMethod(ICashPaymentView cashPaymentView)
        {
            this.cashPaymentView = cashPaymentView;
        }

        public void Execute()
        {
            float money = 0;
            while (PriceToPay - money > 0)
            {
                cashPaymentView.NeedToPayMore(PriceToPay - money);
                money += cashPaymentView.CollectMoneyCash();
            }

            if (PriceToPay - money < 0)
            {
                cashPaymentView.ReturnChange(money - PriceToPay);
                return;
            }

            return;
        }
    }
}