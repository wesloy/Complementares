using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace email_smtp {
    public class envio {

        SmtpClient client = new SmtpClient("10.130.98.5", 25); //Relay de envio mais a porta, pode-se usar o Hostname também.
        MailMessage mail = new MailMessage();

        #region Atributos        
        public string De { get; set; }
        public string Para { get; set; }
        public string Cc { get; set; }
        public string CcO { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public List<string> Anexos { get; set; }
        #endregion


        /// <summary>
        ///string De { Aceita apenas 1 remetente }
        ///string Para { Separado por ; }
        ///string Cc { Separado por ;  }
        ///string CcO { Separado por ; }
        ///string Assunto 
        ///string Mensagem 
        ///List tipo string Anexos { Lista com cada endereço de arquivo }
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool enviarEmail (envio obj) {
            try {
                //Configurando o envio:

                //DE:
                mail.From = new MailAddress(obj.De.ToString());

                //PARA:
                foreach (string item in capturarLista(obj.Para)) {                    
                    if (item != "") {
                        mail.To.Add(new System.Net.Mail.MailAddress(item.ToString()));
                    }
                }

                //CC:
                foreach (string item in capturarLista(obj.Cc)) {
                    if (item != "") {
                        mail.CC.Add(new System.Net.Mail.MailAddress(item.ToString()));
                    }                    
                }

                //CCo:
                foreach (string item in capturarLista(obj.CcO)) {
                    if (item != "") {
                        mail.Bcc.Add(new System.Net.Mail.MailAddress(item.ToString()));
                    }
                }

                //enviando uma copia para o remetente.
                //procedimento de segurança para garantir que o envio aconteceu e para se guardar uma cópia.
                mail.Bcc.Add(new System.Net.Mail.MailAddress(mail.From.Address));

                //ASSUNTO
                mail.Subject = obj.Assunto.ToString(); 

                //MENSAGEM
                mail.Body = obj.Mensagem.ToString();

                //CARREGANDO ANEXOS
                foreach (string item in obj.Anexos) {
                    if (item != "") {
                        mail.Attachments.Add(new System.Net.Mail.Attachment(item));
                    }                    
                }

                //Enviando o e-mail
                client.Send(mail);

                return true;

            } catch (Exception) {                
                return false;
            }
        }

        private List<string> capturarLista(string listaSeparadaPorPontoEVirgula) {

            List<string> lista = new List<string>();

            try {
                foreach (string item in listaSeparadaPorPontoEVirgula.Split(';')) {
                    lista.Add(item);
                }
                return lista;

            } catch (Exception) {
                return lista;
            }
            
        }

    }
}
