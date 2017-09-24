/**
Base definition of world commands.
 */

namespace BadFaith.Commands
{
	public class Command
	{
		public readonly int OriginFieldId;

		public Command(int originFieldId)
		{
			OriginFieldId = originFieldId;
		}

		/**
		Displays this command to the given viewer.
		Returns the string to print to indicate the render state.
		 */
		public virtual string Render(int viewerId) { return ""; }

		/**
		Runs this command on the world.
		The implementor is expected to validate the behavior.
		Returns true if the event was successfully executed, false otherwise.
		*/
		public virtual bool Execute(CommandList commandList) { return true; }
	}
}