using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern
{
    //Add additional functionalities to the object without modifying its structure
    //Here we can add additional items (functionalities) to the cone in any order
    public class DecoratorPattern: IDesignPatten
    {
        public void Main()
        {
            IceCreamContent ic1 = new Toppings(new VanillaScoop(new ChocoCone()));
            Console.WriteLine(ic1.getDescription());
            Console.WriteLine(ic1.getCost());

            IceCreamContent ic2 = new VanillaScoop(new OrangeCone());
            Console.WriteLine(ic2.getDescription());
            Console.WriteLine(ic2.getCost());

            IceCreamContent ic3 = new Toppings(new SBScoop(new ChocoCone()));
            Console.WriteLine(ic3.getDescription());
            Console.WriteLine(ic3.getCost());
        }
    }


    public interface IceCreamContent
    {
        string getDescription();
        int getCost();
    }
    public class Toppings : IceCreamContent
    {
        private readonly string Desc;
        private readonly int Cost;
        public Toppings(IceCreamContent ic)
        {
            this.Desc = ic.getDescription();
            this.Cost = ic.getCost();
        }

        public int getCost()
        {
            return this.Cost + 5;
        }

        public string getDescription()
        {
            return this.Desc + " + Toppings";
        }
    }
    public class VanillaScoop : IceCreamContent
    {
        private readonly string Desc;
        private readonly int Cost;
        public VanillaScoop(IceCreamContent ic)
        {
            this.Desc = ic.getDescription();
            this.Cost = ic.getCost();
        }

        public int getCost()
        {
            return this.Cost + 15;
        }

        public string getDescription()
        {
            return this.Desc + " + Vanilla Scoop";
        }
    }

   

    public class SBScoop : IceCreamContent
    {
        private readonly string Desc;
        private readonly int Cost;
        public SBScoop(IceCreamContent ic)
        {
            this.Desc = ic.getDescription();
            this.Cost = ic.getCost();
        }

        public int getCost()
        {
            return this.Cost + 5;
        }

        public string getDescription()
        {
            return this.Desc + " + SB Scoop";
        }
    }

    public class ChocoCone : IceCreamContent
    {
        public int getCost()
        {
            return 20;
        }

        public string getDescription()
        {
            return "Choco Cone";
        }
    }

    public class OrangeCone : IceCreamContent
    {
        public int getCost()
        {
            return 10;
        }

        public string getDescription()
        {
            return "Orange Cone";
        }
    }

    public abstract class Item
    {
        public string Name { get; set; }
        public abstract void Display();
    }

    public class Book : Item
    {
        public Book(string name)
        {
            this.Name = name;
        }
        public override void Display()
        {
            Console.WriteLine("Name: " + this.Name);
        }
    }

    public class Decorator: Item
    {
        protected Item item;
        public Decorator(Item item)
        {
            this.item = item;
        }
        public override void Display()
        {
            item.Display();
        }
    }

    public class AddCover:  Decorator
    {
        public AddCover(Item item) : base(item)
        {

        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("cover added");
        }
    }

    public class AddBox : Decorator
    {
        public AddBox(Item item): base(item)
        {

        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("box added");
        }
    }
}
