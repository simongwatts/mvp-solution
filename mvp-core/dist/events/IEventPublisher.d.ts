export interface IEventPublisher {
    publish<T>(event: T): void;
    subscribe<T>(eventClass: new (...args: any[]) => T, handler: (event: T) => void): () => void;
}
