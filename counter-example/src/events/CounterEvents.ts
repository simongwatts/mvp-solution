import { ModelEvent } from "mvp-core/events/ModelEvent";
import { ViewEvent } from "mvp-core/events/ViewEvent";

export class IncrementRequestedEvent extends ViewEvent { }
export class CounterUpdatedEvent extends ModelEvent {
    constructor(public readonly newCount: number) {
        console.log("constructor CounterUpdatedEvent");
        super();
    }
}