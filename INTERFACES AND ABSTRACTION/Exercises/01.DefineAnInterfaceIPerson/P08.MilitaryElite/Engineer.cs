using System.Collections.Generic;
using System.Text;
using P08.MilitaryElite.Contracts;

namespace P08.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) 
            :base(id, firstName, lastName, salary, corps)
        {
            repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>) repairs;
        public void AddRepair(IRepair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine($"{nameof(Repairs)}:");
            foreach (var repair in Repairs)
            {
                builder.AppendLine($"  {repair.ToString()}");
            }

            return builder.ToString().TrimEnd();
        }
    }
}