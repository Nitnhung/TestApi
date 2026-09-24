using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestApi.Entities
{
    public class work_item_histories
    {
        public long id { get; set; }
        public long work_item_id {  get; set; }
        public string? from_status {  get; set; }
        public string to_status {  get; set; }
        public string changed_by {  get; set; }
        DateTime created_at { get; set; }
    }
}
