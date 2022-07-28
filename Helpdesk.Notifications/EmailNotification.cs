using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Helpdesk.Notifications;
public class EmailNotification
{
    // IConfiguration _configuration;

    // public EmailNotification(IConfiguration configuration)
    // {
    //     _configuration = configuration;
    // }

    public void Send(string emailDestiny, string formAgencyId)
    {   
        MailMessage mailMessage;
        SmtpClient stmpClient;

        mailMessage = new MailMessage(
            "148318@udlondres.com"          //Origen
            ,emailDestiny                   //Destino
            , "Hola"                        //Asunto
            ,$"Complete el registro haciendo <a href='https://localhost:10023/FormAgencies/{formAgencyId}/Register'>click aqui</a>"   //Mensaje
        );
        mailMessage.IsBodyHtml = true;
        stmpClient = new SmtpClient("smtp.gmail.com");
        stmpClient.EnableSsl = true;
        stmpClient.UseDefaultCredentials = false;
        stmpClient.Port = 587;
        stmpClient.Credentials = new NetworkCredential("148318@udlondres.com","macross#2012");
        //stmpClient.Send(mailMessage);
        stmpClient.Dispose();
    }
}
