using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;
using ToDoApplication.Database.Models;
using ToDoApplication.Domain.ToDoEntities;
using ToDoApplication.Repositories;

namespace ToDoApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ToDoController : ApiControllerBase
    {
        private readonly ILogger<ToDoController> logger;
        private readonly IToDoRepository toDoRepo;

        public ToDoController(ILogger<ToDoController> logger, IToDoRepository toDoRepo)
        {
            this.logger = logger;
            this.toDoRepo = toDoRepo;
        }

        [HttpGet(Name = "GetToDos")]
        public async Task<ToDo[]?> GetAllAsync()
        {
            try
            {
                return await Task.Run(() => toDoRepo.GetAll());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost(Name = "AddToDos")]
        public async Task<BaseResponse> AddAsync([FromBody] AddToDoRequest request)
        {
            try
            {
                if (request.ToDoList == null)
                {
                    return ReturnResponseMessage("1", "İşlem başarısız. Alanlar boş olamaz.");
                }
                foreach (var toDoDataFromRequest in request.ToDoList)
                {
                    if (request.ToDoList.Any(x => AnyFieldsEmpty(x)))
                    {
                        return ReturnResponseMessage("1", "İşlem başarısız. Alanlar boş olamaz.");
                    }
                }
                if (request.ToDoList != null)
                {
                    await Task.Run(() => toDoRepo.AddAll(request.ToDoList));

                }
                return ReturnResponseMessage("0", "İşlem başarılı");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{ErrorMessage}", ex.Message);
                return ReturnResponseMessage("2", "Ekleme işlemi başarısız.");
            }
        }

        private bool AnyFieldsEmpty(ToDo data)
        {
            var isTitleEmpty = string.IsNullOrWhiteSpace(data.Title);
            var isDescriptionEmpty = string.IsNullOrWhiteSpace(data.Description);
            var isCreatedByEmpty = string.IsNullOrWhiteSpace(data.CreatedBy);
            var isCreateDateEmpty = string.IsNullOrWhiteSpace(data.CreateDate.ToString());
            return isTitleEmpty || isDescriptionEmpty || isCreatedByEmpty || isCreateDateEmpty;
        }
    }
}
