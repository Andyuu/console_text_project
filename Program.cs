// See https://aka.ms/new-console-template for more information

namespace NotebookApp;

internal class Program {

    static void Main(string[] args) {

        Notebook notebook = new Notebook();
        NotebookLogger notebookLogger = new NotebookLogger(notebook);

        const string ExitProgramKeyword = "exit";
        string commandPrompt = "Please enter " + notebook.show + ", " + notebook._new + ", " + notebook.delete + ", or " + notebook.log;

        MyConsole.writeLine(Notebook.IntroMessage);
        MyConsole.writeLine(commandPrompt);
        string input = "";
        do {
            input = MyConsole.readLine();

            string[] commands = input.Split();

            try {
                notebook[commands[0]]((commands.Length > 1) ? commands[1] : "");
            } catch (KeyNotFoundException) {
                if (input != ExitProgramKeyword) {
                    MyConsole.writeLine(commandPrompt);
                }
            }
            MyConsole.newLine();


        } while (input != ExitProgramKeyword);

        MyConsole.writeLine(Notebook.IntroMessage);
    }
}
