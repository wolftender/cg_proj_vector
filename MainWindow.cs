using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

// DDA, Midpoint Circle (v2. - additions only), Pixel Copying, Gupta-Sproull 
namespace gc_proj_2 {
	public partial class MainWindow : Form {
		public class ProjectDataObject {
			public string Name { get; set; }
			public VectorObject Instance { get; set; }
		}

		public class ProjectData {
			public int Width { get; set; }
			public int Height { get; set; }
			public List<ProjectDataObject> Objects { get; set; }
		}

		private Dictionary<string, VectorObject> objects;
		private List<VectorObject> tempObjects;

		private Bitmap canvasBitmap;

		private int canvasWidth;
		private int canvasHeight;

		private bool projectLoaded;
		private bool isMouseDown;

		private Point lastMousePosition;
		private ObjectEditor currentTool;

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

		public ObjectEditor CurrentTool {
			get { return currentTool; }
			set {
				tempObjects.Clear ();
				currentTool = value;

				if (currentTool != null) {
					currentTool.Initialize ();
					toolStripStatusLabelTool.Text = currentTool.Name;
				} else {
					toolStripStatusLabelTool.Text = "Cursor Tool";
				}

				redraw ();
				updateToolbar ();
			}
		}
		
		private void updateToolbar () {
			buttonCursor.Checked = (currentTool == null);
			buttonLine.Checked = (currentTool is Editors.LineCreator);
			buttonPolygon.Checked = (CurrentTool is Editors.PolygonCreator);
			buttonCircle.Checked = (currentTool is Editors.CircleCreator);
		}

		public List<VectorObject> TempObjects {
			get { return tempObjects; }
		}

		public void AddObject (string name, VectorObject vectorObject) {
			string newName = name;
			if (objects.ContainsKey (newName)) {
				int i = 0;
				do {
					newName = name + i;
					i++;
				} while (objects.ContainsKey (newName));
			}

			objects.Add (newName, vectorObject);
		}

