/**
	actor.cs
	Objects in the game world distinct from terrain that can move.
*/

struct Actor {
	public int ActorId;
	public string Name;
	public int MaxHealth;
	public int MaxArmor;
	public int MaxPsyche;
	public int Health;
	public int Armor;
	public int Psyche;
}

class Actors {
	/**
	All actors in the game world.
	Element 0 is the null element.
	*/
	protected static Actor[] all = new Actor[1];
	public void fieldChange()
}