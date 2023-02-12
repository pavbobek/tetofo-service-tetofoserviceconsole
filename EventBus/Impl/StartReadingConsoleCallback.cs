using tetofo.Service.Console;

namespace tetofo.EventBus.Impl;

public class StartReadingConsoleCallback : BaseCallback
{
    private IConsoleReaderService _consoleReaderService;

    public StartReadingConsoleCallback
    (
        IConsoleReaderService consoleReaderService
    )
    : base(typeof(StartReadingConsoleEvent))
    {
        _consoleReaderService = consoleReaderService;
    }

    public override void Callback(IEvent iEvent) => _consoleReaderService.StartReadingConsole();
}