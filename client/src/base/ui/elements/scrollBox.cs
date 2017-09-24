using System.Collections.Generic;
using BadFaith.Ui.Terminals;

namespace BadFaith.Ui.Elements
{
	/**
	Displays multiple lines,
	removing the oldest as it goes.
	*/
	public class ScrollBox : UiElement
	{
		/**
		The lines currently being displayed.
		Always displays the *last* of these.
		*/
		public List<string> Lines = new List<string>();
		/**
		The maximum number of lines
		stored before the oldest gets removed.
		*/
		public uint BufferMax;

		public ScrollBox(Terminal terminal, uint bufferMax = 80) : base(terminal)
		{
			//Now init our data.

			BufferMax = bufferMax;
		}

		/**
		Adds a line to the box.
		If the line contains newlines,
		they're each considered a separate line.
		*/
		public void AddLine(string stringToAdd = "")
		{

			string[] allStrings = stringToAdd.Split('\n');
			foreach (string s in allStrings)
			{ Lines.Add(s); }
			//Also pop off any excess from the top.
			while ((uint)Lines.Count > BufferMax)
			{ Lines.RemoveAt(0); }
		}

		/**
		Renders this ScrollBox.
		*/
		public override void Render()
		{
			uint linesToRender = (uint)min(Lines.Count, (uint)Extents.X);
			Vector2I stringPosition = Vector2I.Zero;
			foreach (string s in Lines.GetRange((int)(((uint)Lines.Count) - linesToRender), (int)linesToRender))
			{
				PrintString(s, stringPosition);
				stringPosition.X += 1;
			}
		}
	}
}