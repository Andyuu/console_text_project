namespace NotebookApp;

class NotebookLogger {
    private Notebook trackedNotebook;
    private bool logging = true;

    public NotebookLogger(Notebook trackedNotebook) {
        this.trackedNotebook = trackedNotebook;

        Attach();
        trackedNotebook.loggingToggled += ToggleLogging;

    }

    private void PrintAdded(string typeItemAdded) {
        MyConsole.writeSuccess(typeItemAdded + " was added to the notebook.");
    }

    private void PrintDeleted(string idOfDeleted) {
        if (idOfDeleted != "") {
            MyConsole.writeSuccess("Item " + idOfDeleted + " was deleted from the notebook.");
        } else {
            MyConsole.writeSuccess("Everything was deleted from the notebook.");
        }
    }
    private void IncorrectCommand(string messageToPrint) {
        MyConsole.writeWarning("Bad command: " + messageToPrint);
    }

    public void ToggleLogging(bool turnOn) {
        if (logging) {

            if (!turnOn) {
                Detach();
                logging = false;
                MyConsole.writeSuccess("Logger turned off.");
                return;
            }
        } else {

            if (turnOn) {
                Attach();
                logging = true;
                MyConsole.writeSuccess("Logger turned on.");
                return;
            }
        }
        MyConsole.writeError("Logger already " + (turnOn ? "on" : "off") + ".");
    }

    private void Attach() {
        trackedNotebook.ItemAdded += PrintAdded;
        trackedNotebook.ItemRemoved += PrintDeleted;
        trackedNotebook.InputBadCommand += IncorrectCommand;
    }

    private void Detach() {
        trackedNotebook.ItemAdded -= PrintAdded;
        trackedNotebook.ItemRemoved -= PrintDeleted;
        trackedNotebook.InputBadCommand -= IncorrectCommand;

    }
}