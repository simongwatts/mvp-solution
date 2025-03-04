import { IModel } from "../interfaces/IModel";
import { IView } from "../interfaces/IView";
export interface IPresenter<TView extends IView, TModel extends IModel> {
    readonly view: TView;
    readonly model: TModel;
    dispose(): void;
}
