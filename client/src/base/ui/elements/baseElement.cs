/**
	baseElement.cs
	Specifies Ui elements.
*/
using BadFaith.Ui.Terminals;

namespace BadFaith.Ui.Elements
{
	/**
	Base class for Ui elements.
	*/
	public abstract class UiElement : Window
	{
		public Window MainWindow;
		public UiElement(Terminal terminal)
		{
			//Make the window.
			implementationWindow = terminal._implementationSubWindow();
			base(implementationWindow);
			//Attach ourselves to the terminal's window list.
			terminal.Windows.Add(this);
			//Initialize the super data now...
			MainWindow = terminal.MainWindow;
		}

		/**
		Convenience function for adjusting the row position
		only.
		*/
		public void SetRow(int row)
		{
			SetOrigin(new Vector2I(row, Origin.Y));
		}

		/**
		Convenience function to fill entire row.
		*/
		public void FillRow()
		{
			SetExtents(new Vector2I(Extents.X, MainWindow.Extents.Y));
		}

		/**
		Convenience function to snap to bottom minus
		'displacement'.
		*/
		public void ToBottom(int displacement = 0)
		{
			SetOrigin(new Vector2I(MainWindow.Extents.X - (1 + displacement), Origin.Y));
		}

		/**
		Convenience function to snap to top plus
		'displacement'.
		*/
		public void ToTop(int displacement = 0)
		{
			SetOrigin(new Vector2I(displacement, Origin.Y));
		}

		public abstract void Render();
	}
}