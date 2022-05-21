using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using gc_proj_2.Objects;

namespace gc_proj_2.Editors {
	public class LineCreator : ObjectEditor {
		public override string Name => "Line Creator";

		private Point start, end;
		private VectorCircle markerStart;
		private bool firstPointPlaced;

		public LineCreator (MainWindow window) : base (window) { }

		public override void OnMouseClick (MouseEventArgs e, PictureBox canvas, Point position) {
			if (!firstPointPlaced) {
				start = position;
				markerStart = new VectorCircle (start, 7, Color.Red, 4);
				MainWindow.TempObjects.Add (markerStart);
				firstPointPlaced = true;
				MainWindow.Redraw ();
			} else {
				end = position;
				VectorLine line = new GuptaSproullLine () {
					P1 = start, P2 = end, Color = MainWindow.CurrentColor, Thickness = 1
				};
				MainWindow.AddObject ("line", line);
				MainWindow.CurrentTool = new LineEditor (MainWindow, line);
			}
		}
	}
}
