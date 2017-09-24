using BadFaith.Ui.Terminals;

namespace BadFaith.Ui.Elements
{
	/**
	Displays a single string inside itself.
	This tries to have the same width as the screen.
	*/
	public class TextLine : UiElement
	{
		/**
		The text to display.
		*/
		public string Label;

		public TextLine(Terminal terminal, string label = "") : base(terminal)
		{
			//Now init our data.
			Label = label;
		}

		/**
		Renders this TextLine.
		*/
		public override void Render()
		{
			PrintString(Label);
		}
	}
}