using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern
{
    class ObserverPattern : IDesignPatten
    {
        public void Main()
        {
            //Email Subscriber is registered
            EmailSubscriber email = new EmailSubscriber();
            Flipkart flipkart = Flipkart.GetInstance();
            flipkart.PlaceOrder(123); // We get only email and won't get sms for this order as SMS subscriber is not registered
            SMSSubscriber sms = new SMSSubscriber(); //SMS subscriber is registered without touching Flipkart class.
            flipkart.PlaceOrder(456); // We get both email and sms

        }
    }
    
    public interface IOrderSubscriber
    {
        void OrderPlaced(int orderID);
    }

    public class Flipkart
    {
        List<IOrderSubscriber> subList = new List<IOrderSubscriber>();
        public static Flipkart flipkart;
        private Flipkart()
        {

        }

        //Using singleton.
        //If NOT, when both Email & SMS Notification calls at the same time 2 objects of the flipkart will be created which will affect the subscribing part. 
        public static Flipkart GetInstance()
        {
            if(flipkart == null)
            {
                flipkart = new Flipkart();
            }
            return flipkart;
        }
        public void PlaceOrder(int orderID)
        {
            foreach(IOrderSubscriber subscriber in subList)
            {
                subscriber.OrderPlaced(orderID);
            }
        }

        //Email & SMS notification will call this method in constructor.
        //So that the particular subscriber will be saved in the list and will be called whenever the above PlaceOrder method is called
        public void Register(IOrderSubscriber subscriber)
        {
            subList.Add(subscriber);
        }
    }

    public class EmailSubscriber : IOrderSubscriber
    {
        public EmailSubscriber()
        {
            Flipkart flipkart = Flipkart.GetInstance();
            flipkart.Register(this);
        }
        public void OrderPlaced(int orderID)
        {
            Console.WriteLine("Email Sent for order "+ orderID);
        }
    }

    public class SMSSubscriber : IOrderSubscriber
    {
        public SMSSubscriber()
        {
            Flipkart flipkart = Flipkart.GetInstance();
            flipkart.Register(this);
        }
        public void OrderPlaced(int orderID)
        {
            Console.WriteLine("SMS sent for order " + orderID);
        }
    }

}
