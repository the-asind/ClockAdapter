namespace ClockAdapter;

// Digital Clock interface
internal interface IDigitalClock
{
    void SetTime(int hour, int minute, int second);
    string GetTime();
}