namespace BugLogger.Data.Contracts
{
    using BugLogger.Data.Repositories;
    using BugLogger.Model;

    public interface IBugLoggerData
    {
        IRepository<Bug> Bugs { get; }

        void SaveChanges();
    }
}
