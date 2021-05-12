using Autofac;
using Business.ViewInterfaces;
using DatabaseDataLayer;
using iQuest.Business.Authentication;
using iQuest.Business.PaymentMethods;
using iQuest.Business.Reports;
using iQuest.Business.Repository;
using iQuest.Business.UseCases;
using iQuest.Business.ViewInterfaces;
using iQuest.DatabaseDataLayer;
using iQuest.Presentation.Views;
using JsonRepositories.SalesReport;
using JsonRepositories.StockReport;
using JsonRepositories.VolumeReport;
using Presentation.Commands;
using Presentation.Factories;
using System.Configuration;
using System.Linq;
using System.Reflection;
using XmlRepositories.SalesReport;
using XmlRepositories.StockReport;
using XmlRepositories.VolumeReport;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        private static IContainer Container { get; set; }

        public void Run()
        {
            VendingMachineApplication vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Run();
        }

        private static VendingMachineApplication BuildApplication()
        {
            ContainerBuilder container = new ContainerBuilder();
            //Views init
            container.RegisterType<MainView>().As<IMainView>().SingleInstance();
            container.RegisterType<LoginView>().As<ILoginView>().SingleInstance();
            container.RegisterType<ShowProductsView>().As<IShowProductsView>().SingleInstance();
            container.RegisterType<BuyView>().As<IBuyView>().SingleInstance();
            container.RegisterType<CardPaymentView>().As<ICardPaymentView>().SingleInstance();
            container.RegisterType<CashPaymentView>().As<ICashPaymentView>().SingleInstance();
            container.RegisterType<PayView>().As<IPayView>().SingleInstance();
            container.RegisterType<ReportView>().As<IReportView>().SingleInstance();

            //Services init
            container.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            container.RegisterType<DatabaseShelfColumnRepository>().As<IShelfColumnRepository>().SingleInstance();
            container.RegisterType<CardPaymentMethod>().As<IPaymentMethod>().SingleInstance();
            container.RegisterType<CashPaymentMethod>().As<IPaymentMethod>().SingleInstance();
            container.RegisterType<DatabaseSalesHistoryRepository>().As<ISalesHistoryRepository>().SingleInstance();

            string reportType = ConfigurationManager.AppSettings.Get("reportType");
            if (reportType == "xml")
            {
                container.RegisterType<XmlStockReportRepository>().As<IStockReportRepository>().SingleInstance();
                container.RegisterType<XmlSalesReportRepository>().As<ISalesReportRepository>().SingleInstance();
                container.RegisterType<XmlVolumeReportRepository>().As<IVolumeReportRepository>().SingleInstance();
            }
            else
            {
                container.RegisterType<JsonStockReportRepository>().As<IStockReportRepository>().SingleInstance();
                container.RegisterType<JsonSalesReportRepository>().As<ISalesReportRepository>().SingleInstance();
                container.RegisterType<JsonVolumeReportRepository>().As<IVolumeReportRepository>().SingleInstance();
            }

            //Use cases and sub-use cases init
            Assembly useCaseAssembly = Assembly.GetAssembly(typeof(IUseCase));
            container.RegisterAssemblyTypes(useCaseAssembly)
                .Where(x => typeof(IUseCase).IsAssignableFrom(x))
                .AsSelf();
            container.RegisterType<PayUseCase>().As<IPayUseCase>();

            //Use case commands init
            Assembly commandAssembly = Assembly.GetAssembly(typeof(BuyCommand));
            container.RegisterAssemblyTypes(commandAssembly)
                .Where(x => typeof(IConsoleCommand).IsAssignableFrom(x))
                .As<IConsoleCommand>();

            //Factories init
            container.RegisterType<UseCaseFactory>().As<IUseCaseFactory>();

            //App init
            container.RegisterType<VendingMachineApplication>().SingleInstance();

            Container = container.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                VendingMachineApplication app = scope.Resolve<VendingMachineApplication>();
                return app;
            }
        }
    }
}