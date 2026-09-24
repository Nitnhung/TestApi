using Microsoft.AspNetCore.Mvc;
using TestApi.DTOs;
using TestApi.Implement;

namespace TestApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITest _test;

        public TestsController(ITest test)
        {
            _test = test;
        }

        [HttpGet("health")]
        public async Task<IActionResult> HealthCheckSync()
        {
            var result = await _test.HealthCheckSync();
            return Ok(result);
        }


        [HttpPatch("creat")]
        public async Task<ActionResult> CreatWork_Item()
        {
            var result = await _test.CreatWork_Item();
                return Ok(result);
        }




        [HttpGet("work-items/{id}")]
        public async Task<ActionResult> GetWorkItemsAsync(long id)
        {
            if (id<1)
            {
                return BadRequest(new
                {
                    tracId = HttpContext.TraceIdentifier,
                    status = 400,
                    message = "id khong ddungs",
                    errors = new { id = new[] { "id phai lon hon 0"} }
                });
            }
            var result = await _test.GetWorkItemsAsync(id);
            return result.Status switch
            {
                GetDetailStatus.success => Ok(),
                GetDetailStatus.notfound => NotFound(new
                {
                    traceId = HttpContext.TraceIdentifier,
                    status = 404,
                    message = result.ErrorrMess,
                    errors = new { }
                })
               
            };
        }



        [HttpDelete("work-items/{id}")]
        public async Task<ActionResult> DeleteWorkItem(long id)
        {
            if (id <1)
            {
                return BadRequest(new
                {
                    traceId = HttpContext.TraceIdentifier,
                    status = 400,
                    message = "ID khong dung",
                    errors = new { id = new[] { "ID phai lon hon 0" } }
                });
            }

            var result = await _test.DeleteWorkItem(id);

            return result.Status switch
            {
                SoftDeleteStatus.Success => NoContent(),

                SoftDeleteStatus.NotFound => NotFound(new
                {
                    traceId = HttpContext.TraceIdentifier,
                    status = 404,
                    message = result.ErrorMessage,
                    errors = new { }
                }),

                SoftDeleteStatus.InvalidStatus => Conflict(new
                {
                    traceId = HttpContext.TraceIdentifier,
                    status = 409,
                    message = result.ErrorMessage,
                    errors = new { }
                }),

                _ => StatusCode(500, new
                {
                    traceId = HttpContext.TraceIdentifier,
                    status = 500,
                    message = "loi",
                    errors = new { }
                })
            };
        }
    }
}
