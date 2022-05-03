using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using gc_proj_2.Objects;

namespace gc_proj_2.Editors {
	public class LineEditor : ObjectEditor {
		private VectorLine line;

		public LineEditor (MainWindow window, VectorLine line) : base (window) {
			this.line = line;
		}

		public override void OnColorChange (Color newColor) {
			line.Color = newColor;
			MainWindow.Redraw ();
		}

		public override void OnMouseClick (MouseEventArgs e, PictureBox canvas, Point position) { 
		}

		public override void OnMouseDown (MouseEventArgs e, PictureBox canvas, Point position) { 
		}

		public override void OnMouseMove (MouseEventArgs e, PictureBox canvas, Point lastPosition, Point position, bool isMouseDown) { 
		}

		public override void OnMouseUp (MouseEventArgs e, PictureBox canvas, Point position) { 
		}
	}
}
