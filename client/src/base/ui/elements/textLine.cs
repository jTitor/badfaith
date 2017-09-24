using BadFaith.UI.Terminals;

namespace BadFaith.UI
{
	/**
	Displays a single string inside itself.
	This tries to have the same width as the screen.
	*/
	class TextLine : UIElement
	{
		/**
		The text to display.
		*/
		public string Label;

		public TextLine(self, Terminal terminal, string label = "")
		{
			super(UI.TextLine, self).__init__(terminal);
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