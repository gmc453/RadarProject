
using System;

public class Helicopter : MovingMapObject
{
	public Helicopter(String name, Position initialPosition, double initialSpeed, double initialHeading, double initialAltitude) : base(name, initialPosition, initialSpeed, initialHeading, initialAltitude, 10, 3, 10) { }
}

