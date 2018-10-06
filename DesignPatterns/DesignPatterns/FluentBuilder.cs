using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_F
{
    public class Person
    {
        public string Name;
        public string Position;

        public class Builder:PersonJobBuilder<Builder>
        {
           
        }
        public static Builder New =>new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersionBuilder
    {
      
        protected Person person = new Person();
        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<SELF>:PersionBuilder where SELF: PersonInfoBuilder<SELF>
    {      
        public SELF Called(string name)
        {          
            person.Name = name;
            return (SELF) this;
        }
    }
   // PersonJobBuilder<Builder>: PersonInfoBuilder<PersonJobBuilder<Builder>>
    public class PersonJobBuilder<SELF>: PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF:PersonJobBuilder<SELF>
    {
        public SELF  WorkAsA(string position)
        {
            person.Position = position;
            return (SELF) this;
        }
    }

   /* public class Program
    {
        static void Main(string[] args)
        {
           var Me= Person.New.called("dmitri").workAsA("quant").Build();
            Console.WriteLine(Me);
        }
    }*/

}
