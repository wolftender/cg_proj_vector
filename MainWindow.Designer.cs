
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
			this.toolStripStatusLabelTool = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exportAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.polygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.clearAllObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layoutMain = new System.Windows.Forms.TableLayoutPanel();
			this.panelTools = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonColor = new System.Windows.Forms.Button();
			this.buttonCursor = new System.Windows.Forms.CheckBox();
			this.buttonLine = new System.Windows.Forms.CheckBox();
			this.buttonPolygon = new System.Windows.Forms.CheckBox();
			this.buttonCircle = new System.Windows.Forms.CheckBox();
			this.buttonRectangle = new System.Windows.Forms.CheckBox();
			this.canvas = new System.Windows.Forms.PictureBox();
			this.statusStrip.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.layoutMain.SuspendLayout();
			this.panelTools.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTool});
			this.statusStrip.Location = new System.Drawing.Point(0, 683);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1084, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabelTool
			// 
			this.toolStripStatusLabelTool.Name = "toolStripStatusLabelTool";
			this.toolStripStatusLabelTool.Size = new System.Drawing.Size(0, 17);
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
			this.menuStrip.Size = new System.Drawing.Size(1084, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(128, 6);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.saveAsToolStripMenuItem.Text = "Save as...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(128, 6);
			// 
			// exportAsToolStripMenuItem
			// 
			this.exportAsToolStripMenuItem.Name = "exportAsToolStripMenuItem";
			this.exportAsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.exportAsToolStripMenuItem.Text = "Export as...";
			this.exportAsToolStripMenuItem.Click += new System.EventHandler(this.exportAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(128, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addObjectToolStripMenuItem,
            this.colorSelectToolStripMenuItem,
            this.toolStripSeparator4,
            this.clearAllObjectsToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// addObjectToolStripMenuItem
			// 
			this.addObjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.circleToolStripMenuItem,
            this.polygonToolStripMenuItem});
			this.addObjectToolStripMenuItem.Name = "addObjectToolStripMenuItem";
			this.addObjectToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.addObjectToolStripMenuItem.Text = "Add Object";
			// 
			// lineToolStripMenuItem
			// 
			this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
			this.lineToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.lineToolStripMenuItem.Text = "Line";
			this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
			// 
			// circleToolStripMenuItem
			// 
			this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
			this.circleToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.circleToolStripMenuItem.Text = "Circle";
			this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
			// 
			// polygonToolStripMenuItem
			// 
			this.polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
			this.polygonToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.polygonToolStripMenuItem.Text = "Polygon";
			this.polygonToolStripMenuItem.Click += new System.EventHandler(this.polygonToolStripMenuItem_Click);
			// 
			// colorSelectToolStripMenuItem
			// 
			this.colorSelectToolStripMenuItem.Name = "colorSelectToolStripMenuItem";
			this.colorSelectToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.colorSelectToolStripMenuItem.Text = "Color Select";
			this.colorSelectToolStripMenuItem.Click += new System.EventHandler(this.colorSelectToolStripMenuItem_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(158, 6);
			// 
			// clearAllObjectsToolStripMenuItem
			// 
			this.clearAllObjectsToolStripMenuItem.Name = "clearAllObjectsToolStripMenuItem";
			this.clearAllObjectsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.clearAllObjectsToolStripMenuItem.Text = "Clear All Objects";
			this.clearAllObjectsToolStripMenuItem.Click += new System.EventHandler(this.clearAllObjectsToolStripMenuItem_Click);
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
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
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
			this.layoutMain.Location = new System.Drawing.Point(0, 27);
			this.layoutMain.Name = "layoutMain";
			this.layoutMain.RowCount = 2;
			this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
			this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.layoutMain.Size = new System.Drawing.Size(1084, 653);
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
			this.panelTools.Controls.Add(this.buttonRectangle);
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
			this.buttonColor.TabStop = false;
			this.buttonColor.UseVisualStyleBackColor = true;
			this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
			// 
			// buttonCursor
			// 
			this.buttonCursor.Appearance = System.Windows.Forms.Appearance.Button;
			this.buttonCursor.BackgroundImage = global::gc_proj_2.Properties.Resources.cursor;
			this.buttonCursor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonCursor.Location = new System.Drawing.Point(41, 3);
			this.buttonCursor.Name = "buttonCursor";
			this.buttonCursor.Size = new System.Drawing.Size(32, 32);
			this.buttonCursor.TabIndex = 4;
			this.buttonCursor.TabStop = false;
			this.buttonCursor.UseVisualStyleBackColor = true;
			this.buttonCursor.CheckedChanged += new System.EventHandler(this.buttonCursor_CheckedChanged);
			// 
			// buttonLine
			// 
			this.buttonLine.Appearance = System.Windows.Forms.Appearance.Button;
			this.buttonLine.BackgroundImage = global::gc_proj_2.Properties.Resources.line;
			this.buttonLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonLine.Location = new System.Drawing.Point(79, 3);
			this.buttonLine.Name = "buttonLine";
			this.buttonLine.Size = new System.Drawing.Size(32, 32);
			this.buttonLine.TabIndex = 1;
			this.buttonLine.TabStop = false;
			this.buttonLine.UseVisualStyleBackColor = true;
			this.buttonLine.CheckedChanged += new System.EventHandler(this.buttonLine_CheckedChanged);
			// 
			// buttonPolygon
			// 
			this.buttonPolygon.Appearance = System.Windows.Forms.Appearance.Button;
			this.buttonPolygon.BackgroundImage = global::gc_proj_2.Properties.Resources.polygon;
			this.buttonPolygon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonPolygon.Location = new System.Drawing.Point(117, 3);
			this.buttonPolygon.Name = "buttonPolygon";
			this.buttonPolygon.Size = new System.Drawing.Size(32, 32);
			this.buttonPolygon.TabIndex = 2;
			this.buttonPolygon.TabStop = false;
			this.buttonPolygon.UseVisualStyleBackColor = true;
			this.buttonPolygon.CheckedChanged += new System.EventHandler(this.buttonPolygon_CheckedChanged);
			// 
			// buttonCircle
			// 
			this.buttonCircle.Appearance = System.Windows.Forms.Appearance.Button;
			this.buttonCircle.BackgroundImage = global::gc_proj_2.Properties.Resources.circle;
			this.buttonCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonCircle.Location = new System.Drawing.Point(155, 3);
			this.buttonCircle.Name = "buttonCircle";
			this.buttonCircle.Size = new System.Drawing.Size(32, 32);
			this.buttonCircle.TabIndex = 3;
			this.buttonCircle.TabStop = false;
			this.buttonCircle.UseVisualStyleBackColor = true;
			this.buttonCircle.CheckedChanged += new System.EventHandler(this.buttonCircle_CheckedChanged);
			// 
			// buttonRectangle
			// 
			this.buttonRectangle.Appearance = System.Windows.Forms.Appearance.Button;
			this.buttonRectangle.BackgroundImage = global::gc_proj_2.Properties.Resources.rectangle;
			this.buttonRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonRectangle.Location = new System.Drawing.Point(193, 3);
			this.buttonRectangle.Name = "buttonRectangle";
			this.buttonRectangle.Size = new System.Drawing.Size(32, 32);
			this.buttonRectangle.TabIndex = 5;
			this.buttonRectangle.TabStop = false;
			this.buttonRectangle.UseVisualStyleBackColor = true;
			this.buttonRectangle.CheckedChanged += new System.EventHandler(this.buttonRectangle_CheckedChanged);
			// 
			// canvas
			// 
			this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.canvas.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.canvas.Location = new System.Drawing.Point(3, 44);
			this.canvas.Name = "canvas";
			this.canvas.Size = new System.Drawing.Size(1078, 606);
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
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1084, 705);
			this.Controls.Add(this.layoutMain);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainWindow";
			this.Text = "vector graphics editor v0.1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainWindow_KeyPress);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
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
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTool;
		private System.Windows.Forms.ToolStripMenuItem addObjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem polygonToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearAllObjectsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem colorSelectToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.CheckBox buttonRectangle;
	}
}

