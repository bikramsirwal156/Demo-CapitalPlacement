using Demo_CapitalPlacement.Application.Common.Interfaces;
using Demo_CapitalPlacement.Application.Common.Models;
using Demo_CapitalPlacement.Domain.DataContext;
using Demo_CapitalPlacement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo_CapitalPlacement.Infrastructure.CodeRepository
{
    public class CpCodeRepository(DataContext context) : ICpCodeRepository
    {
        private readonly DataContext _context = context;

        public async Task<ResultDto<List<TodoViewModel>>> GetAllTodoItemAsync()
        {
            try
            {
                var result = await _context.TodoItems.Include(x => x.TodoOptions).Select(rec => new TodoViewModel
                {
                    Id = rec.Id,
                    Description = rec.Description,
                    ApplyDate = rec.ApplyDate,
                    Experience = rec.Experience,
                    IsActive = rec.IsActive,
                    RefrenceNumber = rec.RefrenceNumber,
                    TodoOptionsViewModels = rec.TodoOptions.Select(x => new TodoOptionsViewModel
                                            {
                                                Id = x.Id,
                                                OptionName = x.OptionName,
                                                TodoItemId = x.TodoItemId
                                            }).ToList()
                }).ToListAsync();

                return new ResultDto<List<TodoViewModel>>(result, true, "Data fetech successfully");
            }
            catch (Exception ex)
            {
                return new ResultDto<List<TodoViewModel>>(null, false, ex.Message);
            }
        }
        public async Task<ResultDto<Unit>> CreateTodoItemAsync(TodoViewModel jobApplyViewModel)
        {
            try
            {
                if (jobApplyViewModel is not null)
                {
                    var result = new TodoItem()
                    {
                        Id = jobApplyViewModel.Id,
                        Description = jobApplyViewModel.Description,
                        ApplyDate = jobApplyViewModel.ApplyDate,
                        Experience = jobApplyViewModel.Experience,
                        IsActive = jobApplyViewModel.IsActive,
                        RefrenceNumber = jobApplyViewModel.RefrenceNumber,
                    };
                    var data = await _context.TodoItems.AddAsync(result);
                    await _context.SaveChangesAsync();
                    if (data is not null)
                    {
                        var Id = data.Entity.Id;
                        var result1 = jobApplyViewModel.TodoOptionsViewModels.Select(rec => new TodoOptions
                        {
                           OptionName=rec.OptionName,
                           TodoItemId = Id,
                        }).ToList();
                        await _context.TodoOptions.AddRangeAsync(result1);
                        await _context.SaveChangesAsync();
                    }
                }
                return new ResultDto<Unit>(Unit.Value, true, "Record created successfully");

            }
            catch (Exception ex)
            {
                return new ResultDto<Unit>(Unit.Value, false, ex.Message);
            }
        }
        public async Task<ResultDto<Unit>> UpdateTodoItemAsync(TodoViewModel jobApplyViewModel)
        {
            try
            {
                var result = await _context.TodoItems.Include(x=>x.TodoOptions).Where(x => x.Id == jobApplyViewModel.Id).FirstOrDefaultAsync();
                if (result is not null)
                {
                    result.ApplyDate = jobApplyViewModel.ApplyDate;
                    result.Description = jobApplyViewModel.Description;
                    result.RefrenceNumber = jobApplyViewModel.RefrenceNumber;
                    result.Experience = jobApplyViewModel.Experience;
                    result.IsActive = jobApplyViewModel.IsActive;
                    _context.TodoItems.Update(result);
                    await _context.SaveChangesAsync();
                    foreach (var item in jobApplyViewModel.TodoOptionsViewModels)
                    {
                        var result2 = await _context.TodoOptions.Where(x => x.TodoItemId == result.Id).ToListAsync();
                        if (result2.Count != 0)
                        {
                            _context.TodoOptions.RemoveRange(result2);
                            await _context.SaveChangesAsync();
                            var result1 = jobApplyViewModel.TodoOptionsViewModels.Select(rec => new TodoOptions
                            {
                                TodoItemId = result.Id,
                                OptionName=rec.OptionName,
                            }).ToList();
                            await _context.TodoOptions.AddRangeAsync(result1);
                            await _context.SaveChangesAsync();
                        }
                    }
                    return new ResultDto<Unit>(Unit.Value, true, "Update record successfully");
                }
                return new ResultDto<Unit>(Unit.Value, true, "Record does't exist");
            }
            catch (Exception ex)
            {

                return new ResultDto<Unit>(Unit.Value, false, ex.Message);
            }
        }
        public async Task<ResultDto<Unit>> DeleteTodoItemAsync(int id)
        {
            try
            {
                var remvoeTodoitem = await _context.TodoItems.Include(x=>x.TodoOptions).Where(x => x.Id == id).ToListAsync();
                if (remvoeTodoitem.Count != 0)
                {
                    _context.TodoItems.RemoveRange(remvoeTodoitem);
                    await _context.SaveChangesAsync();
                    return new ResultDto<Unit>(Unit.Value, true, "Delete Record Successfullly");
                }
                return new ResultDto<Unit>(Unit.Value, true, "Record does't exist");
            }
            catch (Exception)
            {

                return new ResultDto<Unit>(Unit.Value, false);
            }
        }
    }
}
