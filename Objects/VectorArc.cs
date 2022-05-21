using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;

namespace gc_proj_2.Objects {
	public class VectorArc : VectorObject {
		private Point a, b, c;
		private Color color;
		private int detABC;

		public Point A {
			get { return a; }
			set { 
				a = value;
				calculateDetABC ();
			}
		}

		public Point B {
			get { return b; }
			set { 
				b = value;
				calculateDetABC ();
			}
		}

		public Point C {
			get { return c; }
			set { 
				c = value;
				calculateDetABC ();
			}
		}

		public Color Color { 
			get { return color; }
			set { color = value; }
		}

		private void calculateDetABC () {
			detABC = determinant (a, b, c);
		}

		public override string Name => "Arc (Lab)";

		private int determinant (Point a, Point b, Point c) {
			return (a.X * b.Y - a.X * c.Y - a.Y * b.X + a.Y * c.X + b.X * c.Y - b.Y * c.X);
		}

		public VectorArc () { }

		private void putPixel (byte [] pixels, int x, int y, int w, int h, Color color, int scanlineWidth, int channels) {
			if (x < 0 || x >= w || y < 0 || y >= h) return;

			Point D = new Point (x, y);
			int detABD = determinant (A, B, D), detACD = determinant (A, C, D);
			if (detABC > 0) {
				if (detABD > 0 && detACD < 0) {
					pixels [y * scanlineWidth + x * channels + 0] = color.B;
					pixels [y * scanlineWidth + x * channels + 1] = color.G;
					pixels [y * scanlineWidth + x * channels + 2] = color.R;
				}
			} else if (detABC < 0) {
				if (detABD > 0 || detACD < 0) {
					pixels [y * scanlineWidth + x * channels + 0] = color.B;
					pixels [y * scanlineWidth + x * channels + 1] = color.G;
					pixels [y * scanlineWidth + x * channels + 2] = color.R;
				}
			}
		}

		private void putCirclePixel (byte [] pixels, int x, int y, int w, int h, Color color, int scanlineWidth, int channels) {
			putPixel (pixels, A.X + x, A.Y - y, w, h, color, scanlineWidth, channels); // 1st octant
			putPixel (pixels, A.X + y, A.Y - x, w, h, color, scanlineWidth, channels); // 2nd octant
			putPixel (pixels, A.X + y, A.Y + x, w, h, color, scanlineWidth, channels); // 3rd octant
			putPixel (pixels, A.X + x, A.Y + y, w, h, color, scanlineWidth, channels); // 4th octant
			putPixel (pixels, A.X - x, A.Y + y, w, h, color, scanlineWidth, channels); // 5th octant
			putPixel (pixels, A.X - y, A.Y + x, w, h, color, scanlineWidth, channels); // 6th octant
			putPixel (pixels, A.X - y, A.Y - x, w, h, color, scanlineWidth, channels); // 7th octant
			putPixel (pixels, A.X - x, A.Y - y, w, h, color, scanlineWidth, channels); // 8th octant
		}

		public override void Draw (byte [] pixels, int width, int height, int stride) {
			// additional data needed for setting correct pixel in the byte array
			int channels = stride / width;
			int padding = (4 - (width * channels % 4)) % 4;
			int scanlineWidth = width * channels + padding;

			// Midpoint circle algorithm
			double dx = A.X - B.X;
			double dy = A.Y - B.Y;
			int r = (int)Math.Sqrt (dx * dx + dy * dy);

			int dE = 3, dSE = 5 - 2 * r, d = 1 - r;
			int x = 0, y = r;

			putCirclePixel (pixels, x, y, width, height, color, scanlineWidth, channels);

			while (y > x) {
				if (d < 0) {
					d += dE;
					dE += 2;
					dSE += 2;
				} else {
					d += dSE;
					dE += 2;
					dSE += 4;
					--y;
				}

				++x;
				putCirclePixel (pixels, x, y, width, height, color, scanlineWidth, channels);
			}
		}

		public override VectorObject Clone () {
			throw new NotImplementedException ();
		}

		public override bool OnCursor (Point position) {
			double dist = Math.Sqrt ((position.X - A.X) * (position.X - A.X) + (position.Y - A.Y) * (position.Y - A.Y));
			double margin = 5;
			double dx = A.X - B.X;
			double dy = A.Y - B.Y;
			int r = (int) Math.Sqrt (dx * dx + dy * dy);
			Point D = position;

			if (dist < r + margin && dist > r - margin) {
				int detABD = determinant (A, B, D), detACD = determinant (A, C, D);
				if (detABC > 0) {
					if (detABD > 0 && detACD < 0) {
						return true;
					}
				} else if (detABC < 0) {
					if (detABD > 0 || detACD < 0) {
						return true;
					}
				}
			}

			return false;
		}

		public override void OpenEditor (MainWindow window) {
			window.CurrentTool = new Editors.ArcEditor (window, this);
		}
	}
}
