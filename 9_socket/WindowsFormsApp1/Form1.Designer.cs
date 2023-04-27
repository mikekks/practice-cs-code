namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_server = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txt_all = new System.Windows.Forms.TextBox();
            this.txt_serverIp = new System.Windows.Forms.TextBox();
            this.txt_send = new System.Windows.Forms.TextBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_server
            // 
            this.btn_server.Location = new System.Drawing.Point(730, 60);
            this.btn_server.Name = "btn_server";
            this.btn_server.Size = new System.Drawing.Size(75, 23);
            this.btn_server.TabIndex = 0;
            this.btn_server.Text = "서버 켜기";
            this.btn_server.UseVisualStyleBackColor = true;
            this.btn_server.Click += new System.EventHandler(this.btn_server_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(730, 121);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "서버 연결";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_all
            // 
            this.txt_all.Location = new System.Drawing.Point(497, 48);
            this.txt_all.Multiline = true;
            this.txt_all.Name = "txt_all";
            this.txt_all.Size = new System.Drawing.Size(203, 291);
            this.txt_all.TabIndex = 2;
            // 
            // txt_serverIp
            // 
            this.txt_serverIp.Location = new System.Drawing.Point(715, 182);
            this.txt_serverIp.Name = "txt_serverIp";
            this.txt_serverIp.Size = new System.Drawing.Size(100, 21);
            this.txt_serverIp.TabIndex = 3;
            this.txt_serverIp.TextChanged += new System.EventHandler(this.txt_serverIp_TextChanged);
            // 
            // txt_send
            // 
            this.txt_send.Location = new System.Drawing.Point(472, 357);
            this.txt_send.Name = "txt_send";
            this.txt_send.Size = new System.Drawing.Size(242, 21);
            this.txt_send.TabIndex = 4;
            this.txt_send.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_send_KeyDown);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(740, 294);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "종료";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(740, 355);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 6;
            this.btn_send.Text = "보내기";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(31, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(430, 305);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 515);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.txt_send);
            this.Controls.Add(this.txt_serverIp);
            this.Controls.Add(this.txt_all);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.btn_server);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_server;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txt_all;
        private System.Windows.Forms.TextBox txt_serverIp;
        private System.Windows.Forms.TextBox txt_send;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

