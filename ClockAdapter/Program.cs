using static System.Console;

namespace ClockAdapter;

// Digital Clock interface
internal interface IDigitalClock
{
    void SetTime(int hour, int minute, int second);
    string GetTime();
}

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

internal static class Program
{
    private static void Main()
    {
        // Create an instance of the AnalogClock class
        var clock = new AnalogClock();

        // Create an instance of the ClockAdapter, passing the AnalogClock instance
        IDigitalClock digitalClock = new ClockAdapter(clock);

        var exit = false;
        while (!exit)
        {
            WriteLine("1. Set time");
            WriteLine("2. Get current time");
            WriteLine("3. Exit");
            WriteLine("Enter your choice:");

            var choice = ReadLine();

            switch (choice)
            {
                case "1":
                    WriteLine("Enter hour (0-23):");
                    var hour = int.Parse(ReadLine()!);

                    WriteLine("Enter minute (0-59):");
                    var minute = int.Parse(ReadLine()!);

                    WriteLine("Enter second (0-59):");
                    var second = int.Parse(ReadLine()!);

                    digitalClock.SetTime(hour, minute, second);
                    break;

                case "2":
                    WriteLine(digitalClock.GetTime());
                    break;

                case "3":
                    exit = true;
                    break;

                default:
                    WriteLine("Invalid choice. Please try again.");
                    break;
            }

            WriteLine();
        }
    }
}