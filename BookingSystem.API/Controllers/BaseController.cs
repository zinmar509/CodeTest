using BookingSystem.DAL.Common.Interface;
using BookingSystem.DAL.ConfigModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookingSystem.API.Controllers
{
    
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var showUserInfo = context.HttpContext.RequestServices.GetService<ShowUserInfo>();
            var currentUserService = context.HttpContext.RequestServices.GetService<ICurrentUserService>();          
            currentUserService.SetCurrentUserInfo( showUserInfo.UserId, showUserInfo.UserRole);

        }

        [NonAction]
        protected ObjectResult SaveOk(object result = null)
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                success = true,
                message = "Successfully Saved",
                data = result
            });
        }

        [NonAction]
        protected ObjectResult Ok(object result = null, String message = null)
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                success = true,
                message = message,
                data = result
            });
        }
        [NonAction]
        protected ObjectResult DeleteOk(object result = null)
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                success = true,
                message = "Successfully Deleted",
                data = result
            });
        }

        [NonAction]
        protected ObjectResult RetriveOk(object result)
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                success = true,
                message = "Successfully Retrieved",
                data = result
            });
        }

        [NonAction]
        protected ObjectResult SaveError(string message = null)
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                success = false,
                message = "Failed to save"
            });
        }
        [NonAction]
        protected ObjectResult RetriveError(string message = null)
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                success = false,
                message = "Failed to retrieve"
            });
        }
        [NonAction]
        protected ObjectResult DeleteError(string message = null)
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                success = false,
                message = "Failed to delete"
            });
        }
        [NonAction]
        protected ObjectResult Error(string message)
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                success = false,
                message = message
            });
        }

        //for custom error message
        [NonAction]
        protected ObjectResult ProcessError(string message)
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                success = false,
                message = "Failed to process"
            });
        }



    }
}
