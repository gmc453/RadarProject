using System;
using System.Collections.Generic;

public enum Status
{
	Safe, InDanger, Collided
}

public class MovingMapObject : MapObject
{
	private double speed;
	private double heading;
	private double altitude;

	private double acceleration;
	private double climbRate;
	private double turnRate;

	private Stack<RouteSegment> route = new Stack<RouteSegment>();

	private Status status = Status.Safe;

	public MovingMapObject(String name, Position position, double speed, double heading, double altitude, double acceleration, double climbRate, double turnRate) : base(name, position)
	{
		this.speed = speed;
		this.heading = heading;
		this.altitude = altitude;
		this.acceleration = acceleration;
		this.climbRate = climbRate;
		this.turnRate = turnRate;
	}

	public void SetNewRoute(Stack<RouteSegment> newRoute) {
		route = newRoute;
	}

	public void SetStatus(Status newStatus) {
		status = newStatus;
	}

	public Status GetStatus()
	{
		return status;
	}

	public double GetAltitude()
	{
		return altitude;
	}

	public double GetHeading()
	{
		return heading;
	}
	public double GetSpeed()
	{
		return speed;
	}

	public void Simulate(double timeDelta) { 
		

	}
}

