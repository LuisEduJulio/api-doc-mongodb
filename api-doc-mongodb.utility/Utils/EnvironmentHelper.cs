namespace api_doc_mongodb.utility.Utils
{
    public static class EnvironmentHelper
    {
        public static readonly Func<string, string, string> Env = delegate (string variable, string defaultValue)
        {
            if (IsProduction())
                return Environment.GetEnvironmentVariable(variable) ??
                       throw new InvalidOperationException();

            return Environment.GetEnvironmentVariable(variable) ?? defaultValue;
        };

        public static bool IsProduction()
        {
            var environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return environmentVariable != null &&
                   (environmentVariable.Contains("Production",
                        StringComparison.InvariantCultureIgnoreCase) ||
                    environmentVariable.Contains("Producao", StringComparison.InvariantCultureIgnoreCase) ||
                    environmentVariable.Contains("Produção", StringComparison.InvariantCultureIgnoreCase));
        }
        public static string GetApplicationName()
        {
            return "api-doc-mongodb";
        }
        public static string GetApplicationSwagger()
        {
            return "/swagger/v1/swagger.json";
        }
        public static string GetVersionApi()
        {
            return "v1";
        }
        public static string GetCross()
        {
            return "AllowOrigin";
        }
        public static string GetSmptHost()
        {
            return Env("SMTP_HOST", "smtp-mail.outlook.com");
        }
        public static string GetSmptPort()
        {
            return Env("SMTP_PORT", "587");
        }
        public static string GetSmptMail()
        {
            return Env("SMTP_EMAIL", "SEU_EMAIL");
        }
        public static string GetSmptPassword()
        {
            return Env("SMTP_PASSOWORD", "SUA_SENHA");
        }
    }
}
