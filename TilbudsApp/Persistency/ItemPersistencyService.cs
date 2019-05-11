using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using TilbudsApp.Model;

namespace TilbudsApp.Persistency
{
    class ItemPersistencyService
    {
        public static async Task<List<Item>> GetItemAsync()
        {
            const string ServerUrl = "http://localhost:64090";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/Json"));

                try
                {
                    var response = client.GetAsync("api/Items").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var items = await response.Content.ReadAsAsync<IEnumerable<Item>>();
                        return (List<Item>)items;
                    }

                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static async void PostItemAsync(Item item)
        {
            const string ServerUrl = "http://localhost:64090";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/Json"));

                try
                {
                    var post = await client.PostAsJsonAsync("Api/Items", item);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        public static async void PutItemAsync(Item item)
        {
            const string ServerUrl = "http://localhost:64090";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/Json"));

                try
                {
                    var put = await client.PutAsJsonAsync("Api/Items/" + item.Id, item);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteItemAsync(Item item)
        {
            const string ServerUrl = "http://localhost:64090";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/Json"));

                try
                {
                    var delete = await client.DeleteAsync("Api/Items/" + item.Id);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

    }
}
