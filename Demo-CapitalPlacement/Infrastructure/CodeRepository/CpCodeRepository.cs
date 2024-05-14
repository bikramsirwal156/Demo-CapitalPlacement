using Demo_CapitalPlacement.Application.Common.Interfaces;
using Demo_CapitalPlacement.Application.Common.Models;
using MediatR;

namespace Demo_CapitalPlacement.Infrastructure.CodeRepository
{
    public class CpCodeRepository : ICpCodeRepository
    {
        public Task<ResultDto<Unit>> CreateTodoItemAsync(TodoViewModel jobApplyViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResultDto<Unit>> DeleteTodoItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultDto<List<TodoViewModel>>> GetAllTodoItemAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultDto<Unit>> UpdateTodoItemAsync(TodoViewModel jobApplyViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
