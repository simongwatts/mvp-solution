"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PresenterBase = void 0;
const ModelEvent_1 = require("../events/ModelEvent");
const ViewEvent_1 = require("../events/ViewEvent");
class PresenterBase {
    constructor(view, model, eventBus) {
        this.view = view;
        this.model = model;
        this.eventBus = eventBus;
        this.subscriptions = [];
        console.log("constructor PresenterBase");
        this.initialize();
    }
    initialize() {
        console.log("Subscribe to concrete base events");
        this.subscribe(ViewEvent_1.ViewEvent, e => this.onViewEvent(e));
        this.subscribe(ModelEvent_1.ModelEvent, e => this.onModelEvent(e));
    }
    onViewEvent(event) { }
    onModelEvent(event) { }
    subscribe(eventType, handler) {
        this.subscriptions.push(this.eventBus.subscribe(eventType, handler));
    }
    dispose() {
        this.subscriptions.forEach(unsubscribe => unsubscribe());
        this.subscriptions = [];
    }
}
exports.PresenterBase = PresenterBase;
