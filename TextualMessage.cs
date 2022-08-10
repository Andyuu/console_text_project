namespace NotebookApp;
class TextualMessage : IPageable {
    protected PageData myData;
    protected string? message;

    public virtual IPageable Input() {
        MyConsole.writeLine("Please input your name");
        myData.author = MyConsole.readLine();
        MyConsole.writeLine("Please input the message title");
        myData.title = MyConsole.readLine();
        MyConsole.writeLine("Please input the message");
        message = MyConsole.readLine();
        return this;
    }

    public void Output() {
        MyConsole.newLine();
        MyConsole.writeLine("/---------------------- Message ----------------------\\");
        MyConsole.writeLine(" Title: " + myData.title);
        MyConsole.writeLine(" Author: " + myData.author);
        MyConsole.writeLine(" Message: \n \n" + message);
        MyConsole.writeLine("\\-----------------------------------------------------/");
    }

    public PageData MyData {
        get => myData;
        set => myData = value;
    }
}