export declare class EventBus implements IEventPublisher {
    private subscriptions;
    publish<T>(event: T): void;
    subscribe<T>(eventClass: new (...args: any[]) => T, handler: (event: T) => void): () => void;
    private unsubscribe;
}
