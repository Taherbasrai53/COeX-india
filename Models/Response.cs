using Microsoft.VisualBasic;

namespace COeX_India.Models
{
    public class Response
    {
        public bool success { get; set; }
        public string msg { get; set; }
        public Response(bool success, string msg)
        {
            this.success = success;
            this.msg = msg;
        }
    }
}
