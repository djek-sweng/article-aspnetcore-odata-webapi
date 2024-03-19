namespace ODataSample.WebApi.Controllers;

[ApiController]
[Route("reminders")]
public class ReminderController : ODataController
{
    private readonly IReminderRepository _reminderRepository;

    public ReminderController(IReminderRepository reminderRepository)
    {
        _reminderRepository = reminderRepository;
    }

    [EnableQuery]
    [HttpGet("query")]
    public IActionResult GetQuery()
    {
        return Ok(_reminderRepository.Query);
    }

    [EnableQuery]
    [HttpGet("list")]
    public IActionResult GetList()
    {
        return Ok(_reminderRepository.List);
    }
}
