using Microsoft.AspNetCore.SignalR;
using Project.Business.Abstract;
using Project.DataAccess.Concrete;

namespace ProjectAPI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly ICustomerService _customerService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, ICustomerService customerService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _customerService = customerService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendStatistics()
        {
            var categoryCount = _categoryService.TGetCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            var productCount = _productService.TGetProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);

            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

            var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);

            var productCountByHamburger = _productService.TGetProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByHamburger", productCountByHamburger);

            var productCountByDesert = _productService.TGetProductCountByCategoryNameDesert();
            await Clients.All.SendAsync("ReceiveProductCountByDesert", productCountByDesert);

            var avgPrice = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", avgPrice.ToString("0.00") + "₺");

            var maxPricedProduct = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", maxPricedProduct);

            var minPricedProduct = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", minPricedProduct);

            var avgHamburgerPrice = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", avgHamburgerPrice.ToString("0.00") + "₺");

            var totalOrderCount = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var lastOrderPrice = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00") + "₺");

            var totalMoney = _moneyCaseService.TGetTotalMoneyInCase();
            await Clients.All.SendAsync("ReceiveTotalMoneyInCase", totalMoney.ToString("0.00") + "₺");

            //var todayTotalPrice = _orderService.TGetTodayTotalPrice();
            //await Clients.All.SendAsync("ReceiveTodayTotalPrice", todayTotalPrice.ToString("0.00")+"₺");

            var totalCustomerCount = _customerService.TCustomerCount();
            await Clients.All.SendAsync("ReceiveCustomerCount", totalCustomerCount);

        }

        public async Task SendProgress()
        {
            var totalMoney = _moneyCaseService.TGetTotalMoneyInCase();
            await Clients.All.SendAsync("ReceiveTotalMoneyInCase", totalMoney.ToString("0.00") + "₺");

            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

            var totalCustomerCount = _customerService.TCustomerCount();
            await Clients.All.SendAsync("ReceiveCustomerCount", totalCustomerCount);
        }

        public async Task GetBookingList()
        {
            var bookingList = _bookingService.TGetAll();
            await Clients.All.SendAsync("ReceiveBookingList", bookingList);
        }

        public async Task SendNotification()
        {
            var notificationCount = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", notificationCount);

            var notificationListByFalse = _notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);
        }
    }
}
