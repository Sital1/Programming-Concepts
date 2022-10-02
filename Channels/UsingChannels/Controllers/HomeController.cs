using System.Threading.Channels;
using Microsoft.AspNetCore.Mvc;
using UsingChannels.Services;

namespace UsingChannels.Controllers;

[ApiController]
[Route("/api/home/")]
public class HomeController: Controller
{   
    [Route("send")]
    public IActionResult Send()
    {   
        // Fire and forget. Not waiting
        Task.Run(() =>
        {
            // some calls/ notification
            Task.Delay(100).Wait();
            Task.Delay(200).Wait();
        });

      

        return Ok("dd");
    }
    
    [Route("sendB")]
    public Task<bool> SendB([FromServices] Notifications notifications)
    {
        return notifications.Send();
    }
    
    [Route("sendA")]
    public bool SendA([FromServices] Notifications notifications)
    {
        return notifications.SendA();
    }
    
    [Route("sendC")]
    public async Task<bool> SendC([FromServices] Channel<string> channel)
    {
        await channel.Writer.WriteAsync("Hello");
        return true;
    }

}