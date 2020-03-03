using PlafonesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace PlafonesWeb
{
    public class Generals : Controller
    {


        public bool SendEmailSMTP(FormCollection formCollection)
        {
            try
            {

                string nombre = formCollection["NOMBRE_VAR"];
                string telefono = formCollection["TELEFONO_VAR"];
                string email = formCollection["EMAIL_VAR"];
                string origen = formCollection["ORIGEN_VAR"];


                string mensaje = formCollection["MENSAJE_VAR"];


                String Body = @"<br></br>";

                // Body = Body + @"<center><div style=""background-color:#01426e;""><br/><img src=""https://plafones.com/wp-content/uploads/2018/03/Logo-plafones-con-eslogan2-1.png"" width=""320"" height=""80""></div></center>";

                Body = Body + @"<center><div style=""background-color:#01426e;""><br/><img src=""https://media-exp1.licdn.com/dms/image/C4E1BAQFxvPzKnDTMTw/company-background_10000/0?e=2159024400&v=beta&t=MHJ6rinyORIwSmYa4PucInh7e2i3cpLVZvRSaTIJ_1c"" width=""320"" height=""80""></div></center>";

                Body = Body + @"</br> <center> <h3> Información de contacto </h3> </center> </br>";

                Body = Body + @"<center><table class=""table"">";

                Body = Body + @"<thead>";
                Body = Body + @"<tr>";
                Body = Body + @"<th> Nombre   </th>";
                Body = Body + @"<th> Correo   </th>";
                Body = Body + @"<th> Teléfono </th>";
                Body = Body + @"</tr>";
                Body = Body + @"</thead>";

                Body = Body + @"<tbody>";
                Body = Body + @"<tr> ";
                Body = Body + @"<td>" + nombre.ToString().Trim() + "</td> ";
                Body = Body + @"<td>" + email.ToString().Trim() + "</td> ";
                Body = Body + @"<td>" + telefono.ToString().Trim() + "</td> ";
                Body = Body + @"</tr> ";
                Body = Body + @"</tbody> ";

                Body = Body + @"</table> </center>";

                Body = Body + @"<br><br>";


                Body = Body + @"<h4> Mensaje </h4>";
                Body = Body + @"<p style=""text-align: justify;"">" + mensaje.ToString().Trim() + "</p>";




                MailMessage mail = new MailMessage();
      
             
                SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString());
                mail.From = new MailAddress(ConfigurationManager.AppSettings["UserSmtp"].ToString());
                mail.To.Add(ConfigurationManager.AppSettings["UserSmtp"].ToString());
                mail.Bcc.Add(ConfigurationManager.AppSettings["UserEmailBCC"].ToString());
                SmtpServer.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"].ToString()); 
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                mail.Subject = ConfigurationManager.AppSettings["SubjectMail"].ToString();
                mail.IsBodyHtml = Convert.ToBoolean(ConfigurationManager.AppSettings["IsBody"].ToString());

               if(Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"].ToString()))
                {
                    mail.Body = Body;
                }
               
                SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"].ToString());
                SmtpServer.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["UserSmtp"].ToString(), ConfigurationManager.AppSettings["PassUserSmtp"].ToString());
                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}