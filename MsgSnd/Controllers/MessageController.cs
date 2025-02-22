using static MsgSnd.Models;
using static MsgSnd.MessageService;
using Microsoft.AspNetCore.Mvc;
using MsgSnd;

namespace MailRequest1.Controllers;

[ApiController]
[Route("[controller]")]
public class MailRequestController : ControllerBase
{
    public MailRequestController()
    {
    }

    [HttpGet]
    public ActionResult<List<MailRequest>> GetAll() =>
    MessageService.GetAll();



    [HttpGet("{id}")]
    public ActionResult<MailRequest> Get(int id)
    {
        var MailRequest = MessageService.Get(id);

        if (MailRequest == null)
            return NotFound();

        return MailRequest;
    }

    [HttpPost]
    public IActionResult Create(MailRequest MailRequest)
    {
        MessageService.Add(MailRequest);
        return CreatedAtAction(nameof(Get), new { id = MailRequest.Id }, MailRequest);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, MailRequest MailRequest)
    {
        if (id != MailRequest.Id)
            return BadRequest();

        var existingMailRequest = MessageService.Get(id);
        if (existingMailRequest is null)
            return NotFound();

        MessageService.Update(MailRequest);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var MailRequest = MessageService.Get(id);

        if (MailRequest is null)
            return NotFound();

        MessageService.Delete(id);

        return NoContent();
    }
}