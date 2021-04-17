using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_project
{
   public class Agent:Client
    {
        public string Id { get; private set; }
        protected string Title { get; set; }
        protected string Description { get; set; }
        protected TimeSpan jobLength { get; set; }
        public override void showName()
        {
           
                Console.WriteLine("Your ID is {0}", Id);
            
        }
    
       

    }
}
