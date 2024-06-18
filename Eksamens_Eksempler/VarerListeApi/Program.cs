var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

List<Item> itemList = new List<Item>(); 

int Id = 1;

itemList.Add(new Item { Id = Id++, Name = "Cola", Description = "Tastes like gold", Price = 4.99 });
itemList.Add(new Item { Id = Id++, Name = "Banana", Description= "Same colour as gold", Price = 2.25});
itemList.Add(new Item { Id = Id++, Name = "Cocunut", Description = "Avoid falling Cocunuts", Price= 5.99});

    // app.MapGet Endpoints
// Endpoint som retunere hele ItemList
app.MapGet("api/items", () => itemList);

// Endpoint som retunere baseret på id
app.MapGet("api/items/{id}", (int id) => {
    var Item = itemList.FirstOrDefault(i => i.Id == id);

    if (Item != null) {
        return Results.Ok(Item); 
    }

    return Results.NotFound("Id not matching an items Id"); 
});

// Endpoint som retunere alle items som starter med det indtastede bogstav  
app.MapGet("api/items/letter/{letter}", (string letter) => {
    var Items = itemList.Where(i => i.Name.StartsWith(letter, StringComparison.OrdinalIgnoreCase)).ToList();

    if (Items.Count > 0) {
        return Results.Ok(Items); 
    }

    return Results.NotFound("No items starting with the letter: " + letter); 
});

// Endpoint som retunere alle items som indeholder det indtastede ord
app.MapGet("api/items/word/{word}", (string word) => {
    var Items = itemList.Where(i => i.Name.Contains(word, StringComparison.OrdinalIgnoreCase)).ToList();

    if (Items.Count > 0) {
        return Results.Ok(Items); 
    }

    return Results.NotFound("No items containing the word: " + word); 
});

// Endpoint som retunere alle items som har en pris mellem de to indtastede beløb
app.MapGet("api/items/price/{minPrice}/{maxPrice}", (double minPrice, double maxPrice) => {
    var Items = itemList.Where(i => i.Price >= minPrice && i.Price <= maxPrice).ToList();

    if (Items.Count > 0) {
        return Results.Ok(Items); 
    }

    return Results.NotFound("No items between: " + minPrice + " and " + maxPrice); 
});

// Endpoint som retunere alle items som er billigere end det indtastede beløb
app.MapGet("api/items/price/{price}", (double price) => {
    var Items = itemList.Where(i => i.Price < price).ToList();

    if (Items.Count > 0) {
        return Results.Ok(Items); 
    }

    return Results.NotFound("No items cheaper than: " + price); 
});

// Endpoint som tilføjer et nyt item til itemList 
app.MapPost("api/items", (NewItem newItem) => {
    var itemToAdd = new Item {
        Id = Id++,
        Name = newItem.Name,
        Description = newItem.Description,
        Price = newItem.Price
    };

    itemList.Add(itemToAdd);

    return Results.Created($"/api/items/{itemToAdd.Id}", itemToAdd);
});

// Endpoint som hæver prisen på alle items i itemList med 10%
app.MapPut("api/items/price/increase", () => {
    foreach (var item in itemList) {
        item.Price = item.Price * 1.1;
    }

    return Results.Ok(itemList);
});

// Endpoint som hæver prisen for en specifik item i itemList med ønskede procent
app.MapPut("api/items/{id}/price/increase/{percent}", (int id, double percent) => {
    var Item = itemList.FirstOrDefault(i => i.Id == id);

    if (Item != null) {
        Item.Price = Item.Price * (1 + percent / 100);

        return Results.Ok(Item);
    }

    return Results.NotFound("No item with this Id");
});

// Endpoint som opdaterer et item i itemList
app.MapPut("api/items/{id}", (Item ItemInput, int id) => {
    var Item = itemList.FirstOrDefault(i => i.Id == id);

    if (Item != null) {
        Item.Name = ItemInput.Name;
        Item.Description = ItemInput.Description;
        Item.Price = ItemInput.Price;

        return Results.Ok(Item);
    }

    return Results.NotFound("No item with this Id");
});

// Endpoint som sletter et item fra itemList
app.MapDelete("api/items/{id}", (int id) => {
    var Item = itemList.FirstOrDefault(i => i.Id == id);

    if (Item != null) {
        itemList.Remove(Item);

        return Results.Ok(Item);
    }

    return Results.NotFound("No item with this Id");
});

app.Run();

public record NewItem (string Name, String Description, double Price);

public class Item 
{
    public int Id { get; set; }
    public string Name { get; set;}
    public string Description { get; set;}
    public double Price { get; set;}
}