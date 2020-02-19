using OpenPop.Mime.Header;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace testeEnvioEmail {

    public class Email {
        public string Id { get; set; }
        public string Assunto { get; set; }
        public string De { get; set; }
        public string Para { get; set; }
        public DateTime Data { get; set; }
        public string ConteudoTexto { get; set; }
        public string ConteudoHtml { get; set; }
    }


    //class LeitorEmails {
    //    public void BuscaEmail(string nome_servidor_pop, int porta, string email, string senha, TextBox textbox) {
    //        // A instrução using faz a desconexão do servidor de email
    //        // e libera corretamente o objeto
    //        using (Pop3Client cliente_pop = new Pop3Client()) {
    //            // Faz a conexão com o servidor
    //            cliente_pop.Connect(nome_servidor_pop, porta, true);

    //            email = "wesleyel@algartech.com";
    //            senha = "mkw@2002";

    //            // Faz a autenticação no servidor
    //            cliente_pop.Authenticate(email, senha,
    //                AuthenticationMethod.UsernameAndPassword);

    //            // Obtêm o número total de emails da caixa de entrada
    //            int numero_emails = cliente_pop.GetMessageCount();

    //            // Faz a leitura dos 10 emails mais recentes da caixa de entrada,
    //            // iniciando a partir do último email recebido.
    //            for (int i = 0; i < 10; i++) {
    //                // Cabeçalho da mensagem
    //                MessageHeader headers = cliente_pop.GetMessageHeaders(numero_emails);

    //                // Email De:
    //                RfcMailAddress emailDe = headers.From;

    //                // Email Para:
    //                // Faz a leitura de todos os emails Para, mas exibe somente o primeiro.
    //                List<RfcMailAddress> emailParaList = headers.To;
    //                string emailPara = string.Empty;
    //                if (emailParaList != null && emailParaList.Count() > 0) {
    //                    emailPara = emailParaList.First().Address;
    //                }

    //                // Assunto
    //                string assunto = headers.Subject;

    //                // Data de envio
    //                DateTime data_envio = headers.DateSent;

    //                // Verifica se o endereço de email De é válido
    //                if (emailDe.HasValidMailAddress) {
    //                    // Corpo do email
    //                    OpenPop.Mime.Message mensagem = cliente_pop.GetMessage(numero_emails);
    //                    string corpo_email = mensagem.MessagePart.GetBodyAsText();

    //                    textbox.Multiline = true;

    //                    // Imprime as informações do email
    //                    textbox.Text = ("De: " + emailDe + Environment.NewLine);
    //                    textbox.Text += ("Para: " + emailPara + Environment.NewLine);
    //                    textbox.Text += ("Assunto: " + assunto + Environment.NewLine);
    //                    textbox.Text += ("Data de Envio: " + data_envio + Environment.NewLine);
    //                    textbox.Text += (corpo_email + Environment.NewLine);
    //                    textbox.Text += ("".PadLeft(30, '-'));

    //                    // Decrementa o número de emails
    //                    numero_emails--;
    //                }
    //            }
    //        }

    //    }

    //}



}
