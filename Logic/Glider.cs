
using System;

public class Glider : MovingMapObject
{
	public Glider(String name, Position initialPosition, double initialSpeed, double initialHeading, double initialAltitude) : base(name, initialPosition, initialSpeed, initialHeading, initialAltitude, 1, 2, 3) { }
}

