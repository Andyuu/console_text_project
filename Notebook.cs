namespace NotebookApp;

class Notebook {

    public const string IntroMessage = "Welcome to Notebook program v1";
    public const string OutroMessage = "Thanks for using Notebook pragram v1";

    List<IPageable> pages = new List<IPageable>();

    public delegate void SimpleFunction(string command);
    public delegate void BooleanFunction(bool isOn);
    public event SimpleFunction? ItemAdded, ItemRemoved, InputBadCommand;
    public event BooleanFunction? loggingToggled;
    private Dictionary<string, SimpleFunction> commandLineArgs = new Dictionary<string, SimpleFunction>();
    public readonly string show = "show", _new = "new", delete = "delete", log = "logger";

    public SimpleFunction this[string command] {
        get { return commandLineArgs[command]; }
    }

    public Notebook() {
        commandLineArgs.Add(show, Show);
        commandLineArgs.Add(_new, New);
        commandLineArgs.Add(delete, Delete);
        commandLineArgs.Add(log, Log);
    }

    /// <summary>
    /// Creates a new notebook with input keywords for commands instead of default ones
    /// </summary>
    /// <param name="commandLineKeywords">index 0 = show, 1 = new, 3 = delete. </param>
    public Notebook(params string[] commandLineKeywords) : this() {

        for (int i = 0; i < commandLineKeywords.Length; i++) {

            if (commandLineKeywords[i] == "") {
                continue;
            }

            switch (i) {

                case 0:
                    commandLineArgs.Remove(show);
                    commandLineArgs.Add(show = commandLineKeywords[i], Show);
                    break;
                case 1:
                    commandLineArgs.Remove(_new);
                    commandLineArgs.Add(_new = commandLineKeywords[i], New);
                    break;
                case 2:
                    commandLineArgs.Remove(delete);
                    commandLineArgs.Add(delete = commandLineKeywords[i], Delete);
                    break;
            }
        }
    }

    private void New(string command) {

        switch (command) {
            case "":
                MyConsole.writeLine("New commands:");
                MyConsole.writeLine("message   create new message page");
                MyConsole.writeLine("list      create new list page");
                MyConsole.writeLine("image     create new image page");
                break;
            case "message":
                pages.Add(new TextualMessage().Input());

                if (ItemAdded != null) {
                    ItemAdded("Textual Message");
                }
                break;
            case "list":
                pages.Add(new MessageList().Input());

                if (ItemAdded != null) {
                    ItemAdded("Message List");
                }
                break;
            case "image":
                pages.Add(new Image().Input());

                if (ItemAdded != null) {
                    ItemAdded("Image");
                }
                break;
            default:
                if (InputBadCommand != null) {
                    InputBadCommand("You didn't enter message, list, or image. Please try again.");
                }
                break;
        }
    }

    private void Show(string command) {
        switch (command) {
            case "":
                MyConsole.writeLine("Show commands:");
                MyConsole.writeLine("pages         lists all pages");
                MyConsole.writeLine("id of page    display that page");
                break;

            case "pages":
                MyConsole.writeLine("/----------------------- Pages -----------------------\\");
                if (pages.Count != 0) {
                    for (int i = 0; i < pages.Count; i++) {
                        MyConsole.writeLine("ID " + i + " " + pages[i].MyData.title);
                    }
                } else {
                    MyConsole.writeError("No pages!");
                }
                MyConsole.writeLine("\\-----------------------------------------------------/");
                break;

            default:
                int number;

                if (int.TryParse(command, out number)) {
                    MyConsole.writeSuccess("Showing page " + number);

                    if (number < pages.Count) {
                        pages[number].Output();
                    } else {
                        if (InputBadCommand != null) {
                            InputBadCommand("Your number was outside of the range of pages. Please try again.");
                        }
                        break;
                    }
                } else {
                    if (InputBadCommand != null) {
                        InputBadCommand("You didn't enter pages or a valid number. Please try again.");
                    }
                }


                break;

        }
    }


    private void Delete(string command) {
        switch (command) {
            case "":
                MyConsole.writeLine("Delete commands:");
                MyConsole.writeLine("all           delete all created pages");
                MyConsole.writeLine("id of page    delete that page");
                break;

            case "all":
                pages.Clear();

                if (ItemRemoved != null) {
                    ItemRemoved("");
                }
                break;

            default:
                int number;

                if (int.TryParse(command, out number)) {

                    if (number < pages.Count) {
                        pages.RemoveAt(number);

                        if (ItemRemoved != null) {
                            ItemRemoved(number + "");
                        }
                    } else {
                        if (InputBadCommand != null) {
                            InputBadCommand("Your number was outside of the range of pages. Please try again.");
                        }
                    }
                } else {
                    if (InputBadCommand != null) {
                        InputBadCommand("You didn't input all, or your number was outside of the range of pages. Please try again.");
                    }
                }
                break;
        }
    }
    private void Log(string command) {
        switch (command) {
            case "":
                MyConsole.writeLine("Logger commands:");
                MyConsole.writeLine("on     turn logger on");
                MyConsole.writeLine("off    turn logger off");
                break;

            case "on":
                if (loggingToggled != null) {
                    loggingToggled(true);
                }
                break;

            case "off":
                if (loggingToggled != null) {
                    loggingToggled(false);
                }
                break;

            default:
                if (InputBadCommand != null) {
                    InputBadCommand("Please enter on or off after inputting the log command. Please try again.");
                }
                break;
        }

    }
}