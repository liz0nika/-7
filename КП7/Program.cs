using System;

namespace KP7
{
    interface IShowPosition
    {
        void showInfo();
    }

    abstract class myObject
    {
        public string Info { get; private set; }

        public myObject(string info)
        {
            Info = info;
        }

        public virtual void pop_message()
        {
            Console.WriteLine("Pop_up message: " + Info);
        }

        public virtual void console_message()
        {
            Console.WriteLine("Message: " + Info);
        }
    }

    abstract class Employee : myObject, IShowPosition, IComparable<Employee> // службовець
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public float Salary { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public double increase = 1.25;

        public Employee(string info) : base(info)
        {
        }

        public void showInfo()
        {
            Console.WriteLine("Name: {0}. Surname: {1}. Age: {2}. Position: {3}", Name, Surname, Age, Position);
        }

        public int CompareTo(Employee other)
        {
            if (other == null) return 1;
            return Salary.CompareTo(other.Salary);
        }

        public double calculateTotalSalary()
        {
            return Salary * increase;
        }

        public int GetSetAge
        {
            get { return Age; }
            set
            {
                if (value < 16 || value > 80)
                {
                    throw new ArgumentOutOfRangeException("Your age must be between 16 and 80.");
                }

                Age = value;
            }
        }

        public float GetSetSalary
        {
            get { return Salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Your salary cannot be negative.");
                }

                Salary = value;
            }
        }

        public virtual void Print()
        {
            if (!string.IsNullOrEmpty(Surname))
            {
                Console.WriteLine($"\nSurname: {Surname}");
            }
            else
            {
                throw new NullReferenceException("Surname cannot be null.");
            }

            if (!string.IsNullOrEmpty(Name))
            {
                Console.WriteLine($"\nName: {Name}");
            }
            else
            {
                throw new NullReferenceException("Name cannot be null.");
            }

            if (!string.IsNullOrEmpty(SecondName))
            {
                Console.WriteLine($"\nSecond Name: {SecondName}");
            }
            else
            {
                Console.WriteLine("\nSecond Name: -");
            }

            Console.WriteLine($"\nAge: {Age}");
            Console.WriteLine($"\nSalary: {Salary}");
            Console.WriteLine($"\nPosition: {Position ?? "not mentioned"}");
        }

        public override void pop_message()
        {
            base.pop_message();
            Console.WriteLine($"Pop_message - Employee info: {Info}");
        }

        public override void console_message()
        {
            base.console_message();
            Console.WriteLine($"Employee info: {Info}");
        }
    }

    class Person : Employee
    {
        public string IdentityNumber { get; set; }

        public Person(string info) : base(info)
        {
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Identity Number: {IdentityNumber ?? "not mentioned"}");
        }
    }

    class Worker : Employee
    {
        public string Shift { get; set; }
        public int ExperienceYears { get; set; }

        public Worker(string info) : base(info)
        {
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Shift: {Shift ?? "not mentioned"}, Experience: {ExperienceYears} years");
        }
    }

    class Engineer : Employee
    {
        public string Specialization { get; set; }
        public int ProjectsCompleted { get; set; }

        public Engineer(string info) : base(info)
        {
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Specialization: {Specialization ?? "not mentioned"}, Projects Completed: {ProjectsCompleted}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Engineer engineer = new Engineer("This is an engineer's info")
            {
                Name = "John",
                Surname = "Doe",
                Age = 30,
                Salary = 3000,
                Position = "Senior Engineer",
                Specialization = "Software",
                ProjectsCompleted = 10
            };

            engineer.showInfo();
            engineer.Print();
            engineer.pop_message();
            engineer.console_message();

            Worker worker = new Worker("This is a worker's info")
            {
                Name = "Jane",
                Surname = "Smith",
                Age = 25,
                Salary = 2000,
                Position = "Worker",
                Shift = "Day",
                ExperienceYears = 5
            };

            worker.showInfo();
            worker.Print();
            worker.pop_message();
            worker.console_message();
        }
    }
}
