using Catalog.Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    
    [ApiController]
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult ApiResponse(Result response)
        {
            if (response.IsSuccess)
            {
                return Ok(new BaseResponse
                {
                    message = response.message,
                    status = response.status,
                    ServerTime = DateTime.UtcNow
                });
            }

            if (!response.IsSuccess)
            {
                return StatusCode(response.StatusCode, new BaseResponse
                {
                    message= response.message,
                    status = response.status,
                    ServerTime = DateTime.UtcNow
                });
            }

            if (response.IsException)
            {
                return StatusCode(response.StatusCode, new BaseResponse
                {
                    message = response.message,
                    status = response.status,
                    ServerTime = DateTime.UtcNow
                });
            }

            return Ok(new BaseResponse
            {
                message = response.message,
                status = response.status,
            });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult ApiResponse<T>(Result<T> response)
        {
            if (response.IsSuccess)
            {
                return Ok(new BaseResponse<T>
                {
                    message = response.message,
                    status = response.status,
                    ServerTime = DateTime.UtcNow,
                    data = response.data
                });
            }

            if (!response.IsSuccess)
            {
                return StatusCode(response.StatusCode, new BaseResponse<List<string>>
                {
                    message = response.message,
                    status = response.status,
                    ServerTime = DateTime.UtcNow,
                    data = response.ErrorList
                });
            }

            if (response.IsException)
            {
                return StatusCode(response.StatusCode, new BaseResponse<T>
                {
                    message = response.message,
                    status = response.status,
                    ServerTime = DateTime.UtcNow,
                    data = response.data
                });
            }

            return Ok(new BaseResponse
            {
                message = response.message,
                status = response.status,
            });
        }
    }
}
