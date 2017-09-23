/**
 */
using System;
using System.Collections.Generic;

namespace BadFaith.Geography.Fields
{
public class Gate: Field
{
	/**A special type of field that lets you go to another zone.
	*/

	/**All gates. Note that Gate.All[0] is valid, since
	all gates are fields.
	*/
	private static List<Gate> _all = new List<Gate>();
	public static List<Gate> AllGates { get { return _all; } }
	public static void InitGates(int numGates)
	{
		throw new System.NotImplementedException("Implement null element initialization");
	}

	public Gate()
	{
		// super(Gate, self).__init__()
		// self.destinationFieldID = 0
		// Gate.All.append(self)
		// self.type = Field.Types.Gate
		throw new NotImplementedException();
	}

	public void LinkTo(Gate destinationGate)
	{
		/**Makes a two-way link with another gate field.
		*/
		// assert isinstance(destinationGate, Gate)
		// #If we were already connected to another gate,
		// #disconnect it from us first.
		// if self.destinationFieldID != 0:
		// 	Field.All[self.destinationFieldID].destinationFieldID = 0
		// self.destinationFieldID = destinationGate.fieldID
		// destinationGate.destinationFieldID = self.fieldID
		throw new NotImplementedException();
	}

	public static void LinkTo(Gate a, Gate b)
	{
		//Probably really naive
		a.LinkTo(b);
	}
}
}