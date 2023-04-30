namespace ConsoleApp.Communication
{
    internal class SignalGenerator
    {
        private const int firstSignalAsciiCode = 65;
        private int currentSignalAsciiCode = firstSignalAsciiCode;

        public string CreateSignal()
        {
            return ((char)(currentSignalAsciiCode++)).ToString();
        }

        public void Reset()
        {
            currentSignalAsciiCode = firstSignalAsciiCode;
        }
    }
}
