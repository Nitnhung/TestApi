namespace TestApi.DTOs
{
    public class GetDetailRequest
    {
        
        public GetDetailStatus Status { get; set; }
        public Item item { get; set; }
        public Project project { get; set; }
        public Assign assign { get; set; }
        public Lable lable { get; set; }
        public History history {  get; set; }
        public string? ErrorrMess {  get; set; }
        public static GetDetailRequest Ok() => new() { Status = GetDetailStatus.success };
        public static GetDetailRequest NotFound(string message) => new() { Status = GetDetailStatus.notfound, ErrorrMess = message };
    }

    public class History
    {
        public long Id {  get; set; }
        public string creatAt { get; set; }
        public string FromStatus {  get; set; }
        public long ChangeBy {  get; set; }
        public string Note {  get; set; }

    }
    public enum GetDetailStatus { success, notfound, invalidStatus}


    public class Lable
    {
        public long id {  get; set; }
        public string Name {  get; set; }
    }

    public class Assign
    {
        public long id {  get; set; }
        public string code {  get; set; }
        public string full_name { get; set; }
    }

    public class Project
    {
        public string Code {  get; set; }
        public string Name { get; set; }
    }

    public class Item
    {
        public long id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public DateTime dueAt { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime completedAt { get; set; }
    }
}
