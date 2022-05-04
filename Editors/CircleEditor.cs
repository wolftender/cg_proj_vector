using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using gc_proj_2.Objects;

namespace gc_proj_2.Editors {
	class CircleEditor : ObjectEditor {
		private VectorCircle circle;
		private VectorCircle markerCenter;
		private bool draggingCenter;

		public CircleEditor (MainWindow window, VectorCircle circle) : base (window) {
			this.circle = circle;
			markerCenter = new VectorCircle (circle.Center, 7, Color.Red, 4);
		}

		public override string Name => "Circle Editor";

		public override void Initialize () {
			MainWindow.TempObjects.Add (markerCenter);
		}

		public override void OnColorChange (Color newColor) {
			circle.Color = newColor;
			MainWindow.Redraw ();
		}

		public override void OnMouseClick (MouseEventArgs e, PictureBox canvas, Point position) {
		}

		public override void OnMouseDown (MouseEventArgs e, PictureBox canvas, Point position) {
			if (markerCenter.OnCursor (position)) {
				draggingCenter = true;
			}
		}

		public override void OnMouseMove (MouseEventArgs e, PictureBox canvas, Point lastPosition, Point position, bool isMouseDown) {
			Point newPos = new Point (
				(int) Math.Max (0, Math.Min (MainWindow.CanvasWidth - 1, position.X)),
				(int) Math.Max (0, Math.Min (MainWindow.CanvasHeight - 1, position.Y))
			);

			if (isMouseDown) {
				if (draggingCenter) {
					circle.Center = newPos;
					markerCenter.Center = newPos;
					MainWindow.Redraw ();
				}
			} else {
				draggingCenter = false;
			}
		}

		public override void OnMouseUp (MouseEventArgs e, PictureBox canvas, Point position) {
			draggingCenter = false;
		}
	}
}
