using System.Collections.Generic;
using BadFaith.Geography;
using BadFaith.Geography.Fields;

namespace BadFaith.Commands
{
	public class CommandList
	{
		//List of commands scheduled to be run.
		private Queue<Command> commands = new Queue<Command>();
		//Executed field-visible events go here,
		//indexed by field ID.
		//This is cleared at the beginning of each update.
		private Dictionary<int, Queue<Command>> fieldEvents = new Dictionary<int, Queue<Command>>();

		public CommandList()
		{
		}
		public void GenerateFieldChannels()
		{//Prime the field event channel if possible.
			foreach (Field field in Field.All)
			{
				fieldEvents[field.FieldId] = new Queue<Command>();
			}
		}

		public void AddCommand(Command command)
		{ commands.Enqueue(command); }

		public void Update(Game game)
		{//Clear all channels.
			foreach (Queue<Command> fieldEventList in fieldEvents.Values)
			{
				fieldEventList.Clear();
			}
			//While we still have commands...
			while (commands.Count > 0)
			{
				//Pop a command
				Command currCommand = commands.Dequeue();//self.commands.pop(0);
				//and execute it.
				if (currCommand.Execute())
				{
					//If it ran, dispatch it to interested parties.
					//For now all events are public propagation,
					//so actor-specific channels aren't needed.
					fieldEvents[currCommand.OriginFieldId].Enqueue(currCommand);
				}
			}
		}
	}
}