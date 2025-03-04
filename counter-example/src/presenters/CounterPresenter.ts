import { PresenterBase } from "mvp-core/presenters/PresenterBase";
import { CounterModel } from "../models/CounterModel";
import { ICounterView } from "../views/CounterView";
import { CounterView } from "../views/CounterView";
import { CounterUpdatedEvent } from "../events/CounterEvents";
import { IncrementRequestedEvent } from "../events/CounterEvents";
import { IEventPublisher } from "mvp-core/interfaces/IEventPublisher";
import { ModelEvent } from "mvp-core/events/ModelEvent";
import { ViewEvent } from "mvp-core/events/ViewEvent";

export class CounterPresenter extends PresenterBase<CounterView, CounterModel> {
    constructor(
        view: CounterView,
        model: CounterModel,
        eventBus: IEventPublisher
    ) {
        console.log("constructor CounterPresenter");
        super(view, model, eventBus);
    }

    // Handle view events
    protected override onViewEvent(event: ViewEvent): void {
        console.log("onViewEvent");
        if (event instanceof IncrementRequestedEvent) {
            console.log("IncrementRequestedEvent");
            this.model.increment();
        }
    }

    // Handle model updates
    protected override onModelEvent(event: ModelEvent): void {
        console.log("onModelEvent");
        if (event instanceof CounterUpdatedEvent) {
            console.log("CounterUpdatedEvent");
            this.view.updateCount(event.newCount);
        }
    }
}