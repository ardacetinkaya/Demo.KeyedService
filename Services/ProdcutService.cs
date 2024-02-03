namespace Demo.KeyedService.ProductService;

public interface IProductService
{
    List<string> ListProducts(int top = 5);
}

public class AmazonProducts : IProductService
{
    public List<string> ListProducts(int top = 5)
    {
        return new List<string>{
            "Fancy Product from Amazon",
            "Another Fancy Product from Amazon",
            "Top Seller Product from Amazon",
            "Most Expensive Product from Amazon",
            "Cheapest Product from Amazon",
            "Some Shinny Product from Amazon",
            "A Red Product from Amazon",
            "A Blue Product from Amazon",
            "Most Tasty Cake from Amazon",
            "Most Biggest Product from Amazon",
       }.Take(top).ToList();
    }
}

public class CDONProducts : IProductService
{
    public List<string> ListProducts(int top = 5)
    {
        var ran = new Random();
        return new List<string>{
            "Fancy Product from CDON",
            "Another Fancy Product from CDON",
            "Top Seller Product from CDON",
            "Most Expensive Product from CDON",
            "Cheapest Product from CDON",
            "Some Shinny Product from CDON",
            "A Red Product from CDON",
            "A Blue Product from CDON",
            "Most Tasty Cake from CDON",
            "Most Biggest Product from CDON",
       }.OrderBy(x => ran.Next()).Take(top).ToList();
    }
}
