namespace web_api_project.Errors
{
    public class ApiResponse
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public ApiResponse(int StatusCode, string Message=null)
        {
            statusCode = StatusCode;
            message = Message ?? getDefaultMessageForErrorCode(StatusCode);
        }

        private string getDefaultMessageForErrorCode(int StatusCode)
        {
            return StatusCode switch
            {
                400 => "bad request",
                401 =>"no authorization",
                404 => "resourcenot found",
                500 => "Server Error",
                _=>null
            };
        }
    }
}
