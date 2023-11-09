using Microsoft.AspNetCore.Mvc;
using PaperlessRestService.Models;
using System.Collections.Generic;
using System.Linq;

namespace PaperlessRestService.Controllers;

[ApiController]
[Route("/api/saved_views/")]
public partial class SavedViewsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetSavedViews()
    {
        int count = 3;
        return Ok(new ViewsListResponse()
        {
            Next = null,
            Previous = null,
            Count = count,
            All = Enumerable.Range(1, 3).ToArray(),
            Results = new List<SavedView>()
            {
                new SavedView()
                {
                    ShowInSidebar = true,
                    ShowOnDashboard = true,
                    FilterRules = new FilterRule[]
                    {
                        new FilterRule()
                        {
                            RuleType = 3,
                            Value = "5"
                        }
                    }
                },
                new SavedView()
                {
                    ShowInSidebar = true,
                    ShowOnDashboard = true,
                    FilterRules = new FilterRule[]
                    {
                        new FilterRule()
                        {
                            RuleType = 3,
                            Value = "5"
                        }
                    }
                },
                new SavedView()
                {
                    ShowInSidebar = true,
                    ShowOnDashboard = true,
                    FilterRules = new FilterRule[]
                    {
                        new FilterRule()
                        {
                            RuleType = 3,
                            Value = "5"
                        }
                    }
                }
            }
        });
    }
}