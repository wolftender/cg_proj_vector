using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using gc_proj_2.Objects;
using System.Diagnostics;

namespace gc_proj_2.Editors {
	public class PolygonEditor : ObjectEditor {
		private record ControlPoint (VectorCircle circle, int index);
		public override string Name => "Polygon Editor";
		
		private VectorPolygon polygon;
		private List<ControlPoint> controlPoints;
		private VectorCircle middlePoint;

		private int draggingIndex = -1;
		private bool dragging = false;

		public PolygonEditor (MainWindow window, VectorPolygon polygon) : base (window) {
			this.polygon = polygon;
			controlPoints = new List<ControlPoint> ();
		}

		public override void Initialize () {
			double sx = 0, sy = 0;
			for (int i = 0; i < polygon.Points.Length; ++i) {
				VectorCircle controlPoint = new VectorCircle (polygon.Points [i], 7, Color.Red, 4);
				controlPoints.Add (new ControlPoint (controlPoint, i));
				MainWindow.TempObjects.Add (controlPoint);

				sx += controlPoint.Center.X;
				sy += controlPoint.Center.Y;
			}

			sx = sx / polygon.Points.Length;
			sy = sy / polygon.Points.Length;

			middlePoint = new VectorCircle (new Point ((int)sx, (int)sy), 7, Color.Red, 4);
			MainWindow.TempObjects.Add (middlePoint);
		}

		public override void OnMouseDown (MouseEventArgs e, PictureBox canvas, Point position) {
			if (!dragging) {
				if (middlePoint.OnCursor (position)) {
					draggingIndex = -1;
					dragging = true;
					return;
				}

				foreach (var controlPoint in controlPoints) {
					if (controlPoint.circle.OnCursor (position)) {
						draggingIndex = controlPoint.index;
						dragging = true;
						return;
					}
				}
			}
		}

		public override void OnMouseMove (MouseEventArgs e, PictureBox canvas, Point lastPosition, Point position, bool isMouseDown) {
			if (isMouseDown) {
				if (dragging) {
					if (draggingIndex < 0) {
						Point oldPos = middlePoint.Center;
						Point newPos = position;

						int dx = newPos.X - oldPos.X;
						int dy = newPos.Y - oldPos.Y;

						Debug.WriteLine ("{0} {1}", dx, dy);

						middlePoint.Center = new Point (oldPos.X + dx, oldPos.Y + dy);

						foreach (var controlPoint in controlPoints) {
							int index = controlPoint.index;
							polygon.Points [index] = new Point (polygon.Points [index].X + dx, polygon.Points [index].Y + dy);
							controlPoint.circle.Center = polygon.Points [index];
						}
					} else {
						controlPoints [draggingIndex].circle.Center = position;
						polygon.Points [draggingIndex] = position;
					}

					MainWindow.Redraw ();
				}
			} else {
				dragging = false;
			}
		}
	}
}
