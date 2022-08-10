namespace NotebookApp;

class MessageList : TextualMessage {
    private enum BulletType { Dashed, Numbered, Star }
    private BulletType bulletType;

    public override IPageable Input() {
        MyConsole.writeLine("Please input your name");
        myData.author = MyConsole.readLine();
        MyConsole.writeLine("Please input the message title");
        myData.title = MyConsole.readLine();
        MyConsole.writeLine("What type of bullet point would you like to use?");
        MyConsole.writeLine("Please enter dashed, numbered, or star");

        bool goodInput = false;
        while (!goodInput) {
            goodInput = true;

            switch (MyConsole.readLine()) {
                case "dashed":
                    bulletType = BulletType.Dashed;
                    break;
                case "numbered":
                    bulletType = BulletType.Numbered;
                    break;
                case "star":
                    bulletType = BulletType.Star;
                    break;
                default:
                    MyConsole.writeLine("Please enter dashed, numbered, or star");
                    goodInput = false;
                    break;
            }
        }

        MyConsole.writeLine("Start typing your list. Every time you press enter, a new item will be created.");
        MyConsole.writeLine("Please enter with a blank line to end your list input.");

        bool finishedList = false;
        int i = 1;
        while (!finishedList) {
            string input = MyConsole.readLine();

            if (input == "") {
                finishedList = true;
            } else {

                switch (bulletType) {
                    case BulletType.Dashed:
                        message += "- " + input + " \n";
                        break;
                    case BulletType.Numbered:
                        message += i + ". " + input + " \n";
                        i++;
                        break;
                    case BulletType.Star:
                        message += "* " + input + " \n";
                        break;
                }
            }
        }


        return this;
    }
}