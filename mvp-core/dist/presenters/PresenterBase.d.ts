import { IEventPublisher } from "../interfaces/IEventPublisher";
import { IModel } from "../interfaces/IModel";
import { IView } from "../interfaces/IView";
import { ModelEvent } from "../events/ModelEvent";
import { ViewEvent } from "../events/ViewEvent";
export declare abstract class PresenterBase<TView extends IView, TModel extends IModel> {
    readonly view: TView;
    readonly model: TModel;
    protected eventBus: IEventPublisher;
    private subscriptions;
    constructor(view: TView, model: TModel, eventBus: IEventPublisher);
    protected initialize(): void;
    protected onViewEvent(event: ViewEvent): void;
    protected onModelEvent(event: ModelEvent): void;
    protected subscribe<T extends object>(eventType: new (...args: any[]) => T, handler: (event: T) => void): void;
    dispose(): void;
}
