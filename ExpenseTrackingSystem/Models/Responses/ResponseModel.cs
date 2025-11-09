namespace ExpenseTrackingSystem.Models.Responses
{
    public class ResponseModel<T>
    {
        public int StatusCode { get; set; }
        public List<string> Messages { get; set; } = [];
        public T Data { get; set; } = default!;
    }
}
