using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_project
{
   public class BankAccount
    {
        public  string FullName { get; set; }
        public void ShowBalance()
        {
            
            Console.WriteLine("Balance {0}",Balance) ;
        }
        public int AccountNumber { get; set; }
        public int CardNumber { get; set; }
        public int PinCode { get; set; }
        public decimal Balance { get; set; }

        public bool isLocked { get; set; }
    }
}
