using Demo_CapitalPlacement.Application.Common.Interfaces;
using Demo_CapitalPlacement.Application.Common.Models;
using MediatR;

namespace Demo_CapitalPlacement.Application.TodoItems.Queries
{
    public class GetTodoItemsQuery : IRequest<ResultDto<List<TodoViewModel>>> { }
    public class Handler(ICpCodeRepository cpCodeRepository) : IRequestHandler<GetTodoItemsQuery, ResultDto<List<TodoViewModel>>>
    {
        private readonly ICpCodeRepository _cpCodeRepository = cpCodeRepository;
        public async Task<ResultDto<List<TodoViewModel>>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _cpCodeRepository.GetAllTodoItemAsync();
                if (result.IsSuccess)
                {
                    return new ResultDto<List<TodoViewModel>>(result.Data, true);
                }
                return new ResultDto<List<TodoViewModel>>(result.Data, false, result.Message);
            }
            catch (Exception ex)
            {
                return new ResultDto<List<TodoViewModel>>(null, false, ex.Message);
            }
        }
    }
}