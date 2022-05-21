using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using gc_proj_2.Objects;

namespace gc_proj_2.Editors {
	public class RectangleCreator : ObjectEditor {
		public override string Name => "Rectangle Creator";

		private Point start, end;
		private VectorCircle markerStart;
		private bool firstPointPlaced;

		public RectangleCreator (MainWindow window) : base (window) { }

		public override void OnMouseClick (MouseEventArgs e, PictureBox canvas, Point position) {
			if (!firstPointPlaced) {
				start = position;
				markerStart = new VectorCircle (start, 7, Color.Red, 4);
				MainWindow.TempObjects.Add (markerStart);
				firstPointPlaced = true;
				MainWindow.Redraw ();
			} else {
				end = position;
				VectorRectangle rect = new VectorRectangle () {
					P1 = start, P2 = end, Color = MainWindow.CurrentColor, Thickness = 1
				};
				MainWindow.AddObject ("rectangle", rect);
				MainWindow.CurrentTool = new RectangleEditor (MainWindow, rect);
			}
		}
	}
}
