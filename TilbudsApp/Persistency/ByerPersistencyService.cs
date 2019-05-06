using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TilbudsApp.Model;
using Windows.UI.Popups;

namespace TilbudsApp.Persistency
{
    class ByerPersistencyService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Byer>> GetByerAsync()
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
                    var response = client.GetAsync("api/Byers").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var byers = await response.Content.ReadAsAsync<IEnumerable<Byer>>();
                        return (List<Byer>)byers;
                    }

                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        public static async void PostByAsync(Byer by)
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
                    var post = await client.PostAsJsonAsync("Api/Byers", by);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        public static async void PutByAsync(Byer by)
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
                    var put = await client.PutAsJsonAsync("Api/Byers/" + by.Id, by);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        public static async void DeleteByAsync(Byer by)
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
                    var delete = await client.DeleteAsync("Api/Byers/" + by.Id);
                }
                catch(Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }
    }
}
