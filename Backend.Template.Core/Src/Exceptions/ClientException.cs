namespace Backend.Template.Core.Exceptions
{
    public class ClientException : DefaultException
    {
        public override int StatusCode { get; set; }
        public string Uri { get; set; }
        public string Content { get; set; }

        public ClientException(string message) : base(message)
        {
        }
    }
}
