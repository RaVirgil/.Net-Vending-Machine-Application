using iQuest.Business.PaymentMethods;
using iQuest.Business.Repository;
using iQuest.Business.ViewInterfaces;
using System;
using System.Collections.Generic;

namespace iQuest.Business.UseCases
{
    public class PayUseCase : IPayUseCase
    {
        private readonly IPayView payView;
        private IEnumerable<IPaymentMethod> paymentMethods;
        public float PriceToPay { get; set; }

        public PayUseCase(IPayView payView, IEnumerable<IPaymentMethod> paymentMethods)
        {
            this.payView = payView ?? throw new ArgumentNullException(nameof(payView));
            this.paymentMethods = paymentMethods ?? throw new ArgumentNullException(nameof(paymentMethods));
        }

        public string Execute()
        {
            IPaymentMethod paymentMethod = payView.AskPaymentMethod(paymentMethods);
            paymentMethod.PriceToPay = PriceToPay;
            paymentMethod.Execute();
            payView.AnnounceSuccessfulPayment();

            return paymentMethod.Name;
        }
    }
}