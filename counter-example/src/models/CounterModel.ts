import { IModel } from "mvp-core/interfaces/IModel";
import { IEventPublisher } from "mvp-core/interfaces/IEventPublisher";
import { CounterUpdatedEvent } from "../events/CounterEvents";

export class CounterModel implements IModel {
    private count = 0;

    constructor(private eventBus: IEventPublisher) { }

    increment(): void {
        console.log("increment");
        this.count++;
        this.eventBus.publish(new CounterUpdatedEvent(this.count));
    }
}