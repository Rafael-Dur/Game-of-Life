using System;

public class Celula
{
    private bool isLive;

    public Celula(bool isLive)
    {
        IsLive=isLive;
    }

    public bool IsLive
    {
        get
        {
            return isLive;
        }
        set
        {
            isLive=value;
        }
    }
}