using System.Web.Mvc;

namespace Studynung.Areas.LabourProtection
{
    public class LabourProtectionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "LabourProtection";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "LabourProtection_default",
                "LabourProtection/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional }
            );
        }
    }
}
