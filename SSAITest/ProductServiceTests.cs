using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using SSAI.Helpers;
using SSAI.Model.Request;
using SSAI.Model.Response;
using SSAI.Service;
using System.Threading.Tasks;

namespace SSAITest
{
    [TestFixture]
    public class ProductServiceTests
    {
        private IOptions<AppSettings> _appSettings { get; set; }


        [SetUp]
        public void Setup()
        {
            _appSettings = Options.Create(new AppSettings
            {
                Secret = "blablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablabla123"
            });
        }


        [Test]
        public async Task UserService_Authenticate_CorrectCredentials_ShouldSuccess()
        {
            //Arrange
            var objtest = new UserService(_appSettings);
            var authModel = new AuthenticateRequest
            {
                Username = "test",
                Password = "test",
            };
            AuthenticateResponse result;

            //Act
            result = objtest.Authenticate(authModel);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(authModel.Username, result.Username);
            Assert.IsNotNull(result.Token);
            Assert.IsNotEmpty(result.Token);
        }


        [Test]
        public async Task UserService_Authenticate_CorrectCredentials_ShouldFail()
        {
            //Arrange
            var objtest = new UserService(_appSettings);
            var authModel = new AuthenticateRequest
            {
                Username = "",
                Password = "",
            };
            AuthenticateResponse result;

            //Act
            result = objtest.Authenticate(authModel);

            //Assert
            Assert.IsNull(result);
        }
    }
}