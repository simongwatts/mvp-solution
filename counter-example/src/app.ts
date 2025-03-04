import { EventAggregator } from "mvp-core/events/EventAggregator";
import { CounterModel } from "./models/CounterModel";
import { CounterView } from "./views/CounterView";
import { CounterPresenter } from "./presenters/CounterPresenter";

// Initialize components
const eventBus = new EventAggregator();
const view = new CounterView(eventBus);
const model = new CounterModel(eventBus);
new CounterPresenter(view, model, eventBus);