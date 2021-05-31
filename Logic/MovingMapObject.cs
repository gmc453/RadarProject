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

		Random random = new Random();

		route.Push(new RouteSegment(position,new Position(random.Next(25,75), random.Next(25, 75)),speed*(1+(random.NextDouble()-0.5f)/5), altitude * (1 + (random.NextDouble() - 0.5f) / 5)));
		route.Push(new RouteSegment(route.Peek().GetDestination(), new Position(random.Next(0,1) * 100, random.Next(0, 1)*100),speed*(1+(random.NextDouble()-0.5f)/5), altitude * (1 + (random.NextDouble() - 0.5f) / 5)));
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

		if (Position.CalculateHeading(GetPosition(), route.Peek().GetDestination()) < 3.0) {
			route.Pop();
		}

		RouteSegment segment = route.Peek();

		double targetHeading = Position.CalculateHeading(GetPosition(), segment.GetDestination());

		if (Math.Abs(heading - targetHeading) < turnRate * timeDelta)
		{
			heading = targetHeading;
		}
		else {
			heading += turnRate * timeDelta*Math.Sign(heading - targetHeading); 
		}

		if (Math.Abs(speed - segment.GetTargetSpeed()) < acceleration * timeDelta)
		{
			speed = segment.GetTargetSpeed();
		}
		else
		{
			speed += acceleration * timeDelta * Math.Sign(speed - segment.GetTargetSpeed());
		}

		if (Math.Abs(altitude - segment.GetTargetAltitude()) < climbRate * timeDelta)
		{
			altitude = segment.GetTargetAltitude();
		}
		else
		{
			altitude += climbRate * timeDelta * Math.Sign(speed - segment.GetTargetAltitude());
		}

		position.Tranlate(Math.Sin(targetHeading) * speed * timeDelta, Math.Sin(targetHeading)*speed*timeDelta);
	}
}

