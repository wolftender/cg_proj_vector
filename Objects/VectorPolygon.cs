using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace gc_proj_2.Objects {
	public class VectorPolygon : IVectorObject {
		public string Name => "Polygon";
		private Point [] points;
		private VectorLine [] edges;

		private void recalculatePositions () {
			for (int i = 0; i < edges.Length; ++i) {
				edges [i].P1 = points [i];
				edges [i].P2 = points [(i + 1) % points.Length];
			}
		}

		public Point [] Points {
			get { return points; }
		}

		public VectorLine [] Edges {
			get { return edges; }
		}

		public VectorPolygon (Point [] points, Color color) {
			this.points = (Point []) points.Clone ();
			edges = new VectorLine [this.points.Length];

			for (int i = 0; i < edges.Length; ++i) {
				edges [i] = new VectorLine (this.points [i], this.points [(i + 1) % this.points.Length], color);
			}
		}

		public void Draw (byte [] pixels, int width, int height, int stride) {
			recalculatePositions ();
			foreach (var edge in edges) {
				edge.Draw (pixels, width, height, stride);
			}
		}

		public IVectorObject Clone () {
			throw new NotImplementedException ();
		}

		public bool OnCursor (Point position) {
			throw new NotImplementedException ();
		}

		public void OpenEditor (MainWindow window) {
			throw new NotImplementedException ();
		}
	}
}
