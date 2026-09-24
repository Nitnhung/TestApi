using TestApi.DTOs;
using TestApi.Entities;

namespace TestApi.Implement
{
    public interface ITest
    {
        public Task<HealthCheckRespone> HealthCheckSync();
        public Task<GetDetailRequest> GetWorkItemsAsync(long id);
        public Task<SoftDeleteResult> DeleteWorkItem(long id);
        public Task<ResponeListIems> GetListItemAsync();
        public Task<work_items> CreatWork_Item();
    }
}
