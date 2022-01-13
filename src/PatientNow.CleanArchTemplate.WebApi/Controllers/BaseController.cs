using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PatientNow.CleanArchTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult CreateResponse<T,TE>(Result<T,TE> payload)
            => payload switch
            {
                { IsSuccess: true } => Ok(payload.Value),
                { IsFailure: true } => BadRequest(payload.Error),
                { Value: null } => NoContent(),
                _ => throw new NotImplementedException()
            };

        protected IActionResult CreateResponse(Result payload)
            => payload switch
            {
                { IsSuccess: true } => Ok(),
                { IsFailure: true } => BadRequest(payload.Error),
                _ => NoContent()
            };
    }
}
