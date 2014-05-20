using Studynung.ProtectiveEarthing.Logic.Interfaces;

namespace Studynung.ProtectiveEarthing.Logic.Stages
{
    public class StageOfAllowableResistance : IStage
    {
        public StageOfAllowableResistance()
        {
            Rdop = double.NaN;
            IsAllowableResistance = false;
        }

        public bool IsAllowableResistance { get; set; }

        public double Rdop { get; set; }

        public void Verify()
        {

        }
    }
}