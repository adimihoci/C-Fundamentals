using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blabla
{
    abstract class Animal : Interface1
    {
        private int age;

        public abstract void  Work();

        public int Age
        {
            get
            {
                return age;   
            }
            set
            {
                if (age < 10)
                {
                    age = value;
                }
                else
                {
                    age = 1;
                }
            }
        }

        public int age {get; set;}

        public void Eat()
        {
            System.Console.WriteLine("I eat what i want !");
        }
    }

    class Dog : Animal
    {
        public string Name { get; set; }

        public override void Speak()
        {
            System.Console.WriteLine("lala");
        }

        public abstract void Speak()
        {
            System.Console.WriteLine("bla bla bla");
        }
    }

    class FatDog : Dog
    {
        public override void Speak()
        {
            System.Console.WriteLine("I'm hungry !");
        }
    }
}
