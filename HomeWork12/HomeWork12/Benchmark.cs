using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace HomeWork12
{
    public class HostBuilderFSharp : WebApplicationFactory<Giraffe11.App.Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Giraffe11.App.Startup>()
                    .UseTestServer());
    }

    public class HostBuilderCSharp : WebApplicationFactory<HomeWork8.Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<HomeWork8.Startup>()
                    .UseTestServer());
    }

    [MinColumn]
    [MaxColumn]
    [MedianColumn]
    public class Benchmark
    {
        private HttpClient CSharpClient;
        private HttpClient FSharpClient;

        [GlobalSetup]
        public void GlobalSetUp()
        {
            CSharpClient = new HostBuilderCSharp().CreateClient();
            FSharpClient = new HostBuilderFSharp().CreateClient();
        }

        [Benchmark]
        public async Task AddInCSharp()
        {
            await SendRequestCSharp("5", "+", "8");
        }

        [Benchmark]
        public async Task AddInFSharp()
        {
            await SendRequestFSharp("5", "Plus", "8");
        }

        [Benchmark]
        public async Task MinInCSharp()
        {
            await SendRequestCSharp("5", "-", "8");
        }

        [Benchmark]
        public async Task MinInFSharp()
        {
            await SendRequestFSharp("10", "Minus", "1");
        }

        [Benchmark]
        public async Task MulInCSharp()
        {
            await SendRequestCSharp("5", "*", "8");
        }

        [Benchmark]
        public async Task MultiplyInFSharp()
        {
            await SendRequestFSharp("5", "Multiply", "8");
        }

        [Benchmark]
        public async Task DivideInCSharp()
        {
            await SendRequestCSharp("5", "/", "8");
        }

        [Benchmark]
        public async Task DivideInFSharp()
        {
            await SendRequestFSharp("10", "Divide", "2");
        }

        private async Task SendRequestFSharp(string v1, string operation, string v2)
        {
            await FSharpClient.GetAsync($"https://localhost:5000/calculate?v1={v1}&operation={operation}&v2={v2}");
        }

        private async Task SendRequestCSharp(string v1, string operation, string v2)
        {
            await CSharpClient.GetAsync($"Calculator/{operation}?v1={v1}&v2={v2}");
        }
    }
}
