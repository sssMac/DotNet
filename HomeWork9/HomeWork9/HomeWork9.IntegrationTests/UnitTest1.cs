using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace HomeWork9.IntegrationTests
{
     public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(x => x.UseStartup<Startup>().UseTestServer());
    }
    
    public class IntegrationTests9 : IClassFixture<HostBuilder>
    {
        private readonly HttpClient _client;
        public IntegrationTests9(HostBuilder server)
        {
            _client = server.CreateClient();
        }
        
        [Theory]
        [InlineData("1 plus 2", "3")]
        [InlineData("1 plus 2 plus lb 1 plus 3 rb", "7")]
        [InlineData("5 divide 1", "5")]
        [InlineData("364 minus 2", "362")]
        [InlineData("12", "12")]
        [InlineData("6 multiply 13", "78")]
        public async Task Calculate_CorrectArguments_CorrectResultReturned(string expression, string expected)
        { 
           using var response = await _client.GetAsync($"https://localhost:5001/Calculator/Calculate?expression={expression}");
           var actual = await response.Content.ReadAsStringAsync();
           Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("12 plus 2 rb")]
        [InlineData("not expression")]
        [InlineData("rb12 multiply 3lb")]
        [InlineData("lb12 a 7rb")]
        [InlineData("12 plus plus 2")]
        public async Task Calculate_IncorrectArguments_ErrorStringReturned(string expression)
        {
            const string expected = "() => \"Error\"";
            using var response = await _client.GetAsync($"https://localhost:5001/Calculator/Calculate?expression={expression}");
            var actual = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("lb 2 plus 3 rb divide 2 multiply 7 plus 8 multiply 9")]
        private async Task Calculate_ParallelTest(string expression)
        {
            var watch = new Stopwatch();
            watch.Start();
            using var response = await _client.GetAsync($"https://localhost:5001/Calculator/Calculate?expression={expression}");
            watch.Stop();
            var time = watch.ElapsedMilliseconds;
            Assert.True(time == 3000);
        }
    }
}