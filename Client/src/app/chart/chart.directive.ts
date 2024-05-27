import { Directive, EventEmitter, Output } from "@angular/core";
import { IndicatorSelection } from "./chart.models";

@Directive({
  standalone: false,
  selector: '[afterAdd]'
})
export class ChartDirective {

  @Output() added: EventEmitter<IndicatorSelection> = new EventEmitter();
  ngAfterContentInit() {
    this.added.next(null);
  }
}
