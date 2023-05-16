namespace ClockAdapter;

// Analog clock class
internal class AnalogClock
{
    private int _hourDegrees;
    private int _minuteDegrees;
    private int _secondDegrees;

    public void SetDegrees(int hourDegrees, int minuteDegrees, int secondDegrees)
    {
        _hourDegrees = hourDegrees;
        _minuteDegrees = minuteDegrees;
        _secondDegrees = secondDegrees;
    }

    public int GetHourDegrees() => _hourDegrees;

    public int GetMinuteDegrees() => _minuteDegrees;

    public int GetSecondDegrees() => _secondDegrees;
}