using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gc_proj_2.Objects {
	public class VectorCircle : IVectorObject {
		private Point center;
		private Color color;

		private int radius;
		private int thickness;

		public Point Center {
			get { return center; }
			set { center = value; }
		}

		public Color Color {
			get { return color; }
			set { color = value; }
		}

		public int Radius {
			get { return radius; }
			set {
				radius = Math.Max (1, value);
			}
		}

		public int Thickness {
			get { return thickness; }
			set {
				thickness = Math.Max (1, Math.Min (16, value));
			}
		}

		public string Name => "Circle";

		public VectorCircle (Point center, int radius) {
			this.center = center;
			this.radius = radius;
			this.thickness = 1;
			this.color = Color.Black;
		}

		public VectorCircle (Point center, int radius, Color color) {
			this.center = center;
			this.radius = radius;
			this.thickness = 1;
			this.color = color;
		}

		public VectorCircle (Point center, int radius, Color color, int thickness) {
			this.center = center;
			this.radius = radius;
			this.Thickness = thickness;
			this.color = color;
		}

		private void putPixel (byte [] pixels, int x, int y, int w, int h, Color color, int scanlineWidth, int channels) {
			if (x < 0 || x > w || y < 0 || y > h) return;

			pixels [y * scanlineWidth + x * channels + 0] = color.R;
			pixels [y * scanlineWidth + x * channels + 1] = color.G;
			pixels [y * scanlineWidth + x * channels + 2] = color.B;
		}

		private void putCirclePixel (byte [] pixels, int x, int y, int w, int h, Color color, int scanlineWidth, int channels) {
			putPixel (pixels, center.X + x, center.Y - y, w, h, color, scanlineWidth, channels); // 1st octant
			putPixel (pixels, center.X + y, center.Y - x, w, h, color, scanlineWidth, channels); // 2nd octant
			putPixel (pixels, center.X + y, center.Y + x, w, h, color, scanlineWidth, channels); // 3rd octant
			putPixel (pixels, center.X + x, center.Y + y, w, h, color, scanlineWidth, channels); // 4th octant
			putPixel (pixels, center.X - x, center.Y + y, w, h, color, scanlineWidth, channels); // 5th octant
			putPixel (pixels, center.X - y, center.Y + x, w, h, color, scanlineWidth, channels); // 6th octant
			putPixel (pixels, center.X - y, center.Y - x, w, h, color, scanlineWidth, channels); // 7th octant
			putPixel (pixels, center.X - x, center.Y - y, w, h, color, scanlineWidth, channels); // 8th octant
		}

		private void putThickPixel (byte [] pixels, int x, int y, int w, int h, Color color, int scanlineWidth, int channels) {
			putCirclePixel (pixels, x, y, w, h, color, scanlineWidth, channels);

			if (thickness > 1) {
				int min = (int) Math.Floor ((thickness - 1) / 2.0);
				int max = (int) Math.Ceiling ((thickness - 1) / 2.0);

				for (int dx = -min; dx < max; ++dx) {
					for (int dy = -min; dy < max; ++dy) {
						if (dx * dx + dy * dy <= max * max) {
							putCirclePixel (pixels, x + dx, y + dy, w, h, color, scanlineWidth, channels);
						}
					}
				}
			}
		}

		public void Draw (byte [] pixels, int width, int height, int stride) {
			// additional data needed for setting correct pixel in the byte array
			int channels = stride / width;
			int padding = (4 - (width * channels % 4)) % 4;
			int scanlineWidth = width * channels + padding;

			// Midpoint circle algorithm
			int dE = 3, dSE = 5 - 2 * Radius, d = 1 - Radius;
			int x = 0, y = Radius;

			putThickPixel (pixels, x, y, width, height, color, scanlineWidth, channels);

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
				putThickPixel (pixels, x, y, width, height, color, scanlineWidth, channels);
			}
		}

		public IVectorObject Clone () {
			return new VectorCircle (center, radius, color, thickness);
		}

		public bool OnCursor (Point position) {
			double dist = Math.Sqrt ((position.X - center.X) * (position.X - center.X) + (position.Y - center.Y) * (position.Y - center.Y));
			double margin = (thickness / 2) + 5;
			if (dist < radius + margin && dist > radius - margin) {
				return true;
			}

			return false;
		}

		public void OpenEditor (MainWindow window) {
			window.CurrentTool = new Editors.CircleEditor (window, this);
		}
	}
}
