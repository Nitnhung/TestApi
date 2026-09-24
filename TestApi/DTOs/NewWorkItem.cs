using TestApi.Entities;

namespace TestApi.DTOs
{
    public class NewWorkItem:work_items
    {
        public long id { get; set; }
        public string code {  get; set; }
        public string title {  get; set; }
        public string Description {  get; set; }
        public Status status { get; set; }
        public Priority priority { get; set; }
        public long project_id {  get; set; }
        public long assign { get; set; }
        public DateTime? dueAt {  get; set; }
        public DateTime? completed_at { get; set; } = null;
        public bool is_deleted { get; set; } = false;
        public DateTime? deleted_at { get; set; } = DateTime.Now;
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
    }
    public enum Status { InProcess, ToDo, Blocked, Done, Cancelled};
    public enum Priority {  Urgent, Hight, Normal, Low}
}
