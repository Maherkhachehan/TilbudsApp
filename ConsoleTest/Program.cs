using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebSerivceHttp;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
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
                    //Get metoden til DataBasen - bruges til at hente fra databasen
                    var response = client.GetAsync("api/Byers").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var byers = response.Content.ReadAsAsync<IEnumerable<Byer>>().Result;

                        foreach (var byer in byers)
                        {
                            Console.WriteLine(byer);
                        }
                    }

                    //Post metoden til databasen - bruges til at tilføje til databasen
                    //Byer by = new Byer() { Id = 0, Bname = "Helsingør" };
                    //var post = client.PostAsJsonAsync("Api/Byers", by).Result;
                    //Console.WriteLine(post.StatusCode);

                    //Put metoden til databasen - bruges til at ændre i databasen
                    //Byer by1 = new Byer() { Id = 0, Bname = "Helsingør2" };
                    //var put = client.PutAsJsonAsync("Api/Byers/0", by1).Result;
                    //Console.WriteLine(put.StatusCode);

                    //Delete metoden til databasen - bruges til at slette fra databasen
                    //var delete = client.DeleteAsync("Api/Byers/0").Result;
                    //Console.WriteLine(delete.StatusCode);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Console.ReadKey();
            }
        }
    }
}
