using Demo_Asp_NetCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using Xunit;
using Xunit.Abstractions;

namespace TestWarehouse
{
    public class WarehouseTest
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly WebApplicationFactory<Startup> _factory;

        public WarehouseTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async void TestGetWarehouses()
        {
            //Arrange
            var client = _factory.CreateDefaultClient();

            //Act
            var response = await client.GetAsync("/api/warehouse/GetWarehouses");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);
            Assert.NotEmpty(responseContent);

            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }
    }
}
