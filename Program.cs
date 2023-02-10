var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World 4!");
app.MapPost("/", () => new { Name = "Peter Parker", Age = 35 });
app.MapGet("/AddHeader", (HttpResponse response) => {
    response.Headers.Add("Teste", "Peter Parker");
    return new { Name = "Peter Parker", Age = 35 };
    });

app.MapPost("/saveproduct", (Product product) =>
{
    return product.Code + " - " + product.Name;
});

app.Run();

public class Product
{
    public string Code { get; set; }  public string Name { get; set; }
}