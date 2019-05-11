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
    class TilbudItemPersistencyService
    {
        public static async Task<List<TilbudItem>> GetTilbudItemAsync()
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
                    var response = client.GetAsync("api/TilbudItems").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var tilbudItems = await response.Content.ReadAsAsync<IEnumerable<TilbudItem>>();
                        return (List<TilbudItem>)tilbudItems;
                    }

                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static async void PostTilbudItemAsync(TilbudItem tilbudItem)
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
                    var post = await client.PostAsJsonAsync("Api/TilbudItems", tilbudItem);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        public static async void PutTilbudItemAsync(TilbudItem tilbudItem)
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
                    var put = await client.PutAsJsonAsync("Api/TilbudsItems/" + tilbudItem.Id, tilbudItem);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteTilbudItemAsync(TilbudItem tilbudItem)
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
                    var delete = await client.DeleteAsync("Api/TilbudsItems/" + tilbudItem.Id);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }
    }
}
