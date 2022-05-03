using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gc_proj_2.Objects {
	public class VectorLine : IVectorObject {
		private Point p1;
		private Point p2;
		private Color color;
		private int thickness;
		private bool dotted;

		public Point P1 {
			get { return p1; }
			set { p1 = value; }
		}

		public Point P2 {
			get { return p2; }
			set { p2 = value; }
		}

		public Color Color {
			get { return color; }
			set { color = value; }
		}

		public int Thickness {
			get { return thickness; }
			set {
				thickness = Math.Max (1, Math.Min (16, value));
			}
		}

		public bool Dotted {
			get { return dotted; }
			set { dotted = value; }
		}

		public string Name => "Line";

		public VectorLine () {
			p1 = new Point (0, 0);
			p2 = new Point (0, 0);
		}

		public VectorLine (Point p1, Point p2) {
			this.p1 = p1;
			this.p2 = p2;
			this.color = Color.Black;
			this.thickness = 1;
		}

		public VectorLine (Point p1, Point p2, Color color) {
			this.p1 = p1;
			this.p2 = p2;
			this.color = color;
			this.thickness = 1;
		}

		public VectorLine (Point p1, Point p2, Color color, int thickness) {
			this.p1 = p1;
			this.p2 = p2;
			this.color = color;
			this.Thickness = thickness;
		}

		public IVectorObject Clone () {
			return new VectorLine (p1, p2, color);
		}

		public void Draw (byte [] pixels, int width, int height, int stride) {
			// additional data needed for setting correct pixel in the byte array
			int channels = stride / width;
			int padding = (4 - (width * channels % 4)) % 4;
			int scanlineWidth = width * channels + padding;

			// DDA algorithm implementation
			Point startPoint = p1, endPoint = p2;

			float dx = endPoint.X - startPoint.X;
			float dy = endPoint.Y - startPoint.Y;
			int cx, cy;
			
			if (dx >= dy) {
				float m = dy / dx;
				float y = startPoint.Y;

				for (int x = Math.Min(startPoint.X, endPoint.X), j = 0; x < Math.Max (startPoint.X, endPoint.X); ++x, ++j) {
					if (dotted && j % 6 < 3) {
						y += m;
						continue;
					}

					cx = x;
					cy = (int) y;

					pixels [cy * scanlineWidth + cx * channels + 0] = color.R;
					pixels [cy * scanlineWidth + cx * channels + 1] = color.G;
					pixels [cy * scanlineWidth + cx * channels + 2] = color.B;

					// pixel copying
					if (thickness > 1) {
						int min = (int) Math.Floor ((thickness - 1) / 2.0);
						int max = (int) Math.Ceiling ((thickness - 1) / 2.0);

						for (int i = -min; i < max; ++i) {
							if (cx + i > width || cx + i < 0) continue;
							pixels [cy * scanlineWidth + (cx + i) * channels + 0] = color.R;
							pixels [cy * scanlineWidth + (cx + i) * channels + 1] = color.G;
							pixels [cy * scanlineWidth + (cx + i) * channels + 2] = color.B;
						}
					}

					y += m;
				}
			} else {
				float m = dx / dy;
				float x = startPoint.Y;

				for (int y = Math.Min (startPoint.Y, endPoint.Y), j = 0; y < Math.Max (startPoint.Y, endPoint.Y); ++y, ++j) {
					if (dotted && j % 6 < 3) {
						x += m;
						continue;
					}

					cx = (int) x;
					cy = y;

					pixels [cy * scanlineWidth + cx * channels + 0] = color.R;
					pixels [cy * scanlineWidth + cx * channels + 1] = color.G;
					pixels [cy * scanlineWidth + cx * channels + 2] = color.B;

					// pixel copying
					if (thickness > 1) {
						int min = (int) Math.Floor ((thickness - 1) / 2.0);
						int max = (int) Math.Ceiling ((thickness - 1) / 2.0);

						for (int i = -min; i < max; ++i) {
							if (cy + i > height || cy + i < 0) continue;
							pixels [(cy + i) * scanlineWidth + cx * channels + 0] = color.R;
							pixels [(cy + i) * scanlineWidth + cx * channels + 1] = color.G;
							pixels [(cy + i) * scanlineWidth + cx * channels + 2] = color.B;
						}
					}

					x += m;
				}
			}
		}

		public bool OnCursor (Point position) {
			// collision code with the line
			float minX = Math.Min (p1.X, p2.X), maxX = Math.Max (p1.X, p2.X);
			float minY = Math.Min (p1.Y, p2.Y), maxY = Math.Max (p1.Y, p2.Y);

			if (position.X > minX && position.X < maxX && position.Y > minY && position.Y < maxY) {
				double dist = Math.Abs ((p2.X - p1.X) * (p1.Y - position.Y) - (p1.X - position.X) * (p2.Y - p1.Y));
				dist = dist / Math.Sqrt ((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));

				return (dist < thickness + 5);
			}

			return false;
		}

		public void OpenEditor (MainWindow window) {
			window.CurrentTool = new Editors.LineEditor (window, this);
		}
	}
}
