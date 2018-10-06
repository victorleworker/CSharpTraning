using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Person
    {
        public string StreetAddress, Postcode, City;
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}" +
                $", {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}," +
                $" {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class PersonBuilder
    {
        protected Person person = new Person();
        public PersonJobBuilder works => new PersonJobBuilder(person);
        public PersonAddressBuilder lives => new PersonAddressBuilder(person);
        //https://www.codeproject.com/Articles/15191/Understanding-Implicit-Operator-Overloading-in-C
        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
        public Person returnperson()
        {
            return person;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        // might not work with a value type!
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }

    }
    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }
        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }
    /*
    class Demo
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var pb = new PersonBuilder();
                var person = pb
                    .lives.At("123 london road")
                         .In("London")
                         .WithPostcode("sw123c")
                    .works.At("Fabrikam")
                         .AsA("Engineer")
                         .Earning(123333);
                Console.WriteLine(person.ToString());
            }
        }
    }*/
}
