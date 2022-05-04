
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
			this.panelTools = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonColor = new System.Windows.Forms.Button();
			this.buttonCursor = new System.Windows.Forms.CheckBox();
			this.buttonLine = new System.Windows.Forms.CheckBox();
			this.buttonPolygon = new System.Windows.Forms.CheckBox();
			this.buttonCircle = new System.Windows.Forms.CheckBox();
			this.canvas = new System.Windows.Forms.PictureBox();
			this.menuStrip.SuspendLayout();
			this.layoutMain.SuspendLayout();
			this.panelTools.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Location = new System.Drawing.Point(0, 918);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip.Size = new System.Drawing.Size(1239, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			// 
			// menuStrip
			// 
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
			this.menuStrip.Size = new System.Drawing.Size(1239, 30);
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
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
			this.openToolStripMenuItem.Text = "Open";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
			this.saveAsToolStripMenuItem.Text = "Save as...";
			// 
			// exportAsToolStripMenuItem
			// 
			this.exportAsToolStripMenuItem.Name = "exportAsToolStripMenuItem";
			this.exportAsToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
			this.exportAsToolStripMenuItem.Text = "Export as...";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
			this.newToolStripMenuItem.Text = "New";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redoToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
			this.redoToolStripMenuItem.Text = "Redo";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
			this.aboutToolStripMenuItem.Text = "About...";
			// 
			// layoutMain
			// 
			this.layoutMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.layoutMain.ColumnCount = 1;
			this.layoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layoutMain.Controls.Add(this.panelTools, 0, 0);
			this.layoutMain.Controls.Add(this.canvas, 0, 1);
			this.layoutMain.Location = new System.Drawing.Point(0, 36);
			this.layoutMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.layoutMain.Name = "layoutMain";
			this.layoutMain.RowCount = 2;
			this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
			this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.layoutMain.Size = new System.Drawing.Size(1239, 871);
			this.layoutMain.TabIndex = 2;
			// 
			// panelTools
			// 
			this.panelTools.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelTools.Controls.Add(this.buttonColor);
			this.panelTools.Controls.Add(this.buttonCursor);
			this.panelTools.Controls.Add(this.buttonLine);
			this.panelTools.Controls.Add(this.buttonPolygon);
			this.panelTools.Controls.Add(this.buttonCircle);
			this.panelTools.Location = new System.Drawing.Point(3, 4);
			this.panelTools.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panelTools.Name = "panelTools";
			this.panelTools.Size = new System.Drawing.Size(1233, 47);
			this.panelTools.TabIndex = 1;
			// 
			// buttonColor
			// 
			this.buttonColor.Location = new System.Drawing.Point(3, 4);
			this.buttonColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonColor.Name = "buttonColor";
			this.buttonColor.Size = new System.Drawing.Size(37, 43);
			this.buttonColor.TabIndex = 0;
			this.buttonColor.UseVisualStyleBackColor = true;
			this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
			// 
			// buttonCursor
			// 
			this.buttonCursor.Appearance = System.Windows.Forms.Appearance.Button;
			this.buttonCursor.BackgroundImage = global::gc_proj_2.Properties.Resources.cursor;
			this.buttonCursor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonCursor.Location = new System.Drawing.Point(46, 4);
			this.buttonCursor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonCursor.Name = "buttonCursor";
			this.buttonCursor.Size = new System.Drawing.Size(37, 43);
			this.buttonCursor.TabIndex = 4;
			this.buttonCursor.UseVisualStyleBackColor = true;
			this.buttonCursor.CheckedChanged += new System.EventHandler(this.buttonCursor_CheckedChanged);
			// 
			// buttonLine
			// 
			this.buttonLine.Appearance = System.Windows.Forms.Appearance.Button;
			this.buttonLine.BackgroundImage = global::gc_proj_2.Properties.Resources.line;
			this.buttonLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonLine.Location = new System.Drawing.Point(89, 4);
			this.buttonLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonLine.Name = "buttonLine";
			this.buttonLine.Size = new System.Drawing.Size(37, 43);
			this.buttonLine.TabIndex = 1;
			this.buttonLine.UseVisualStyleBackColor = true;
			this.buttonLine.CheckedChanged += new System.EventHandler(this.buttonLine_CheckedChanged);
			// 
			// buttonPolygon
			// 
			this.buttonPolygon.Appearance = System.Windows.Forms.Appearance.Button;
			this.buttonPolygon.BackgroundImage = global::gc_proj_2.Properties.Resources.polygon;
			this.buttonPolygon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonPolygon.Location = new System.Drawing.Point(132, 4);
			this.buttonPolygon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonPolygon.Name = "buttonPolygon";
			this.buttonPolygon.Size = new System.Drawing.Size(37, 43);
			this.buttonPolygon.TabIndex = 2;
			this.buttonPolygon.UseVisualStyleBackColor = true;
			this.buttonPolygon.CheckedChanged += new System.EventHandler(this.buttonPolygon_CheckedChanged);
			// 
			// buttonCircle
			// 
			this.buttonCircle.Appearance = System.Windows.Forms.Appearance.Button;
			this.buttonCircle.BackgroundImage = global::gc_proj_2.Properties.Resources.circle;
			this.buttonCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonCircle.Location = new System.Drawing.Point(175, 4);
			this.buttonCircle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonCircle.Name = "buttonCircle";
			this.buttonCircle.Size = new System.Drawing.Size(37, 43);
			this.buttonCircle.TabIndex = 3;
			this.buttonCircle.UseVisualStyleBackColor = true;
			this.buttonCircle.CheckedChanged += new System.EventHandler(this.buttonCircle_CheckedChanged);
			// 
			// canvas
			// 
			this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.canvas.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.canvas.Location = new System.Drawing.Point(3, 59);
			this.canvas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.canvas.Name = "canvas";
			this.canvas.Size = new System.Drawing.Size(1233, 808);
			this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.canvas.TabIndex = 2;
			this.canvas.TabStop = false;
			this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
			this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
			this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
			this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1239, 940);
			this.Controls.Add(this.layoutMain);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainWindow";
			this.Text = "vector graphics editor v0.1";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainWindow_KeyPress);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.layoutMain.ResumeLayout(false);
			this.panelTools.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
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
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.FlowLayoutPanel panelTools;
		private System.Windows.Forms.Button buttonColor;
		private System.Windows.Forms.CheckBox buttonLine;
		private System.Windows.Forms.CheckBox buttonPolygon;
		private System.Windows.Forms.CheckBox buttonCircle;
		private System.Windows.Forms.PictureBox canvas;
		private System.Windows.Forms.CheckBox buttonCursor;
	}
}

