
using System;

public class MapObject {
	private String name;
	private Position position;

	public MapObject(String name, Position position) {
		this.name = name;
		this.position = position;
	}

	public String GetName()
	{
		return name;
	}
	
	public Position GetPosition()
	{
		return position;
	}
}

