using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Weather.WebApi;
using Xunit;

namespace Weather.Tests;

public class WeatherTests
{
    [Fact]
    public async Task BuscarPrevisao()
    {
        var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();
        var response = await client.GetAsync("/weatherforecast");

        response.EnsureSuccessStatusCode();

        var forecast = JsonConvert.DeserializeObject<WeatherForecast[]>(await response.Content.ReadAsStringAsync());

        Assert.Equal(5, forecast.Length);
    }    
}
