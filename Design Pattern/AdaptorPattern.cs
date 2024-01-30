using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern
{
    public class AdaptorPattern : IDesignPatten
    {
        //client code
        public void Main()
        {
            //In client Amount will be always received as below
            int rupee = 13;
            int paise = 20;
            
            //Look at it at the end
            ITarget target = new GpayAdaptor();
            target.ProcessClientAmount(rupee, paise);

        }
    }

    //GPay (Adaptee) always proceess amount only in double. So, client cannot call gapy directly. 
    //So, we need to introduce a adaptor
    public class GPay
    {
        public void ProcessAmount(double amount)
        {
            Console.WriteLine(amount.ToString() + " Processed");
        }
    }

    interface ITarget
    {
        void ProcessClientAmount(int rupee, int paise);
    }

    public class GpayAdaptor : ITarget
    {
        GPay adaptee = new GPay();
        public void ProcessClientAmount(int rupee, int paise)
        {
            double amount = Convert.ToDouble(rupee.ToString() + "." + paise.ToString());
            adaptee.ProcessAmount(amount);
        }
    }

   


}
