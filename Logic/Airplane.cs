﻿
using System;

public class Airplane : MovingMapObject
{
	public Airplane(String name, Position initialPosition, double initialSpeed, double initialHeading, double initialAltitude) : base(name, initialPosition, initialSpeed, initialHeading, initialAltitude, 3, 5, 5) { }
}

