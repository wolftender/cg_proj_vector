using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gc_proj_2.Editors {
	public class ArcEditor : ObjectEditor {
		private Objects.VectorArc arc;
		private Objects.VectorCircle markerA, markerB, markerC;
		private bool dragA, dragB, dragC;

		public ArcEditor (MainWindow window, Objects.VectorArc arc) : base (window) {
			this.arc = arc;
		}

		public override void Initialize () {
			markerA = new Objects.VectorCircle (arc.A, 7, Color.Red, 4);
			markerB = new Objects.VectorCircle (arc.B, 7, Color.Green, 4);
			markerC = new Objects.VectorCircle (arc.C, 7, Color.Blue, 4);

			MainWindow.TempObjects.Add (markerA);
			MainWindow.TempObjects.Add (markerB);
			MainWindow.TempObjects.Add (markerC);
		}

		public override string Name => "Arc Editor";

		public override void OnMouseDown (MouseEventArgs e, PictureBox canvas, Point position) {
			if (markerA.OnCursor (position)) {
				dragA = true;
				dragB = false;
				dragC = false;
			} else if (markerB.OnCursor (position)) {
				dragA = false;
				dragB = true;
				dragC = false;
			} else if (markerC.OnCursor (position)) {
				dragA = false;
				dragB = false;
				dragC = true;
			}
		}

		public override void OnMouseMove (MouseEventArgs e, PictureBox canvas, Point lastPosition, Point position, bool isMouseDown) {
			if (isMouseDown) {
				if (dragA) {
					arc.A = position;
					markerA.Center = position;
				} else if (dragB) {
					arc.B = position;
					markerB.Center = position;
				} else if (dragC) {
					arc.C = position;
					markerC.Center = position;
				}

				MainWindow.Redraw ();
			} else {
				dragA = false;
				dragB = false;
				dragC = false;
			}
		}
	}
}
