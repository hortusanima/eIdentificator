namespace eIdentificator.Domain.Interfaces
{
    public interface IDatabaseHelper
    {
        void InitializeDatabase();
        string GetConnectionString();
    }
}
