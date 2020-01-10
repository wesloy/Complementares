using System;
using System.Net.Mail;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;

namespace testeEnvioEmail {
    public partial class frmEnviarEmail : Form {


        //MailMessage mail = new MailMessage();
        //SmtpClient client = new SmtpClient();
        //client.Host = "outlook.office365.com"; //"smtp.office365.com";
        //client.Port = 25; //483; //587;  
        //client.EnableSsl = true;
        //client.UseDefaultCredentials = false;
        //client.Credentials = new System.Net.NetworkCredential("wesleyel@algartech.com", senha);


        AppSettingsReader config = new AppSettingsReader();
        string senha = "";


        public frmEnviarEmail() {
            InitializeComponent();
        }

        private void frmEnviarEmail_Load(object sender, EventArgs e) {
            senha = config.GetValue("pwd_email", typeof(string)).ToString();
        }

        private void btnEnviar_Click(object sender, EventArgs e) {

            //Configurando o envio
            SmtpClient client = new SmtpClient("10.130.98.5", 25);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(txtDE.Text);
            client.UseDefaultCredentials = true;

            if (!string.IsNullOrWhiteSpace(txtPara.Text)) {
                mail.To.Add(new System.Net.Mail.MailAddress(txtPara.Text));
            } else {
                MessageBox.Show("Campo 'para' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtCC.Text)) {
                mail.CC.Add(new System.Net.Mail.MailAddress(txtCC.Text));
            }

            if (!string.IsNullOrWhiteSpace(txtCCo.Text)) {
                mail.Bcc.Add(new System.Net.Mail.MailAddress(txtCCo.Text));
            }

            mail.Subject = txtAssunto.Text;
            mail.Body = txtMsg.Text;

            //Carregando os anexos
            foreach (string file in lbAnexos.Items) {
                mail.Attachments.Add(new System.Net.Mail.Attachment(file));
            }

            client.Send(mail);
            //smtp.Send(mail);
        }

        private void btnAnexar_Click(object sender, EventArgs e) {
            using (OpenFileDialog dialog = new OpenFileDialog()) {
                dialog.Multiselect = true;

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    foreach (var file in dialog.FileNames) {
                        lbAnexos.Items.Add(file);
                    }
                }
            }
        }

        private void btnEnviarDLL_Click(object sender, EventArgs e) {

            email_smtp.envio envio = new email_smtp.envio();

            envio.De = txtDE.Text;
            envio.Para = txtPara.Text;
            envio.Cc = txtCC.Text;
            envio.CcO = txtCCo.Text;
            envio.Assunto = txtAssunto.Text;
            envio.Mensagem = txtMsg.Text;

            //Carregando os anexos
            List<string> listaAnexos = new List<string>();
            foreach (string file in lbAnexos.Items) { listaAnexos.Add(file); }
            envio.Anexos = listaAnexos;

            if (envio.enviarEmail(envio))  {
                MessageBox.Show("E-mail enviado com sucesso!", "Envio de E-mail");
            } else {
                MessageBox.Show("Falha no envio de E-mail!", "Envio de E-mail");
            }
        }

        private void btnEnviarSDK_Click(object sender, EventArgs e)
        {
            email_dynamics.email_dynamics email = new email_dynamics.email_dynamics();

            email.Assunto = txtAssunto.Text;
            email.Mensagem = txtMsg.Text.Replace("\r\n", "<br />");

            //Para
            List<string> para = new List<string>();
            string[] _para = txtPara.Text.Split(';');            
            foreach (var item in _para) { para.Add(item); }
            email.Para = para;

            //CC
            List<string> cc = new List<string>();
            string[] _cc = txtCC.Text.Split(';');
            foreach (var item in _cc) { cc.Add(item); }
            email.Cc = cc;

            //CCo
            List<string> ccO = new List<string>();
            string[] _ccO = txtCCo.Text.Split(';');
            foreach (var item in _ccO) { ccO.Add(item); }
            email.CcO = ccO;

            //Carregando os anexos
            List<string> listaAnexos = new List<string>();
            foreach (string file in lbAnexos.Items) { listaAnexos.Add(file); }
            email.Anexos = listaAnexos;
            
            
            if (email.envio(email.Assunto, email.Mensagem, email.Para, email.Cc, email.CcO, email.Anexos))
            {
                MessageBox.Show("E-mail enviado com sucesso!", "Envio de E-mail");
            }
            else
            {
                MessageBox.Show("Falha no envio de E-mail!", "Envio de E-mail");
            }

        }
    }
}

