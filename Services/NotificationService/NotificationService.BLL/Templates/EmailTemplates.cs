namespace NotificationService.BLL.Templates
{
    public static class EmailTemplates
    {
        public const string DefaultEmailTemplate = "<html>" +
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
