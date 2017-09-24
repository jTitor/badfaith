using BadFaith.Commands;
using BadFaith.Geography;

namespace BadFaith.Views.Player
{
	public static class XActionCommands
	{
		/**
		Attempts to move the player's actor in
		the given direction.
		*/
		public void Move(Direction direction)
		{
			CommandList.AddCommand(new Commands.Move(ControlledActorId, direction));
			UiInterpreterResponse.Label = string.Format("Moving {0}...", direction.Name);
		}

		/**
		Prompts for a field to go to,
		then tries to go to that field.
		*/
		public void ChangeField()
		{
			pass;
			_updateField();
		}

		/**
		Uses the field's gate, if it has one.
		*/
		public void UseGate()
		{
			if (Field.Type != Field.Types.Gate)
			{ UiInterpreterResponse.Label = "This isn't a gate field."; }
			else
			{
				CommandList.AddCommand(new Commands.EnterGate(ControlledActorId));
				_updateField();
			}
		}
	}
}