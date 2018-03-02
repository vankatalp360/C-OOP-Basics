using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using P08.MilitaryElite.Contracts;

namespace P08.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
            :base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)missions;
        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }

        public void CompleteMission(string missionCodeName)
        {
            IMission mission = Missions.FirstOrDefault(m => m.CodeName == missionCodeName);

            if (mission == null)
            {
                throw new ArgumentException("Mission not found");
            }
            mission.Complete();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine($"{nameof(Missions)}:");
            foreach (var mission in Missions)
            {
                builder.AppendLine($"  {mission.ToString()}");
            }

            return builder.ToString().TrimEnd();
        }
    }
}