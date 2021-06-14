using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using SSAI.Entity.DB;
using SSAI.Entity.IRepository;
using SSAI.Helpers;
using SSAI.Model.Request;
using SSAI.Model.Response;
using SSAI.Service;
using SSAI.UOW;
using System.Threading.Tasks;

namespace SSAITest
{
    [TestFixture]
    public class ProductServiceTests
    {
        private Mock<IProductRepository> _mockRepositoryProduct { get; set; }
        private Mock<IUnitOfWorkProduct> _mockUOWProduct { get; set; }
        private Mock<IUnitOfWorkOrder> _mockUOWOrder { get; set; }
        private ProductService _productService;


        [SetUp]
        public void Setup()
        {
            _mockRepositoryProduct = new Mock<IProductRepository>();
            _mockUOWProduct = new Mock<IUnitOfWorkProduct>();
            _mockUOWOrder = new Mock<IUnitOfWorkOrder>();

            _mockUOWProduct.SetupGet(x => x.Products).Returns(_mockRepositoryProduct.Object);

            _productService = new ProductService(_mockUOWProduct.Object, _mockUOWOrder.Object);
        }


        [Test]
        public async Task ProductService_Add_ShouldSuccess()
        {
            //Arrange
            var productModel = new Product
            {
                Name = "Prova",
                Description = "Prova",
                StockQty = 500,
                UnitPrice = 25
            };
            GenericResponse<ProductResponse> result;
            _mockRepositoryProduct.Setup(x => x.Exists(productModel)).Returns(false);
            _mockRepositoryProduct.Setup(x => x.Add(productModel)).ReturnsAsync(true);

            //Act
            result = await _productService.Add(productModel);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.error);
            Assert.AreEqual(result.model.name, productModel.Name);
            Assert.AreEqual(result.model.description, productModel.Description);
        }


        [Test]
        public async Task ProductService_Add_SameName_ShouldFail()
        {
            //Arrange
            var productModel = new Product
            {
                Name = "Prova",
                Description = "Prova",
                StockQty = 500,
                UnitPrice = 25
            };
            GenericResponse<ProductResponse> result;
            _mockRepositoryProduct.Setup(x => x.Exists(productModel)).Returns(true);

            //Act
            result = await _productService.Add(productModel);

            //Assert
            Assert.IsTrue(result.error);
            Assert.AreEqual(result.message, "Product already exists with the same name and description.");
        }


    }
}