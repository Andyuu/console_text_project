namespace NotebookApp;

public struct PageData {
    public string title;
    public string author;

}

public interface IPageable {
    PageData MyData { get; set; }
    IPageable Input();
    void Output();
}