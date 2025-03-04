
type EventMapping = {
    [eventName: string]: string[];
};

export const eventHierarchy: EventMapping = {
    'IncrementRequestedEvent': ['ViewEvent'],
    'CounterUpdatedEvent': ['ModelEvent']
};

// Add new events here rather than modifying core code