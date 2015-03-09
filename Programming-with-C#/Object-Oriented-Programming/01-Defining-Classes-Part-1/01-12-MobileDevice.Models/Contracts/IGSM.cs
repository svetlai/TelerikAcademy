namespace MobileDevice.Models.Contracts
{
    public interface IGSM
    {
        void AddCall(Call call);

        void RemoveCall(Call call);

        void ClearCallHistory();

        decimal CalculateTotalCallPrice(decimal pricePerMinute);
    }
}
