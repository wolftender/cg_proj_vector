using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using System.Diagnostics;

namespace gc_proj_2.Objects {
	static class GuptaSproullTable {
		private static double [,] covTable;

		public static double CalculateCov (double d, double r) {
			if (d <= r) {
				double ang = (d / r) - (d / (Math.PI * r * r)) * Math.Sqrt (r * r - d * d);
				return (1 / Math.PI) * Math.Acos (ang);
			} else {
				return 0.0;
			}
		}

		static GuptaSproullTable () {
			// precalculate the values for r = 0.1, 0.2, ..., 1.0
			// and for d = 0.00, 0.01, 0.02, ..., 1.0

			double r = 0.1, d = 0.00;
			double dr = 0.1, dd = 0.01;
			int nr = 10, nd = 100;

			covTable = new double [nr, nd];

			for (int ir = 0; ir < nr; ++ir) {
				d = 0.00;
				for (int id = 0; id < nd; ++id) {
					covTable [ir, id] = CalculateCov (d, r);
					d = d + dd;
				}

				r = r + dr;
			}
		}

		public static double cov (double d, double r) {
			d = Math.Max (0.0, Math.Min (1.0, d));
			r = Math.Max (0.0, Math.Min (1.0, r));

			double dr = 0.1, dd = 0.01;
			int ir = (int) Math.Round (r / dr) - 1;
			int id = (int) Math.Floor (d / dd);

			return covTable [ir, id];
		}
	}

	public class GuptaSproullLine : VectorLine {
		private double coverage (double w, double d, double r) {
			if (w >= r) {
				if (w <= d) {
					return GuptaSproullTable.CalculateCov (d - w, r);
				} else {
					return 1.0 - GuptaSproullTable.CalculateCov (w - d, r);
				}
			} else {
				if (0 <= d & d <= w) {
					return 1.0 - GuptaSproullTable.CalculateCov (w - d, r) - GuptaSproullTable.CalculateCov (w + d, r);
				} else if (w <= d && d <= r - w) {
					return GuptaSproullTable.CalculateCov (d - w, r) - GuptaSproullTable.CalculateCov (w + d, r);
				} else {
					return GuptaSproullTable.CalculateCov (d - w, r);
				}
			}
		}

		private int lerp (int first, int second, double t) {
			return (int) Math.Min (255, first * (1 - t) + second * t);
		}

		private void blendPixel (byte [] pixels, int cx, int cy, int w, int h, int scanlineWidth, int channels, Color color, double t) {
			if (cx < 0 || cx >= w || cy < 0 || cy >= h) return;
			int r = pixels [cy * scanlineWidth + cx * channels + 2];
			int g = pixels [cy * scanlineWidth + cx * channels + 1];
			int b = pixels [cy * scanlineWidth + cx * channels + 0];

			r = lerp (r, color.R, t);
			g = lerp (g, color.G, t);
			b = lerp (b, color.B, t);

			pixels [cy * scanlineWidth + cx * channels + 0] = (byte)b;
			pixels [cy * scanlineWidth + cx * channels + 1] = (byte)g;
			pixels [cy * scanlineWidth + cx * channels + 2] = (byte)r;
		}

		private double intensifyPixel (byte [] pixels, int x, int y, int w, int h, int s, int c, double distance) {
			double r = 0.5f;
			double cov = coverage(Thickness, distance, r);

			if (cov > 0) {
				blendPixel (pixels, x, y, w, h, s, c, Color, (double) cov);
			}

			return cov;
		}

		public override void Draw (byte [] pixels, int width, int height, int stride) {
			// additional data needed for setting correct pixel in the byte array
			int channels = stride / width;
			int padding = (4 - (width * channels % 4)) % 4;
			int scanlineWidth = width * channels + padding;

			// Gupta-Sproull algorithm implementation
			int dx = P2.X - P1.X, dy = P2.Y - P1.Y;
			int dE = 2 * dy, dNE = 2 * (dy - dx);
			int d = 2 * dy - dx;

			// numerator
			int numerator = 0;
			double denominatorInv = 1.0 / (2.0 * Math.Sqrt (dx * dx + dy * dy));
			double denominator = 2 * dx * denominatorInv;

			int x = P1.X, y = P1.Y;
			int i;

			intensifyPixel (pixels, x, y, width, height, scanlineWidth, channels, 0);
			for (i = 1; intensifyPixel (pixels, x, y + i, width, height, scanlineWidth, channels, i * denominator) > 0; ++i) ;
			for (i = 1; intensifyPixel (pixels, x, y - i, width, height, scanlineWidth, channels, i * denominator) > 0; ++i) ;

			while (x < P2.X) {
				++x;
				if (d < 0) {
					numerator = d + dx;
					d = d + dE;
				} else {
					numerator = d - dx;
					d = d + dNE;
					++y;
				}

				intensifyPixel (pixels, x, y, width, height, scanlineWidth, channels, 0);
				for (i = 1; intensifyPixel (pixels, x, y + i, width, height, scanlineWidth, channels, i * denominator - numerator * denominatorInv) > 0; ++i) ;
				for (i = 1; intensifyPixel (pixels, x, y - i, width, height, scanlineWidth, channels, i * denominator + numerator * denominatorInv) > 0; ++i) ;
			}
		}
	}
}
