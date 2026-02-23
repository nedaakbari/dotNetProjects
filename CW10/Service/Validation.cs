namespace CW10.Service;

public class Validation
{
    public static void ValidateNull(String value, String message)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(message);
    }
}