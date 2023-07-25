namespace Pizzapan.PresentationLayer.Models
{
    public class MailRequest
    {
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string MessageContext { get; set; }
    }
}