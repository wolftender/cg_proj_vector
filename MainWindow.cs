using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// DDA, Midpoint Circle (v2. - additions only), Pixel Copying, Gupta-Sproull 
namespace gc_proj_2 {
	public partial class MainWindow : Form {
		private Dictionary<string, IVectorObject> objects;
		private Bitmap canvasBitmap;

		private int canvasWidth;
		private int canvasHeight;

		private bool projectLoaded;

		private Color currentColor;

		public int CanvasWidth {
			get { return canvasWidth; }
		}

		public int CanvasHeight {
			get { return canvasHeight; }
		}

		public bool ProjectLoaded {
			get { return projectLoaded; }
		}

		public Color CurrentColor {
			get { return currentColor; }
		}

		public MainWindow () {
			InitializeComponent ();

			// initial settings
			currentColor = Color.Black;
			refreshColorButton ();

			// initial project
			objects = new Dictionary<string, IVectorObject> ();
			NewProject (500, 400);

			// test
			objects.Add ("line1", new Objects.VectorLine (new Point (0, 0), new Point (200, 110), Color.Black, 16));
			objects.Add ("line2", new Objects.VectorLine (new Point (0, 0), new Point (110, 200), Color.Black, 16));
			objects.Add ("line3", new Objects.VectorLine (new Point (0, 0), new Point (200, 200), Color.Black, 1) { Dotted = true });
			objects.Add ("circle1", new Objects.VectorCircle (new Point (200, 200), 30, Color.Black));
			objects.Add ("circle2", new Objects.VectorCircle (new Point (200, 200), 60, Color.Black, 16));
			redraw ();
		}

		private Bitmap makeSingleColorBitmap (int width, int height, Color color) {
			Bitmap bitmap = new Bitmap (width, height, PixelFormat.Format24bppRgb);

			using (var ctx = Graphics.FromImage (bitmap)) {
				ctx.Clear (color);
			}

			return bitmap;
		}

		public void NewProject (int width, int height) {
			if (ProjectLoaded) {
				if (MessageBox.Show (this, "are you sure that you want to start a new project?", "new project", 
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
					return;
				}
			}

			projectLoaded = true;

			// reset object collection
			objects.Clear ();

			// set properties of the project
			canvasWidth = width;
			canvasHeight = height;

			// create new bitmap and dispose of the old one
			if (canvasBitmap != null) {
				canvasBitmap.Dispose ();
			}

			canvasBitmap = makeSingleColorBitmap (width, height, Color.White);
			canvas.Image = canvasBitmap;
		}

		private void redraw () {
			// if there is no bitmap then there is nothing to redraw
			if (canvasBitmap == null) {
				return;
			}

			// lock pixels for drawing
			Bitmap output = makeSingleColorBitmap (canvasWidth, canvasHeight, Color.White);
			BitmapData data = output.LockBits (new Rectangle (0, 0, canvasWidth, canvasHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int size = data.Stride * output.Height;
			byte [] pixels = new byte [size];

			Marshal.Copy (data.Scan0, pixels, 0, size);

			// draw each object
			foreach (var vectorObj in objects.Values) {
				vectorObj.Draw (pixels, canvasWidth, canvasHeight, data.Stride);
			}

			// copy modified bytes back and apply changes
			Marshal.Copy (pixels, 0, data.Scan0, size);
			output.UnlockBits (data);

			if (canvasBitmap != null) {
				canvasBitmap.Dispose ();
			}

			canvasBitmap = output;
			canvas.Image = canvasBitmap;
		}

		private void refreshColorButton () {
			Image oldBitmap = buttonColor.BackgroundImage;

			if (oldBitmap != null) {
				oldBitmap.Dispose ();
			}

			Image newImage = makeSingleColorBitmap (32, 32, currentColor);
			buttonColor.BackgroundImage = newImage;
		}

		private void buttonColor_Click (object sender, EventArgs e) {
			ColorDialog dialog = new ColorDialog ();
			dialog.Color = currentColor;

			if (dialog.ShowDialog (this) == DialogResult.OK) {
				currentColor = dialog.Color;
				refreshColorButton ();
			}
		}
	}
}
