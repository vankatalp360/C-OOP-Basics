using System.Text;
using P08.MilitaryElite.Contracts;

namespace P08.MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) 
            :base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine($"Code Number: {CodeNumber}");

            return builder.ToString().TrimEnd();
        }
    }
}