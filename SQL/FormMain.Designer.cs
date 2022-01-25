namespace SQL
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageConnection = new System.Windows.Forms.TabPage();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxDb = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelDb = new System.Windows.Forms.Label();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.labelDsn = new System.Windows.Forms.Label();
            this.textBoxDsn = new System.Windows.Forms.TextBox();
            this.radioButtonOdbc = new System.Windows.Forms.RadioButton();
            this.radioButtonNoOdbc = new System.Windows.Forms.RadioButton();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.tabPageQuery = new System.Windows.Forms.TabPage();
            this.buttonNonQuery = new System.Windows.Forms.Button();
            this.buttonScalar = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPageConnection.SuspendLayout();
            this.tabPageQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageConnection);
            this.tabControl.Controls.Add(this.tabPageQuery);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(913, 406);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageConnection
            // 
            this.tabPageConnection.Controls.Add(this.textBoxPassword);
            this.tabPageConnection.Controls.Add(this.textBoxUser);
            this.tabPageConnection.Controls.Add(this.textBoxDb);
            this.tabPageConnection.Controls.Add(this.labelPassword);
            this.tabPageConnection.Controls.Add(this.labelUser);
            this.tabPageConnection.Controls.Add(this.labelDb);
            this.tabPageConnection.Controls.Add(this.labelServer);
            this.tabPageConnection.Controls.Add(this.textBoxServer);
            this.tabPageConnection.Controls.Add(this.labelDsn);
            this.tabPageConnection.Controls.Add(this.textBoxDsn);
            this.tabPageConnection.Controls.Add(this.radioButtonOdbc);
            this.tabPageConnection.Controls.Add(this.radioButtonNoOdbc);
            this.tabPageConnection.Controls.Add(this.buttonDisconnect);
            this.tabPageConnection.Controls.Add(this.buttonHelp);
            this.tabPageConnection.Controls.Add(this.buttonConnect);
            this.tabPageConnection.Controls.Add(this.labelMessage);
            this.tabPageConnection.Controls.Add(this.textBoxStatus);
            this.tabPageConnection.Location = new System.Drawing.Point(4, 25);
            this.tabPageConnection.Name = "tabPageConnection";
            this.tabPageConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnection.Size = new System.Drawing.Size(905, 377);
            this.tabPageConnection.TabIndex = 0;
            this.tabPageConnection.Text = "Connection";
            this.tabPageConnection.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxPassword.Location = new System.Drawing.Point(630, 141);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(265, 26);
            this.textBoxPassword.TabIndex = 17;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxUser.Location = new System.Drawing.Point(630, 111);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(265, 26);
            this.textBoxUser.TabIndex = 16;
            // 
            // textBoxDb
            // 
            this.textBoxDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxDb.Location = new System.Drawing.Point(630, 81);
            this.textBoxDb.Name = "textBoxDb";
            this.textBoxDb.Size = new System.Drawing.Size(265, 26);
            this.textBoxDb.TabIndex = 15;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelPassword.Location = new System.Drawing.Point(532, 141);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(83, 20);
            this.labelPassword.TabIndex = 14;
            this.labelPassword.Text = "Password";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelUser.Location = new System.Drawing.Point(532, 111);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(45, 20);
            this.labelUser.TabIndex = 13;
            this.labelUser.Text = "User";
            // 
            // labelDb
            // 
            this.labelDb.AutoSize = true;
            this.labelDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDb.Location = new System.Drawing.Point(532, 81);
            this.labelDb.Name = "labelDb";
            this.labelDb.Size = new System.Drawing.Size(81, 20);
            this.labelDb.TabIndex = 12;
            this.labelDb.Text = "Database";
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelServer.Location = new System.Drawing.Point(532, 51);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(58, 20);
            this.labelServer.TabIndex = 11;
            this.labelServer.Text = "Server";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxServer.Location = new System.Drawing.Point(630, 48);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(265, 26);
            this.textBoxServer.TabIndex = 10;
            // 
            // labelDsn
            // 
            this.labelDsn.AutoSize = true;
            this.labelDsn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDsn.Location = new System.Drawing.Point(8, 51);
            this.labelDsn.Name = "labelDsn";
            this.labelDsn.Size = new System.Drawing.Size(45, 20);
            this.labelDsn.TabIndex = 9;
            this.labelDsn.Text = "DSN";
            // 
            // textBoxDsn
            // 
            this.textBoxDsn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxDsn.Location = new System.Drawing.Point(59, 48);
            this.textBoxDsn.Name = "textBoxDsn";
            this.textBoxDsn.Size = new System.Drawing.Size(265, 26);
            this.textBoxDsn.TabIndex = 7;
            // 
            // radioButtonOdbc
            // 
            this.radioButtonOdbc.AutoSize = true;
            this.radioButtonOdbc.Checked = true;
            this.radioButtonOdbc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButtonOdbc.Location = new System.Drawing.Point(11, 18);
            this.radioButtonOdbc.Name = "radioButtonOdbc";
            this.radioButtonOdbc.Size = new System.Drawing.Size(182, 24);
            this.radioButtonOdbc.TabIndex = 6;
            this.radioButtonOdbc.TabStop = true;
            this.radioButtonOdbc.Text = "Connect with ODBC";
            this.radioButtonOdbc.UseVisualStyleBackColor = true;
            this.radioButtonOdbc.CheckedChanged += new System.EventHandler(this.radioButtonOdbc_CheckedChanged);
            // 
            // radioButtonNoOdbc
            // 
            this.radioButtonNoOdbc.AutoSize = true;
            this.radioButtonNoOdbc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonNoOdbc.Location = new System.Drawing.Point(536, 18);
            this.radioButtonNoOdbc.Name = "radioButtonNoOdbc";
            this.radioButtonNoOdbc.Size = new System.Drawing.Size(205, 24);
            this.radioButtonNoOdbc.TabIndex = 5;
            this.radioButtonNoOdbc.Text = "Connect without ODBC";
            this.radioButtonNoOdbc.UseVisualStyleBackColor = true;
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonDisconnect.Location = new System.Drawing.Point(12, 186);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(213, 39);
            this.buttonDisconnect.TabIndex = 4;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonHelp.Location = new System.Drawing.Point(493, 186);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(404, 39);
            this.buttonHelp.TabIndex = 3;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonConnect.Location = new System.Drawing.Point(245, 186);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(213, 39);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(126, 237);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(99, 25);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "Message:";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Location = new System.Drawing.Point(245, 237);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(652, 132);
            this.textBoxStatus.TabIndex = 0;
            // 
            // tabPageQuery
            // 
            this.tabPageQuery.Controls.Add(this.buttonNonQuery);
            this.tabPageQuery.Controls.Add(this.buttonScalar);
            this.tabPageQuery.Controls.Add(this.buttonSelect);
            this.tabPageQuery.Controls.Add(this.textBoxResult);
            this.tabPageQuery.Controls.Add(this.textBoxQuery);
            this.tabPageQuery.Location = new System.Drawing.Point(4, 25);
            this.tabPageQuery.Name = "tabPageQuery";
            this.tabPageQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuery.Size = new System.Drawing.Size(905, 377);
            this.tabPageQuery.TabIndex = 1;
            this.tabPageQuery.Text = "Queries";
            this.tabPageQuery.UseVisualStyleBackColor = true;
            // 
            // buttonNonQuery
            // 
            this.buttonNonQuery.Enabled = false;
            this.buttonNonQuery.Location = new System.Drawing.Point(718, 96);
            this.buttonNonQuery.Name = "buttonNonQuery";
            this.buttonNonQuery.Size = new System.Drawing.Size(179, 39);
            this.buttonNonQuery.TabIndex = 4;
            this.buttonNonQuery.Text = "Non Query";
            this.buttonNonQuery.UseVisualStyleBackColor = true;
            // 
            // buttonScalar
            // 
            this.buttonScalar.Enabled = false;
            this.buttonScalar.Location = new System.Drawing.Point(718, 51);
            this.buttonScalar.Name = "buttonScalar";
            this.buttonScalar.Size = new System.Drawing.Size(179, 39);
            this.buttonScalar.TabIndex = 3;
            this.buttonScalar.Text = "Scalar";
            this.buttonScalar.UseVisualStyleBackColor = true;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Enabled = false;
            this.buttonSelect.Location = new System.Drawing.Point(718, 6);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(179, 39);
            this.buttonSelect.TabIndex = 2;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxResult.Location = new System.Drawing.Point(3, 208);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResult.Size = new System.Drawing.Size(899, 166);
            this.textBoxResult.TabIndex = 1;
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Location = new System.Drawing.Point(4, 4);
            this.textBoxQuery.Multiline = true;
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxQuery.Size = new System.Drawing.Size(708, 198);
            this.textBoxQuery.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 406);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL";
            this.tabControl.ResumeLayout(false);
            this.tabPageConnection.ResumeLayout(false);
            this.tabPageConnection.PerformLayout();
            this.tabPageQuery.ResumeLayout(false);
            this.tabPageQuery.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageConnection;
        private System.Windows.Forms.RadioButton radioButtonOdbc;
        private System.Windows.Forms.RadioButton radioButtonNoOdbc;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TabPage tabPageQuery;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxDb;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelDb;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label labelDsn;
        private System.Windows.Forms.TextBox textBoxDsn;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.Button buttonNonQuery;
        private System.Windows.Forms.Button buttonScalar;
    }
}

