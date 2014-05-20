using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studynung.ProtectiveEarthing.Logic.Interfaces;

namespace Studynung.ProtectiveEarthing.Logic.Stages
{
    public class StageTypeOfEarthing : IStage
    {
        public int CountGroundingId { get; set; }

        public bool IsGroupGrounding { get; set; }

        public void Verify()
        {
            IsGroupGrounding = (CountGroundingId == 1); // якщо групове заземлення            
        }
    }
}
