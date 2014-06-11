using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Studynung.Areas.LaboratoryWork.Controllers;
using Studynung.Database;
using Studynung.Helpers;
using Studynung.Logic;

namespace Studynung.Managers
{
    public class LaboratoryManager : BaseManager
    {
        public int Start(int userId, int laboratoryId)
        {
            FinishedOldProcess(userId, laboratoryId);
            var laboratoryProcess = new LaboratoryProcess()
            {
                Status = LaboratoryStatus.InProgress,
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now,
                UserId = userId,
                LaboratoryWorkId = laboratoryId
            };
            DB.Entry(laboratoryProcess).State = EntityState.Added;
            DB.SaveChanges();
            var laboratoryResult = new LaboratoryResult()
            {
                LaboratoryProcess = laboratoryProcess
            };
            DB.Entry(laboratoryResult).State = EntityState.Added;
            DB.SaveChanges();
            return laboratoryResult.Id;
        }

        private void FinishedOldProcess(int userId, int laboratoryId)
        {
            if (DB.LaboratoryProcesses.Any(
                p =>
                    p.UserId == userId && p.LaboratoryWorkId == laboratoryId &&
                    p.Status == LaboratoryStatus.InProgress))
            {
                IQueryable<LaboratoryProcess> items = DB.LaboratoryProcesses.Where(
                    p =>
                        p.UserId == userId && p.LaboratoryWorkId == laboratoryId &&
                        p.Status == LaboratoryStatus.InProgress);
                foreach (var laboratoryProcess in items)
                {
                    laboratoryProcess.Status = LaboratoryStatus.Finished;
                    DB.Entry(laboratoryProcess).State = EntityState.Modified;
                }
                DB.SaveChanges();
            }
        }

        public void SaveChangesForUser(ProtectiveEarthingResults data)
        {
            string xml = XmlParser.Serialize(data);
            LaboratoryResult resultItem = DB.LaboratoryResults.FirstOrDefault(lr => lr.Id == data.Id);
            if (resultItem != null)
            {
                resultItem.Results = xml;
                DB.Entry(resultItem).State = EntityState.Modified;
                DB.SaveChanges();
            }
        }

        public ProtectiveEarthingResults LoadProtectiveEarthingResults(int processId)
        {
            var result = DB.LaboratoryResults.FirstOrDefault(lr => lr.LaboratoryProcess.Id == processId);
            if (result != null)
            {
                var data = XmlParser.Deserialize<ProtectiveEarthingResults>(result.Results);
                return data;
            }
            return null;
        }

        public int GetInProgressProcess(int userId, int laboratoryId)
        {
            var item = DB.LaboratoryProcesses.FirstOrDefault(lp => 
                lp.UserId == userId && 
                lp.LaboratoryWorkId == laboratoryId && 
                lp.Status == LaboratoryStatus.InProgress);
            if (item == null)
                return -1;
            return item.Id;
        }
    }
}