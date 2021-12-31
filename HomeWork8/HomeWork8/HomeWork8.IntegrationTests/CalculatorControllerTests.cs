using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace HomeWork8.IntegrationTests
{
    [TestFixture]
    public class CalculatorControllerTests
    {
        [Test]
        public async Task Add_10and5_ShouldReturn15()
        {
            WebApplicationFactory<Startup> webHost = new WebApplicationFactory<Startup>().WithWebHostBuilder(_ => { });
            HttpClient httpClient = webHost.CreateClient();

            HttpResponseMessage response = await httpClient.GetAsync("Calculator/Add?v1=10&v2=5");
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        } 
        
        [Test]
        public async Task Min_20min7_ShouldReturn13()
        {
            WebApplicationFactory<Startup> webHost = new WebApplicationFactory<Startup>().WithWebHostBuilder(_ => { });
            HttpClient httpClient = webHost.CreateClient();

            HttpResponseMessage response = await httpClient.GetAsync("Calculator/Min?v1=20&v2=7");
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        } 
        
        [Test]
        public async Task Div_45div5_ShouldReturn7()
        {
            WebApplicationFactory<Startup> webHost = new WebApplicationFactory<Startup>().WithWebHostBuilder(_ => { });
            HttpClient httpClient = webHost.CreateClient();

            HttpResponseMessage response = await httpClient.GetAsync("Calculator/Div?v1=45&v2=5");
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        } 
        
        [Test]
        public async Task Mul_14and3_ShouldReturn42()
        {
            WebApplicationFactory<Startup> webHost = new WebApplicationFactory<Startup>().WithWebHostBuilder(_ => { });
            HttpClient httpClient = webHost.CreateClient();

            HttpResponseMessage response = await httpClient.GetAsync("Calculator/Mul?v1=14&v2=3");
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        } 
        
        [Test]
        public async Task Div_14and0_ShouldReturn0()
        {
            WebApplicationFactory<Startup> webHost = new WebApplicationFactory<Startup>().WithWebHostBuilder(_ => { });
            HttpClient httpClient = webHost.CreateClient();

            HttpResponseMessage response = await httpClient.GetAsync("Calculator/Div?v1=14&v2=0");
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        } 
    }
}