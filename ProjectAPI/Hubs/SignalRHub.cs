using Microsoft.AspNetCore.SignalR;
using Project.DataAccess.Concrete;

namespace ProjectAPI.Hubs
{
    public class SignalRHub : Hub
    {
        SignalRContext context = new SignalRContext();

        public async Task SendCategoryCount()
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}
