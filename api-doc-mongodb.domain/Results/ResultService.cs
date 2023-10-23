namespace api_doc_mongodb.domain.Results
{
    public class ResultService<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public ResultService(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public ResultService()
        {
        }
    }
}
