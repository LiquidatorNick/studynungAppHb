using System.Web.Mvc;

namespace Studynung.Areas.LaboratoryWork
{
    public class LaboratoryWorkAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "LaboratoryWork";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "LaboratoryWork_default",
                "LaboratoryWork/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
