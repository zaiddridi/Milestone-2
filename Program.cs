using System;
using Logic_project;
namespace Console_project
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MybankATM atm = new MybankATM();
                atm.Execute();
            }
           
               
                catch (NotImplementedException e)
                {
                Console.WriteLine("My Utility calss is still under construction stay tuned :)");
            }
            }
        }
    }

