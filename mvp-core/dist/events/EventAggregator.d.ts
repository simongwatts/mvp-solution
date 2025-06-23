import { IEventPublisher } from "../interfaces/IEventPublisher";
export declare class EventAggregator implements IEventPublisher {
    private subscriptions;
    publish<T extends object>(event: T): void;
    subscribe<T extends object>(eventType: new (...args: any[]) => T, handler: (event: T) => void): () => void;
    private unsubscribe;
    private getEventTypeHierarchy;
}
