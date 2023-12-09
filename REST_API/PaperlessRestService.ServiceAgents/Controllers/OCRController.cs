using Microsoft.AspNetCore.Mvc;
using PaperlessRestService.BusinessLogic.DataAccess.Database;
// using PaperlessRestService.Logging;

namespace PaperlessRestService.ServiceAgents.Controllers;

[ApiController]
[Route("[controller]")]
public class OCRController : ControllerBase
{



    //public CorrespondentsController(IMapper mapper, ILogger<CorrespondentsController> logger)
    //{
    //    _mapper = mapper;
    //    _logger = logger;
    //}


    private readonly ILogger<OCRController> _logger;

  //  private readonly IMapper _mapper;
    public OCRController(ILogger<OCRController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostQueueMessage")]
    public IActionResult PostQueueMessage(string message)
    {


        // NAchrichten, vom rabbitMQ zu bekommen. 

        StatusCodeResult result = new StatusCodeResult(StatusCodes.Status200OK);
        return result;
    }
}
