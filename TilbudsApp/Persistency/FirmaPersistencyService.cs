﻿using System;
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
    class FirmaPersistencyService
    {
        public static async Task<List<Firma>> GetFirmaAsync()
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
                    var response = client.GetAsync("api/Firmas").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var firmas = await response.Content.ReadAsAsync<IEnumerable<Firma>>();
                        return (List<Firma>)firmas;
                    }

                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static async void PostFirmaAsync(Firma firma)
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
                    var post = await client.PostAsJsonAsync("Api/Firmas", firma);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        public static async void PutFirmaAsync(Firma firma)
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
                    var put = await client.PutAsJsonAsync("Api/Firmas/" + firma.Id, firma);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteFirmaAsync(Firma firma)
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
                    var delete = await client.DeleteAsync("Api/Firmas/" + firma.Id);
                }
                catch (Exception e)
                {
                    await new MessageDialog(e.Message).ShowAsync();
                }
            }
        }
    }
}
