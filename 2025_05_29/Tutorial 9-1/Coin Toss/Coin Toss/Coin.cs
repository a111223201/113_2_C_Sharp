using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Toss
{
    class Coin
    {
        private string sideUp; // The side of the coin that is facing up
        Random random = new Random();

        public Coin()
        {
            sideUp = "正面";// Initialize the coin to show heads
        }

        public void Toss()
        {
            
            // Generate a random number, 0 or 1
            int result = random.Next(0, 2);
            // If the result is 0, set sideUp to "正面", otherwise set it to "反面"
            if (result == 0)
            {
                sideUp = "正面";
            }
            else
            {
                sideUp = "反面";
            }
        }

        public string GetSideUp()
        {
            // Return the side of the coin that is facing up
            return sideUp;
        }
    }
}
