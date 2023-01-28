using HttpUtility.Response;

namespace HttpUtility
{
    public class ResponseBase<T> where T : class
    {
        public T? Data { get; set; }
        public IEnumerable<Error>? Errors { get; set; }

        
        
    }
}
