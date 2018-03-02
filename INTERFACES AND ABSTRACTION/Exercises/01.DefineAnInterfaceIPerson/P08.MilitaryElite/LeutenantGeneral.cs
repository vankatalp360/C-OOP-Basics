using System.Collections.Generic;
using System.Text;
using P08.MilitaryElite.Contracts;

namespace P08.MilitaryElite
{
    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        private ICollection<ISoldier> privates;

        public LeutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>)privates;
        public void AddPivate(ISoldier soldier)
        {
            privates.Add(soldier);
        }

        public override string ToString()
        {
            var bulder = new StringBuilder();
            bulder.AppendLine(base.ToString());
            bulder.AppendLine($"{nameof(Privates)}:");
            foreach (var soldier in Privates)
            {
                bulder.AppendLine($"  {soldier.ToString()}");
            }

            return bulder.ToString().TrimEnd();
        }
    }
}