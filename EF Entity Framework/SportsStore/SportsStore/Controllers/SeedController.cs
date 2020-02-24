using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;
using System.Linq;

namespace SportsStore.Controllers
{
    public class SeedController : Controller
    {
        private DataContext context;
        public SeedController(DataContext ctx) => context = ctx;
        public IActionResult Index()
        {
            ViewBag.Count = context.Products.Count();
            return View(context.Products
            .Include(p => p.Category).OrderBy(p => p.Id).Take(20));
        }
        [HttpPost]
        public IActionResult CreateSeedData(int count)
        {
            ClearData();
            if (count > 0)
            {
                context.Database.SetCommandTimeout(System.TimeSpan.FromMinutes(10));
                context.Database
                .ExecuteSqlCommand("DROP PROCEDURE IF EXISTS CreateSeedData");
                context.Database.ExecuteSqlCommand($@"
                    CREATE PROCEDURE CreateSeedData
                    @RowCount decimal
                    AS
                    BEGIN
                    SET NOCOUNT ON
                    DECLARE @i INT = 1;
                    DECLARE @catId BIGINT;
                    DECLARE @CatCount INT = @RowCount / 10;
                    DECLARE @pprice DECIMAL(5,2);
                    DECLARE @rprice DECIMAL(5,2);
                    BEGIN TRANSACTION
                    WHILE @i <= @CatCount
                    BEGIN
                    INSERT INTO Categories (Name, Description)
                    VALUES (CONCAT('Category-', @i),
                    'Test Data Category');
                    SET @catId = SCOPE_IDENTITY();
                    DECLARE @j INT = 1;
                    WHILE @j <= 10
                    BEGIN
                    SET @pprice = RAND()*(500-5+1);
                    SET @rprice = (RAND() * @pprice)
                    + @pprice;
                    INSERT INTO Products (Name, CategoryId,
                    PurchasePrice, RetailPrice)
                    VALUES (CONCAT('Product', @i, '-', @j),
                    @catId, @pprice, @rprice)
                    SET @j = @j + 1
                    END
                    SET @i = @i + 1
                    END
                    COMMIT
                    END");
                context.Database.BeginTransaction();
                context.Database
                .ExecuteSqlCommand($"EXEC CreateSeedData @RowCount = {count}");
                context.Database.CommitTransaction();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ClearData()
        {
            context.Database.SetCommandTimeout(System.TimeSpan.FromMinutes(10));
            context.Database.BeginTransaction();
            context.Database.ExecuteSqlCommand("DELETE FROM Orders");
            context.Database.ExecuteSqlCommand("DELETE FROM Categories");
            context.Database.ExecuteSqlCommand("DELETE FROM Prices");
            context.Database.CommitTransaction();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult CreateProductionData()
        {
            ClearData();
            context.Categories.AddRange(new Category[] {
                    new Category {
                    Name = "Watersports",
                    Description = "Make a splash",
                    Products = new Product[] {
                    new Product {
                    Name = "Kayak", Description = "A boat for one person",
                    Prices = new[]{
                        new Price { Value = 200, PriceType = PriceType.Purchase },
                        new Price { Value = 275, PriceType = PriceType.Retail },
                    }
                    },
                    new Product {
                    Name = "Lifejacket",
                    Description = "Protective and fashionable",
                    Prices = new[]{
                        new Price { Value = 40, PriceType = PriceType.Purchase },
                        new Price { Value = 48.95m, PriceType = PriceType.Retail },
                    }
                    },
                    }
                    },
                    new Category {
                    Name = "Soccer",
                    Description = "The World's Favorite Game",
                    Products = new Product[] {
                    new Product {
                    Name = "Soccer Ball",
                    Description = "FIFA-approved size and weight",
                    Prices = new[]{
                        new Price { Value = 18, PriceType = PriceType.Purchase },
                        new Price { Value = 19.50m, PriceType = PriceType.Retail },
                    }
                    },
                    new Product {
                    Name = "Corner Flags", Description
                    = "Give your playing field a professional touch",
                    Prices = new[]{
                        new Price { Value = 32.50m, PriceType = PriceType.Purchase },
                        new Price { Value = 34.95m, PriceType = PriceType.Retail },
                    }
                    },
                    new Product {
                    Name = "Stadium",
                    Description = "Flat-packed 35,000-seat stadium",
                    Prices = new[]{
                        new Price { Value = 75000, PriceType = PriceType.Purchase },
                        new Price { Value = 79500, PriceType = PriceType.Retail },
                    }
                    }
                    }
                    },
                    new Category {
                    Name = "Chess",
                    Description = "The Thinky Game",
                    Products = new Product[] {
                    new Product {
                    Name = "Thinking Cap",
                    Description = "Improve brain efficiency by 75%",
                    Prices = new[]{
                        new Price { Value = 10, PriceType = PriceType.Purchase },
                        new Price { Value = 16, PriceType = PriceType.Retail },
                    }
                    },new Product {
                    Name = "Unsteady Chair", Description
                    = "Secretly give your opponent a disadvantage",
                    Prices = new[]{
                        new Price { Value = 28, PriceType = PriceType.Purchase },
                        new Price { Value = 29.95m, PriceType = PriceType.Retail },
                    }
                    },
                    new Product {
                    Name = "Human Chess Board",
                    Description = "A fun game for the family",
                    Prices = new[]{
                        new Price { Value = 68.50m, PriceType = PriceType.Purchase },
                        new Price { Value = 75, PriceType = PriceType.Retail },
                    }
                    },
                    new Product {
                    Name = "Bling-Bling King",
                    Description = "Gold-plated, diamond-studded King",
                    Prices = new[]{
                        new Price { Value = 800, PriceType = PriceType.Purchase },
                        new Price { Value = 1200, PriceType = PriceType.Retail },
                    }
                    }
                    }
                    }
                    });
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
