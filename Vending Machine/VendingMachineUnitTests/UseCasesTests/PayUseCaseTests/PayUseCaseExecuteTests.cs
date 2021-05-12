using iQuest.Business.Exceptions;
using iQuest.Business.PaymentMethods;
using iQuest.Business.UseCases;
using iQuest.Business.ViewInterfaces;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace VendingMachineUnitTests.UseCasesTests.PayUseCaseTests
{
    public class PayUseCaseExecuteTests
    {
        private readonly Mock<IPayView> payView;
        private readonly Mock<ICashPaymentView> cashPaymentView;
        private readonly Mock<ICardPaymentView> cardPaymentView;
        private readonly List<IPaymentMethod> paymentMethods;
        private readonly PayUseCase payUseCase;

        public PayUseCaseExecuteTests()
        {
            payView = new Mock<IPayView>();
            cashPaymentView = new Mock<ICashPaymentView>();
            cardPaymentView = new Mock<ICardPaymentView>();

            paymentMethods = new List<IPaymentMethod> {
                new CashPaymentMethod(cashPaymentView.Object),
                new CardPaymentMethod(cardPaymentView.Object)
                };

            payUseCase = new PayUseCase(payView.Object, paymentMethods);
            payUseCase.PriceToPay = 5;
        }

        [Fact]
        public void HavingACashPaymentMethod_WhenUserInputFails_ThenCheckIfNoAnnouncedSuccessfulPayment()
        {
            payView.Setup(x => x.AskPaymentMethod(paymentMethods)).Returns(paymentMethods[0]);
            cashPaymentView.Setup(x => x.CollectMoneyCash()).Throws<CancelException>();

            Assert.Throws<CancelException>(() =>
            {
                payUseCase.Execute();
            }
            );
        }

        [Fact]
        public void HavingACashPaymentMethod_WhenUserInputIsOk_ThenCheckIfAnnouncedSuccessfulPayment()
        {
            payView.Setup(x => x.AskPaymentMethod(paymentMethods)).Returns(paymentMethods[0]);
            cashPaymentView.Setup(x => x.CollectMoneyCash()).Returns(5);

            payUseCase.Execute();

            payView.Verify(x => x.AnnounceSuccessfulPayment(), Times.Once);
        }

        [Fact]
        public void HavingACardPaymentMethod_WhenUserInputIsOk_ThenCheckIfAnnouncedSuccessfulPayment()
        {
            payView.Setup(x => x.AskPaymentMethod(paymentMethods)).Returns(paymentMethods[1]);
            cardPaymentView.Setup(x => x.AskCardNumber()).Returns("4916505479001417");

            payUseCase.Execute();

            payView.Verify(x => x.AnnounceSuccessfulPayment(), Times.Once);
        }
    }
}