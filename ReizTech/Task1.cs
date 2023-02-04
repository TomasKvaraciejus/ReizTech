// 1 - Calculating lesser angle between hour and minute hands on analogue clock

try
{
    int minutes;
    float hours, angle;
    string input;

    Console.WriteLine("Enter hour value:"); // Input must be integer between 0-24 (values above 12 will be lowered to 0-12 range)
    input = Console.ReadLine();
    hours = Int32.Parse(input);
    if (hours > 12)
        hours -= 12;
    if (hours > 12 || hours < 0)
        throw new Exception("Hour hand out of range");

    Console.WriteLine("Enter minute value:"); // Input must be integer between 0-60
    input = Console.ReadLine();
    minutes = Int32.Parse(input);
    if (minutes > 60 || minutes < 0)
        throw new Exception("Minute hand out of range");

    Console.WriteLine($"Time on clock is {hours}h {minutes}min");

    hours += (float)minutes / 60;

    angle = Math.Abs((hours * 5) - minutes) * 6;
    if (angle > 180)
        angle = 360 - angle;

    Console.WriteLine($"\nLesser angle between hour and minute hands is {Math.Round(angle, 2)}deg");
}
catch (Exception ex)
{
    Console.WriteLine($"err: {ex.Message}");
}
