namespace testeEnvioEmail {
    partial class frmReceberEmail {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.carregarButton = new System.Windows.Forms.Button();
            this.deTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paraTextBox = new System.Windows.Forms.TextBox();
            this.dataDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.emailsListBox = new System.Windows.Forms.ListBox();
            this.emailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.conteudoWebBrowser = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.emailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // carregarButton
            // 
            this.carregarButton.Location = new System.Drawing.Point(12, 7);
            this.carregarButton.Name = "carregarButton";
            this.carregarButton.Size = new System.Drawing.Size(196, 23);
            this.carregarButton.TabIndex = 0;
            this.carregarButton.Text = "Carregar";
            this.carregarButton.UseVisualStyleBackColor = true;
            this.carregarButton.Click += new System.EventHandler(this.carregarButton_Click);
            // 
            // deTextBox
            // 
            this.deTextBox.Location = new System.Drawing.Point(244, 10);
            this.deTextBox.Name = "deTextBox";
            this.deTextBox.Size = new System.Drawing.Size(210, 20);
            this.deTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "De:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Para:";
            // 
            // paraTextBox
            // 
            this.paraTextBox.Location = new System.Drawing.Point(498, 10);
            this.paraTextBox.Name = "paraTextBox";
            this.paraTextBox.Size = new System.Drawing.Size(210, 20);
            this.paraTextBox.TabIndex = 3;
            // 
            // dataDateTimePicker
            // 
            this.dataDateTimePicker.Location = new System.Drawing.Point(753, 10);
            this.dataDateTimePicker.Name = "dataDateTimePicker";
            this.dataDateTimePicker.Size = new System.Drawing.Size(224, 20);
            this.dataDateTimePicker.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(714, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data:";
            // 
            // emailsListBox
            // 
            this.emailsListBox.FormattingEnabled = true;
            this.emailsListBox.Location = new System.Drawing.Point(12, 36);
            this.emailsListBox.Name = "emailsListBox";
            this.emailsListBox.Size = new System.Drawing.Size(196, 511);
            this.emailsListBox.TabIndex = 7;
            // 
            // conteudoWebBrowser
            // 
            this.conteudoWebBrowser.Location = new System.Drawing.Point(217, 36);
            this.conteudoWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.conteudoWebBrowser.Name = "conteudoWebBrowser";
            this.conteudoWebBrowser.Size = new System.Drawing.Size(760, 511);
            this.conteudoWebBrowser.TabIndex = 8;
            // 
            // frmReceberEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 560);
            this.Controls.Add(this.conteudoWebBrowser);
            this.Controls.Add(this.emailsListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.paraTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deTextBox);
            this.Controls.Add(this.carregarButton);
            this.Name = "frmReceberEmail";
            this.Text = ".: Receber E-mail :.";
            this.Load += new System.EventHandler(this.frmReceberEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.emailsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button carregarButton;
        private System.Windows.Forms.TextBox deTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox paraTextBox;
        private System.Windows.Forms.DateTimePicker dataDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox emailsListBox;
        private System.Windows.Forms.BindingSource emailsBindingSource;
        private System.Windows.Forms.WebBrowser conteudoWebBrowser;
    }
}