namespace iQuest.Business.UseCases
{
    public interface IPayUseCase
    {
        float PriceToPay { get; set; }

        string Execute();
    }
}