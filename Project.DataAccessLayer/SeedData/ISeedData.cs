using Project.DataAccess.Concrete;

namespace Project.DataAccess.SeedData
{
    public interface ISeedData
    {
        Task SeedAsync(SignalRContext context);
    }
}
