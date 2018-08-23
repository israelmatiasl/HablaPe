using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace SocialNetwork.BL.BC.Helpers
{
    public static class Email
    {

        public static String buildBody(String name, String linkAtivation)
        {
            StringBuilder bodyBuilder = new StringBuilder();

            bodyBuilder.AppendFormat("<table id=\"x_middle_column_table\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"background:#fafcfd; width: 640px; padding-left:20px; padding-right:20px; border-collapse:separate; border-radius: 10px\">");
            bodyBuilder.AppendFormat("<tbody>");
            bodyBuilder.AppendFormat("<tr>");
            bodyBuilder.AppendFormat("<td>");
            bodyBuilder.AppendFormat("<table id=\"x_middle_column_content_table\" border=\"0\" cellspacing=\"0\" cellpadding=\"40\" width=\"100%\" style=\"background:#ffffff; -webkit-border-radius:8px; -moz-border-radius:8px; border-radius:8px\">");
            bodyBuilder.AppendFormat("<tbody>");
            bodyBuilder.AppendFormat("<tr>");
            bodyBuilder.AppendFormat("<td id=\"x_middle_column_content_cell\" style=\"background-color:#fafcfd; -webkit-border-radius:6px; -moz-border-radius:6px; border-radius:6px\">");
            bodyBuilder.AppendFormat("<h1 align=\"center\" style=\"margin-bottom:30px; color:#25abd4; font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif\"> Bienvenido a HablaPe </h1>");
            bodyBuilder.AppendFormat("<span style=\"font-family: Helvetica Neue, Helvetica, Arial, sans-serif, serif, EmojiFont; font-size: 16px; line-height: 22px; color: rgb(66, 66, 66);\">");
            bodyBuilder.AppendFormat("<p style=\"margin: 0 0 30px 0\">¡Hola {0}! Nos es grato que pertenezcas a esta nueva comunidad. Por favor, para poder continuar es necesario que verifiques tu cuenta haciendo clic en el enlace inferior.</p>", name);
            bodyBuilder.AppendFormat("<a href=\"{0}\" target=\"_blank\" rel=\"noopener noreferrer\" data-auth=\"NotApplicable\" style=\"display:inline-block; width:100%; background-color:#ece9dd; text-decoration:none; color:#5486c6; font-size:18px; font-weight:bold; text-align:center; padding:15px 0px 15px 0px; -webkit-border-radius:2px; -moz-border-radius:2px; border-radius:2px\">Verificar mi cuenta</a>", linkAtivation);
            bodyBuilder.AppendFormat("<p style=\"margin: 30px 0 0 0\">Seguiremos trabajando para poder mejorar tu experiencia.</p>");
            bodyBuilder.AppendFormat("</span>");
            bodyBuilder.AppendFormat("</td>");
            bodyBuilder.AppendFormat("</tr>");
            bodyBuilder.AppendFormat("</tbody>");
            bodyBuilder.AppendFormat("</table>");
            bodyBuilder.AppendFormat("</td>");
            bodyBuilder.AppendFormat("</tr>");
            bodyBuilder.AppendFormat("</tbody>");
            bodyBuilder.AppendFormat("</table>");

            return bodyBuilder.ToString();
        }

    }
}
