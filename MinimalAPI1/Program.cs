using System.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

#region cennik

var priceItemGroup = app.MapGroup("/priceitem");

priceItemGroup.MapGet("/", async () =>
{
    return await GetPriceItems();
});

priceItemGroup.MapGet("/{id}", async (int id) =>
{
    PriceItem item = await GetPriceItem(id);
    if (item is null)
        return Results.NotFound();
    return Results.Ok(item);
});

priceItemGroup.MapDelete("/{id}", async (int id) =>
{
    PriceItem item = await DeletePriceItem(id);
    if (item is null)
        return Results.NotFound();
    return Results.Ok(item);
});

priceItemGroup.MapPost("/", async (PriceItem priceItem) =>
{
    PriceItem item = await CreatePriceItem(priceItem);
    if (item is null)
        return Results.BadRequest();
    return Results.Created($"/priceitem/{item.Id}", item);
});

priceItemGroup.MapPut("/", async (PriceItem priceItem) =>
{
    PriceItem item = await UpdatePriceItem(priceItem);
    if (item is null)
        return Results.BadRequest();
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
    return null;
}
static async Task<List<PriceItem>> GetPriceItems() 
{
    //fetch the list of price items and return it
    return null;
}
static async Task<PriceItem> GetPriceItem(int id)
{
    //fetch price item and return it, if not found return null
    return null;
}
static async Task<PriceItem> CreatePriceItem(PriceItem priceItem) 
{
    //add price item and return it, if unsuccessful return null
    return null;
}
static async Task<PriceItem> UpdatePriceItem(PriceItem priceItem)
{
    //find price item, update and return it, if not found return null
    return null;
}
static async Task<PriceItem> DeletePriceItem(int id) 
{
    //find price item, delete and return it, if not found return null
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


