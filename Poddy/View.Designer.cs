namespace Poddy
{
    partial class View
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
          this.toolStrip = new System.Windows.Forms.ToolStrip();
          this.toolStripButtonAddFeed = new System.Windows.Forms.ToolStripButton();
          this.toolStripButtonDeleteFeed = new System.Windows.Forms.ToolStripButton();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.tsbtOpenTargetFolder = new System.Windows.Forms.ToolStripButton();
          this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
          this.tsbtBrowse = new System.Windows.Forms.ToolStripButton();
          this.tstbTargetFolder = new System.Windows.Forms.ToolStripTextBox();
          this.tslTargetFolder = new System.Windows.Forms.ToolStripLabel();
          this.tsbtStartDownload = new System.Windows.Forms.ToolStripButton();
          this.tsbtStopDownload = new System.Windows.Forms.ToolStripButton();
          this.listBox = new System.Windows.Forms.ListBox();
          this.splitContainer = new System.Windows.Forms.SplitContainer();
          this.listView = new System.Windows.Forms.ListView();
          this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.statusStrip = new System.Windows.Forms.StatusStrip();
          this.toolStrip.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
          this.splitContainer.Panel1.SuspendLayout();
          this.splitContainer.Panel2.SuspendLayout();
          this.splitContainer.SuspendLayout();
          this.SuspendLayout();
          // 
          // toolStrip
          // 
          this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddFeed,
            this.toolStripButtonDeleteFeed,
            this.toolStripSeparator1,
            this.tsbtOpenTargetFolder,
            this.toolStripSeparator2,
            this.tsbtBrowse,
            this.tstbTargetFolder,
            this.tslTargetFolder,
            this.tsbtStartDownload,
            this.tsbtStopDownload});
          this.toolStrip.Location = new System.Drawing.Point(0, 0);
          this.toolStrip.Name = "toolStrip";
          this.toolStrip.Size = new System.Drawing.Size(729, 25);
          this.toolStrip.TabIndex = 0;
          this.toolStrip.Text = "toolStrip1";
          // 
          // toolStripButtonAddFeed
          // 
          this.toolStripButtonAddFeed.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddFeed.Image")));
          this.toolStripButtonAddFeed.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripButtonAddFeed.Name = "toolStripButtonAddFeed";
          this.toolStripButtonAddFeed.Size = new System.Drawing.Size(77, 22);
          this.toolStripButtonAddFeed.Text = "Add Feed";
          this.toolStripButtonAddFeed.Click += new System.EventHandler(this.toolStripButtonAddFeed_Click);
          // 
          // toolStripButtonDeleteFeed
          // 
          this.toolStripButtonDeleteFeed.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteFeed.Image")));
          this.toolStripButtonDeleteFeed.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.toolStripButtonDeleteFeed.Name = "toolStripButtonDeleteFeed";
          this.toolStripButtonDeleteFeed.Size = new System.Drawing.Size(98, 22);
          this.toolStripButtonDeleteFeed.Text = "Remove Feed";
          this.toolStripButtonDeleteFeed.Click += new System.EventHandler(this.toolStripButtonDeleteFeed_Click);
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
          // 
          // tsbtOpenTargetFolder
          // 
          this.tsbtOpenTargetFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsbtOpenTargetFolder.Image")));
          this.tsbtOpenTargetFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.tsbtOpenTargetFolder.Name = "tsbtOpenTargetFolder";
          this.tsbtOpenTargetFolder.Size = new System.Drawing.Size(92, 22);
          this.tsbtOpenTargetFolder.Text = "Open Folder";
          this.tsbtOpenTargetFolder.Click += new System.EventHandler(this.tsbtOpenTargetFolder_Click);
          // 
          // toolStripSeparator2
          // 
          this.toolStripSeparator2.Name = "toolStripSeparator2";
          this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
          // 
          // tsbtBrowse
          // 
          this.tsbtBrowse.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
          this.tsbtBrowse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
          this.tsbtBrowse.Image = ((System.Drawing.Image)(resources.GetObject("tsbtBrowse.Image")));
          this.tsbtBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.tsbtBrowse.Name = "tsbtBrowse";
          this.tsbtBrowse.Size = new System.Drawing.Size(23, 22);
          this.tsbtBrowse.Text = "...";
          this.tsbtBrowse.Click += new System.EventHandler(this.tsbtBrowse_Click);
          // 
          // tstbTargetFolder
          // 
          this.tstbTargetFolder.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
          this.tstbTargetFolder.Name = "tstbTargetFolder";
          this.tstbTargetFolder.Size = new System.Drawing.Size(150, 25);
          // 
          // tslTargetFolder
          // 
          this.tslTargetFolder.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
          this.tslTargetFolder.Name = "tslTargetFolder";
          this.tslTargetFolder.Size = new System.Drawing.Size(75, 22);
          this.tslTargetFolder.Text = "Targetfolder:";
          // 
          // tsbtStartDownload
          // 
          this.tsbtStartDownload.Image = ((System.Drawing.Image)(resources.GetObject("tsbtStartDownload.Image")));
          this.tsbtStartDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.tsbtStartDownload.Name = "tsbtStartDownload";
          this.tsbtStartDownload.Size = new System.Drawing.Size(51, 22);
          this.tsbtStartDownload.Text = "Start";
          this.tsbtStartDownload.Click += new System.EventHandler(this.tsbtStartDownload_Click);
          // 
          // tsbtStopDownload
          // 
          this.tsbtStopDownload.Image = ((System.Drawing.Image)(resources.GetObject("tsbtStopDownload.Image")));
          this.tsbtStopDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.tsbtStopDownload.Name = "tsbtStopDownload";
          this.tsbtStopDownload.Size = new System.Drawing.Size(51, 22);
          this.tsbtStopDownload.Text = "Stop";
          this.tsbtStopDownload.Click += new System.EventHandler(this.tsbtStopDownload_Click);
          // 
          // listBox
          // 
          this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
          this.listBox.FormattingEnabled = true;
          this.listBox.IntegralHeight = false;
          this.listBox.Location = new System.Drawing.Point(0, 0);
          this.listBox.Name = "listBox";
          this.listBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
          this.listBox.Size = new System.Drawing.Size(150, 363);
          this.listBox.Sorted = true;
          this.listBox.TabIndex = 1;
          this.listBox.SelectedValueChanged += new System.EventHandler(this.listBox_SelectedValueChanged);
          // 
          // splitContainer
          // 
          this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.splitContainer.Location = new System.Drawing.Point(12, 28);
          this.splitContainer.Name = "splitContainer";
          // 
          // splitContainer.Panel1
          // 
          this.splitContainer.Panel1.Controls.Add(this.listBox);
          // 
          // splitContainer.Panel2
          // 
          this.splitContainer.Panel2.Controls.Add(this.listView);
          this.splitContainer.Size = new System.Drawing.Size(705, 363);
          this.splitContainer.SplitterDistance = 150;
          this.splitContainer.TabIndex = 2;
          // 
          // listView
          // 
          this.listView.AllowColumnReorder = true;
          this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chStatus,
            this.chTitle,
            this.chDate,
            this.chDescription});
          this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
          this.listView.FullRowSelect = true;
          this.listView.Location = new System.Drawing.Point(0, 0);
          this.listView.Name = "listView";
          this.listView.ShowItemToolTips = true;
          this.listView.Size = new System.Drawing.Size(551, 363);
          this.listView.TabIndex = 0;
          this.listView.UseCompatibleStateImageBehavior = false;
          this.listView.View = System.Windows.Forms.View.Details;
          this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
          this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
          // 
          // chStatus
          // 
          this.chStatus.Text = "Status";
          // 
          // chTitle
          // 
          this.chTitle.Text = "Title";
          this.chTitle.Width = 280;
          // 
          // chDate
          // 
          this.chDate.Text = "Date";
          this.chDate.Width = 70;
          // 
          // chDescription
          // 
          this.chDescription.Text = "Description";
          this.chDescription.Width = 340;
          // 
          // statusStrip
          // 
          this.statusStrip.Location = new System.Drawing.Point(0, 394);
          this.statusStrip.Name = "statusStrip";
          this.statusStrip.Size = new System.Drawing.Size(729, 22);
          this.statusStrip.TabIndex = 3;
          this.statusStrip.Text = "statusStrip1";
          // 
          // View
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(729, 416);
          this.Controls.Add(this.statusStrip);
          this.Controls.Add(this.splitContainer);
          this.Controls.Add(this.toolStrip);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Name = "View";
          this.Text = "Poddy";
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.View_FormClosing);
          this.Load += new System.EventHandler(this.View_Load);
          this.toolStrip.ResumeLayout(false);
          this.toolStrip.PerformLayout();
          this.splitContainer.Panel1.ResumeLayout(false);
          this.splitContainer.Panel2.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
          this.splitContainer.ResumeLayout(false);
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddFeed;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteFeed;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripLabel tslTargetFolder;
        private System.Windows.Forms.ToolStripTextBox tstbTargetFolder;
        private System.Windows.Forms.ToolStripButton tsbtBrowse;
        private System.Windows.Forms.ToolStripButton tsbtOpenTargetFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtStartDownload;
        private System.Windows.Forms.ToolStripButton tsbtStopDownload;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.ColumnHeader chDate;


    }
}

