using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using gc_proj_2.Objects;

namespace gc_proj_2.Editors {
	public class RectangleEditor : ObjectEditor {
		private VectorRectangle rect;
		private VectorCircle markerStart, markerEnd;
		private bool draggingStart, draggingEnd;

		public RectangleEditor (MainWindow window, VectorRectangle rect) : base (window) {
			this.rect = rect;

			markerStart = new VectorCircle (rect.P1, 7, Color.Red, 4);
			markerEnd = new VectorCircle (rect.P2, 7, Color.Red, 4);
		}

		public override string Name => "Rectangle Editor";

		public override void Initialize () {
			MainWindow.TempObjects.Add (markerStart);
			MainWindow.TempObjects.Add (markerEnd);
		}

		public override void OnColorChange (Color newColor) {
			rect.Color = newColor;
			MainWindow.Redraw ();
		}

		public override void OnMouseClick (MouseEventArgs e, PictureBox canvas, Point position) {

		}

		public override void OnMouseDown (MouseEventArgs e, PictureBox canvas, Point position) {
			if (markerStart.OnCursor (position)) {
				draggingStart = true;
			} else if (markerEnd.OnCursor (position)) {
				draggingEnd = true;
			}
		}

		public override void OnMouseMove (MouseEventArgs e, PictureBox canvas, Point lastPosition, Point position, bool isMouseDown) {
			Point newPos = new Point (
				(int) Math.Max (0, Math.Min (MainWindow.CanvasWidth - 1, position.X)),
				(int) Math.Max (0, Math.Min (MainWindow.CanvasHeight - 1, position.Y))
			);

			if (isMouseDown) {
				if (draggingStart) {
					rect.P1 = newPos;
					markerStart.Center = newPos;
					MainWindow.Redraw ();
				} else if (draggingEnd) {
					rect.P2 = newPos;
					markerEnd.Center = newPos;
					MainWindow.Redraw ();
				}
			} else {
				draggingStart = false;
				draggingEnd = false;
			}
		}

		public override void OnMouseUp (MouseEventArgs e, PictureBox canvas, Point position) {
			draggingStart = false;
			draggingEnd = false;
		}

		public override void OnKeyDown (KeyEventArgs e) {
			if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus) {
				rect.Thickness++;
				MainWindow.Redraw ();
			} else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus) {
				rect.Thickness--;
				MainWindow.Redraw ();
			} else if (e.KeyCode == Keys.Delete) {
				MainWindow.DeleteObject (rect);
			}
		}
	}
}
