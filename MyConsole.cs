namespace NotebookApp;

public static class MyConsole {

    public static ConsoleColor outputColor = ConsoleColor.White;
    public static ConsoleColor inputColor = ConsoleColor.Gray;
    public static ConsoleColor successColor = ConsoleColor.Green;
    public static ConsoleColor warningColor = ConsoleColor.Yellow;
    public static ConsoleColor errorColor = ConsoleColor.Red;

    public static string inputPrefix = "> ";

    public static void newLine() {
        Console.WriteLine();
    }
    public static void writeLine(string? text) {
        Console.ForegroundColor = outputColor;
        Console.WriteLine(text);
    }
    public static string readLine() {
        Console.ForegroundColor = inputColor;
        Console.Write(inputPrefix);
        return (Console.ReadLine() ?? "");
    }
    public static void writeSuccess(string? text) {
        Console.ForegroundColor = successColor;
        Console.WriteLine(text);
    }

    public static void writeWarning(string? text) {
        Console.ForegroundColor = warningColor;
        Console.WriteLine(text);
    }

    public static void writeError(string? text) {
        Console.ForegroundColor = errorColor;
        Console.WriteLine("⚠️  " + text);
    }
}