namespace GenchoCMD.IModels
{
    public interface ICommand
    {
        string Name { get; }
        void Input(string[] input);
        void Execute(string command);
        void Output(string output);
    }
}
