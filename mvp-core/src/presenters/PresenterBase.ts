import { IEventPublisher } from "../interfaces/IEventPublisher";
import { IModel } from "../interfaces/IModel";
import { IView } from "../interfaces/IView";

import { ModelEvent } from "../events/ModelEvent";
import { ViewEvent } from "../events/ViewEvent";

export abstract class PresenterBase<TView extends IView, TModel extends IModel> {
    private subscriptions: Array<() => void> = [];

    constructor(
        public readonly view: TView,
        public readonly model: TModel,
        protected eventBus: IEventPublisher
    ) {
        console.log("constructor PresenterBase");
        this.initialize();
    }

    protected initialize(): void {
        console.log("Subscribe to concrete base events");
        this.subscribe(ViewEvent, e => this.onViewEvent(e));
        this.subscribe(ModelEvent, e => this.onModelEvent(e));
    }

    protected onViewEvent(event: ViewEvent): void { }
    protected onModelEvent(event: ModelEvent): void { }

    protected subscribe<T extends object>(
        eventType: new (...args: any[]) => T,
        handler: (event: T) => void
    ): void {
        this.subscriptions.push(
            this.eventBus.subscribe(eventType, handler)
        );
    }

    public dispose(): void {
        this.subscriptions.forEach(unsubscribe => unsubscribe());
        this.subscriptions = [];
    }
}