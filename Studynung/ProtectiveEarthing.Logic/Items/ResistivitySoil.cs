using System.Text;

namespace Studynung.ProtectiveEarthing.Logic.Items
{
    public class ResistivitySoil : BaseItem
    {
        public int RecomendedValue { get; set; }

        public int[] SoilIds { get; set; }

        public string StringSoilIds
        {
            get { return string.Join(";", SoilIds); }
        }
    }
}