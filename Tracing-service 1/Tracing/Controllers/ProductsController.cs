using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry;
using System.Diagnostics;
using Tracing.Data;

namespace Tracing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ProductsDataContext _dataContext;
        private static List<Product>? _products;
        private static readonly ActivitySource _activitySource = new("Tracing");

        public ProductsController(ProductsDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            if (CheckCache(out var products))
            {
                return Ok(products);
            }

            _products = await _dataContext.Products.ToListAsync();

            Response.Headers.Add("Request-Id", Activity.Current?.TraceId.ToString());
            return Ok(_products);
        }

        private static bool CheckCache(out IEnumerable<Product> products)
        {
            using var activity = _activitySource.StartActivity("CheckCache");

            var userId = Activity.Current?.GetBaggageItem("UserId");
            activity?.AddTag("UserId", userId);

            if (_products is not null)
            {
                var activityEvent = new ActivityEvent("ProductsRetrievedFromCache",
                    tags: new ActivityTagsCollection { new("products.count", _products.Count) });
                activity?.AddEvent(activityEvent);
                products = _products;
                return true;
            }

            products = new List<Product>();

            return false;
        }
    }
}
