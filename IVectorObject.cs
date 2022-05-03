using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gc_proj_2 {
	public interface IVectorObject {
		public string Name { get; }

		public void Draw (byte [] pixels, int width, int height, int stride);
		public IVectorObject Clone ();

		public bool OnCursor (Point position);
		public void OpenEditor (MainWindow window);
	}
}
