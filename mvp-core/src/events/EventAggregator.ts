import { IEventPublisher } from "../interfaces/IEventPublisher";
import { eventHierarchy } from "./EventTypes";

export class EventAggregator implements IEventPublisher {
    private subscriptions = new Map<string, Set<Function>>();

    publish<T extends object>(event: T): void {
        console.log("EventAggregator publish");

        const eventTypes = this.getEventTypeHierarchy(event);
        eventTypes.forEach(type => {
            const handlers = this.subscriptions.get(type) || new Set();
            handlers.forEach(handler => handler(event));
        });
    }

    subscribe<T extends object>(
        eventType: new (...args: any[]) => T,
        handler: (event: T) => void
    ): () => void {
        console.log("EventAggregator subscribe");

        const typeName = eventType.name;
        const handlers = this.subscriptions.get(typeName) || new Set<Function>();
        handlers.add(handler);
        this.subscriptions.set(typeName, handlers);
        return () => this.unsubscribe(typeName, handler);
    }

    private unsubscribe(typeName: string, handler: Function): void {
        console.log("EventAggregator unsubscribe");

        const handlers = this.subscriptions.get(typeName);
        if (handlers) {
            handlers.delete(handler);
            if (handlers.size === 0) {
                this.subscriptions.delete(typeName);
            }
        }
    }

    private getEventTypeHierarchy(event: object): string[] {
        console.log("EventAggregator getEventTypeHierarchy");

        const types: string[] = [];
        const eventName = event.constructor.name;
        console.log("eventName: " + eventName);

        // Add concrete type
        types.push(eventName);

        // Add registered base types
        if (eventHierarchy[eventName]) {
            types.push(...eventHierarchy[eventName]);
        }

        return types;
    }
}