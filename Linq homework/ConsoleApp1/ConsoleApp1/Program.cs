﻿using LinqHomework.Classes;
using LinqHomework.Enums;

Console.WriteLine("LINQ HOMEWORK");
Console.WriteLine("===============");

List<Product> products = new List<Product>()
{
    new Product(1, "iPhone 9", "An apple mobile which is nothing like apple", 549, 4.69, 94, "Apple", ProductCategory.Smartphones),
    new Product(2, "iPhone X", "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...", 899, 4.44, 34, "Apple", ProductCategory.Smartphones),
    new Product(3, "Samsung Universe 9", "Samsung's new variant which goes beyond Galaxy to the Universe", 1249, 4.09, 36, "Samsung", ProductCategory.Smartphones),
    new Product(4, "OPPOF19", "OPPO F19 is officially announced on April 2021.", 280, 4.3, 123, "OPPO", ProductCategory.Smartphones),
    new Product(5, "Huawei P30", "Huawei’s re-badged P30 Pro New Edition was officially unveiled yesterday in Germany and now the device has made its way to the UK.", 499, 4.09, 32, "Huawei", ProductCategory.Smartphones),
    new Product(6, "MacBook Pro", "MacBook Pro 2021 with mini-LED display may launch between September, November", 1749, 4.57, 83, "Apple", ProductCategory.Laptops),
    new Product(7, "Samsung Galaxy Book", "Samsung Galaxy Book S (2020) Laptop With Intel Lakefield Chip, 8GB of RAM Launched", 1499, 4.25, 50, "Samsung", ProductCategory.Laptops),
    new Product(8, "Microsoft Surface Laptop 4", "Style and speed. Stand out on HD video calls backed by Studio Mics. Capture ideas on the vibrant touchscreen.", 1499, 4.43, 68, "Microsoft Surface", ProductCategory.Laptops),
    new Product(9, "Infinix INBOOK", "Infinix Inbook X1 Ci3 10th 8GB 256GB 14 Win10 Grey – 1 Year Warranty", 1099, 4.54, 96, "Infinix", ProductCategory.Laptops),
    new Product(10, "HP Pavilion 15-DK1056WM", "HP Pavilion 15-DK1056WM Gaming Laptop 10th Gen Core i5, 8GB, 256GB SSD, GTX 1650 4GB, Windows 10", 1099, 4.43, 89, "HP Pavilion", ProductCategory.Laptops),
    new Product(11, "perfume Oil", "Mega Discount, Impression of Acqua Di Gio by GiorgioArmani concentrated attar perfume Oil", 13, 4.26, 65, "Impression of Acqua Di Gio", ProductCategory.Fragrances),
    new Product(12, "Brown Perfume", "Royal_Mirage Sport Brown Perfume for Men & Women - 120ml", 40, 4, 52, "Royal_Mirage", ProductCategory.Fragrances),
    new Product(13, "Fog Scent Xpressio Perfume", "Product details of Best Fog Scent Xpressio Perfume 100ml For Men cool long lasting perfumes for Men", 13, 4.59, 61, "Fog Scent Xpressio", ProductCategory.Fragrances),
    new Product(14, "Non-Alcoholic Concentrated Perfume Oil", "Original Al Munakh® by Mahal Al Musk | Our Impression of Climate | 6ml Non-Alcoholic Concentrated Perfume Oil", 120, 4.21, 114, "Al Munakh", ProductCategory.Fragrances),
    new Product(15, "Eau De Perfume Spray", "Genuine  Al-Rehab spray perfume from UAE/Saudi Arabia/Yemen High Quality", 30, 4.7, 105, "Lord - Al-Rehab", ProductCategory.Fragrances),
    new Product(16, "Hyaluronic Acid Serum", "L'OrÃ©al Paris introduces Hyaluron Expert Replumping Serum formulated with 1.5% Hyaluronic Acid", 19, 4.83, 110, "L'Oreal Paris", ProductCategory.Skincare),
    new Product(17, "Tree Oil 30ml", "Tea tree oil contains a number of compounds, including terpinen-4-ol, that have been shown to kill certain bacteria,", 12, 4.52, 78, "Hemani Tea", ProductCategory.Skincare),
    new Product(18, "Oil Free Moisturizer 100ml", "Dermive Oil Free Moisturizer with SPF 20 is specifically formulated with ceramides, hyaluronic acid & sunscreen.", 40, 4.56, 88, "Dermive", ProductCategory.Skincare),
    new Product(19, "Skin Beauty Serum.", "Product name: rorec collagen hyaluronic acid white face serum riceNet weight: 15 m", 46, 4.42, 54, "ROREC White Rice", ProductCategory.Skincare),
    new Product(20, "Freckle Treatment Cream- 15gm", "Fair & Clear is Pakistan's only pure Freckle cream which helpsfade Freckles, Darkspots and pigments. Mercury level is 0%, so there are no side effects.", 70, 4.06, 140, "Fair & Clear", ProductCategory.Skincare),
    new Product(21, "- Daal Masoor 500 grams", "Fine quality Branded Product Keep in a cool and dry place", 20, 4.44, 133, "Saaf & Khaas", ProductCategory.Groceries),
    new Product(22, "Elbow Macaroni - 400 gm", "Product details of Bake Parlor Big Elbow Macaroni - 400 gm", 14, 4.57, 146, "Bake Parlor Big", ProductCategory.Groceries),
    new Product(23, "Orange Essence Food Flavou", "Specifications of Orange Essence Food Flavour For Cakes and Baking Food Item", 14, 4.85, 26, "Baking Food Items", ProductCategory.Groceries)
};

