using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;

namespace gc_proj_2.Objects {
	public class VectorPolygon : VectorObject {
		public override string Name => "Polygon";
		private Point [] points;
		private VectorLine [] edges;
		private Color color;

		private void recalculatePositions () {
			for (int i = 0; i < edges.Length; ++i) {
				edges [i].P1 = points [i];
				edges [i].P2 = points [(i + 1) % points.Length];
			}
		}

		[XmlIgnore]
		public Color Color {
			get { return color; }
			set { color = value; }
		}

		[XmlElement("Color")]
		public int ColorArgb {
			get { return Color.ToArgb (); }
			set { Color = Color.FromArgb (value); }
		}

		public Point [] Points {
			get { return points; }
			set {
				points = (Point []) value.Clone ();
				edges = new VectorLine [points.Length];

				for (int i = 0; i < edges.Length; ++i) {
					edges [i] = new VectorLine (points [i], points [(i + 1) % points.Length], color);
				}
			}
		}

		public VectorLine [] Edges {
			get { return edges; }
			set { edges = (VectorLine []) value.Clone (); }
		}

		public VectorPolygon () { }

		public VectorPolygon (Point [] points, Color color) {
			this.color = color;
			Points = points;
		}

		public override void Draw (byte [] pixels, int width, int height, int stride) {
			recalculatePositions ();
			foreach (var edge in edges) {
				edge.Draw (pixels, width, height, stride);
			}
		}

		public override VectorObject Clone () {
			throw new NotImplementedException ();
		}

		public override bool OnCursor (Point position) {
			foreach (var edge in edges) {
				if (edge.OnCursor (position)) {
					return true;
				}
			}

			return false;
		}

		public override void OpenEditor (MainWindow window) {
			window.CurrentTool = new Editors.PolygonEditor (window, this);
		}
	}
}