		public MainWindow () {
			objects = new Dictionary<string, VectorObject> ();
			tempObjects = new List<VectorObject> ();

			InitializeComponent ();
			KeyPreview = true;

			// initial settings
			currentColor = Color.Black;
			refreshColorButton ();

			buttonCursor.Checked = true;

			// initial project
			NewProject (1000, 700);

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

		public bool NewProject (int width, int height) {
			if (ProjectLoaded) {
				if (MessageBox.Show (this, "are you sure that you want to start a new project?", "new project", 
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
					return false;
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

			return true;
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

			// logic for rendering the temp. editor objects
			foreach (var vectorObj in tempObjects) {
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

		public void Redraw () {
			redraw ();
		}

		private void refreshColorButton () {
			Image oldBitmap = buttonColor.BackgroundImage;

			if (oldBitmap != null) {
				oldBitmap.Dispose ();
			}

			Image newImage = makeSingleColorBitmap (32, 32, currentColor);
			buttonColor.BackgroundImage = newImage;
		}

		private void colorSelection () {
			ColorDialog dialog = new ColorDialog ();
			dialog.Color = currentColor;

			if (dialog.ShowDialog (this) == DialogResult.OK) {
				currentColor = dialog.Color;
				refreshColorButton ();

				if (currentTool != null) {
					currentTool.OnColorChange (currentColor);
				}
			}
		}

		private void buttonColor_Click (object sender, EventArgs e) {
			colorSelection ();
		}

		private Point calculateRelativePosition (Point pos) {
			int topLeftX = (canvas.Width - canvasWidth) / 2;
			int topLeftY = (canvas.Height - canvasHeight) / 2;

			Point newPos = new Point (pos.X - topLeftX, pos.Y - topLeftY);
			return newPos;
		}

		private void canvas_MouseClick (object sender, MouseEventArgs e) {
			// is current tool is null then this is pointer
			if (currentTool == null) {
				Point relativePos = calculateRelativePosition (e.Location);
				Debug.WriteLine ("pos {0} {1}", relativePos.X, relativePos.Y);

				foreach (var vectorObject in objects.Values) {
					if (vectorObject.OnCursor (relativePos)) {
						vectorObject.OpenEditor (this);
						break;
					}
				}
			} else {
				currentTool.OnMouseClick (e, canvas, calculateRelativePosition (e.Location));
			}
		}

		private void canvas_MouseDown (object sender, MouseEventArgs e) {
			isMouseDown = true;

			if (currentTool != null) {
				currentTool.OnMouseDown (e, canvas, calculateRelativePosition (e.Location));
			}
		}

		private void canvas_MouseUp (object sender, MouseEventArgs e) {
			isMouseDown = false;

			if (currentTool != null) {
				currentTool.OnMouseDown (e, canvas, calculateRelativePosition (e.Location));
			}
		}

		private void canvas_MouseMove (object sender, MouseEventArgs e) {
			if (currentTool != null) {
				currentTool.OnMouseMove (e, canvas, lastMousePosition, calculateRelativePosition (e.Location), isMouseDown);
			}

			lastMousePosition = e.Location;
		}

		private void buttonCursor_CheckedChanged (object sender, EventArgs e) {
			if ((sender as CheckBox).Checked) {
				CurrentTool = null;
			}

			this.Focus ();
			ActiveControl = null;
		}

		private void buttonLine_CheckedChanged (object sender, EventArgs e) {
			if ((sender as CheckBox).Checked) {
				CurrentTool = new Editors.LineCreator (this);
			}

			this.Focus ();
			ActiveControl = null;
		}

		private void buttonPolygon_CheckedChanged (object sender, EventArgs e) {
			if ((sender as CheckBox).Checked) {
				CurrentTool = new Editors.PolygonCreator (this);
			}

			this.Focus ();
			ActiveControl = null;
		}

		private void buttonCircle_CheckedChanged (object sender, EventArgs e) {
			if ((sender as CheckBox).Checked) {
				CurrentTool = new Editors.CircleCreator (this);
			}

			this.Focus ();
			ActiveControl = null;
		}

		public void DeleteObject (VectorObject objectInstance) {
			foreach (var pair in objects) {
				if (pair.Value == objectInstance) {
					currentTool = null;
					objects.Remove (pair.Key);

					CurrentTool = null;
				}
			}
		}

		private void MainWindow_KeyPress (object sender, KeyPressEventArgs e) {
			if (currentTool != null) {
				currentTool.OnKeyPress (e);
			}
		}

		private void MainWindow_KeyDown (object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Escape) {
				CurrentTool = null;
			}

			if (currentTool != null) {
				currentTool.OnKeyDown (e);
			}
		}

		private void newToolStripMenuItem_Click (object sender, EventArgs e) {
			NewProjectForm form = new NewProjectForm ();
			
			if (form.ShowDialog (this) == DialogResult.OK) {
				NewProject (form.ProjectWidth, form.ProjectHeight);
			}
		}

		private string getSerializedProject () {
			XmlSerializer serializer = new XmlSerializer (typeof (ProjectData), new Type [] {
				typeof (Objects.VectorCircle), typeof (Objects.VectorLine), typeof (Objects.VectorPolygon)
			});
			ProjectData data = new ProjectData ();

			data.Width = canvasWidth;
			data.Height = canvasHeight;
			data.Objects = new List<ProjectDataObject> ();

			foreach (var pair in objects) {
				data.Objects.Add (new ProjectDataObject () {
					Instance = pair.Value,
					Name = pair.Key
				});
			}

			string serialized;
			using (var sww = new StringWriter ()) {
				using (var xmlWriter = new XmlTextWriter (sww) { Formatting = Formatting.Indented }) {
					serializer.Serialize (xmlWriter, data);
					serialized = sww.ToString ();
				}
			}

			return serialized;
		}

		private void deserializeProject (string serialized) {
			XmlSerializer serializer = new XmlSerializer (typeof (ProjectData), new Type [] {
				typeof (Objects.VectorCircle), typeof (Objects.VectorLine), typeof (Objects.VectorPolygon)
			});

			ProjectData data;
			using (var reader = new StringReader (serialized)) {
				data = (ProjectData) serializer.Deserialize (reader);
			}

			if (NewProject (data.Width, data.Height)) {
				foreach (var pair in data.Objects) {
					objects.Add (pair.Name, pair.Instance);
				}
			}

			redraw ();
		}

		private void openToolStripMenuItem_Click (object sender, EventArgs e) {
			OpenFileDialog openFileDialog = new OpenFileDialog ();
			openFileDialog.DefaultExt = "cgv";
			openFileDialog.Filter = "CG Project (*.cgv)|*.cgv";

			if (openFileDialog.ShowDialog () == DialogResult.OK) {
				try {
					string filename = openFileDialog.FileName;
					string serialized = File.ReadAllText (filename);

					deserializeProject (serialized);
				} catch (Exception exception) {
					MessageBox.Show ("failed to open specified file, error:\n" + exception.Message, "file error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void saveToolStripMenuItem_Click (object sender, EventArgs e) { }

		private void saveAsToolStripMenuItem_Click (object sender, EventArgs e) {
			SaveFileDialog saveFileDialog = new SaveFileDialog ();
			saveFileDialog.DefaultExt = "cgv";

			if (saveFileDialog.ShowDialog () == DialogResult.OK) {
				try {
					File.WriteAllText (saveFileDialog.FileName, getSerializedProject ());
				} catch (Exception exception) {
					MessageBox.Show ("failed to save filtered image to file, error:\n" + exception.Message, "save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void exportAsToolStripMenuItem_Click (object sender, EventArgs e) {
			SaveFileDialog saveFileDialog = new SaveFileDialog ();
			saveFileDialog.DefaultExt = "png"; 

			if (saveFileDialog.ShowDialog (this) == DialogResult.OK) {
				try {
					if (canvas.Image != null) {
						canvas.Image.Save (saveFileDialog.FileName);
					} else {
						MessageBox.Show ("bitmap is null", "save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} catch (Exception exception) {
					MessageBox.Show ("failed to save filtered image to file, error:\n" + exception.Message, "save error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void exitToolStripMenuItem_Click (object sender, EventArgs e) {
			Close ();
		}

		private void clearAllObjectsToolStripMenuItem_Click (object sender, EventArgs e) {
			objects.Clear ();
			CurrentTool = null;
			redraw ();
		}

		private void lineToolStripMenuItem_Click (object sender, EventArgs e) {
			CurrentTool = new Editors.LineCreator (this);
		}

		private void circleToolStripMenuItem_Click (object sender, EventArgs e) {
			CurrentTool = new Editors.CircleCreator (this);
		}

		private void polygonToolStripMenuItem_Click (object sender, EventArgs e) {
			CurrentTool = new Editors.PolygonCreator (this);
		}

		private void aboutToolStripMenuItem_Click (object sender, EventArgs e) {

		}

		private void colorSelectToolStripMenuItem_Click (object sender, EventArgs e) {
			colorSelection ();
		}

		private void MainWindow_FormClosing (object sender, FormClosingEventArgs e) {
			DialogResult res = MessageBox.Show (this, "are you sure that you want to exit?", "exit",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			e.Cancel = (res == DialogResult.No);
		}
	}
}
