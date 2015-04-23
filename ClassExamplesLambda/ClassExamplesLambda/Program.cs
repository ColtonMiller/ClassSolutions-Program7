using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExamplesLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> blah = new List<string>() { "one", "two", "three", "three", "three" };

            Car myCar = new Car(); //instantiate object
            Console.WriteLine(myCar.Color); //get

            // Use the overloaded constructor
            Car myCustomCar = new Car("Ford", "Black", 250, 33834, true);
            Console.WriteLine(myCustomCar.Model);

            //c
            Car customModel = new Car("Honda");
            Console.WriteLine(customModel.Model);
            Console.WriteLine(customModel.TopSpeed);

            List<Car> carList = new List<Car>() { myCar, myCustomCar, customModel };

            // iterate over class properties
            Console.WriteLine("car list model properties:");
            foreach (string modelName in carList.Where(y => y.Color == "red").Select(x => x.Model))
            {
                Console.WriteLine(modelName);
            }

            Console.WriteLine(blah.Count(x => x.Length > 3));

            Console.ReadKey();
        }
    }

    public class Dealership
    {
        public List<Car> CarsOnLot { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Person> Staff { get; set; } 
    }
    public class Person
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
    }
    
    public class Car
    {
        public bool IsNew { get; set; }
        private readonly int ftInMile = 5280;
        private int odometer = 183892;
        private string _color;
        public string Color
        {
            get { return "hot " + _color; }
            set
            {
                if (value == "Red")
                { _color = value; }
            }
        }

        public string Model { get; private set; }
        public int TopSpeed { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Car()
        {
            this.Model = "Tesla";
            this.Color = "Red";
            this.TopSpeed = 300;
            this.odometer = 0;
            this.IsNew = true;
        }

        public Car(string model)
            : this()
        {
            this.Model = model;
        }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="model">Car Model Name</param>
        /// <param name="color">Car Color</param>
        /// <param name="topSpeed">Top Speed in MPH</param>
        /// <param name="odo">Mileage reading</param>
        public Car(string model, string color, int topSpeed, int odo, bool isNew)
        {
            this.Model = model;
            this.Color = color;
            this.TopSpeed = topSpeed;
            this.odometer = odo;
            this.IsNew = isNew;
        }

        public int getOdometer(string password)
        {
            Model = "honda";
            if (password == "pass")
            {
                return odometer;
            }
            return 0;
        }
    }
}
