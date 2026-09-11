
using System.Text.Json;

using var client = new HttpClient();
client.DefaultRequestHeaders.Add("x-api-key", "live_d1P51nodlXOcpOcurizLfJyRZ56feNEWAVFGwlY5ei5b8Ug7kp2kFURcWlWHUwH7");

var response = await client.GetAsync("https://api.thecatapi.com/v1/images/search?limit=10&breed_ids=beng");
var body = await response.Content.ReadAsStringAsync();
var jsonElement = JsonDocument.Parse(body).RootElement;
var prettyJson = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true });
if (response.IsSuccessStatusCode)
{
    Console.WriteLine("request success! returned:");
    Console.WriteLine(prettyJson);
}
else
{
    Console.WriteLine($"request failed with statuscode: {(int)response.StatusCode} {response.ReasonPhrase}");
    Console.WriteLine(prettyJson);
}

