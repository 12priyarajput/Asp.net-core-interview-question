using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LinqCollectionsController : ControllerBase
    {

        [HttpGet(Name = "GetCollections")]
        public IEnumerable<Object> getCollections()
        {
            var numbersArray = new[] { 1, 3, 4, 2, 4, 5, 6 };

            // Skip method
            var reesult = numbersArray.Skip(3);

            foreach (var data in reesult)
            {
                Console.WriteLine(data);
            }

            // Take Method
            var takeResult = numbersArray.Take(3);
            foreach (var data in takeResult)
            {
                Console.WriteLine(data);
            }

            // Skip and Take combined
            var combinedResult = numbersArray.Skip(3).Take(2);
            foreach (var item in combinedResult)
            {
                Console.WriteLine(item);
            }


            var people = new[]
            {
                new {PeopleId = 1,Name ="Man"},
                new {PeopleId = 2,Name = "Woman" }
            };

            var dicObject = people.ToDictionary(x => x.PeopleId);
            foreach (var data in dicObject)
            {
                Console.WriteLine(data);
            }

       

            var listNumbers = new List<int> { 13, 24, 3, 14, 05, 600, 73, 8,19 };
            var lists = new List<int> { 34, 54, 3432 };
            int temp = 0;
            lists.AddRange(new[] { 99, 33, 4 });
            for (int i =0; i<listNumbers.Count-1; i++)
            {
                for(int j=i+1; j<listNumbers.Count; j++)
                {
                    if (listNumbers[i] < listNumbers[j])
                    {
                        temp = listNumbers[i];
                        listNumbers[i] = listNumbers[j];
                        listNumbers[j]= temp;
                    }

                }
            }
            listNumbers.Remove(22);
            listNumbers.Add(100);
            listNumbers.Sort();

            var listCheck = new List<int>();
            var value = listCheck.SingleOrDefault();
            var withoutCheckOFDefault = listCheck.Single(); // it will throw exception

            listNumbers.RemoveAt(4);
            listNumbers.Reverse();
            listNumbers.Average();
            listNumbers.RemoveRange(2, 1);
            listNumbers.Clear();
            listNumbers.Concat(lists);
            bool flag = listNumbers.Contains(2);
            return Enumerable.Empty<Object>();

        }

        [HttpGet("CheckMethods")]
        public IEnumerable<int> checkMethods()
        {
            var listNumbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var filteredData = listNumbers.Where(x => x > 5).ToList();
            foreach (var item in filteredData)
            {
                Console.WriteLine(item);
            }

            var mixedList = new List<object> { 1, 2, "Priya", true, 9.88 };

            var items = mixedList.OfType<int>();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }


            var select = listNumbers.Select(x => x * 2);
            foreach (var item in select)
            {
                Console.WriteLine(item);
            }
            return listNumbers.ToList<int>();
        }


        [HttpGet("GetListTest")]
        public IEnumerable<Customer> getCustomer()
        {
            var customers = new List<Customer>
{
    new Customer
    {
        Name = "John",
        Order = new List<Order>
        {
            new Order { Product = "Laptop" },
            new Order { Product = "Mouse" }
        }
    },
    new Customer
    {
        Name = "Jane",
        Order = new List<Order>
        {
            new Order { Product = "Smartphone" },
            new Order { Product = "Tablet" }
        }
    }
};

            var selectRecords = customers.Select(x => x.Order);

            foreach(var record in selectRecords)
            {
                Console.WriteLine(record);
            }


            var selectManyRecords = customers.SelectMany(x => x.Order);

            foreach (var record in selectManyRecords)
            {
                Console.WriteLine(record);
            }

            return customers;
        }

    }
}
