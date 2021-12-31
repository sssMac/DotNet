using System;
using System.Threading.Tasks;
using System.Net.Http;

     static async Task DoRequest()
     {
         var hhtpClient = await HttpClient
                .GetAsync("http://localhost:5000/add?v1=1&v2=2");
         var str = await response.Content
             .ReadAsStringAsync();
         Console.WriteLine(str);
            
     }

 await DoRequest();
