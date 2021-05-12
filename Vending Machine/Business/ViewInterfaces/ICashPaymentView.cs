namespace iQuest.Business.ViewInterfaces
{
    public interface ICashPaymentView
    {
        float CollectMoneyCash();

        void NeedToPayMore(float priceToPay);

        void ReturnChange(float change);
    }
}