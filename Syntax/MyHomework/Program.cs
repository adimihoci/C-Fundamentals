using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomework
{

    class Person
    {
        protected string lastname;
        protected string firstname;
        protected int dateOfBirth;
    }

    class Employee : Person
    {
        int dateOfEmployment;
        int salary;
        int availableDaysOff;

        List<Leave> lista_concedii = new List<Leave>();

        public Employee(string lastname, string firstname, int dateOfBirth, int dateOfEmployment, int salary, int availableDaysOff)
        {
            this.lastname = lastname;
            this.firstname = firstname;
            this.dateOfBirth = dateOfBirth;
            this.dateOfEmployment = dateOfEmployment;
            this.salary = salary;
            this.availableDaysOff = availableDaysOff;
        }

        public void DisplayInfo()
        {
            System.Console.WriteLine("Nume :                          {0}", this.firstname);
            System.Console.WriteLine("Prenume :                       {0}", this.lastname);
            System.Console.WriteLine("Salariu :                       {0}", this.salary);
            System.Console.WriteLine("Numar zile libere disponibile : {0}", this.availableDaysOff);
            System.Console.WriteLine();
        }

        private void SubstractDays(int xDays)
        {
            this.availableDaysOff = this.availableDaysOff - xDays;
        }

        public void AddNewLeave(Leave leave1)
        {
            if (leave1.duration > this.availableDaysOff)
            {
                throw new MyCustomException("Numarul de zile libere ramase nu poate fi mai mare decat durata concediului !");
            }

            SubstractDays(leave1.duration);
            lista_concedii.Add(leave1);
            leave1.employee = this;
        }

        public void DisplayLeave()
        {
            int i = 1;

            foreach (Leave leave2 in lista_concedii)
            {
                if (leave2.startingDate % 10000 == 2015)
                {
                    System.Console.WriteLine(i);
                    System.Console.WriteLine("Starting Date : {0}", leave2.startingDate);
                    System.Console.WriteLine("Duration      : {0}", leave2.duration);
                    System.Console.WriteLine("Leave Type    : {0}", leave2.leaveType);
                    System.Console.WriteLine();
                    i++;
                }
            }
        }
    }

    class Leave
    {
        protected internal int startingDate;
        protected internal int duration;
        protected internal Employee employee;
        protected internal string leaveType;

        public Leave(int startingDate, int duration, string leaveType)
        {
            this.startingDate = startingDate;
            this.duration = duration;
            this.leaveType = leaveType;
        }

    }

    class MyCustomException : Exception
    {
        public MyCustomException(string name)
            : base(name)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee person1 = new Employee("Adi", "Mihoci", 04021994,22042015,1200,15);
            
            Leave leave1 = new Leave(04022015, 5, "medical");
            person1.AddNewLeave(leave1);
            
            Leave leave2 = new Leave(04022014, 2, "medical");
            person1.AddNewLeave(leave2);
            
            Leave leave3 = new Leave(04022015, 1, "medical");
            person1.AddNewLeave(leave3);
            
            person1.DisplayLeave();
        }
    }
}