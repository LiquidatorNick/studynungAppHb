using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Studynung.Database;
using Studynung.Filters;
using Studynung.Logic;
using Studynung.ProtectiveEarthing.Logic;
using Studynung.ProtectiveEarthing.Logic.Managers;

namespace Studynung.Controllers
{
    public class HomeController : DBController
    {
        public ActionResult Index()
        {
           
            return View();
        }


        public CheckResults VerificationData(DataIds data = null)
        {
            if (data != null)
            {
                Log logInstance = Log.GetInstance();
                CheckResults results = CheckResults.Current;
                results.IsGroupGrounding = data.CountGroundingId == 1; // true якщо групове заземлення   
                return results;
            }
            return null;
        }
    }

    public class DataIds
    {
        public DataIds()
        {
            CountGroundingId = -1;
            FirstPlacementElectrodesId = -1;
            GroundDeviceTypeId = -1;
            LocationElectodesId = -1;
            MaterialId = -1;
            ProfileSectionsId = -1;
            TypeSoilsId = -1;
            ResistivitySoilsId = -1;
            FirstTypeElectrodeId = -1;
            SecondTypeElectrodeId = -1;
            FirstGroundItemTypeId = -1;
            SecondGroundItemTypeId = -1;
            FirstFormulaId = -1;
            SecondFormulaId = -1;
        }

        public int CountGroundingId { get; set; }
        public int FirstPlacementElectrodesId { get; set; }
        public int GroundDeviceTypeId { get; set; }
        public int LocationElectodesId { get; set; }
        public int MaterialId { get; set; }
        public int ProfileSectionsId { get; set; }
        public int TypeSoilsId { get; set; }
        public int ResistivitySoilsId { get; set; }
        public int FirstTypeElectrodeId { get; set; }
        public int SecondTypeElectrodeId { get; set; }
        public int FirstLengthElectrodeId { get; set; }
        public int SecondLengthElectrodeId { get; set; }
        public int FirstGroundItemTypeId { get; set; }
        public int SecondGroundItemTypeId { get; set; }
        public int FirstFormulaId { get; set; }
        public int SecondFormulaId { get; set; }
    }

    public class DataValues
    {

    }

    public class CheckResults
    {
        private static CheckResults _checkResults;

        public static CheckResults Current
        {
            get { return _checkResults ?? (_checkResults = new CheckResults()); }
        }

        public bool IsGroupGrounding { get; set; }
    }
}
