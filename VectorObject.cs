using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gc_proj_2 {
	public abstract class VectorObject {
		public abstract string Name { get; }

		public abstract void Draw (byte [] pixels, int width, int height, int stride);
		public abstract VectorObject Clone ();

		public abstract bool OnCursor (Point position);
		public abstract void OpenEditor (MainWindow window);
	}
}
