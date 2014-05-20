using Studynung.ProtectiveEarthing.Logic.Items;

namespace Studynung.ProtectiveEarthing.Items
{
    public class ProfileSection : BaseItem
    {
        public int MaterialId { get; set; }

        public double Diameter { get; set; }
        public double Square { get; set; }
        public double Thickness { get; set; }

        public string StringDiameter
        {
            get { return (Diameter == -1) ? "-" : string.Format("{0} мм", Diameter); }
        }

        public string StringSquare
        {
            get { return (Square == -1) ? "-" : string.Format("{0} мм²", Square); }
        }

        public string StringThickness
        {
            get { return (Thickness == -1) ? "-" : string.Format("{0} мм", Thickness); }
        }
    }
}
