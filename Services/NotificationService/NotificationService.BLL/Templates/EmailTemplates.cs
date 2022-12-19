namespace NotificationService.BLL.Templates
{
    public class EmailTemplates
    {
        public static string DefaultEmailTemplate = "<html>" +
                                                    "<body>" +
                                                   "<div>" +
                                                   "<p>Hi</p>" +
                                                   "<p>@Model,</p>" +
                                                   "<p>Date and time is @System.DateTime.Now</p>" +
                                                   "</div>" +
                                                    "</body>" +
                                                    "</html>";
    }
}
