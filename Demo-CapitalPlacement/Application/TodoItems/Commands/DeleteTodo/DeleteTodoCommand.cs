using Demo_CapitalPlacement.Application.Common.Interfaces;
using Demo_CapitalPlacement.Application.Common.Models;
using MediatR;

namespace Demo_CapitalPlacement.Application.TodoItems.Commands.DeleteTodo
{
    public class DeleteTodoCommand : IRequest<ResultDto<int>>
    {
        public int Id { get; set; }
    }

    public class Handler(ICpCodeRepository cpCodeRepository) : IRequestHandler<DeleteTodoCommand, ResultDto<int>>
    {
        private readonly ICpCodeRepository _cpCodeRepository = cpCodeRepository;

        public async Task<ResultDto<int>> Handle(DeleteTodoCommand cammand, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _cpCodeRepository.DeleteTodoItemAsync(cammand.Id);
                if (result.IsSuccess)
                {
                    return new ResultDto<int>(1, true);
                }
                return new ResultDto<int>(-1, false);
            }
            catch (Exception ex)
            {
                return new ResultDto<int>(-1, false, ex.Message);
            }
        }
    }
}