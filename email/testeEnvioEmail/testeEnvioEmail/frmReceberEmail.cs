using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace testeEnvioEmail {
    public partial class frmReceberEmail : Form {
        public frmReceberEmail() {
            InitializeComponent();
        }


        private List<Email> _emails = new List<Email>();
        private string _hostname = "pop.gmail.com"; // Host do seu servidor POP3. Por exemplo, pop.gmail.com para o servidor do Gmail.
        private int _port = 995; // Porta utilizada pelo host. Por exemplo, 995 para o servidor do Gmail.
        private bool _useSsl = true; // Indicação se o servidor POP3 utiliza SSL para autenticação. Por exemplo, o servidor do Gmail utiliza SSL, então, "true".
        private string _username = "recent:wesloy@gmail.com"; // Usuário do servidor POP3. Por exemplo, seuemail@gmail.com.
        private string _password = "xxxxx"; // Senha do servidor POP3.


        private void AtualizarDataBindings() {
            // Limpando os bindings.
            deTextBox.DataBindings.Clear();
            paraTextBox.DataBindings.Clear();
            dataDateTimePicker.DataBindings.Clear();
            conteudoWebBrowser.DataBindings.Clear();
            emailsListBox.DataSource = null;
            emailsBindingSource.DataSource = null;

            // Re-configurando os bindings.
            emailsBindingSource.DataSource = _emails;
            emailsListBox.DataSource = emailsBindingSource;
            emailsListBox.DisplayMember = "Assunto";
            deTextBox.DataBindings.Add(new Binding("Text", emailsBindingSource, "De"));
            paraTextBox.DataBindings.Add(new Binding("Text", emailsBindingSource, "Para"));
            dataDateTimePicker.DataBindings.Add(new Binding("Value", emailsBindingSource, "Data"));
            conteudoWebBrowser.DataBindings.Add(new Binding("DocumentText", emailsBindingSource, "ConteudoHtml"));
        }


        private void frmReceberEmail_Load(object sender, EventArgs e) {

        }

        private void carregarButton_Click(object sender, EventArgs e) {

            try {

                Cursor = Cursors.WaitCursor;

                //bloco “using” (para que a conexão seja fechada automaticamente quando sairmos do bloco “using“).
                using (var client = new OpenPop.Pop3.Pop3Client()) {

                    client.Connect(_hostname, _port, _useSsl);
                    client.Authenticate(_username, _password);

                    //Após isso, temos que perguntar para o servidor qual é quantidade de e-mails que será baixada.Precisamos disso porque faremos um “loop” pelas mensagens para baixar uma a uma.O método GetMessageCount é método responsável por retornar a quantidade de mensagens.
                    //Com a quantidade de mensagens, podemos fazer um loop. Note que, se quisermos baixar os e-mails mais recentes primeiro, devemos começar do número mais alto até o número “1” (os servidores POP consideram “1” como o menor índice, e não “0” como estamos acostumados com o C#):
                    _emails.Clear();
                    int messageCount = client.GetMessageCount();

                    for (int i = messageCount; i > 0; i--) {
                        var popEmail = client.GetMessage(i);

                        //Dentro da mensagem baixada pela biblioteca OpenPop.NET, temos basicamente duas versões da mensagem: uma em formato texto e a outra em formato HTML. Para recuperarmos a versão da mensagem em formato texto, utilizamos o método “FindFirstPlainTextVersion“. Já para baixarmos a versão HTML, utilizamos o método “FindFirstHtmlVersion“
                        var popText = popEmail.FindFirstPlainTextVersion();
                        var popHtml = popEmail.FindFirstHtmlVersion();

                        string mailText = string.Empty;
                        string mailHtml = string.Empty;
                        if (popText != null) {
                            mailText = popText.GetBodyAsText();
                        }

                        if (popHtml != null) {
                            mailHtml = popHtml.GetBodyAsText();
                        }

                        //armazená-las dentro da nossa lista de e-mails (atributo chamado “_emails” no nível do formulário)
                        _emails.Add(new Email() {
                            Id = popEmail.Headers.MessageId,
                            Assunto = popEmail.Headers.Subject,
                            De = popEmail.Headers.From.Address,
                            Para = string.Join("; ", popEmail.Headers.To.Select(to => to.Address)),
                            Data = popEmail.Headers.DateSent,
                            ConteudoTexto = mailText,
                            ConteudoHtml = !string.IsNullOrWhiteSpace(mailHtml) ? mailHtml : mailText
                        });
                    }

                    AtualizarDataBindings();
                }
            }
            finally {

                Cursor = Cursors.Default;
            }
        }
    }
}

