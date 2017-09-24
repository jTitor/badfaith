namespace BadFaith.Views.Player
{
	/**
	View commands for the player view.
	 */
	public static class XViewCommands
	{
		public string DescribeSelf()
		{ return string.Format("You are {0}.", Actor.Name); }

		public string DescribeField()
		{
			string fieldDescription = string.Format("You are in {0}.", Field.FullName);
			if (Field.FieldId == 0)
			{ fieldDescription += "\nYou get the feeling you shouldn't be here..."; }
			if (Field.Type == Field.Types.Gate)
			{
				Field otherField = Field.All[Field.DestinationFieldId];
				fieldDescription += string.Format("\nThis is a gate field! It's pointing to {0}.", otherField.FullName);
			}
			return fieldDescription;
		}

		public void LookAll()
		{
			/**
			Looks at everything in the field.
			*/
			//Print to world status even though this isn't a event.
			UiWorldEvents.AddLine(DescribeField());
		}

		public string ActorState()
		{
			return string.Format("Position:{0}, Armor: {1}/{2}, Psyche: {3}/{4}", Actor.FieldPosition, Actor.Armor, Actor.MaxArmor, Actor.Psyche, Actor.MaxPsyche);
		}

		public string ActorLocation()
		{ return string.Format("{0}: {1}", Actor.Name, Field.fullName); }

		public void DescribeActor(int otherActorId)
		{
			if (otherActorId == ControlledActorId)
				DescribeSelf();
			return;

			Actor actor = Actor.All[otherActorId];
			print(string.Format("You see a {0}.", actor.Name));
		}
	}
}