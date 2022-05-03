using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace gc_proj_2 {
	public abstract class ObjectEditor {
		private MainWindow mainWindow;

		public MainWindow MainWindow {
			get { return mainWindow; }
		}

		public ObjectEditor (MainWindow window) {
			mainWindow = window;
		}

		public virtual void Initialize () { }
		public virtual void OnColorChange (Color newColor) { }
		public virtual void OnMouseClick (MouseEventArgs e, PictureBox canvas, Point position) { }
		public virtual void OnMouseDown (MouseEventArgs e, PictureBox canvas, Point position) { }
		public virtual void OnMouseMove (MouseEventArgs e, PictureBox canvas, Point lastPosition, Point position, bool isMouseDown) { }
		public virtual void OnMouseUp (MouseEventArgs e, PictureBox canvas, Point position) { }
	}
}
