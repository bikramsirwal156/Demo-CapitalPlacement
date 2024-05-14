using Demo_CapitalPlacement.Application.Common.Interfaces;
using Demo_CapitalPlacement.Application.Common.Models;
using MediatR;

namespace Demo_CapitalPlacement.Application.TodoItems.Commands.CreateTodo
{
    public class CreateTodoCommand : IRequest<ResultDto<int>>
    {
        public int Id { get; set; }
        /// <summary>
        /// Job Description
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// This is flag to denote the currenly applying candidate is ex-emp
        /// if ex-Emp flag is true other mark false
        /// </summary>
        public required bool IsActive { get; set; }

        /// <summary>
        /// This will be a dropwon of yes and no. If the Candidate is refer by some mark yes else no
        /// </summary>
        public string RefrenceNumber { get; set; }

        /// <summary>
        /// Apply Date
        /// </summary>
        public DateTime ApplyDate { get; set; }

        /// <summary>
        /// Experience
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// List of Skills
        /// </summary>
        public required List<TodoOptionsViewModel> TodoOptionsViews { get; set; }
    }

    public class Handler : IRequestHandler<CreateTodoCommand, ResultDto<int>>
    {
        private readonly ICpCodeRepository _cpCodeRepository;
        public Handler(ICpCodeRepository cpCodeRepository)
        {
            _cpCodeRepository = cpCodeRepository;
        }

        public async Task<ResultDto<int>> Handle(CreateTodoCommand cammand, CancellationToken cancellationToken)
        {
            try
            {

                var data = new TodoViewModel
                {
                    Id = cammand.Id,
                    Description = cammand.Description,
                    ApplyDate = cammand.ApplyDate,
                    Experience = cammand.Experience,
                    IsActive = cammand.IsActive,
                    RefrenceNumber = cammand.RefrenceNumber,
                    TodoOptionsViewModels = cammand.TodoOptionsViews
                };

                var result = await _cpCodeRepository.CreateTodoItemAsync(data);
                if (result.IsSuccess)
                {
                    return new ResultDto<int>(1, true);
                }
                return new ResultDto<int>(-1, false, result.Message);
            }
            catch (Exception ex)
            {
                return new ResultDto<int>(-1, false, ex.Message);
            }
        }
    }
}

