using Microsoft.AspNetCore.Mvc;
using ToDoApplication.Domain.ToDoEntities;

namespace ToDoApplication.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected static BaseResponse ReturnResponseMessage(string code, string description)
        {
            return new BaseResponse()
            {
                ResponseCode = code,
                ResponseDescription = description
            };
        }

        protected static void FillSuccessMessage(BaseResponse responseToFill, string code, string description)
        {
            responseToFill.ResponseCode = code;
            responseToFill.ResponseDescription = description;
        }
    }
}
