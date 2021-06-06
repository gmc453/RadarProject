using System;



public class RadarExceptions : Exception
{
    public MovingObjectExceptions() { }
    public MovingObjectExceptions(string msg) : base(msg) { }
}


public class MovingObjectExceptions : RadarExceptions
{
    public MovingObjectExceptions() { }
    public MovingObjectExceptions(string msg) : base(msg) { }
}

public class WrongConstructorValue : MovingObjectExceptions
{
    private double value;
    public WrongConstructorValue() { }
    public WrongConstructorValue(string msg, double _value) : base(msg) { value = _value; }
}



