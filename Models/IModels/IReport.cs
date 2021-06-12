using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models.IModels
{
    public interface IReport
    {
        Task<List<Report>> GetReports();
        Task<Report> GetReportById(Guid reportId);
        Task<Report> PostReport(Report report);
        Task DeleteReport(Guid reportId);
    }
}
