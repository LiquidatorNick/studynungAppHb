using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using Studynung.Controllers;
using Studynung.Filters;
using Studynung.Helpers;
using Studynung.Managers;
using Studynung.ProtectiveEarthing.Logic;

namespace Studynung.Areas.LaboratoryWork.Controllers
{
    public class ProtectiveEarthingController : DBController
    {
        private LaboratoryManager _laboratoryManager;
        public ProtectiveEarthingController()
        {
            _laboratoryManager = new LaboratoryManager();
        }

        [AuthSystem]
        public ActionResult Index()
        {
            ViewBag.ProcessId = _laboratoryManager.GetInProgressProcess(SessionHelper.User.Id, 1);
            return View();
        }

        [AuthSystem]
        public ActionResult Calculation()
        {
            int labResultId = _laboratoryManager.Start(SessionHelper.User.Id, 1);
            ViewBag.LaboratoryResultId = labResultId;
            ViewBag.CountGrounding = BaseData.GetInstance().CountGrounding;
            ViewBag.PlacementElectrodes = BaseData.GetInstance().PlacementElectrodes;
            ViewBag.GroundDeviceTypes = BaseData.GetInstance().GroundDeviceTypes.ToArray();
            ViewBag.LocationElectrodes = BaseData.GetInstance().LocationElectrodes.ToArray();
            ViewBag.Materials = BaseData.GetInstance().Materials.ToArray();
            ViewBag.ProfileSections = BaseData.GetInstance().ProfileSections;
            ViewBag.TypeSoils = BaseData.GetInstance().Soils.ToArray();
            ViewBag.ResistivitySoils = BaseData.GetInstance().ResistivitySoils;
            ViewBag.TypeElectrode = BaseData.GetInstance().TypeElectrode;
            ViewBag.VerticalLengthElectrode = BaseData.GetInstance().VerticalLengthElectrode;
            ViewBag.HorizontalLengthElectrode = BaseData.GetInstance().HorizontalLengthElectrode;
            ViewBag.Heaven = BaseData.GetInstance().Heaven;
            ViewBag.Humidity = BaseData.GetInstance().Humidity;
            ViewBag.GroundItems = BaseData.GetInstance().GroundItems.ToArray();
            ViewBag.RatioDistanceWithLength = BaseData.GetInstance().RatioDistanceWithLength;
            return View();
        }

        public bool SaveChanges(ProtectiveEarthingResults data = null)
        {
            _laboratoryManager.SaveChangesForUser(data);
            return true;
        }


    }

    public class ProtectiveEarthingResults
    {
        public ProtectiveEarthingResults()
        {
            CountGroundingId = -1;
            //FirstPlacementElectrodesId = string.Empty;
            //GroundDeviceTypeId = string.Empty;
            //LocationElectrodesId = string.Empty;
            //MaterialId = string.Empty;
            //ProfileSectionsId = string.Empty;
            //TypeSoilsId = string.Empty;
            //ResistivitySoilsId = string.Empty;
            //FirstTypeElectrodeId = string.Empty;
            //SecondTypeElectrodeId = string.Empty;
            //FirstLengthElectrodeId = string.Empty;
            //SecondLengthElectrodeId = string.Empty;
            //HeavenId = string.Empty;
            //HumidityId = string.Empty;
            //FirstGroundItemTypeId = string.Empty;
            //SecondGroundItemTypeId = string.Empty;
            //FirstFormulaId = string.Empty;
            //SecondFormulaId = string.Empty;
            //RatioDistanceWithLength = string.Empty;

            //Results = string.Empty;
            //Errors = string.Empty;

            //Rdop = double.NaN;
            //Lvert = double.NaN;
            //Lhoriz = double.NaN;
            //KcVertical = double.NaN;
            //KcHoriz = double.NaN;
            //Rovym = double.NaN;
            //a = double.NaN;
            //b = double.NaN;
            //t = double.NaN;
            //t0 = double.NaN;
            //d = double.NaN;
            //D = double.NaN;
            //RorVert = double.NaN;
            //RorHoriz = double.NaN;
            //Rvert = double.NaN;
            //Rhoriz = double.NaN;
            //Rz = double.NaN;
            //countElectrodes = double.NaN;
            //countElectrodesWithoutNude = double.NaN;
            //countElectrodesWithNude = double.NaN;
            //nudeVert = double.NaN;
            //nudeHoriz = double.NaN;
            //ratioDistanceWithLength = double.NaN;
        }

        public int Id { get; set; }

        #region Ids
        public int CountGroundingId { get; set; }
        public int FirstPlacementElectrodesId { get; set; }
        public int GroundDeviceTypeId { get; set; }
        public int LocationElectrodesId { get; set; }
        public int MaterialId { get; set; }
        public int ProfileSectionsId { get; set; }
        public int TypeSoilsId { get; set; }
        public int ResistivitySoilsId { get; set; }
        public int FirstTypeElectrodeId { get; set; }
        public int SecondTypeElectrodeId { get; set; }
        public int FirstLengthElectrodeId { get; set; }
        public int SecondLengthElectrodeId { get; set; }
        public int HeavenId { get; set; }
        public int HumidityId { get; set; }
        public int FirstGroundItemTypeId { get; set; }
        public int SecondGroundItemTypeId { get; set; }
        public int FirstFormulaId { get; set; }
        public int SecondFormulaId { get; set; }
        public int RatioDistanceWithLength { get; set; }
        #endregion

        #region Results & Errors

        public string Results { get; set; }
        public string Errors { get; set; }

        #endregion

        #region Fields
        public string ValueRdop { get; set; }
        public string ValueLvert { get; set; }
        public string ValueLhoriz { get; set; }
        public string ValueKcVertical { get; set; }
        public string ValueKcHoriz { get; set; }
        public string ValueRovym { get; set; }
        public string Valuea { get; set; }
        public string Valueb { get; set; }
        public string Valuet { get; set; }
        public string Valuet0 { get; set; }
        public string Valued { get; set; }
        public string ValueDUpper { get; set; }
        public string ValueRorVert { get; set; }
        public string ValueRorHoriz { get; set; }
        public string ValueRvert { get; set; }
        public string ValueRhoriz { get; set; }
        public string ValueRz { get; set; }
        public string ValuecountElectrodes { get; set; }
        public string ValuecountElectrodesWithoutNude { get; set; }
        public string ValuecountElectrodesWithNude { get; set; }
        public string ValuenudeVert { get; set; }
        public string ValuenudeHoriz { get; set; }
        public string ValueratioDistanceWithLength { get; set; }
        #endregion
    }

    public class XmlParser
    {
        public static string Serialize<T>(T value)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, value);
                return textWriter.ToString();
            }
        }

        public static T Deserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var textReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(textReader))
                {
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }
    }
}
