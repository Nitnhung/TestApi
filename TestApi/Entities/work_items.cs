namespace TestApi.Entities
{
    public class work_items
    {
        public long id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public long project_id { get; set; }
        public long? assignee_id { get; set; } = null;
        public DateTime? due_at { get; set; } = null;
        public DateTime? completed_at { get; set; } = null;
        public bool is_deleted { get; set; } = false;
        public DateTime? deleted_at { get; set; } = null;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
