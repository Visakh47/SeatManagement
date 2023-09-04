public interface IReportManagerView<T>
{
    void Display();

    Task GenerateReportView();
}