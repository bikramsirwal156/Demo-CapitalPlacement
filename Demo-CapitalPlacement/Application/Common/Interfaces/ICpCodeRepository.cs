using Demo_CapitalPlacement.Application.Common.Models;
using MediatR;

namespace Demo_CapitalPlacement.Application.Common.Interfaces
{
    public interface ICpCodeRepository
    {
        Task<ResultDto<List<TodoViewModel>>> GetAllTodoItemAsync();
        Task<ResultDto<Unit>> CreateTodoItemAsync(TodoViewModel jobApplyViewModel);
        Task<ResultDto<Unit>> UpdateTodoItemAsync(TodoViewModel jobApplyViewModel);
        Task<ResultDto<Unit>> DeleteTodoItemAsync(int id);
    }
}
