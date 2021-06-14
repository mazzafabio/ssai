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
    public class OrderServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public async Task OrderService_Add_ShouldSuccess()
        {
            Assert.Pass();
        }
    }
}