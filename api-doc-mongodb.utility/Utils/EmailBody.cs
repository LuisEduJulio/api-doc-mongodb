using api_doc_mongodb.domain.Entities;

namespace api_doc_mongodb.utility.Utils
{
    public static class EmailBody
    {
        public static string NewCustomerBodyEmail(CustomerEntity Customer)
        {
            return @"
                    <!DOCTYPE html>
                    <html lang='en'>
                    <head>
                        <meta charset='UTF-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <style>
                            /* Estilos CSS da sua página de boas-vindas aqui */
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <h1>Olá, " + Customer.Name + ", bem-vindo ao nosso site!</h1>"+
                                        " <p>Obrigado por se juntar à nossa comunidade. Estamos empolgados em tê-lo conosco.</p>" +
                                   "</div>" +
                               "</body>" +
                              "</html>";
        }
    }
}
