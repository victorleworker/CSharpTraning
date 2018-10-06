using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class CodeElement
    {
        public string Name, Text;
        public List<CodeElement> elements = new List<CodeElement>();
        private const int indentSize = 2;

        public CodeElement()
        {
        }

        public CodeElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"public class {Name}");
            sb.AppendLine("{");           

            foreach (var e in elements)
            {
                sb.AppendLine($"{i}public {e.Name} {e.Text} ;");
            }
            sb.AppendLine("}");         
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(2);
        }
    }

    class CodeBuilder
    {
        string ClassName;
        CodeElement rootClass = new CodeElement();

        public CodeBuilder(string className)
        {
            ClassName = className ?? throw new ArgumentNullException(nameof(className));
            rootClass.Name = className;
        }
        public CodeBuilder AddField(string strName,string strType)
        {
            rootClass.elements.Add(new CodeElement(strName, strType));
            return this;
        }

        public override string ToString()
        {
            return rootClass.ToString();
        }
    }

    /*
    public class demo
    {

        static void Main(string[] args)
        {
            var builder = new CodeBuilder("Person");
            builder.AddField("Name", "String").AddField("Age", "int");
            Console.WriteLine(builder);

        }
    }*/
}
