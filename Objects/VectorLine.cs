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

		private void setPixel (byte [] pixels, int cx, int cy, int w, int h, int scanlineWidth, int channels, Color color) {
			if (cx < 0 || cx >= w || cy < 0 || cy >= h) return;
			pixels [cy * scanlineWidth + cx * channels + 0] = color.B;
			pixels [cy * scanlineWidth + cx * channels + 1] = color.G;
			pixels [cy * scanlineWidth + cx * channels + 2] = color.R;
		}

		public void Draw (byte [] pixels, int width, int height, int stride) {
			// additional data needed for setting correct pixel in the byte array
			int channels = stride / width;
			int padding = (4 - (width * channels % 4)) % 4;
			int scanlineWidth = width * channels + padding;

			// DDA algorithm implementation
			Point startPoint = p1, endPoint = p2;

			float dx = Math.Abs (endPoint.X - startPoint.X);
			float dy = Math.Abs (endPoint.Y - startPoint.Y);
			int cx, cy;
			
			if (dx >= dy) {
				if (p1.X < p2.X) {
					startPoint = p1;
					endPoint = p2;
				} else {
					startPoint = p2;
					endPoint = p1;
				}

				float m = (float)(endPoint.Y - startPoint.Y) / (float)(endPoint.X - startPoint.X);
				float y = startPoint.Y;

				for (int x = startPoint.X, j = 0; x < endPoint.X; ++x, ++j) {
					if (dotted && j % 6 < 3) {
						y += m;
						continue;
					}

					cx = x;
					cy = (int) y;

					setPixel (pixels, cx, cy, width, height, scanlineWidth, channels, color);

					// pixel copying
					if (thickness > 1) {
						int min = (int) Math.Floor ((thickness - 1) / 2.0);
						int max = (int) Math.Ceiling ((thickness - 1) / 2.0);

						for (int i = -min; i < max; ++i) {
							setPixel (pixels, cx, cy + i, width, height, scanlineWidth, channels, color);
						}
					}

					y += m;
				}
			} else {
				if (p1.Y < p2.Y) {
					startPoint = p1;
					endPoint = p2;
				} else {
					startPoint = p2;
					endPoint = p1;
				}

				float m = (float)(endPoint.X - startPoint.X) / (float)(endPoint.Y - startPoint.Y);
				float x = startPoint.X;

				for (int y = startPoint.Y, j = 0; y < endPoint.Y; ++y, ++j) {
					if (dotted && j % 6 < 3) {
						x += m;
						continue;
					}

					cx = (int) x;
					cy = y;

					setPixel (pixels, cx, cy, width, height, scanlineWidth, channels, color);

					// pixel copying
					if (thickness > 1) {
						int min = (int) Math.Floor ((thickness - 1) / 2.0);
						int max = (int) Math.Ceiling ((thickness - 1) / 2.0);

						for (int i = -min; i < max; ++i) {
							setPixel (pixels, cx + i, cy, width, height, scanlineWidth, channels, color);
						}
					}

					x += m;
				}
			}
		}

		public bool OnCursor (Point position) {
			// collision code with the line
			float minX = Math.Min (p1.X, p2.X) - 5, maxX = Math.Max (p1.X, p2.X) + 5;
			float minY = Math.Min (p1.Y, p2.Y) - 5, maxY = Math.Max (p1.Y, p2.Y) + 5;

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
