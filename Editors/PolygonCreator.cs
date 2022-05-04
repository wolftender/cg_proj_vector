using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using gc_proj_2.Objects;

namespace gc_proj_2.Editors {
	public class PolygonCreator : ObjectEditor {
		public override string Name => "Polygon Creator";

		private List<Point> points;

		public PolygonCreator (MainWindow window) : base (window) {
			points = new List<Point> ();
		}

		public override void OnMouseClick (MouseEventArgs e, PictureBox canvas, Point position) {
			VectorCircle marker = new VectorCircle (position, 7, Color.Red, 4);

			if (points.Count > 0) {
				VectorLine edge = new VectorLine (points [points.Count - 1], position);
				MainWindow.TempObjects.Add (edge);
			}

			points.Add (position);
			MainWindow.TempObjects.Add (marker);
			MainWindow.Redraw ();
		}

		public override void OnKeyDown (KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				VectorPolygon polygon = new VectorPolygon (points.ToArray (), MainWindow.CurrentColor);
				MainWindow.AddObject ("polygon", polygon);
				MainWindow.CurrentTool = new PolygonEditor (MainWindow, polygon);
			}
		}
	}
}
