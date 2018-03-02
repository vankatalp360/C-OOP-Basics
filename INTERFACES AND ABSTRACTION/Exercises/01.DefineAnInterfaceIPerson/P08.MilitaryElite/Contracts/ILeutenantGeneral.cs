using System.Collections.Generic;

namespace P08.MilitaryElite.Contracts
{
    public interface ILeutenantGeneral : IPrivate   
    {
        IReadOnlyCollection<ISoldier> Privates { get; }
        void AddPivate(ISoldier soldier);
    }
}