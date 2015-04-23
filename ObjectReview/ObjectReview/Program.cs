using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectReview
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Fido", "Terrier");

            Console.WriteLine(dog);

            
            Dog dog2 = new Dog();
            dog2.Name = "Biscuits";

            Console.WriteLine(dog2);

            Console.ReadKey();


        }
    }

    class Dog
    {
        //step 1: define properties
        private string _breed; //variable to hold the breed
        public string Breed
        {
            get { return _breed; }
            set { _breed = value; }
        }

        //shorthand, it does exactly like it does above
        public string Name { get; set; }

        public List<string> SomeList { get; set; }

        //lazy loading a list
        private List<string> _lazyList;
        public List<string> LazyList
        {
            get 
            {
                //lazy loading
                if (_lazyList == null)
                {
                    //initialize the list
                    _lazyList = new List<string>();
                }
                return _lazyList;
            }
            set { _lazyList = value; }
        }

        public Dog()
        {
            this.SomeList = new List<string>();
        }

        public Dog(string name, string breed)
        {
            this.Name = name;
            this.Breed = breed;
            this.SomeList = new List<string>(); //really important to initialize lists and other objects that are not primitive data types

            this.LazyList.Add("some value");
        }

        public override string ToString()
        {
            return string.Format("Woof!  My name is {0} and I am a {1}.  Rufffff!", this.Name, this.Breed);
        }

    }
}
