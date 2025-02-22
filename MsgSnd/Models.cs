namespace MsgSnd
{
    public class Models
    {
        public class MailRequest
        {
            public int Id {  get; set; }
            public string ToEmail { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
           
        }

        
    }
}
