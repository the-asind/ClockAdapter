using static System.Console;

namespace ClockAdapter;

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