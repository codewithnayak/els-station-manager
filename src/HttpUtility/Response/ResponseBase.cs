using HttpUtility.Response;

namespace HttpUtility
{
    public class ResponseBase
    {
        public IEnumerable<Error>? Errors { get; set; }
    }
}
