namespace MDO.Desktop.Forms
{
    partial class MainForm
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
            txt_Result = new TextBox();
            txt_ServerName = new TextBox();
            txt_DatabaseName = new TextBox();
            txt_UserName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txt_Password = new TextBox();
            btn_Connect = new Button();
            btn_GetVersion = new Button();
            btn_Disconnect = new Button();
            panel_databaseInfo = new Panel();
            panel_databaseInfo.SuspendLayout();
            SuspendLayout();
            // 
            // txt_Result
            // 
            txt_Result.Location = new Point(12, 190);
            txt_Result.Multiline = true;
            txt_Result.Name = "txt_Result";
            txt_Result.ReadOnly = true;
            txt_Result.ScrollBars = ScrollBars.Vertical;
            txt_Result.Size = new Size(450, 217);
            txt_Result.TabIndex = 0;
            // 
            // txt_ServerName
            // 
            txt_ServerName.Font = new Font("Segoe UI", 10F);
            txt_ServerName.Location = new Point(106, 4);
            txt_ServerName.Name = "txt_ServerName";
            txt_ServerName.Size = new Size(333, 25);
            txt_ServerName.TabIndex = 1;
            txt_ServerName.Text = "DESKTOP-G0ATUAA\\SQLEXPRESS";
            // 
            // txt_DatabaseName
            // 
            txt_DatabaseName.Font = new Font("Segoe UI", 10F);
            txt_DatabaseName.Location = new Point(106, 33);
            txt_DatabaseName.Name = "txt_DatabaseName";
            txt_DatabaseName.Size = new Size(333, 25);
            txt_DatabaseName.TabIndex = 1;
            txt_DatabaseName.Text = "MDO_Database";
            // 
            // txt_UserName
            // 
            txt_UserName.Font = new Font("Segoe UI", 10F);
            txt_UserName.Location = new Point(106, 62);
            txt_UserName.Name = "txt_UserName";
            txt_UserName.Size = new Size(333, 25);
            txt_UserName.TabIndex = 1;
            txt_UserName.Text = "sa";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 7);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 2;
            label1.Text = "Server Name  ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 36);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 2;
            label2.Text = "Database Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 65);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 2;
            label3.Text = "Login:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 94);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 2;
            label4.Text = "Password:";
            // 
            // txt_Password
            // 
            txt_Password.Font = new Font("Segoe UI", 10F);
            txt_Password.Location = new Point(106, 91);
            txt_Password.Name = "txt_Password";
            txt_Password.PasswordChar = '*';
            txt_Password.Size = new Size(333, 25);
            txt_Password.TabIndex = 1;
            txt_Password.Text = "123xxx123";
            // 
            // btn_Connect
            // 
            btn_Connect.Location = new Point(12, 141);
            btn_Connect.Name = "btn_Connect";
            btn_Connect.Size = new Size(126, 34);
            btn_Connect.TabIndex = 3;
            btn_Connect.Text = "Connect";
            btn_Connect.UseVisualStyleBackColor = true;
            btn_Connect.Click += btn_Connect_Click;
            // 
            // btn_GetVersion
            // 
            btn_GetVersion.Location = new Point(159, 141);
            btn_GetVersion.Name = "btn_GetVersion";
            btn_GetVersion.Size = new Size(126, 34);
            btn_GetVersion.TabIndex = 3;
            btn_GetVersion.Text = "Get Version";
            btn_GetVersion.UseVisualStyleBackColor = true;
            btn_GetVersion.Click += btn_GetVersion_Click;
            // 
            // btn_Disconnect
            // 
            btn_Disconnect.Location = new Point(306, 141);
            btn_Disconnect.Name = "btn_Disconnect";
            btn_Disconnect.Size = new Size(126, 34);
            btn_Disconnect.TabIndex = 3;
            btn_Disconnect.Text = "Disconnect";
            btn_Disconnect.UseVisualStyleBackColor = true;
            btn_Disconnect.Click += btn_Disconnect_Click;
            // 
            // panel_databaseInfo
            // 
            panel_databaseInfo.Controls.Add(txt_Password);
            panel_databaseInfo.Controls.Add(txt_ServerName);
            panel_databaseInfo.Controls.Add(txt_DatabaseName);
            panel_databaseInfo.Controls.Add(txt_UserName);
            panel_databaseInfo.Controls.Add(label4);
            panel_databaseInfo.Controls.Add(label1);
            panel_databaseInfo.Controls.Add(label3);
            panel_databaseInfo.Controls.Add(label2);
            panel_databaseInfo.Location = new Point(12, 12);
            panel_databaseInfo.Name = "panel_databaseInfo";
            panel_databaseInfo.Size = new Size(450, 123);
            panel_databaseInfo.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 419);
            Controls.Add(panel_databaseInfo);
            Controls.Add(btn_Disconnect);
            Controls.Add(btn_GetVersion);
            Controls.Add(btn_Connect);
            Controls.Add(txt_Result);
            MaximumSize = new Size(490, 458);
            MinimumSize = new Size(490, 458);
            Name = "MainForm";
            Text = "ManForm";
            panel_databaseInfo.ResumeLayout(false);
            panel_databaseInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Result;
        private TextBox txt_ServerName;
        private TextBox txt_DatabaseName;
        private TextBox txt_UserName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txt_Password;
        private Button btn_Connect;
        private Button btn_GetVersion;
        private Button btn_Disconnect;
        private Panel panel_databaseInfo;
    }
}