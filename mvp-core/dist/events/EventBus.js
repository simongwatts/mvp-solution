"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EventBus = void 0;
class EventBus {
    constructor() {
        this.subscriptions = new Map();
    }
    publish(event) {
        const eventType = event.constructor.name;
        const handlers = this.subscriptions.get(eventType);
        if (handlers) {
            handlers.forEach(handler => handler(event));
        }
    }
    subscribe(eventClass, handler) {
        const eventType = eventClass.name;
        let handlers = this.subscriptions.get(eventType);
        if (!handlers) {
            handlers = new Set();
            this.subscriptions.set(eventType, handlers);
        }
        handlers.add(handler);
        return () => this.unsubscribe(eventType, handler);
    }
    unsubscribe(eventType, handler) {
        const handlers = this.subscriptions.get(eventType);
        if (handlers) {
            handlers.delete(handler);
            if (handlers.size === 0) {
                this.subscriptions.delete(eventType);
            }
        }
    }
}
exports.EventBus = EventBus;
