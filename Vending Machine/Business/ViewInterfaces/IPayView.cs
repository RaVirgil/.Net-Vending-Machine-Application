using iQuest.Business.PaymentMethods;
using System.Collections.Generic;

namespace iQuest.Business.ViewInterfaces
{
    public interface IPayView
    {
        void AnnounceSuccessfulPayment();

        IPaymentMethod AskPaymentMethod(IEnumerable<IPaymentMethod> paymentMethods);
    }
}