using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TestApi.DTOs;
using TestApi.Entities;

namespace TestApi.Implement
{
    public class TestService : ITest
    {
        private readonly AppDbContext _context;

        public TestService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<HealthCheckRespone> HealthCheckSync()
        {
            bool canConnect = await _context.Database.CanConnectAsync();

            return new HealthCheckRespone
            {
                Status = canConnect ? "Healthy" : "Unhealthy",
                Message = canConnect ? "successful." : "fail",
                Timestamp = DateTime.UtcNow
            };
        }

        public async Task<ResponeListIems> GetListItemAsync(work_items work_Items, projects projects)
        {
            var result = _context.Work_Items
                .Join(
                projects,
                wi=>wi.project_id,
                wi => wi.project_name,
                p=> p.id,
                (work_Items, projects) => (work_Items, projects))
                .GroupBy(g=>g.projects.id)
                .Select(x=> new ResponeListIems(
                    projects.id,
                    projects.name,
                    x.Count(),

                    ))
                .ToList();
            return result;
        }//chua hoan thanh


        public async Task<NewWorkItem> CreatWork_Item(work_items work)
        {
            var item = new NewWorkItem();
            var exitWorkItem = await _context.Work_Items.FirstOrDefaultAsync(x => x.id == item.id);
            if (exitWorkItem != null)
            {
                throw new Exception("id da ton tai");
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newItem = new NewWorkItem();
                    newItem.id = item.id;
                    newItem.code = item.code;
                    newItem.title = item.title;
                    newItem.Description = item.Description;
                    newItem.status = item.status;
                    newItem.priority = item.priority;
                    newItem.project_id = item.project_id;
                    newItem.assignee_id = item.assignee_id;
                    newItem.dueAt = item.dueAt;
                    newItem.completed_at = item.completed_at;
                    newItem.is_deleted = item.is_deleted;
                    newItem.deleted_at = item.deleted_at;
                    newItem.created_at = item.created_at;
                    newItem.updated_at = item.updated_at;
                    _context.Work_Items.Add(newItem);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"loi he thong {ex.Message}");
                }
            }
            return item;
        }




        public async Task<SoftDeleteResult> DeleteWorkItem(long id)
        {
            var item = await _context.Work_Items
                .FirstOrDefaultAsync(w => w.id == id && !w.is_deleted);

            if (item == null)
                return SoftDeleteResult.NotFound("Work item khong ton tai ");
            if (item.status != "Todo" && item.status != "Cancelled")
                return SoftDeleteResult.Conflict($"khong xoa work item  cos trang thai nay dduocj{item.status}");
            var now = DateTime.UtcNow;
            item.is_deleted = true;
            item.updated_at = now;
            item.deleted_at = now;
            await _context.SaveChangesAsync();
            return SoftDeleteResult.Ok();
        }

        public async Task<GetDetailRequest> GetWorkItemsAsync(long id)
        {
            var items = await _context.Work_Items
                .FirstOrDefaultAsync(w => w.id == id && !w.is_deleted);
            if (items is null) return GetDetailRequest.NotFound("khong tim thay id");
            var item = _context.Work_Items;
            return GetDetailRequest.Ok();
            
        }
                                                                                                                                                   
    }
}
