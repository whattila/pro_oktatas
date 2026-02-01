using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_oktatas.async
{
    public class AsyncFunctions
    {
        public static async Task<int> GetUsersCountAsync()
        {
            await Task.Delay(800);
            return 3;
        }

        public static async Task<int> GetOrdersCountAsync()
        {
            await Task.Delay(800);
            return 9;
        }

        public static async Task<int> GetProductsCountAsync()
        {
            await Task.Delay(400);
            return 6;
        }
    }
}
