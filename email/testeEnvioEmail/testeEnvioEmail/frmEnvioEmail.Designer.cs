namespace testeEnvioEmail
{
    partial class frmEnviarEmail
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnviarEmail));
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtPara = new System.Windows.Forms.TextBox();
            this.txtCCo = new System.Windows.Forms.TextBox();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAssunto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbAnexos = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAnexar = new System.Windows.Forms.Button();
            this.btnEnviarDLL = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDE = new System.Windows.Forms.TextBox();
            this.btnEnviarSDK = new System.Windows.Forms.Button();
            this.btnLerEmail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(466, 35);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(73, 72);
            this.btnEnviar.TabIndex = 6;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtPara
            // 
            this.txtPara.Location = new System.Drawing.Point(71, 49);
            this.txtPara.Name = "txtPara";
            this.txtPara.Size = new System.Drawing.Size(385, 20);
            this.txtPara.TabIndex = 0;
            // 
            // txtCCo
            // 
            this.txtCCo.Location = new System.Drawing.Point(71, 101);
            this.txtCCo.Name = "txtCCo";
            this.txtCCo.Size = new System.Drawing.Size(385, 20);
            this.txtCCo.TabIndex = 2;
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(71, 75);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(385, 20);
            this.txtCC.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Para";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "CC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "CCo";
            // 
            // txtAssunto
            // 
            this.txtAssunto.Location = new System.Drawing.Point(71, 127);
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(714, 20);
            this.txtAssunto.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Assunto";
            // 
            // lbAnexos
            // 
            this.lbAnexos.FormattingEnabled = true;
            this.lbAnexos.Location = new System.Drawing.Point(71, 153);
            this.lbAnexos.Name = "lbAnexos";
            this.lbAnexos.Size = new System.Drawing.Size(550, 56);
            this.lbAnexos.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Anexos";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(71, 215);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(714, 187);
            this.txtMsg.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mensagem";
            // 
            // btnAnexar
            // 
            this.btnAnexar.Location = new System.Drawing.Point(627, 155);
            this.btnAnexar.Name = "btnAnexar";
            this.btnAnexar.Size = new System.Drawing.Size(158, 56);
            this.btnAnexar.TabIndex = 4;
            this.btnAnexar.Text = "Anexar";
            this.btnAnexar.UseVisualStyleBackColor = true;
            this.btnAnexar.Click += new System.EventHandler(this.btnAnexar_Click);
            // 
            // btnEnviarDLL
            // 
            this.btnEnviarDLL.Location = new System.Drawing.Point(545, 35);
            this.btnEnviarDLL.Name = "btnEnviarDLL";
            this.btnEnviarDLL.Size = new System.Drawing.Size(76, 72);
            this.btnEnviarDLL.TabIndex = 7;
            this.btnEnviarDLL.Text = "Enviar DLL";
            this.btnEnviarDLL.UseVisualStyleBackColor = true;
            this.btnEnviarDLL.Click += new System.EventHandler(this.btnEnviarDLL_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "De";
            // 
            // txtDE
            // 
            this.txtDE.Location = new System.Drawing.Point(71, 23);
            this.txtDE.Name = "txtDE";
            this.txtDE.Size = new System.Drawing.Size(385, 20);
            this.txtDE.TabIndex = 13;
            // 
            // btnEnviarSDK
            // 
            this.btnEnviarSDK.Location = new System.Drawing.Point(627, 36);
            this.btnEnviarSDK.Name = "btnEnviarSDK";
            this.btnEnviarSDK.Size = new System.Drawing.Size(76, 72);
            this.btnEnviarSDK.TabIndex = 15;
            this.btnEnviarSDK.Text = "Enviar SDK";
            this.btnEnviarSDK.UseVisualStyleBackColor = true;
            this.btnEnviarSDK.Click += new System.EventHandler(this.btnEnviarSDK_Click);
            // 
            // btnLerEmail
            // 
            this.btnLerEmail.Location = new System.Drawing.Point(709, 36);
            this.btnLerEmail.Name = "btnLerEmail";
            this.btnLerEmail.Size = new System.Drawing.Size(76, 72);
            this.btnLerEmail.TabIndex = 16;
            this.btnLerEmail.Text = "Leitura E-mail";
            this.btnLerEmail.UseVisualStyleBackColor = true;
            this.btnLerEmail.Click += new System.EventHandler(this.btnLerEmail_Click);
            // 
            // frmEnviarEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 445);
            this.Controls.Add(this.btnLerEmail);
            this.Controls.Add(this.btnEnviarSDK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDE);
            this.Controls.Add(this.btnEnviarDLL);
            this.Controls.Add(this.btnAnexar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbAnexos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAssunto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.txtCCo);
            this.Controls.Add(this.txtPara);
            this.Controls.Add(this.btnEnviar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEnviarEmail";
            this.Text = ".: Enviar E-mail :.";
            this.Load += new System.EventHandler(this.frmEnviarEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtPara;
        private System.Windows.Forms.TextBox txtCCo;
        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAssunto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbAnexos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAnexar;
        private System.Windows.Forms.Button btnEnviarDLL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDE;
        private System.Windows.Forms.Button btnEnviarSDK;
        private System.Windows.Forms.Button btnLerEmail;
    }
}

