using System.Xml.Linq;
using static MsgSnd.Models;
using Aspose.Email;

using System.Net.Mail;


namespace MsgSnd
{
    public class MessageService
    {
        static List<MailRequest> Messages { get; }
        static int nextId = 2;
        static MessageService()
        {
            Messages = new List<MailRequest>
        {
            new MailRequest {Id = 1, ToEmail = "vichernenko@sfedu.ru", Subject = "chvmmob@gmail.com",Body = "Goodbye World!"}

        };
        }

        public static List<MailRequest> GetAll() => Messages;

        public static MailRequest? Get(int id) => Messages.FirstOrDefault(p => p.Id == id);

        public static void Add(MailRequest MailRequest)
        {
            MailRequest.Id = nextId++;
            Messages.Add(MailRequest);
        }

        public static void Delete(int id)
        {
            var MailRequest = Get(id);
            if (MailRequest is null)
                return;

            Messages.Remove(MailRequest);
        }

        public static void Update(MailRequest MailRequest)
        {
            var index = Messages.FindIndex(p => p.Id == MailRequest.Id);
            if (index == -1)
                return;

            Messages[index] = MailRequest;
        }


   /* 
                public static void Send()
        {
          
              SmtpClient client = new SmtpClient("smtp.gmail.com", 587, "chvmmob@gmail.com", "Vitya2003");


             client.Send(MailRequest);
              Console.WriteLine("Сообщение успешно отправлено!");
      
     
             {
              Console.WriteLine("Ошибка при отправке сообщения: " + ex.Message);
             }

        }
   */

    }
} 
        
 