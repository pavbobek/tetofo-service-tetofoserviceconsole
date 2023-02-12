using tetofo.EventBus.Impl;

namespace tetofo.DesignPattern;

public interface IMessageEventFactory : IFactory<string?, MessageEvent> {}