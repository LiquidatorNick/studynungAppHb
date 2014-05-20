using Studynung.ProtectiveEarthing.Logic.Stages;

namespace Studynung.ProtectiveEarthing.Logic.Managers
{
    public class StageManager
    {
        private static StageManager _stageManager;

        public static StageManager Manager
        {
            get { return _stageManager ?? (_stageManager = new StageManager()); }
        }

        public StageManager()
        {
            StageOfAllowableResistance = new StageOfAllowableResistance();
            StageTypeOfEarthing = new StageTypeOfEarthing();
            //StageGroundDeviceType = new StageGroundDeviceType();
            //StageLocationElectrodes = new StageLocationElectrodes();
            //StageGeometricDimensionsAndMaterial = new StageGeometricDimensionsAndMaterial();
            //StageResistivitySoil = new StageResistivitySoil();
            //StageMethodsGroundingElectrode = new StageMethodsGroundingElectrode();
            //StageSelectionFormula = new StageSelectionFormula();
            //StageContinue = new StageContinue();
        }

        public StageOfAllowableResistance StageOfAllowableResistance { get; private set; }

        public StageTypeOfEarthing StageTypeOfEarthing { get; private set; }

        //public Stages.StageGroundDeviceType StageGroundDeviceType { get; private set; }

        //public StageLocationElectrodes StageLocationElectrodes { get; private set; }

        //public StageGeometricDimensionsAndMaterial StageGeometricDimensionsAndMaterial { get; private set; }

        //public StageResistivitySoil StageResistivitySoil { get; private set; }

        //public StageMethodsGroundingElectrode StageMethodsGroundingElectrode { get; private set; }

        //public StageSelectionFormula StageSelectionFormula { get; private set; }

        //public StageContinue StageContinue { get; private set; }

        public void Verification()
        {
            StageOfAllowableResistance.Verify();
            StageTypeOfEarthing.Verify();
            //StageGroundDeviceType.Verify();
            //StageLocationElectrodes.Verify();
            //StageGeometricDimensionsAndMaterial.Verify();
            //StageResistivitySoil.Verify();
            //StageMethodsGroundingElectrode.Verify();
            //StageSelectionFormula.Verify();
            //StageContinue.Verify();
        }
    }
}

