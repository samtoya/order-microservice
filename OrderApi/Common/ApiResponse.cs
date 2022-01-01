namespace OrderApi.Common
{
    public class ApiResponse<T>
    {
        public Boolean Success { get; set; } = true;
        public IEnumerable<string>? ErrorMessages { get; set; }
        public T? Data { get; set; }
        public String Message { get; set; }
    }
}
