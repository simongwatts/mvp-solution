"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EventAggregator = void 0;
const EventTypes_1 = require("./EventTypes");
class EventAggregator {
    constructor() {
        this.subscriptions = new Map();
    }
    publish(event) {
        console.log("EventAggregator publish");
        const eventTypes = this.getEventTypeHierarchy(event);
        eventTypes.forEach(type => {
            const handlers = this.subscriptions.get(type) || new Set();
            handlers.forEach(handler => handler(event));
        });
    }
    subscribe(eventType, handler) {
        console.log("EventAggregator subscribe");
        const typeName = eventType.name;
        const handlers = this.subscriptions.get(typeName) || new Set();
        handlers.add(handler);
        this.subscriptions.set(typeName, handlers);
        return () => this.unsubscribe(typeName, handler);
    }
    unsubscribe(typeName, handler) {
        console.log("EventAggregator unsubscribe");
        const handlers = this.subscriptions.get(typeName);
        if (handlers) {
            handlers.delete(handler);
            if (handlers.size === 0) {
                this.subscriptions.delete(typeName);
            }
        }
    }
    getEventTypeHierarchy(event) {
        console.log("EventAggregator getEventTypeHierarchy");
        const types = [];
        const eventName = event.constructor.name;
        console.log("eventName: " + eventName);
        // Add concrete type
        types.push(eventName);
        // Add registered base types
        if (EventTypes_1.eventHierarchy[eventName]) {
            types.push(...EventTypes_1.eventHierarchy[eventName]);
        }
        return types;
    }
}
exports.EventAggregator = EventAggregator;
