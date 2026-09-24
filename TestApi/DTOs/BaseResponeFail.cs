using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestApi.DTOs
{
    public class BaseResponeFail
    {
        public string TracId { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        //public Error<string> Title { get; set; }
    }
}
