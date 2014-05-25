using System.Collections.Generic;
using Studynung.ProtectiveEarthing.Items;
using Studynung.ProtectiveEarthing.Logic.Items;

namespace Studynung.ProtectiveEarthing.Logic
{
    public partial class BaseData
    {
        private static BaseData _baseData;

        public static BaseData GetInstance()
        {
            return _baseData ?? (_baseData = new BaseData());
        }

        public BaseItem[] CountGrounding { get; set; }

        public BaseItemWithImage[] PlacementElectrodes { get; set; }

        public BaseItemWithImage[] GroundDeviceTypes { get; protected set; }

        public LocationItem[] LocationElectrodes { get; protected set; }

        public List<BaseItem> Materials { get; protected set; }

        public List<ProfileSection> ProfileSections { get; protected set; }

        public List<BaseItem> Soils { get; private set; }

        public ResistivitySoil[] ResistivitySoils { get; protected set; }

        public BaseItem[] TypeElectrode { get; protected set; }

        public BaseItem[] VerticalLengthElectrode { get; protected set; }

        public BaseItem[] HorizontalLengthElectrode { get; protected set; }

        public BaseItem[] Heaven { get; protected set; }
        public BaseItem[] Humidity { get; protected set; }

        public List<GroundItem> GroundItems { get; set; }
        public BaseItem[] RatioDistanceWithLength { get; set; }
    }
}
