
namespace gc_proj_2 {
	partial class MainWindow {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent () {
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
			this.canvas = new System.Windows.Forms.PictureBox();
			this.panelTools = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonColor = new System.Windows.Forms.Button();
			this.buttonLine = new System.Windows.Forms.Button();
			this.buttonPolygon = new System.Windows.Forms.Button();
			this.buttonCircle = new System.Windows.Forms.Button();
			this.menuStrip.SuspendLayout();
			this.layoutMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
			this.panelTools.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Location = new System.Drawing.Point(0, 683);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1084, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1084, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportAsToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.newToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.openToolStripMenuItem.Text = "Open";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.saveAsToolStripMenuItem.Text = "Save as...";
			// 
			// exportAsToolStripMenuItem
			// 
			this.exportAsToolStripMenuItem.Name = "exportAsToolStripMenuItem";
			this.exportAsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.exportAsToolStripMenuItem.Text = "Export as...";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.newToolStripMenuItem.Text = "New";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redoToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
			this.redoToolStripMenuItem.Text = "Redo";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.aboutToolStripMenuItem.Text = "About...";
			// 
			// layoutMain
			// 
			this.layoutMain.ColumnCount = 1;
			this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layoutMain.Controls.Add(this.canvas, 0, 1);
			this.layoutMain.Controls.Add(this.panelTools, 0, 0);
			this.layoutMain.Location = new System.Drawing.Point(0, 27);
			this.layoutMain.Name = "layoutMain";
			this.layoutMain.RowCount = 2;
			this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
			this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layoutMain.Size = new System.Drawing.Size(1084, 653);
			this.layoutMain.TabIndex = 2;
			// 
			// canvas
			// 
			this.canvas.Location = new System.Drawing.Point(3, 44);
			this.canvas.Name = "canvas";
			this.canvas.Size = new System.Drawing.Size(1078, 606);
			this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.canvas.TabIndex = 0;
			this.canvas.TabStop = false;
			// 
			// panelTools
			// 
			this.panelTools.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelTools.Controls.Add(this.buttonColor);
			this.panelTools.Controls.Add(this.buttonLine);
			this.panelTools.Controls.Add(this.buttonPolygon);
			this.panelTools.Controls.Add(this.buttonCircle);
			this.panelTools.Location = new System.Drawing.Point(3, 3);
			this.panelTools.Name = "panelTools";
			this.panelTools.Size = new System.Drawing.Size(1078, 35);
			this.panelTools.TabIndex = 1;
			// 
			// buttonColor
			// 
			this.buttonColor.Location = new System.Drawing.Point(3, 3);
			this.buttonColor.Name = "buttonColor";
			this.buttonColor.Size = new System.Drawing.Size(32, 32);
			this.buttonColor.TabIndex = 0;
			this.buttonColor.UseVisualStyleBackColor = true;
			this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
			// 
			// buttonLine
			// 
			this.buttonLine.BackgroundImage = global::gc_proj_2.Properties.Resources.line;
			this.buttonLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonLine.Location = new System.Drawing.Point(41, 3);
			this.buttonLine.Name = "buttonLine";
			this.buttonLine.Size = new System.Drawing.Size(32, 32);
			this.buttonLine.TabIndex = 1;
			this.buttonLine.UseVisualStyleBackColor = true;
			// 
			// buttonPolygon
			// 
			this.buttonPolygon.BackgroundImage = global::gc_proj_2.Properties.Resources.polygon;
			this.buttonPolygon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonPolygon.Location = new System.Drawing.Point(79, 3);
			this.buttonPolygon.Name = "buttonPolygon";
			this.buttonPolygon.Size = new System.Drawing.Size(32, 32);
			this.buttonPolygon.TabIndex = 2;
			this.buttonPolygon.UseVisualStyleBackColor = true;
			// 
			// buttonCircle
			// 
			this.buttonCircle.BackgroundImage = global::gc_proj_2.Properties.Resources.circle;
			this.buttonCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonCircle.Location = new System.Drawing.Point(117, 3);
			this.buttonCircle.Name = "buttonCircle";
			this.buttonCircle.Size = new System.Drawing.Size(32, 32);
			this.buttonCircle.TabIndex = 3;
			this.buttonCircle.UseVisualStyleBackColor = true;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1084, 705);
			this.Controls.Add(this.layoutMain);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainWindow";
			this.Text = "vector graphics editor v0.1";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.layoutMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
			this.panelTools.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel layoutMain;
		private System.Windows.Forms.PictureBox canvas;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.FlowLayoutPanel panelTools;
		private System.Windows.Forms.Button buttonColor;
		private System.Windows.Forms.Button buttonLine;
		private System.Windows.Forms.Button buttonPolygon;
		private System.Windows.Forms.Button buttonCircle;
	}
}

