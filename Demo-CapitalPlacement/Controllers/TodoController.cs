using Demo_CapitalPlacement.Application.TodoItems.Commands.CreateTodo;
using Demo_CapitalPlacement.Application.TodoItems.Commands.DeleteTodo;
using Demo_CapitalPlacement.Application.TodoItems.Commands.UpdateTodo;
using Demo_CapitalPlacement.Application.TodoItems.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_CapitalPlacement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("GetTodoItems")]
        public async Task<IActionResult> GetTodoItemList()
        {
            return Ok(await _mediator.Send(new GetTodoItemsQuery()));
        }

        [HttpPost("CreateTodoItem")]
        public async Task<IActionResult> CreateTodoItem([FromBody] CreateTodoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateTodoItem")]
        public async Task<IActionResult> UpdateTodoItem([FromBody] UpdateTodoItemCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("DeleteTodoItem")]
        public async Task<IActionResult> DeleteTodoItem([FromQuery] int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }
            var command = new DeleteTodoCommand
            {
                Id = Id
            };
            return Ok(await _mediator.Send(command));
        }
    }
}
