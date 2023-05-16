namespace ClockAdapter;

// Adapter class for AnalogClock
internal class ClockAdapter : IDigitalClock
{
    private readonly AnalogClock _clock;

    public ClockAdapter(AnalogClock clock)
    {
        _clock = clock;
    }

    public void SetTime(int hour, int minute, int second)
    {
        // Convert hour, minute, and second to degrees of the analog clock
        var hourDegrees = hour * 30; // Each hour is 30 degrees
        var minuteDegrees = minute * 6; // Each minute is 6 degrees
        var secondDegrees = second * 6; // Each second is 6 degrees
        _clock.SetDegrees(hourDegrees, minuteDegrees, secondDegrees);
    }

    public string GetTime()
    {
        // Convert degrees of the analog clock to hour, minute, and second
        var hourDegrees = _clock.GetHourDegrees();
        var minuteDegrees = _clock.GetMinuteDegrees();
        var secondDegrees = _clock.GetSecondDegrees();

        var hour = hourDegrees / 30; // Each hour is 30 degrees
        var minute = minuteDegrees / 6; // Each minute is 6 degrees
        var second = secondDegrees / 6; // Each second is 6 degrees

        return $"{hour:D2}:{minute:D2}:{second:D2}";
    }
}