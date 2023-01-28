namespace HttpUtility.Response
{
    public class Error
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string? Field { get; set; }
    }
}
