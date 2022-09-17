namespace LiveSplit.HitCounterManagerConnector
{
    partial class HitCounterManagerConnectorSettings
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblConnected = new System.Windows.Forms.Label();
            this.txtConnected = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnReconnect = new System.Windows.Forms.Button();
            this.txtVersion = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.Location = new System.Drawing.Point(10, 45);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(74, 13);
            this.lblConnected.TabIndex = 2;
            this.lblConnected.Text = "Connected to:";
            this.lblConnected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtConnected
            // 
            this.txtConnected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtConnected.Location = new System.Drawing.Point(90, 40);
            this.txtConnected.Name = "txtConnected";
            this.txtConnected.Size = new System.Drawing.Size(376, 23);
            this.txtConnected.TabIndex = 3;
            this.txtConnected.Text = "<None>";
            this.txtConnected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.txtConnected, "The connected HitCounterManager process.");
            // 
            // btnReconnect
            // 
            this.btnReconnect.Location = new System.Drawing.Point(90, 66);
            this.btnReconnect.Name = "btnReconnect";
            this.btnReconnect.Size = new System.Drawing.Size(75, 23);
            this.btnReconnect.TabIndex = 4;
            this.btnReconnect.Text = "Reconnect";
            this.toolTip1.SetToolTip(this.btnReconnect, "Reestablish the connection or try to connect again if not connected yet.");
            this.btnReconnect.UseVisualStyleBackColor = true;
            this.btnReconnect.Click += new System.EventHandler(this.btnReconnect_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtVersion.Location = new System.Drawing.Point(90, 7);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(376, 23);
            this.txtVersion.TabIndex = 1;
            this.txtVersion.Text = "0.0.0.0";
            this.txtVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.txtVersion, "Plugin version");
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(10, 12);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 13);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version:";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HitCounterManagerConnectorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnReconnect);
            this.Controls.Add(this.txtConnected);
            this.Controls.Add(this.lblConnected);
            this.Name = "HitCounterManagerConnectorSettings";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(476, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnected;
        public System.Windows.Forms.Label txtConnected;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnReconnect;
        public System.Windows.Forms.Label txtVersion;
        private System.Windows.Forms.Label lblVersion;
    }
}
