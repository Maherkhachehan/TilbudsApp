using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using TilbudsApp.Model;

namespace TilbudsApp.Persistency
{
    class ButikPersistencyService
    {
        
        public static async Task<List<Butik>> GetButikAsync()
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
                    var response = client.GetAsync("api/Butiks").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var butiks = await response.Content.ReadAsAsync<IEnumerable<Butik>>();
                        return (List<Butik>)butiks;
                    }

                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static async void PostButikAsync(Butik butik)
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
                    var post = await client.PostAsJsonAsync("Api/Butiks", butik);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        public static async void PutButikAsync(Butik butik)
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
                    var put = await client.PutAsJsonAsync("Api/Butiks/" + butik.Id, butik);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteButikAsync(Butik butik)
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
                    var delete = await client.DeleteAsync("Api/Butiks/" + butik.Id);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }
    }
}
