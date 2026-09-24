namespace TestApi.DTOs
{
    public class ResponeListIems:BaseRespone
    {
        public string traceId {  get; set; }
        public string status { get; set; }
        public string Messsage { get; set; }
        public List<Item> item {  get; set; }

    }
}
