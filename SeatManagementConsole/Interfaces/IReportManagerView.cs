public interface IReportManagerView
{
    void DisplaySeat();

    void DisplayCabin();

    Task GenerateReportView();
}