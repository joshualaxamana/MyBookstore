using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;

/// <summary>
/// Summary description for Helper
/// </summary>
public class Helper
{
    public Helper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetConnection()
    {
        return ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
    }
    public static string CreateSHAHash(string Phrase)
    {
        SHA512Managed HashTool = new SHA512Managed();
        Byte[] PhraseAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Phrase));
        Byte[] EncryptedBytes = HashTool.ComputeHash(PhraseAsByte);
        HashTool.Clear();
        return Convert.ToBase64String(EncryptedBytes);
    }

    public static void SendEmail(string email, string subject, string message)
    {
        MailMessage emailMessage = new MailMessage();
        emailMessage.From = new MailAddress("calemph@gmail.com", "The Administrator");
        emailMessage.To.Add(new MailAddress(email));
        emailMessage.Subject = subject;
        emailMessage.Body = message;
        emailMessage.IsBodyHtml = true;
        emailMessage.Priority = MailPriority.Normal;
        SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587);
        MailClient.EnableSsl = true;
        MailClient.Credentials = new System.Net.NetworkCredential("calemph@gmail.com", "crimeawareness");
        MailClient.Send(emailMessage);
    }

    public static string GetURL()
    {
        string URL = HttpContext.Current.Request.Url.Scheme + "://" +
            HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;
        return URL;
    }
}