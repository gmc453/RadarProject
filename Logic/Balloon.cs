
using System;

[Serializable()]
public class Balloon : MovingMapObject
{
	public Balloon(String name, Position initialPosition, double initialSpeed, double initialHeading, double initialAltitude) : base(name, initialPosition, initialSpeed, initialHeading, initialAltitude, 8, 1, 8) { }
}

