using System.Net.Http.Headers;
using System.Text.Json;

public class Operations
{
    private HttpClient client = new HttpClient();

    public Operations()
    {

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

    }

    public async Task<List<Drink>> GetDrinks(string category)
    {
        try
        {
            var url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={category}";
            await using Stream stream = await client.GetStreamAsync(url);
            var response = await JsonSerializer.DeserializeAsync<DrinkResponse>(stream);
            return response?.Content ?? new List<Drink>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<Drink>();
        }
    }

    public async Task<List<DrinkDetail>> GetDrinksInfo(string id)
    {
        try
        {
            
            var url = $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}";
            await using Stream stream = await client.GetStreamAsync(url);
            
            var response = await JsonSerializer.DeserializeAsync<DrinkDetailObject>(stream);
            
            return response?.Content ?? new List<DrinkDetail>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<DrinkDetail>();
        }
    }

}