// 1) Retrieve all products with a price greater than $500.
List<Product> productsHigherThanFiveHundred = (from product in products
                                               where product.Price > 500
                                               select product).ToList();

List<Product> productsHigherThanFiveHundred1 = products.Where(x => x.Price > 500).ToList();

// 2) Retrive all Skincare products.
List<Product> skinCareProducts = (from product in products
                                  where product.Category == ProductCategory.Skincare
                                  select product).ToList();

List<Product> skinCareProducts1 = products.Where(r => r.Category == ProductCategory.Skincare).ToList();

// 3) Retrive all products titles.
List<string> productTitles = (from product in products
                              select product.Title).ToList();

List<string> productTitles1 = products.Select(product => product.Title).ToList();

// 4) Select the titles of all products in the "Laptops" category.
List<string> lapTopTitles = (from product in products
                             where product.Category == ProductCategory.Laptops
                             select product.Title).ToList();

List<string> lapTopTitles1 = products.Where(product => product.Category == ProductCategory.Laptops).Select(product => product.Title).ToList();

// 5) Select the descriptions of all products with a stock of less than 50.
List<string> productsDescription = (from product in products
                                    where product.Stock < 50
                                    select product.Description).ToList();

List<string> productsDescription1 = products.Where(x => x.Stock < 50).Select(product => product.Description).ToList();

// 6) Retrieve the titles of all products with a rating above 4.5.
List<string> ratingAboveFour = (from product in products
                                where product.Rating > 4.5
                                select product.Title).ToList();

List<string> ratingAboveFour1 = products.Where(products => products.Rating > 4.5).Select(products => products.Title).ToList();

// 7) Select the titles of all products with a price between $100 and $200.
List<string> titlesOfProductsBetweenHunAndTwoHun = (from product in products
                                                    where product.Price > 100 && product.Price < 200
                                                    select product.Title).ToList();

List<string> titlesOfProductsBetweenHunAndTwoHun1 = products.Where(products => products.Price > 100 || products.Price < 200).Select(products => products.Title).ToList();

// 8) Select the titles of all products from the "Fragrances" category with a rating above 4.6.
List<string> fragrancesProducts = (from product in products
                                   where product.Category == ProductCategory.Fragrances && product.Rating > 4.6
                                   select product.Title).ToList();

List<string> fragrancesProducts2 = products.Where(r => r.Category == ProductCategory.Fragrances && r.Rating > 4.6).Select(r => r.Title).ToList();

// 9) Retrieve the brands of all products with a price above $1000
List<string> brandsOfProducts = (from product in products
                                 where product.Price > 1000
                                 select product.Brand).ToList();

List<string> brandsOfProducts1 = products.Where(x => x.Price > 1000).Select(x => x.Brand).ToList();

// 10) Select the titles of all products with the word "perfume" in the title.
List<string> perfumeTitle = (from product in products
                             where product.Title.Contains("perfume")
                             select product.Title).ToList();

List<string> perfumeTitle1 = products.Where(x => x.Title.Contains("perfume")).Select(x => x.Title).ToList();

// 11) Find the last Grocery product
Product? lastGrocery = products.LastOrDefault(products => products.Category == ProductCategory.Groceries); // da nemam non-nullable warning staviv "?"

// 12) Find the first product with a price above $1000
Product? firstGrocery = products.FirstOrDefault(products => products.Price > 1000);

// 13) Select the titles of all products from the "Groceries" category with a stock above 150
List<string> stockAboveRange = (from product in products
                                where product.Category == ProductCategory.Groceries && product.Stock > 150
                                select product.Title).ToList();

//List<string> stockAbove150Other = (from product in products
//                              where product.Category == ProductCategory.Groceries
//                              where product.Stock > 150
//                              select product.Title).ToList();

List<string> stockAboveRange1 = products.Where(product => product.Category == ProductCategory.Groceries).Where(product => product.Stock > 150).Select(product => product.Title).ToList();

// 14) Find the first item from the brand "Hemani Tea".
Product? firstItemHemaniTea = products.FirstOrDefault(products => products.Brand == "Hemani Tea");
//Product? firstItemHemaniTea = products.FirstOrDefault(products => products.Brand.Contains("Hemani Tea")); // ne znam dali mozhe i vaka ali mi drzhi logika

// 15) Retrieve the ratings of all products with a stock between 30 and 50.
List<double> ratingBetweenRange = (from product in products
                                   where product.Stock > 30 && product.Stock < 50
                                   select product.Rating).ToList();

List<double> ratingBetweenRange1 = products.Where(products => products.Stock > 30 && products.Stock < 50).Select(products => products.Rating).ToList();

// BONUS
Console.WriteLine("BONUSES");
Console.WriteLine("========");

// 1) Find the average price of all products.
double averagePrice = products.Select(products => products.Price).Average();

// 2) Find the total stock of all products.
int totalStock = (from product in products
                  select product.Stock).Sum();

//int totalStock1 = products.Select(product => product.Stock).Sum();

// 3) Check if there is any product with price over $2000.
bool ifPriceOverRange = products.Any(products => products.Price > 2000);

// 4) Find the most expensive Laptop.
Product? mostExpenisveLaptop = products.Where(product => product.Category == ProductCategory.Laptops).OrderByDescending(product => product.Price).FirstOrDefault(); // ChatGPT (ne go znaev OrderByDescending)

// 5) Retrieve the titles and descriptions of all products from the "Skincare" category.
List<string> allSkinCareProducts = products.Where(products => products.Category == ProductCategory.Skincare).Select(products => $"{products.Title} {products.Description}").ToList();