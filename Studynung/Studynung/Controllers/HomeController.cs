using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Studynung.ContentPicker;
using Studynung.Filters;
using Studynung.ProtectiveEarthing.Logic;
using Studynung.ProtectiveEarthing.Logic.Managers;

namespace Studynung.Controllers
{
    public class HomeController : DBController
    {
        //[AuthSystem]
        public ActionResult Index()
        {
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
