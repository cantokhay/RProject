using Microsoft.Extensions.DependencyInjection;
using Project.Business.Abstract;
using Project.Business.Concrete;
using Project.DataAccess.Abstract;
using Project.DataAccess.EF;

namespace Project.Business.Container
{
    public static class ExtensionClass
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EFAboutDal>();
            
            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<IBookingDal, EFBookingDal>();
            
            services.AddScoped<IBasketService, BasketManager>();
            services.AddScoped<IBasketDal, EFBasketDal>();
            
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();
            
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EFContactDal>();
            
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<ICustomerDal, EFCustomerDal>();
            
            services.AddScoped<IDiscountService, DiscountManager>();
            services.AddScoped<IDiscountDal, EFDiscountDal>();
            
            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<INotificationDal, EFNotificationDal>();
            
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EFMessageDal>();
            
            services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
            services.AddScoped<IMoneyCaseDal, EFMoneyCaseDal>();
            
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDal, EFOrderDal>();
            
            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<IOrderDetailDal, EFOrderDetailDal>();
            
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EFProductDal>();
            
            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ISliderDal, EFSliderDal>();
            
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ISocialMediaDal, EFSocialMediaDal>();
            
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EFTestimonialDal>();
        }
    }
}
