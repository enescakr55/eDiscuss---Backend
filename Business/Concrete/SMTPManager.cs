using Business.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class SMTPManager
  {
    public SmtpClient Client()
    {
      SmtpClient client = new SmtpClient();
      client.Port = SMTPConfig.SMTPPort; // Genelde 587 ve 25 portları kullanılmaktadır.
      client.Host = SMTPConfig.SMTPAddress; // Hostunuzun smtp için mail domaini.
      client.EnableSsl = true; // Güvenlik ayarları, host'a ve gönderilen server'a göre değişebilir.
      client.Timeout = 20000; // Milisaniye cinsten timeout
      client.DeliveryMethod = SmtpDeliveryMethod.Network; // Mailin yollanma methodu
      client.UseDefaultCredentials = false;
      client.Credentials = new System.Net.NetworkCredential(SMTPConfig.SMTPUsername, SMTPConfig.SMTPPassword); // Burada hangi hesabı kullanarak mail yollayacaksanız onun ayarlarını yapmanız gerekiyor
      return client;

    }
  }
}
