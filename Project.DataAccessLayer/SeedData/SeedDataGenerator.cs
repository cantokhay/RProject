using Bogus;
using Project.Data.Entities;
using Project.Data.Entities.Abstract;
using Project.Data.Enums;
using Project.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.SeedData
{
    public class SeedDataGenerator : ISeedData
    {
        public async Task SeedAsync(SignalRContext db)
        {
            {
                #region Helper Data

                var restaurantMenuCategories = new Dictionary<string, string[]>
                {
                    { "Mains", new[] { "Lamb Stew", "Grilled Chicken", "Beef Steak", "Vegetarian Lasagna", "Salmon Fillet", "Stuffed Peppers" } },
                    { "Appetizers", new[] { "Bruschetta", "Mozzarella Sticks", "Chicken Wings", "Hummus", "Spring Rolls", "Garlic Bread" } },
                    { "Soups", new[] { "Tomato Soup", "Chicken Noodle Soup", "Mushroom Soup", "Lentil Soup", "Seafood Chowder", "Pumpkin Soup" } },
                    { "Salads", new[] { "Caesar Salad", "Greek Salad", "Cobb Salad", "Caprese Salad", "Quinoa Salad", "Spinach Salad" } },
                    { "Beverages", new[] { "Fresh Orange Juice", "Iced Tea", "Lemonade", "Espresso", "Latte", "Sparkling Water" } },
                    { "Desserts", new[] { "Cheesecake", "Brownie", "Tiramisu", "Panna Cotta", "Ice Cream Sundae", "Creme Brulee" } },
                    { "Pizza", new[] { "Margherita", "Pepperoni", "BBQ Chicken", "Veggie Supreme", "Four Cheese", "Hawaiian" } },
                    { "Pasta", new[] { "Spaghetti Bolognese", "Fettuccine Alfredo", "Penne Arrabbiata", "Ravioli", "Carbonara", "Pesto Pasta" } },
                    { "Grills", new[] { "Mixed Grill Platter", "Lamb Chops", "Grilled Shrimp", "BBQ Ribs", "Tandoori Chicken", "Grilled Vegetables" } }
                };

                var productImageURLList = new[] { "/feane-1.0.0/images/f1.png", "/feane-1.0.0/images/f2.png", "/feane-1.0.0/images/f3.png", };

                var socialMediaDictionary = new Dictionary<string, (string URL, string Icon)>
                {
                    { "Facebook", ("https://www.facebook.com", "fa fa-facebook") },
                    { "Instagram", ("https://www.instagram.com", "fa fa-instagram") },
                    { "Twitter", ("https://www.twitter.com", "fa fa-twitter") },
                    { "Pinterest", ("https://www.pinterest.com", "fa fa-pinterest") },
                    { "Shopier", ("https://www.shopier.com", "fa-solid fa-shop") },
                    { "Linkedin", ("https://www.linkedin.com", "fa fa-linkedin") }
                };

                var notificationTypeList = new[] { "notif-icon notif-primary", "notif-icon notif-success", "notif-icon notif-danger", "notif-icon notif-warning" };

                var notificationIconList = new[] { "la la-user-plus", "la la-comment", "la la-heart", "la la-car", "la la-shopping-cart" };

                var discountImageURLList = new[] { "/feane-1.0.0/images/o1.jpg", "/feane-1.0.0/images/o2.jpg" };

                var testimonialImageURLList = new[] { "/feane-1.0.0/images/client1.jpg", "/feane-1.0.0/images/client2.jpg" };

                byte maxAboutCount = 1;
                byte maxBasketCount = 5;
                byte maxBookingCount = 18;
                byte maxCategoryCount = 10;
                byte maxCustomerCount = 20;
                byte maxContactCount = 1;
                byte maxDiscountCount = 2;
                byte maxMessageCount = 25;
                byte maxMoneyCaseCount = 1;
                byte maxNotificationCount = 15;
                byte maxOrderCount = 10;
                byte maxSliderCount = 1;
                byte maxSocialMediaCount = 6;
                byte maxTestimonialCount = 8;

                #endregion

                if (db.Abouts.Count() < maxAboutCount || db.Baskets.Count() < maxBasketCount || db.Bookings.Count() < maxBookingCount || db.Categories.Count() < maxCategoryCount || db.Customers.Count() < maxCustomerCount || db.Contacts.Count() < maxContactCount || db.Discounts.Count() < maxDiscountCount || db.Messages.Count() < maxMessageCount || db.MoneyCases.Count() < maxMoneyCaseCount || db.Notifications.Count() < maxNotificationCount || db.Orders.Count() < maxOrderCount || db.Sliders.Count() < maxSliderCount || db.SocialMedias.Count() < maxSocialMediaCount || db.Testimonials.Count() < maxTestimonialCount)
                {
                    byte aboutCountToGenerate = (byte)(maxAboutCount - db.Abouts.Count());
                    byte basketCountToGenerate = (byte)(maxBasketCount - db.Baskets.Count());
                    byte bookingCountToGenerate = (byte)(maxBookingCount - db.Bookings.Count());
                    byte categoryCountToGenerate = (byte)(maxCategoryCount - db.Categories.Count());
                    byte customerCountToGenerate = (byte)(maxCustomerCount - db.Customers.Count());
                    byte contactCountToGenerate = (byte)(maxContactCount - db.Contacts.Count());
                    byte discountCountToGenerate = (byte)(maxDiscountCount - db.Discounts.Count());
                    byte messageCountToGenerate = (byte)(maxMessageCount - db.Messages.Count());
                    byte moneyCaseCountToGenerate = (byte)(maxMoneyCaseCount - db.MoneyCases.Count());
                    byte notificationCountToGenerate = (byte)(maxNotificationCount - db.Notifications.Count());
                    byte orderCountToGenerate = (byte)(maxOrderCount - db.Orders.Count());
                    byte sliderCountToGenerate = (byte)(maxSliderCount - db.Sliders.Count());
                    byte socialMediaCountToGenerate = (byte)(maxSocialMediaCount - db.SocialMedias.Count());
                    byte testimonialCountToGenerate = (byte)(maxTestimonialCount - db.Testimonials.Count());

                    GenerateCategoriesAndProducts(categoryCountToGenerate);
                    GenerateCustomers(customerCountToGenerate);
                    GenerateOrdersAndOrderDetails(orderCountToGenerate);
                    GenerateBaskets(basketCountToGenerate);
                    GenerateAbouts(aboutCountToGenerate);
                    GenerateBookings(bookingCountToGenerate);
                    GenerateContacts(contactCountToGenerate);
                    GenerateDiscounts(discountCountToGenerate);
                    GenerateMessages(messageCountToGenerate);
                    GenerateMoneyCases(moneyCaseCountToGenerate);
                    GenerateNotifications(notificationCountToGenerate);
                    GenerateSliders(sliderCountToGenerate);
                    GenerateSocialMedia(socialMediaCountToGenerate);
                    GenerateTestimonials(testimonialCountToGenerate);

                    await db.SaveChangesAsync();

                }

                #region Faker Methods

                void GenerateAbouts(byte maxCount)
                {
                    var faker = new Faker();

                    byte missingAbouts = Math.Max(maxCount, (byte)0);

                    for (byte i = 0; i < missingAbouts; i++)
                    {
                        var about = new About
                        {
                            AboutTitle = "Welcome to Our Company",
                            AboutDescription = "We provide the best services for you.",
                            AboutImageURL = "/feane-1.0.0/images/about-img.png",
                            CreatedDate = DateTime.Now,
                            DataStatus = DataStatus.Active
                        };

                        db.Abouts.Add(about);
                    }
                    db.SaveChanges();
                }

                void GenerateBaskets(byte maxCount)
                {
                    var faker = new Faker();

                    var productIds = db.Products.Select(p => p.ProductId).ToList();
                    var customerIds = 4;

                    byte missingBaskets = Math.Max(maxCount, (byte)0);

                    for (byte i = 0; i < missingBaskets; i++)
                    {
                        var selectedProductId = faker.PickRandom(productIds);
                        var productPrice = db.Products.Where(p => p.ProductId == selectedProductId).Select(p => p.ProductPrice).FirstOrDefault();
                        var basketPrice = productPrice;
                        var basketCount = faker.Random.Int(1, 10);

                        Basket basket = new Basket
                        {
                            Price = basketPrice,
                            Count = basketCount,
                            TotalProductPrice = basketPrice * basketCount,
                            ProductId = selectedProductId,
                            CustomerId = 4,
                        };

                        AssignEntityDatesAndDataStatus(basket);
                        db.Baskets.Add(basket);
                    }

                    db.SaveChanges();
                }

                void GenerateBookings(byte maxCount)
                {
                    var faker = new Faker();

                    byte missingBookings = Math.Max(maxCount, (byte)0);

                    for (byte i = 0; i < missingBookings; i++)
                    {
                        Booking booking = new Booking
                        {
                            BookingName = faker.Name.FullName(),
                            BookingEmail = faker.Internet.Email(),
                            BookingPhone = faker.Phone.PhoneNumber(),
                            BookingStatus = faker.PickRandom<BookingStatus>(),
                            BookingDate = faker.Date.Soon(faker.Random.Int(3, 12)),
                            PersonCount = faker.Random.Int(2, 12),
                        };

                        AssignEntityDatesAndDataStatus(booking);
                        db.Bookings.Add(booking);
                    }

                    db.SaveChanges();
                }

                void GenerateCategoriesAndProducts(byte maxCategories)
                {
                    var faker = new Faker();
                    var existingCategories = db.Categories.Select(c => c.CategoryName).ToList();
                    var remainingCategories = restaurantMenuCategories.Keys.Except(existingCategories).ToList();

                    byte missingCategories = Math.Max(maxCategories, (byte)0);

                    foreach (var categoryName in remainingCategories.Take(missingCategories))
                    {
                        Category category = new Category
                        {
                            CategoryName = EnsureMaxLength(categoryName, 50),
                            CreatedDate = DateTime.Now,
                            DataStatus = DataStatus.Active
                        };
                        db.Categories.Add(category);
                        db.SaveChanges();

                        if (restaurantMenuCategories.ContainsKey(categoryName))
                        {
                            var productsForCategory = restaurantMenuCategories[categoryName];

                            byte productCount = (byte)faker.Random.Number(3, 6);

                            for (byte i = 0; i < productCount; i++)
                            {
                                var product = new Product
                                {
                                    ProductName = EnsureMaxLength(productsForCategory[i], 50),
                                    ProductDescription = EnsureMaxLength(faker.Lorem.Sentence(7), 75),
                                    ProductPrice = decimal.Parse(faker.Commerce.Price()),
                                    ProductImageURL = faker.PickRandom(productImageURLList),
                                    CategoryId = category.CategoryId,
                                    CreatedDate = DateTime.Now,
                                    DataStatus = DataStatus.Active
                                };

                                db.Products.Add(product);
                            }
                        }
                    }

                    db.SaveChanges();
                }

                void GenerateCustomers(byte maxCount)
                {
                    var faker = new Faker();
                    byte missingCustomers = Math.Max(maxCount, (byte)0);

                    for (byte i = 0; i < missingCustomers; i++)
                    {
                        var customer = new Customer
                        {
                            CustomerName = EnsureMaxLength(faker.Name.FullName(), 100),
                            CustomerStatus = faker.PickRandom<CustomerStatus>()
                        };

                        AssignEntityDatesAndDataStatus(customer);
                        db.Customers.Add(customer);
                    }
                    db.SaveChanges();
                }

                void GenerateContacts(byte maxCount)
                {
                    var faker = new Faker();
                    byte missingContacts = Math.Max(maxCount, (byte)0);

                    for (byte i = 0; i < missingContacts; i++)
                    {
                        var contact = new Contact
                        {
                            ContactLocation = EnsureMaxLength(faker.Address.FullAddress(), 250),
                            ContactPhone = GeneratePhoneNumber(),
                            ContactEmail = faker.Internet.Email(),
                            FooterTitle = EnsureMaxLength(faker.Commerce.Department(), 50),
                            FooterDescription = EnsureMaxLength(faker.Lorem.Sentence(), 250),
                            OpenDays = "Monday - Friday",
                            OpenDaysDescription = "Open all weekdays",
                            OpenHours = "9:00 AM - 5:00 PM",
                            CreatedDate = DateTime.Now,
                            DataStatus = DataStatus.Active
                        };

                        db.Contacts.Add(contact);
                    }

                    db.SaveChanges();
                }

                void GenerateNotifications(byte maxCount)
                {
                    var faker = new Faker();
                    byte missingNotifications = Math.Max(maxCount, (byte)0);

                    for (byte i = 0; i < missingNotifications; i++)
                    {
                        var notification = new Notification
                        {
                            Type = faker.PickRandom(notificationTypeList),
                            Icon = faker.PickRandom(notificationIconList),
                            Message = EnsureMaxLength(faker.Lorem.Sentence(), 250),
                            NotificationDate = faker.Date.Recent(10)
                        };

                        AssignEntityDatesAndDataStatus(notification);
                        db.Notifications.Add(notification);
                    }

                    db.SaveChanges();
                }

                void GenerateMessages(byte maxCount)
                {
                    var faker = new Faker();
                    byte missingMessages = Math.Max(maxCount, (byte)0);

                    for (byte i = 0; i < missingMessages; i++)
                    {
                        var message = new Message
                        {
                            MessageFullName = EnsureMaxLength(faker.Name.FullName(), 100),
                            MessageEmail = faker.Internet.Email(),
                            MessageSubject = EnsureMaxLength(faker.Lorem.Word(), 100),
                            MessageContent = EnsureMaxLength(faker.Lorem.Paragraph(), 500),
                            MessagePhone = GeneratePhoneNumber()
                        };

                        AssignEntityDatesAndDataStatus(message);
                        db.Messages.Add(message);
                    }

                    db.SaveChanges();
                }

                void GenerateDiscounts(byte maxCount)
                {
                    var faker = new Faker();
                    byte missingDiscounts = Math.Max(maxCount, (byte)0);

                    for (byte i = 0; i < missingDiscounts; i++)
                    {
                        var discount = new Discount
                        {
                            Title = EnsureMaxLength(faker.Commerce.ProductName(), 100),
                            Description = EnsureMaxLength(faker.Lorem.Paragraph(), 250),
                            DiscountAmount = faker.Random.Decimal(5, 50),
                            ImageURL = faker.PickRandom(discountImageURLList),
                            CreatedDate = DateTime.Now,
                            DataStatus = DataStatus.Active,
                            DiscountStatus = true
                        };

                        db.Discounts.Add(discount);
                    }

                    db.SaveChanges();
                }

                void GenerateMoneyCases(byte maxCount)
                {
                    var faker = new Faker();
                    byte missingMoneyCases = Math.Max(maxCount, (byte)0);

                    for (byte i = 0; i < missingMoneyCases; i++)
                    {
                        var moneyCase = new MoneyCase
                        {
                            TotalMoneyInCase = faker.Random.Decimal(1000, 50000),
                            CreatedDate = DateTime.Now,
                            DataStatus = DataStatus.Active
                        };

                        db.MoneyCases.Add(moneyCase);
                    }

                    db.SaveChanges();
                }

                void GenerateOrdersAndOrderDetails(byte maxOrders)
                {
                    var faker = new Faker();
                    var productIds = db.Products.Select(p => p.ProductId).ToList();
                    var customerIds = db.Customers.Select(c => c.CustomerId).ToList();

                    byte missingOrders = Math.Max(maxOrders, (byte)0);

                    for (byte i = 0; i < missingOrders; i++)
                    {
                        var order = new Order
                        {
                            CustomerName = EnsureMaxLength(faker.Name.FullName(), 100),
                            OrderDescription = faker.PickRandom<OrderDescription>(),
                            OrderDate = faker.Date.Recent(30),
                            TotalPrice = 0
                        };

                        AssignEntityDatesAndDataStatus(order);
                        db.Orders.Add(order);
                        db.SaveChanges();

                        byte orderDetailCount = (byte)faker.Random.Number(1, 5);
                        decimal totalPrice = 0;

                        for (byte j = 0; j < orderDetailCount; j++)
                        {
                            var selectedProductId = faker.PickRandom(productIds);
                            var unitPrice = db.Products.Where(p => p.ProductId == selectedProductId).Select(p => p.ProductPrice).FirstOrDefault();
                            var quantity = faker.Random.Int(1, 10);

                            var orderDetail = new OrderDetail
                            {
                                OrderId = order.OrderId,
                                ProductId = selectedProductId,
                                UnitPrice = unitPrice,
                                Quantity = quantity,
                                TotalPrice = unitPrice * quantity
                            };

                            totalPrice += orderDetail.TotalPrice;
                            AssignEntityDatesAndDataStatus(orderDetail);
                            db.OrderDetails.Add(orderDetail);
                        }

                        order.TotalPrice = totalPrice;
                        db.SaveChanges();
                    }
                }

                void GenerateSliders(byte maxCount)
                {
                    var faker = new Faker();
                    byte missingSliders = Math.Max(maxCount, (byte)0);

                    for (byte i = 0; i < missingSliders; i++)
                    {
                        var slider = new Slider
                        {
                            SliderTitle1 = EnsureMaxLength(faker.Commerce.ProductName(), 30),
                            SliderDescription1 = EnsureMaxLength(faker.Lorem.Sentence(), 100),
                            SliderTitle2 = EnsureMaxLength(faker.Commerce.ProductName(), 30),
                            SliderDescription2 = EnsureMaxLength(faker.Lorem.Sentence(), 100),
                            SliderTitle3 = EnsureMaxLength(faker.Commerce.ProductName(), 30),
                            SliderDescription3 = EnsureMaxLength(faker.Lorem.Sentence(), 100),
                            CreatedDate = DateTime.Now,
                            DataStatus = DataStatus.Active
                        };

                        db.Sliders.Add(slider);
                    }

                    db.SaveChanges();
                }


                void GenerateSocialMedia(byte maxCount)
                {
                    var faker = new Faker();
                    var existingSocialMedia = db.SocialMedias.Select(s => s.SocialMediaTitle).ToList();
                    var remainingSocialMedia = socialMediaDictionary.Keys.Except(existingSocialMedia).ToList();

                    byte missingSocialMedia = (byte)Math.Max(maxCount, (byte)0);

                    foreach (var socialMediaTitle in remainingSocialMedia.Take(missingSocialMedia))
                    {
                        if (socialMediaDictionary.ContainsKey(socialMediaTitle))
                        {
                            var socialMediaData = socialMediaDictionary[socialMediaTitle];

                            SocialMedia socialMedia = new SocialMedia
                            {
                                SocialMediaTitle = EnsureMaxLength(socialMediaTitle, 50),
                                SocialMediaURL = socialMediaData.URL,
                                SocialMediaIcon = socialMediaData.Icon,
                                CreatedDate = DateTime.Now,
                                DataStatus = DataStatus.Active
                            };

                            db.SocialMedias.Add(socialMedia);
                        }
                    }

                    db.SaveChanges();
                }

                void GenerateTestimonials(byte maxCount)
                {
                    var faker = new Faker();
                    byte missingTestimonials = Math.Max(maxCount, (byte)0);

                    for (byte i = 0; i < missingTestimonials; i++)
                    {
                        var testimonial = new Testimonial
                        {
                            Comment = EnsureMaxLength(faker.Lorem.Sentence(), 50),
                            TestimonialName = EnsureMaxLength(faker.Name.FullName(), 50),
                            TestimonialTitle = EnsureMaxLength(faker.Lorem.Word(), 50),
                            TestimonialImageURL = GenerateAvatarUrl()
                        };

                        AssignEntityDatesAndDataStatus(testimonial);
                        db.Testimonials.Add(testimonial);
                    }

                    db.SaveChanges();
                }

                #endregion

                #region Helper Methods

                string EnsureMaxLength(string value, int maxLength)
                {
                    if (string.IsNullOrEmpty(value)) return value;
                    return value.Length <= maxLength ? value : value.Substring(0, maxLength);
                }

                string GeneratePhoneNumber()
                {
                    var faker = new Faker();
                    var areaCode = faker.Random.Number(100, 999);
                    var centralOfficeCode = faker.Random.Number(100, 999);
                    var lineNumber = faker.Random.Number(1000, 9999);
                    return $"{areaCode}-{centralOfficeCode}-{lineNumber}";
                }

                string GenerateAvatarUrl()
                {
                    var faker = new Faker();
                    return $"https://robohash.org/{faker.Random.Number(1, 200)}.png";
                }

                void AssignEntityDatesAndDataStatus<T>(T entity) where T : class, IGenericEntity
                {
                    var faker = new Faker();
                    entity.DataStatus = faker.PickRandom(new[] { DataStatus.Active, DataStatus.Modified, DataStatus.Deleted });

                    if (entity.DataStatus == DataStatus.Active)
                    {
                        entity.CreatedDate = faker.Date.Past(2);
                        entity.ModifiedDate = null;
                        entity.DeletedDate = null;
                    }
                    else if (entity.DataStatus == DataStatus.Modified)
                    {
                        entity.CreatedDate = faker.Date.Past(3);
                        entity.ModifiedDate = faker.Date.Recent(30);
                        entity.DeletedDate = null;
                    }
                    else if (entity.DataStatus == DataStatus.Deleted)
                    {
                        entity.CreatedDate = faker.Date.Past(4);
                        entity.ModifiedDate = faker.Date.Recent(60);
                        entity.DeletedDate = faker.Date.Recent(10);
                    }
                }

                #endregion
            }
        }
    }
}
