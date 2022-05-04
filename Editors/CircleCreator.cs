using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace gc_proj_2.Editors {
	public class CircleCreator : ObjectEditor {
		public override string Name => "Circle Creator";
		private bool firstPointPlaced;
		private Objects.VectorCircle circle;

		public CircleCreator (MainWindow window) : base (window) { }

		public override void OnMouseClick (MouseEventArgs e, PictureBox canvas, Point position) {
			if (!firstPointPlaced) {
				circle = new Objects.VectorCircle (position, 1, MainWindow.CurrentColor);
				MainWindow.TempObjects.Add (circle);
				MainWindow.Redraw ();
				firstPointPlaced = true;
			} else {
				endEditor ();
			}
		}

		public override void OnMouseMove (MouseEventArgs e, PictureBox canvas, Point lastPosition, Point position, bool isMouseDown) {
			if (firstPointPlaced) {
				double dx = circle.Center.X - position.X;
				double dy = circle.Center.Y - position.Y;
				double radius = Math.Sqrt (dx * dx + dy * dy);
				circle.Radius = (int) radius;
				MainWindow.Redraw ();
			}
		}

		private void endEditor () {
			MainWindow.AddObject ("circle", circle);
			MainWindow.CurrentTool = new CircleEditor (MainWindow, circle);
		}
	}
}
