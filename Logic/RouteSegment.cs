using System;

[Serializable()]
public class RouteSegment {
	private double targetSpeed;
	private double targetAltitude;
	private Position origin;
	private Position destination;

	public RouteSegment(Position _origin, Position _destination ,double speed, double altitude) {
		targetAltitude = altitude;
		targetSpeed = speed;
		destination = _destination;
		origin = _origin;
	}

	public Position GetDestination()
	{
		return destination;
	}

	public Position GetOrigin()
	{
		return origin;
	}

	public double GetTargetSpeed()
	{
		return targetSpeed;
	}

	public double GetTargetAltitude()
	{
		return targetAltitude;
	}
}

