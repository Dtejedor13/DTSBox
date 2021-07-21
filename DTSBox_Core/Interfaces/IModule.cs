namespace DTSBox_Core.Interfaces
{
    /// <summary>
    /// all with DTSBox to executing Programms need IModule Interface
    /// </summary>
    public interface IModule
    {
        bool StartModule();
        bool EndOfModule();
    }
}
