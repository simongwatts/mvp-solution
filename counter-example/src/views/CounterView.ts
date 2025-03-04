import { IView } from "mvp-core/interfaces/IView";
import { IEventPublisher } from "mvp-core/interfaces/IEventPublisher";
import { IncrementRequestedEvent } from "../events/CounterEvents";

export interface ICounterView extends IView {
    updateCount(count: number): void;
}

export class CounterView implements ICounterView {
    private countElement: HTMLElement;
    private incrementButton: HTMLButtonElement;

    constructor(private eventBus: IEventPublisher) {
        console.log("constructor CounterView");

        this.countElement = document.getElementById('count')!;

        const button = document.getElementById('increment-btn');

        if (button instanceof HTMLButtonElement)
        {
            this.incrementButton = button;
        }
        else
        {
            throw new Error('Increment button not found or is not a button element');
        }

        this.incrementButton.textContent = 'Increment Me';
        this.incrementButton.addEventListener('click', () => {
            console.log('Increment button clicked');
            this.eventBus.publish(new IncrementRequestedEvent());
        });

        //document.body.append(this.countElement, this.incrementButton);
    }

    updateCount(count: number): void {
        console.log("updateCount");
        this.countElement.textContent = count.toString();
    }
}