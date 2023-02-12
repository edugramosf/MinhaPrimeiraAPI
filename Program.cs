using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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

//api.app.com/users?datastart={date}&dateend={date}
app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) =>
{
    return dateStart + " - " + dateEnd;
});

//api.app.com/user/{code}
app.MapGet("/getproduct/{code}", ([FromRoute]string code) =>
{
    return code;
});

app.MapGet("/getproductbyheader", (HttpRequest request) =>
{
    return request.Headers["product-code"].ToString();
});

app.Run();

public static class ProductRepository
{
    public List<Product> Products { get; set; }

    public void Add(Product product) {
        if (Products == null) { Products = new List<Product>(); }
        Products.Add(product);
    }
        
       public Product GetBy(string code)
        {
            return Products.First(p => p.code == code);
        }
    }
}

public class Product
{
    public string Code { get; set; }  public string Name { get; set; }
}