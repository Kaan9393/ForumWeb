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
        private readonly IComment _commentGateway;
        private readonly IPost _postGateway;

        public ReportsAdminModel(IReport reportGateway, IComment commentGateway, IPost postGateway)
        {
            _reportGateway = reportGateway;
            _commentGateway = commentGateway;
            _postGateway = postGateway;
        }

        public List<Report> Reports { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid DeleteReportId { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            if (DeleteReportId != Guid.Empty)
            {
                await _reportGateway.DeleteReport(DeleteReportId);
                return RedirectToPage();
            }

            Reports = await _reportGateway.GetReports();



            return Page();
        }

    }
}
