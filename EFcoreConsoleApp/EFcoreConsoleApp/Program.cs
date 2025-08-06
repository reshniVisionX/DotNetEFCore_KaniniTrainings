// See https://aka.ms/new-console-template for more information
using EFcoreConsoleApp.Models;

Console.WriteLine("Hello, World!");
MyDemoDbContext dbContext = new MyDemoDbContext();



foreach(MenuList menu in dbContext.MenuLists)
{
    Console.WriteLine($"Menu ID: {menu.MenuId}, Dish Name: {menu.DishName}, Price: {menu.Price}, Category: {menu.Category}");
}

using (var context = new MyDemoDbContext())
{
    var products = context.Products.ToList();
    foreach (var p in products)
    {
        Console.WriteLine($"Product: {p.ProName}, Price: {p.Price}");
    }
}

using (var context = new MyDemoDbContext())
{
    var orders = context.ParlourLists.ToList();
    foreach (var o in orders)
    {
        Console.WriteLine($"Order ID: {o.ParlourId}, Customer Name: {o.ParlourName}, Total Amount: {o.City}, Phone: {o.Phone}, Rating: {o.Rating}");
    }
}
//The using keyword ensures that the context is disposed automatically after use.
using (var context = new MyDemoDbContext())
{
    var newProduct = new Product { ProdId=1,ProName = "Keyboard", Price = 1000 };
    context.Products.Add(newProduct);
    context.SaveChanges();
    Console.WriteLine("New product added successfully!");
}

using (var context = new MyDemoDbContext())
{
    var res = context.Restaurants.FirstOrDefault(p => p.RestId== 1);
    if (res != null)
    {
        res.Phno = "8890008789";
        context.SaveChanges();
        Console.WriteLine($"Updated Restaurant Phone: {res.Phno}");
    }
}
