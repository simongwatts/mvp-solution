export interface IEventPublisher {
    publish<T extends object>(event: T): void;
    subscribe<T extends object>(
        eventType: new (...args: any[]) => T,
        handler: (event: T) => void
    ): () => void;
}