using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gc_proj_2.Objects {
	public class VectorLine : IVectorObject {
		private Point p1;
		private Point p2;

		public Point P1 {
			get { return p1; }
			set { p1 = value; }
		}

		public Point P2 {
			get { return p2; }
			set { p2 = value; }
		}

		public string Name => "Line";

		public VectorLine () {
			p1 = new Point (0, 0);
			p2 = new Point (0, 0);
		}

		public VectorLine (Point p1, Point p2) {
			this.p1 = p1;
			this.p2 = p2;
		}

		public IVectorObject Clone () {
			return new VectorLine (p1, p2);
		}

		public void Draw (byte [] pixels, int width, int height, int stride) {
			// DDA algorithm implementation
			Point startPoint, endPoint;

			// choose the leftmost point
			if (p1.X <= p2.X) {
				startPoint = p1;
				endPoint = p2;
			} else {
				startPoint = p2;
				endPoint = p1;
			}

			float dx = endPoint.X - startPoint.X;
			float dy = endPoint.Y - startPoint.Y;
			
			if (dx > dy) {
				float m = dy / dx;
				float y = startPoint.Y;

				for (int x = startPoint.X; x < endPoint.X; ++x) {

				}
			} else {

			}
		}
	}
}
