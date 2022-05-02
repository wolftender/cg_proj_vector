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

namespace gc_proj_2 {
	public partial class MainWindow : Form {
		private Dictionary<string, IVectorObject> objects;
		private Bitmap canvasBitmap;

		private int canvasWidth;
		private int canvasHeight;

		private bool projectLoaded;

		public int CanvasWidth {
			get { return canvasWidth; }
		}

		public int CanvasHeight {
			get { return canvasHeight; }
		}

		public bool ProjectLoaded {
			get { return projectLoaded; }
		}

		public MainWindow () {
			InitializeComponent ();

			// initial project
			objects = new Dictionary<string, IVectorObject> ();
			NewProject (500, 400);
		}

		private Bitmap makeWhiteBitmap (int width, int height) {
			Bitmap bitmap = new Bitmap (canvasWidth, canvasHeight, PixelFormat.Format24bppRgb);

			using (var ctx = Graphics.FromImage (bitmap)) {
				ctx.Clear (Color.White);
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

			canvasBitmap = makeWhiteBitmap (width, height);
			canvas.Image = canvasBitmap;
		}

		private void redraw () {
			// if there is no bitmap then there is nothing to redraw
			if (canvasBitmap == null) {
				return;
			}

			// lock pixels for drawing
			Bitmap output = makeWhiteBitmap (canvasWidth, canvasHeight);
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
	}
}
