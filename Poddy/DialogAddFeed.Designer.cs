namespace Poddy
{
  partial class DialogAddFeed
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
      this.tbUrl = new System.Windows.Forms.TextBox();
      this.lbUrl = new System.Windows.Forms.Label();
      this.btAdd = new System.Windows.Forms.Button();
      this.btCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // tbUrl
      // 
      this.tbUrl.Location = new System.Drawing.Point(41, 6);
      this.tbUrl.Name = "tbUrl";
      this.tbUrl.Size = new System.Drawing.Size(378, 20);
      this.tbUrl.TabIndex = 0;
      // 
      // lbUrl
      // 
      this.lbUrl.AutoSize = true;
      this.lbUrl.Location = new System.Drawing.Point(12, 9);
      this.lbUrl.Name = "lbUrl";
      this.lbUrl.Size = new System.Drawing.Size(23, 13);
      this.lbUrl.TabIndex = 1;
      this.lbUrl.Text = "Url:";
      // 
      // btAdd
      // 
      this.btAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btAdd.Location = new System.Drawing.Point(425, 4);
      this.btAdd.Name = "btAdd";
      this.btAdd.Size = new System.Drawing.Size(75, 23);
      this.btAdd.TabIndex = 2;
      this.btAdd.Text = "Add";
      this.btAdd.UseVisualStyleBackColor = true;
      this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
      // 
      // btCancel
      // 
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Location = new System.Drawing.Point(506, 3);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(75, 23);
      this.btCancel.TabIndex = 3;
      this.btCancel.Text = "Cancel";
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // DialogAddFeed
      // 
      this.AcceptButton = this.btAdd;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(505, 38);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.btAdd);
      this.Controls.Add(this.lbUrl);
      this.Controls.Add(this.tbUrl);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DialogAddFeed";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Add Feed";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbUrl;
    private System.Windows.Forms.Label lbUrl;
    private System.Windows.Forms.Button btAdd;
    private System.Windows.Forms.Button btCancel;
  }
}