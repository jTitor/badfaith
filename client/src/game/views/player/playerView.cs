using System.Collections.Generic;

using BadFaith.Commands;
using BadFaith.Geography;
using BadFaith.Geography.Fields;
using BadFaith.Ui.Elements;
using BadFaith.Ui.Terminals;
using BadFaith.Views.Player;

namespace BadFaith.Views
{
	/**
	Displays world state and relays player input as world commands.

	There are two main sections: the world display
	and the command interpreter. The interpreter is split into
	two halves, a top line displaying system responses to their
	actions and a bottom line where the player enters commands.
	By default most commands are keyboard shortcuts, and '`' activates the interpreter mode.
	*/
	class PlayerView
	{
		public int ControlledActorId;
		public Actor Actor;
		public Field Field;
		public CommandList CommandList;
		public Terminal Terminal;
		public pass ActionList;
		public UiElement[] UiAll;
		public ScrollBox UiWorldEvents;
		public TextLine UiPlayerLocation;
		public TextLine UiPlayerStatus;
		public TextLine UiInterpreterResponse;
		public TextLine UiInterpreterInput;
		private void _doControlActor(int actorId)
		{
			if (actorId > Actor.All.Count)
			{ throw new GameException(string.Format("Invalid actor {0}", actorId)); }
			ControlledActorId = actorId;
			Actor = Actor.All[ControlledActorId];
			_updateField();
		}

		private void _updateField()
		{ Field = Field.All[Actor.FieldId]; }

		public PlayerView(Game game, int actorId = 0)
		{
			print("Entering world...");
			_doControlActor(actorId);
			ActionList = {
				ord('q'): game.Quit,
			ord('w'): lambda: Move(Directions.North),
			ord('s'): lambda: Move(Directions.South),
			ord('a'): lambda: Move(Directions.East),
			ord('d'): lambda: Move(Directions.West),
			ord('f'): ChangeField,
			ord('g'): UseGate,
			ord('l'): LookAll
			};
			CommandList = game.CommandList;
			//Ui elements.
			Terminal = game.Terminal;
			ScrollBox UiWorldEvents = new ScrollBox(Terminal);
			TextLine UiPlayerLocation = new TextLine(Terminal);
			TextLine UiPlayerStatus = new TextLine(Terminal);
			TextLine UiInterpreterResponse = new TextLine(Terminal);
			TextLine UiInterpreterInput = new TextLine(Terminal);
			UiPlayerLocation.SetColor(Terminal.Palette.WhiteOnBlack);
			UiPlayerStatus.SetColor(Terminal.Palette.WhiteOnBlack);
			UiInterpreterResponse.SetColor(Terminal.Palette.WhiteOnBlack);
			UiInterpreterInput.Label = ">";
			UiInterpreterResponse.Label = "What next?";
			UiElement[] UiAll = { UiWorldEvents, UiPlayerLocation, UiPlayerStatus, UiInterpreterResponse, UiInterpreterInput };
		}

		public void UpdateUi()
		{
			UiInterpreterResponse.Label = "What next?";
			UiPlayerLocation.Label = ActorLocation();
			UiPlayerStatus.Label = ActorState();
			foreach (Command fieldEvent in _getFieldChannel())
			{ UiWorldEvents.AddLine(fieldEvent.Render(ControlledActorId)); }
			foreach (UiElement uiElement in UiAll)
			{ uiElement.Render(); }
		}

		/**
		Ui layout callback.
		*/
		public void Layout(_)
		{
			UiInterpreterInput.ToBottom();
			UiInterpreterResponse.ToBottom(1);
			UiPlayerStatus.ToBottom(2);
			UiWorldEvents.ToTop(1);
			UiPlayerLocation.ToTop();
			UiInterpreterInput.FillRow();
			UiInterpreterResponse.FillRow();
			UiPlayerStatus.FillRow();
			Vector2I screenExtents = Terminal.MainWindow.Extents;
			UiWorldEvents.SetExtents(new Vector2I(screenExtents.X - 4, screenExtents.Y));
			UiPlayerLocation.FillRow();
			UpdateUi();
		}

		public void Update(Game game)
		{
			//Get player input here and send commands here.
			int playerInput = game.Terminal.GetCh();
			if (ActionList.Contains(playerInput))
			{
				//If input's a valid command, run it.
				ActionList[playerInput]();
			}
		}

		private List<Command> _getFieldChannel()
		{ return CommandList.FieldEvents[Actor.FieldId]; }

		public void Render()
		{
			//Display game world here.
			Terminal.Refresh(Layout);
		}
	}
}