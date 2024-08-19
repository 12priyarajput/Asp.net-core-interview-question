using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringFunctionsControllers : ControllerBase
    {
        [HttpGet("GetOccurrence")]
        public Dictionary<char, int> getOccurrenceOfChar(string Input)
        {
            Dictionary<char,int> result = new Dictionary<char,int>();
            int[] charCount = new int[256];

            for(int i=0; i<Input.Length; i++)
            {
                char c = Input[i];
                charCount[(int)c] ++; // checks using ASCII
            }

            for(int i=0; i<charCount.Length; i++)
            {
                if (charCount[i] > 0)
                {
                    result.Add((char)i, charCount[i]);
                }
            }
            fincDistinctDuplicate(new int[] { 3, 4, 5, 3, 4, 2, 2, 2, 23, 3, 3, 5, 5, 6, 7 }, 15);
            return result;
        }



        private Dictionary<char, int> test(string Input)
        {
            Dictionary<char,int> result = new Dictionary<char,int>();
            int[] charCount = new int[256];

            for(int i=0; i<Input.Length; i++)
            {
                char c = Input[i];
                charCount[(int)c]++;
            }

            for(int i=0; i<charCount.Length; i++)
            {
                if (charCount[i] > 0)
                {
                    result.Add((char)i, charCount[i]);
                }
            }
            return result;
        }


        private int[] fincDistinctDuplicate(int[] inputArray, int length)
        {
            ArrayList result = new ArrayList();

            for(int i=0; i<length-1; i++)
            {
                if (inputArray[i] == inputArray[i + 1])
                {
                    result.Add(inputArray[i]);
                }
            }

            return result.OfType<int>().ToArray();
        }
    }
}
