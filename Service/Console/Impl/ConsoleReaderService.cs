using tetofo.DesignPattern;
using tetofo.EventBus;

namespace tetofo.Service.Console.Impl;

public class ConsoleReaderService : IConsoleReaderService
{

    private bool IsDisposed;
    private IEventBus _eventBus;
    private IMessageEventFactory _messageEventFactory;

    public ConsoleReaderService
    (
        IEventBus eventBus,
        IMessageEventFactory messageEventFactory
    )
    {
        _eventBus = eventBus;
        _messageEventFactory = messageEventFactory;
    }

    private Task? task;

    public void Dispose()
    {
        IsDisposed = true;
        if (task != null)
        {
            task = null;
        }
    }

    public void StartReadingConsole()
    {
        IsDisposed = false;
        if (task != null)
        {
            return;
        }
        task = new Task(() => ReadConsole());
        task.Start();
    }

    private void ReadConsole()
    {
        while (!IsDisposed)
        {
            string? line = System.Console.ReadLine();
            _eventBus.Event(_messageEventFactory.Create(line));
        }
    }
}