using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gc_proj_2.Objects {
	public class VectorRectangle : VectorObject {
		private Point p1;
		private Point p2;

		// lines
		private VectorLine leftLine;
		private VectorLine topLine;
		private VectorLine rightLine;
		private VectorLine bottomLine;

		public Point P1 {
			get { return p1; }
			set { p1 = value; }
		}

		public Point P2 {
			get { return p2; }
			set { p2 = value; }
		}

		public int Thickness { get; set; }

		[XmlIgnore]
		public Color Color { get; set; }

		[XmlElement ("Color")]
		public int ColorArgb {
			get { return Color.ToArgb (); }
			set { Color = Color.FromArgb (value); }
		}

		public override string Name => "Rectangle";

		private void refreshLines () {
			// A------B
			// |      |
			// C------D
			Point a = p1, b = new Point (p2.X, p1.Y), c = new Point (p1.X, p2.Y), d = p2;

			leftLine.P1 = a;
			leftLine.P2 = c;

			topLine.P1 = a;
			topLine.P2 = b;

			rightLine.P1 = b;
			rightLine.P2 = d;

			bottomLine.P1 = c;
			bottomLine.P2 = d;
		}

		public VectorRectangle () {
			leftLine = new VectorLine ();
			rightLine = new VectorLine ();
			topLine = new VectorLine ();
			bottomLine = new VectorLine ();
		}

		public override VectorObject Clone () {
			throw new NotImplementedException ();
		}

		public override void Draw (byte [] pixels, int width, int height, int stride) {
			refreshLines ();
			topLine.Draw (pixels, width, height, stride);
			bottomLine.Draw (pixels, width, height, stride);
			rightLine.Draw (pixels, width, height, stride);
			leftLine.Draw (pixels, width, height, stride);
		}

		public override bool OnCursor (Point position) {
			return topLine.OnCursor (position) 
				|| leftLine.OnCursor (position) 
				|| rightLine.OnCursor (position) 
				|| bottomLine.OnCursor (position);
		}

		public override void OpenEditor (MainWindow window) {
			window.CurrentTool = new Editors.RectangleEditor (window, this);
		}
	}
}
