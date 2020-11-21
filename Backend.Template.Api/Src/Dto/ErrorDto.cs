namespace Backend.Template.Api.Dto
{
    public class ErrorDto
    {
        public string Message { get; set; } = "";
        public string? ExceptionMessage  { get; set; }
        public string? Source { get; set; }
        public string? NameSpace { get; protected set; }
        public string? Caller { get; protected set; }
        public int? Line { get; protected set; }
        public string? StackTrace { get; set; }
    }
}
