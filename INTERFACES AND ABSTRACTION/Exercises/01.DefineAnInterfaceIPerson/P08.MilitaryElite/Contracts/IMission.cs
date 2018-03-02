namespace P08.MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }
        MissionState State { get; }
        void Complete();
    }
}