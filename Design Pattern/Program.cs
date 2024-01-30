using System;

namespace Design_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IDesignPatten pattern;
            //pattern = new SingletonPattern();
            //pattern = new AdaptorPattern();
            //pattern = new PrototypePattern();
            //pattern = new BuilderPattern();
            //pattern = new DecoratorPattern();
            pattern = new ObserverPattern();
            pattern.Main();
            Console.ReadLine();
        }
    }
}
