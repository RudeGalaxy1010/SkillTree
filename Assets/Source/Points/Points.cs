using System;

public class Points
{
    private const string NegativeArgumentExceptionMessage = "Value can't be less than zero";

    public event Action<int> Changed;

    private int _value;

    public Points(int startValue = 0)
    {
        _value = startValue;
    }

    public int Value => _value;

    public void Add(int value)
    {
        if (value == 0)
        {
            return;
        }

        if (value <= 0)
        {
            throw new ArgumentException(NegativeArgumentExceptionMessage);
        }

        _value += value;
        Changed?.Invoke(_value);
    }

    public bool TrySpend(int value)
    {
        if (_value < value)
        {
            return false;
        }

        if (value <= 0)
        {
            throw new ArgumentException(NegativeArgumentExceptionMessage);
        }

        _value -= value;
        Changed?.Invoke(_value);
        return true;
    }
}
