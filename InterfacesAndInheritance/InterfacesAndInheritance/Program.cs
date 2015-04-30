using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            // list of things that fly
            //List<IFlyable> thingsThatFly = new List<IFlyable>();
            //thingsThatFly.Add(new Plane());
            //thingsThatFly.Add(new Bird());
            //thingsThatFly.Add(new Plane());

            //foreach (IFlyable flyer in thingsThatFly)
            //{
            //    //flyer.Fly();
            //}


            //List<ICombustionEngine> thingsWithAnEngine = new List<ICombustionEngine>();
            //thingsWithAnEngine.Add(new Car());
            //thingsWithAnEngine.Add(new Generator());
            ////add some fuel to the first item
            //thingsWithAnEngine[0].Refuel(100); //add some gas to the car

            //foreach (var enginyThing in thingsWithAnEngine)
            //{
            //    enginyThing.Go();
            //}

            //Inhertiance Usage
            Employee employee1 = new Employee("John", "McClary", "Professional Liar");
            employee1.Talk();

            Musician musician1 = new Musician("cat", "stevens", "guitar, aka the axe");
            musician1.Talk();
            musician1.Jam();

            List<Person> listOfPeople = new List<Person>();
            listOfPeople.Add(employee1);
            listOfPeople.Add(musician1);
            foreach (var x in listOfPeople)
            {
                
            }
         
        }
    }

    #region " Interface Stuff "
    //interfaces are declared on the same level as classes (still inside the namespace)
    interface IFlyable
    {
        //specify its properties and methods
        void Fly();
        string PropulsionMethod { get; set; }
    }

    //consume our IFlyable Interface
    public class Bird : IFlyable
    {
        public string PropulsionMethod { get; set; }
        public Bird()
        {
            this.PropulsionMethod = "Wings";
        }

        public void Fly()
        {
            Console.WriteLine("flap flap flap, red bull gives you {0}", this.PropulsionMethod);
        }
    }

    public class Plane : IFlyable
    {
        public string PropulsionMethod { get; set; }
        public Plane()
        {
            this.PropulsionMethod = "Single Prop Turbo";
        }
        public void Fly()
        {
            Console.WriteLine("VRROOOOOOOM! I soar through the air with a {0}", this.PropulsionMethod);
        }
    }

    interface ICombustionEngine
    {
        int FuelLevel { get; set; }
        void Refuel(int fuelAdded);
        void Go();
    }

    interface IVehicle
    {
        int Velocity { get; set; }
    }

    interface IGenerator
    {
        int KilowattsGenerated { get; set; }
    }

    public class Car : IVehicle, ICombustionEngine
    {
        public int Velocity { get; set; }
        public int FuelLevel { get; set; }

        public Car()
        {
            this.Velocity = 0;
            this.FuelLevel = 0;
        }

        public void Refuel(int fuelAdded)
        {
            this.FuelLevel += fuelAdded;
        }

        public void Go()
        {
            //make sure the car has gas before you put the pedal to the metal
            if (this.FuelLevel >= 10)
            {
                this.FuelLevel -= 10;
                this.Velocity += 10;
                Console.WriteLine("vroom, i'm going {0}", this.Velocity);
            }            
        }
    }

    public class Generator : ICombustionEngine, IGenerator
    {
        public int KilowattsGenerated { get; set; }
        public int FuelLevel { get; set; }

        public Generator()
        {
            this.KilowattsGenerated = 0;
            this.FuelLevel = 0;
        }


        public void Refuel(int fuelAdded)
        {
            this.FuelLevel += fuelAdded;
            Console.WriteLine("hmmm, so thirsty.  Fuel: {0}", this.FuelLevel);
        }

        public void Go()
        {
            if (this.FuelLevel >= 10) 
            {
                this.KilowattsGenerated += 10;
                this.FuelLevel -= 10;
                Console.WriteLine("mwahahaha more power.  KW generated: {0}", this.KilowattsGenerated);
            }
            else
            {
                Console.Beep();
                Console.WriteLine("Not enough gas");
            }
        }
    }


    //public class GasStation 
    //{
    //    int FuelLevel { get; set; }

    //    public GasStation()
    //    {
    //        this.FuelLevel = 100;
    //    }

    //    public void FillErUp(ICombustionEngine engine)
    //    {
    //        engine.Refuel(50);
    //    }

    //    public void FillErUp(Car car)
    //    {
    //        car.Refuel(50);
    //    }

    //    public void FillErUp(Generator gen)
    //    {
    //        gen.Refuel(50);
    //    }
    //}



    #endregion

    #region " Inheritance Stuff "

    //Abstract: cannot be instantiated (cannot do: Person p = new Person();)
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName; this.LastName = lastName;
        }

        public void Walk()
        {
            Console.WriteLine("**whistling sounds**");
        }

        //virtual modifier: allows us to override the behavior in a child class.  this is only needed on a class marked as abstract
        public virtual void Talk()
        {
            Console.WriteLine("Hey maaaaan, what's up? My name is {0} {1}", this.FirstName, this.LastName);
        }
    }

    public class Employee : Person
    {
        public string JobTitle { get; set; }

        public Employee(string firstName, string lastName, string jobTitle) : base(firstName, lastName)
        {
            //the constructor for the base class will be executed first!
            this.JobTitle = jobTitle;
        }

        //override the base class Talk(), because an employee wants to talk about their job.
        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("My job is {0}, and I LOOOOOVE it!", this.JobTitle);
        }
    }

    public class Musician : Employee
    {
        public string Instrument { get; set; }

        public Musician(string firstName, string lastName, string instrument)
            : base(firstName, lastName, "Musician")
        {
            this.Instrument = instrument;
        }

        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("I like to wail on my {0}.  Who wants to hear Freebird?", this.Instrument);
        }

        public void Jam()
        {
            Console.WriteLine("aww man, can you feel it?");
            Console.Beep(); Console.Beep(); Console.Beep(); Console.Beep(); Console.Beep();
            
        }
    }


    #endregion

}
