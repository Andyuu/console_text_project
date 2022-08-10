namespace NotebookApp;

class Image : IPageable {
    private PageData myData;
    private string? asciiImage;

    public IPageable Input() {
        MyConsole.writeLine("Please input your name");
        myData.author = MyConsole.readLine();
        MyConsole.writeLine("Please input the message title");
        myData.title = MyConsole.readLine();

        MyConsole.writeLine("Start inputting your image. Press enter to create as many lines as you like.");
        MyConsole.writeLine("Type \"end\" on a single line to stop creating your image.");

        while (true) {
            string input = MyConsole.readLine();

            if (input == "end") {
                break;
            } else {
                asciiImage += "\t" + input + "\n";
            }
        }
        return this;

    }

    public void Output() {
        MyConsole.newLine();
        MyConsole.writeLine("/----------------------- Image -----------------------\\");
        MyConsole.writeLine(" Title: " + myData.title);
        MyConsole.writeLine(" Author: " + myData.author);
        MyConsole.newLine();
        MyConsole.writeLine(asciiImage);
        MyConsole.writeLine("\\-----------------------------------------------------/");
    }
    public PageData MyData {
        get => myData;
        set => myData = value;
    }
}