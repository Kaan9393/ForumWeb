using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumWeb.Models;
using ForumWeb.Models.IModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumWeb.Pages.Admin
{
    public class ReportsAdminModel : PageModel
    {
        private readonly IReport _reportGateway;

        public ReportsAdminModel(IReport reportGateway)
        {
            _reportGateway = reportGateway;
        }

        public List<Report> Reports { get; set; }

        public async Task OnGetAsync()
        {
            Reports = await _reportGateway.GetReports();
        }
    }
}
