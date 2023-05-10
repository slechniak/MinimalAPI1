using System.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

#region cennik

app.MapGet("/priceitems", async () =>
{
    return await GetPriceItems();
});

app.MapGet("/priceitem/{id}", async (int id) =>
{
    PriceItem item = await GetPriceItem(id);
    if (item is null)
        return Results.NotFound();
    return Results.Ok(item);
});

app.MapDelete("/priceitem/{id}", async (int id) =>
{
    PriceItem item = await DeletePriceItem(id);
    if (item is null)
        return Results.NotFound();
    return Results.Ok(item);
});

app.MapPost("/priceitem", async (PriceItem priceItem) =>
{
    PriceItem item = await CreatePriceItem(priceItem);
    if (item is null)
        return Results.BadRequest();
    return Results.Created($"/priceitem/{item.Id}", item);
});

app.MapPut("/priceitem", async (PriceItem priceItem) =>
{
    await UpdatePriceItem(priceItem);
    return Results.NoContent();
});

# endregion

#region zestawienie sprzedaży

app.MapGet("/sales", async () =>
{
    return await GetSalesItems();
});

#endregion

app.Run();


static async Task<List<SalesItem>> GetSalesItems()
{
    //fetch the list of sales items and return it
    return new List<SalesItem>() {
        new SalesItem { Id = 0, Date = new DateTime(2023,6,10,12,30,22), Sum = 10.99m},
        new SalesItem { Id = 1, Date = new DateTime(2023,3,17,14,24,13), Sum = 20.99m } };
    //return null;
}
static async Task<List<PriceItem>> GetPriceItems() 
{
    //fetch the list of price items and return it
    return new List<PriceItem>() {
        new PriceItem { Id = 0, Name = "test0", Price = 0.99m},
        new PriceItem { Id = 1, Name = "test1", Price = 1.99m } };
    //return null;
}
static async Task<PriceItem> GetPriceItem(int id)
{
    //fetch price item and return it
    return new List<PriceItem>() {
        new PriceItem { Id = 0, Name = "test0", Price = 0.99m},
        new PriceItem { Id = 1, Name = "test1", Price = 1.99m } }.FirstOrDefault(x=>x.Id==id);
    //return null;
}
static async Task<PriceItem> CreatePriceItem(PriceItem priceItem) 
{
    //add price item
    return priceItem;
    //return null;
}
static async Task UpdatePriceItem(PriceItem priceItem) { }
static async Task<PriceItem> DeletePriceItem(int id) 
{
    //find item, delete and return it, if not found return null
    return null;
}

public class PriceItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class SalesItem
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Sum { get; set; }
}


