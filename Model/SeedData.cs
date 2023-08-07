using Microsoft.EntityFrameworkCore;
using FYP2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace FYP2.Model
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApp1IdentityDbContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<WebApp1IdentityDbContext>>()))
            {
                InitializeCategory(context);
                InitializeMenu(context);
                InitializeOrders(context);
                InitializeOrderitems(context);
            }

        }


        public static void InitializeMenu(WebApp1IdentityDbContext context)
        {

            {
                if (context == null || context.MenuItem == null)
                {
                    throw new ArgumentNullException("Null WebApp1IdentityDbContext");
                }

                // Look for any movies.
                if (context.MenuItem.Any())
                {
                    return;   // DB has been seeded
                }

                //
                context.MenuItem.AddRange(
                    new MenuItem
                    {
                        Id = "A01",
                        CatId = "A",
                        Iname = "Grilled Striploin",
                        Price = 12.0m,
                        Idescription = ""

                    },

                    new MenuItem
                    {
                        Id = "A02",
                        CatId = "A",
                        Iname = "Sizzling Hotplate Striploin",
                        Price = 13.0m,
                        Idescription = ""
                    },

                   new MenuItem
                   {
                       Id = "A03",
                       CatId = "A",
                       Iname = "Grilled Ribeye",
                       Price = 14.0m,
                       Idescription = ""
                   },

                  new MenuItem
                  {
                      Id = "A04",
                      CatId = "A",
                      Iname = "Sizzling Hotplate Ribeye",
                      Price = 12.0m,
                      Idescription = ""
                  },

                    new MenuItem
                    {
                        Id = "B01",
                        CatId = "B",
                        Iname = "Grilled Chicken Chop",
                        Price = 6.5m,
                        Idescription = ""
                    },

                    new MenuItem
                    {
                        Id = "B02",
                        CatId = "B",
                        Iname = "Crispy Cutlet",
                        Price = 6.5m,
                        Idescription = ""
                    },
                    new MenuItem
                    {
                        Id = "B03",
                        CatId = "B",
                        Iname = "Smoked BBQ Chicken Chop",
                        Price = 6.5m,
                        Idescription = ""
                    },

                    new MenuItem
                    {
                        Id = "B04",
                        CatId = "B",
                        Iname = "Grilled Jumbo Sausage",
                        Price = 8.0m,
                        Idescription = ""
                    },
                     new MenuItem
                     {
                         Id = "B05",
                         CatId = "B",
                         Iname = "Chicken Wing Set",
                         Price = 5.0m,
                         Idescription = ""
                     },

                  new MenuItem
                  {
                      Id = "C01",
                      CatId = "C",
                      Iname = "Grilled Lamb Chop",
                      Price = 12.0m,
                      Idescription = ""
                  },
                  new MenuItem
                  {
                      Id = "C02",
                      CatId = "C",
                      Iname = "Sizzling Hotplate Lamb Chop",
                      Price = 13.0m,
                      Idescription = ""
                  },
                  new MenuItem
                  {
                      Id = "C03",
                      CatId = "C",
                      Iname = "Grilled Pork Chop ",
                      Price = 7.5m,
                      Idescription = ""
                  },
                   new MenuItem
                   {
                       Id = "C04",
                       CatId = "C",
                       Iname = "Sizzling Hotplate Pork Chop",
                       Price = 12.0m,
                       Idescription = ""
                   },

                   new MenuItem
                   {
                       Id = "C05",
                       CatId = "C",
                       Iname = "Vienna Sausage Set",
                       Price = 6.5m,
                       Idescription = ""
                   }
                );
                context.SaveChanges();
            }
        }

     
        public static void InitializeCategory(WebApp1IdentityDbContext context)
        {

            {

                if (context == null || context.Category == null)
                {
                    throw new ArgumentNullException("Null WebApp1IdentityDbContext");
                }

                // Look for any movies.
                if (context.Category.Any())
                {
                    return;   // DB has been seeded
                }

                //
                context.Category.AddRange(
                    new Category
                    {
                        Id = "A",
                        Cname = "Grilled Beef",
                        CatOrder = 1

                    },

                    new Category
                    {
                        Id = "B",
                        Cname = "Chicken",
                        CatOrder = 2
                    },

                   new Category
                   {
                       Id = "C",
                       Cname = "Lamb and Pork",
                       CatOrder = 3
                   },

                  new Category
                  {
                      Id = "D",
                      Cname = "Spaghetti",
                      CatOrder = 4
                  },

                  new Category
                  {
                      Id = "E",
                      Cname = "Ocean Catch",
                      CatOrder = 5
                  },
                  new Category
                  {
                      Id = "F",
                      Cname = "Spaghetti",
                      CatOrder = 6
                  },
                  new Category
                  {
                      Id = "G",
                      Cname = "Spaghetti",
                      CatOrder = 7
                  },
                   new Category
                   {
                       Id = "H",
                       Cname = "Drinks",
                       CatOrder = 8
                   }
                );
                context.SaveChanges();
            }

            //menuitem

        }


        public static void InitializeOrders(WebApp1IdentityDbContext context)
        {

            {
                if (context == null || context.Orders == null)
                {
                    throw new ArgumentNullException("Null WebApp1IdentityDbContext");
                }

                // Look for any movies.
                if (context.Orders.Any())
                {
                    return;   // DB has been seeded
                }

                //
                context.Orders.AddRange(
                    new Orders
                    {
                        UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
                        Note = "Grilled to medium rare",
                    }

                );
                context.SaveChanges();
            }
        }
        public static void InitializeOrderitems(WebApp1IdentityDbContext context)
        {
            if (context == null || context.Orders == null)
            {
                throw new ArgumentNullException("Null WebApp1IdentityDbContext");
            }

            // Look for any movies.
            if (context.OrderItems.Any())
            {
                return;   // DB has been seeded
            }

            context.OrderItems.AddRange(
                  new OrderItem
                  {
                      ItemId = "A01",
                      OrderID = 1,
                      Price = 12.0m,
                      Quantity = 1
                  },
                       new OrderItem
                       {
                           ItemId = "A02",
                           OrderID = 1,
                           Price = 13.0m,
                           Quantity = 1
                       }

              );
            context.SaveChanges();
        }
    }
}

