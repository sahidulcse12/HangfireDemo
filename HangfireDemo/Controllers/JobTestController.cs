using Hangfire;
using HangfireDemo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTestController : ControllerBase
    {
        private readonly IService _service;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        public JobTestController(
            IService service, 
            IBackgroundJobClient backgroundJobClient,
            IRecurringJobManager recurringJobManager
            ) 
        { 
            _service = service;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }

        [HttpGet("/FireAndForgotJob")]
        public ActionResult CreateFireAndForgotJOb()
        {
            _backgroundJobClient.Enqueue(()=>_service.FireAndForgot());
            return Ok();
        }

        [HttpGet("/DelayedJOb")]
        public ActionResult CreateDelayedJOb()
        {
            _backgroundJobClient.Schedule(()=>_service.DelayedJob(),TimeSpan.FromSeconds(30));
            return Ok();
        }

        [HttpGet("/RecurringJob")]
        public ActionResult CreateRecurringJob()
        {
            _recurringJobManager.AddOrUpdate("jobId", () => _service.RecurringJOb(), Cron.Minutely);
            return Ok();
        }

        [HttpGet("/CotinuationJob")]
        public ActionResult CreateCotinuationJob()
        {
            var parentJobId = _backgroundJobClient.Enqueue(()=>_service.FireAndForgot());
            _backgroundJobClient.ContinueJobWith(parentJobId,()=>_service.CotinuationJob());
            return Ok(); 
        }
    }
}
