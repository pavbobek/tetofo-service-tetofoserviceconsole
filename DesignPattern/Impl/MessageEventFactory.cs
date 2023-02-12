using tetofo.EventBus;
using tetofo.EventBus.Impl;
using tetofo.Model;

namespace tetofo.DesignPattern.Impl;

public class MessageEventFactory : IMessageEventFactory
{
    private IAuthor _author;
    private IDataFactory _dataFactory;
    private readonly ISet<Tag> tags;

    public MessageEventFactory
    (
        IAuthor author,
        IDataFactory dataFactory
    )
    {
        _author = author;
        _dataFactory = dataFactory;
        tags = new HashSet<Tag>();
        tags.Add(Tag.MESSAGE);
    }
    public MessageEvent Create(string? s)
    {
        return new MessageEvent
        {
            Author = _author,
            Payload = _dataFactory.Create((tags, s, null))
        };
    }
}