using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingApp.functionality;

namespace TestingApp.Test
{
    internal class DbServiceMock : IDbService
    {
        public bool ProcessResult { get; set; }
        public Product ProductBeingProcessed { get; set; }

        public int ProductIdBeingProcessed { get; set; }    
        public bool RemoveItemFromShoppingCart(int? prodId)
        {
            if(prodId != null)
            {
                ProductIdBeingProcessed = Convert.ToInt32(prodId);
                return ProcessResult;
            }
            return false;
        }

        public bool SaveItemToShoppingCart(Product? prod)
        {
            if (prod == null) return false;
            ProductBeingProcessed = prod;

            return ProcessResult;
        }
    }
    public class ShoppingCartTest
    {
        [Fact]
        public void AddProduct_Success()
        {
            var dbMock = new DbServiceMock();
            //writing dbMock.ProcessResult = false; will fail the test signifying that data has not been added to the database
            dbMock.ProcessResult = true;
            var shoppingCart = new ShoppingCart(dbMock);

            var product = new Product(1, "shoes", 150);
            var result = shoppingCart.AddProduct(product);

            Assert.True(result);
            Assert.Equal(result, dbMock.ProcessResult);
            Assert.Equal("shoes", dbMock.ProductBeingProcessed.Name);
        }

        [Fact]
        public void RemoveProduct_Success()
        {
            var dbMock = new DbServiceMock();
            dbMock.ProcessResult = true;

            var shoppingCart = new ShoppingCart(dbMock);

            var product = new Product(1, "shoe", 150);
            var result = shoppingCart.DeleteProduct(product.Id);

            Assert.True(result);
            Assert.Equal(result, dbMock.ProcessResult);
            Assert.Equal(product.Id, dbMock.ProductIdBeingProcessed);
        }
    }

}
