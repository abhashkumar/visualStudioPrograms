using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp.functionality;

namespace TestingApp_.Test
{
    public class ShoppingCartTestWithMoq
    {
        public readonly Mock<IDbService> _dbServiceMock = new();
        [Fact]
        public void AddProduct_Success()
        {
            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);

            var product = new Product(1, "shoes", 150);
            var result = shoppingCart.AddProduct(product);

            Assert.True(result);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void AddProduct_FailueDueToInvalidPayload()
        {
            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);

            Product product = null;
            var result = shoppingCart.AddProduct(product);

            Assert.False(result);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public void RemoveProduct_Success()
        {

            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);

            var product = new Product(1, "shoe", 150);
            var result = shoppingCart.DeleteProduct(product.Id);

            Assert.True(result);
            _dbServiceMock.Verify(x => x.RemoveItemFromShoppingCart(It.IsAny<int>()), Times.Once);
        }
    }
}
