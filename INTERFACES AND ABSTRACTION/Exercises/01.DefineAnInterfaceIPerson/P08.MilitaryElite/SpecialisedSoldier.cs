using System;
using System.Text;
using P08.MilitaryElite.Contracts;

namespace P08.MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) 
            :base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        private void ParseCorps(string corps)
        {
            bool validCorps = Enum.TryParse(typeof(Corps), corps, out object outCorps);

            if (!validCorps)
            {
                throw new ArgumentException("Invalid corps!");
            }
            this.Corps = (P08.MilitaryElite.Contracts.Corps)outCorps;
        }

        public Corps Corps { get; private set; }


        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine($"Corps: {Corps}");

            return builder.ToString().TrimEnd();
        }
    }
}