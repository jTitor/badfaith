namespace BadFaith
{
	public class CommandList(object):{
	def __init__(self):
		#List of commands scheduled to be run.
		self.commands = []
		#Executed field-visible events go here,
		#indexed by field ID.
		#This is cleared at the beginning of each update.
		self.fieldEvents = {}

	def generateFieldChannels(self):
		#Prime the field event channel if possible.
		for field in Field.All:
			self.fieldEvents[field.fieldID] = []

	def addCommand(self, command):
		self.commands.append(command)

	def update(self, game):
		#Clear all channels.
		for channelKey in self.fieldEvents:
			#Why doesn't Python 2 have clear()?
			del self.fieldEvents[channelKey][:]
		#While we still have commands...
		while self.commands:
			#Pop a command
			currCommand = self.commands.pop(0)
			#and execute it.
			if currCommand.execute(self):
				#If it ran, dispatch it to interested parties.
				#For now all events are public propagation,
				#so actor-specific channels aren't needed.
				self.fieldEvents[currCommand.originFieldID].append(currCommand)
				}
				}