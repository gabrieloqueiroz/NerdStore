using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NSE.Identity.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidationOperation())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Messages", errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach(var error in errors)
            {
                AddErrorProcessor(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool ValidationOperation() 
        {
            return !errors.Any();
        }

        protected void AddErrorProcessor(string error)
        {
            errors.Add(error);
        }

        protected void CleanErrorsProcessor()
        {
            errors.Clear();
        }
    }
}
