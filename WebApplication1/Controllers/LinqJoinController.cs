using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LinqJoinController : ControllerBase
    {
        private readonly ILogger<LinqJoinController> _logger;
        public LinqJoinController(ILogger<LinqJoinController> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "Joins")]
        public IEnumerable<object> getJoin()
        {
            var customer = new[]
            {
                new {CustomerId=1, Name ="Priya"},
                new {CustomerId=2, Name="Rajput" },
                new {CustomerId=3, Name="John" },
                new {CustomerId=4, Name="Caven" }
            };

            var order = new[]
            {
                new {OrderId = 001,CustomerId = 1, Name = "Charirs" },
                new {OrderId = 002,CustomerId = 2, Name = "Cupboard" },
            };


            //Inner Join
            var details = from customerData in customer
                          join orderData in order
                          on customerData.CustomerId equals orderData.CustomerId
                          select new { customerData.Name, orderData.OrderId };

            foreach (var item in details)
            {
                Console.WriteLine(item);
            }

            // Group Join
            var groupedDetails = from customerData in customer
                                 join orderData in order
                                 on customerData.CustomerId equals orderData.CustomerId
                                 into groupedDa
                                 select new { customerData.Name, groupedItem = groupedDa };


            foreach (var item in groupedDetails)
            {
                Console.WriteLine(item);
            }

            // Left Join
            var leftDetails = from customerData in customer
                              join orderData in order
                              on customerData.CustomerId equals orderData.CustomerId
                              into groupedData
                              from joinData in groupedData.DefaultIfEmpty()
                              select new
                              {
                                  customerData.CustomerId,
                                  joinData = groupedData
                              };


            foreach (var item in leftDetails)
            {
                Console.WriteLine(item);
            }

            // Cross Join
            var crossDetails = from customerData in customer
                               from orderData in order
                               select new
                               {
                                   customerData,
                                   orderData
                               };

            foreach (var item in crossDetails)
            {
                Console.WriteLine(item);
            }

            // Self Join 
            var selfDetails = from customerData in customer
                              join customerData1 in customer
                              on customerData.CustomerId equals customerData1.CustomerId
                              select new
                              {
                                  customerData,
                                  customerData1
                              };
            foreach (var item in selfDetails)
            {
                Console.WriteLine(item);
            }

            // Outer Join
            //var OuterDetails = (from customerData in customer
            //                    join orderData in order on customerData.CustomerId equals orderData.CustomerId into customerData1
            //                    from orderData in customerData1.DefaultIfEmpty()
            //                    select new { customerData, customerData1.Name })
            //                   .Union(
            //    from orderData in order
            //    join customerData in customer
            //    on orderData.CustomerId equals customerData.CustomerId
            //    into groupedItems
            //    from ab in groupedItems.DefaultIfEmpty()
            //    select new { orderData, groupedItems });

            return leftDetails;
        }

    }
}
