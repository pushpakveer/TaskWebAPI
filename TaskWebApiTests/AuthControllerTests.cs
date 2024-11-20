using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using TaskWebAPI.Controllers;
using TaskWebAPI.Models;

namespace TaskWebApiTests
{
 [TestFixture]
    public class AuthControllerTests
    {
        private AuthController _controller;
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            // Setting up configuration as an in-memory dictionary for testing
            var inMemorySettings = new Dictionary<string, string>
        {
            { "ApiKey", "12345-API-KEY-67890" },
            { "Jwt:SecretKey", "my-very-secure-jwt-secret-key-which-is-32-bytes-long!" },
            { "Jwt:Issuer", "TaskWebApi" },
            { "Jwt:Audience", "Wellness360" }
        };
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _controller = new AuthController(_configuration);
        }

        [Test]
        public void GetToken_ReturnsUnauthorized_WhenApiKeyIsInvalid()
        {
        
            var invalidApiKeyRequest = new ApiKeyRequest { ApiKey = "12345-INVALID-API-KEY-67890" };

          
            var result = _controller.GetToken(invalidApiKeyRequest);

            Assert.IsInstanceOf<UnauthorizedResult>(result);  // Expect Unauthorized
        }

        [Test]
        public void GetToken_ReturnsOkWithToken_WhenApiKeyIsValid()
        {
         
            var validApiKeyRequest = new ApiKeyRequest { ApiKey = "12345-API-KEY-67890" };

           
            var result = _controller.GetToken(validApiKeyRequest);

           
            Assert.IsInstanceOf<OkObjectResult>(result); 

            var actionResult = result as OkObjectResult;

            Assert.NotNull(actionResult);

            string json = JsonConvert.SerializeObject(actionResult.Value); 

            var response = JsonConvert.DeserializeObject<dynamic>(json);   

            string token = response.token;  
            Assert.NotNull(token);          
            Assert.IsNotEmpty(token);  
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            Assert.AreEqual("TaskWebApi", jwtToken.Issuer);
        }
    }
}