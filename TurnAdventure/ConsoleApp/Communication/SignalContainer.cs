namespace ConsoleApp.Communication
{
    internal class SignalContainer<Option> where Option : notnull
    {
        private readonly SignalGenerator _signalGenerator = new();

        private readonly Dictionary<Option, string> _signals = new();

        public string GetSignal(Option option)
        {
            if (_signals.TryGetValue(option, out string? signal))
            {
                return signal;
            }
            else
            {
                string newSignal = _signalGenerator.CreateSignal();
                _signals.Add(option, newSignal);

                return newSignal;
            }
        }

        public void Reset()
        {
            _signalGenerator.Reset();
            _signals.Clear();
        }
    }
}