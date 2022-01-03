import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { env } from '../../environments/environment';

import {
  ChartDataset,
  ScatterDataPoint
} from 'chart.js';

import {
  IndicatorListing,
  IndicatorParam,
  IndicatorResult,
  IndicatorResultConfig,
  IndicatorSelection
} from './chart.models';

@Injectable()
export class ApiService {

  constructor(
    private readonly http: HttpClient
  ) { }

  getQuotes() {
    return this.http.get(`${env.api}/quotes`, this.requestHeader());
  }

  getListings() {
    return this.http.get(`${env.api}/indicators`, this.requestHeader());
  }

  getSelectionData(selection: IndicatorSelection, listing: IndicatorListing): Observable<any> {

    const obs = new Observable((observer) => {

      // compose url
      let url = `${listing.endpoint}?`;
      selection.params.forEach((param: IndicatorParam, param_index: number) => {
        if (param_index != 0) url += "&";
        url += `${param.name}=${param.value}`;
      });

      // fetch data
      this.http.get(url, this.requestHeader())
        .subscribe({

          next: (apidata: any[]) => {

            // parse each dataset
            selection.results
              .forEach((result: IndicatorResult) => {

                // initialize dataset
                const config = listing.results.find(x => x.dataName == result.dataName);
                const dataset = this.initializeDataset(result, config);
                const data: ScatterDataPoint[] = [];

                // populate data
                apidata.forEach(dt => {

                  data
                    .push({
                      x: new Date(dt.date).valueOf(),
                      y: dt[result.dataName]
                    });
                });

                dataset.data = data;
                result.dataset = dataset;
              });

            observer.next(selection.results);
          },

          error: (e: HttpErrorResponse) => { console.log(e); return null; }
        });

    });

    return obs;
  }

  initializeDataset(r: IndicatorResult, c: IndicatorResultConfig) {

    switch (r.lineType) {

      case 'line':
        const lineDataset: ChartDataset = {
          label: r.label,
          type: 'line',
          data: [],
          yAxisID: 'yAxis',
          pointRadius: 0,
          borderWidth: r.lineWidth,
          borderColor: r.color,
          backgroundColor: r.color,
          fill: c.fill == null ? false : {
            target: c.fill.target,
            above: c.fill.colorAbove,
            below: c.fill.colorBelow
          },
          order: r.order
        };
        return lineDataset;

      case 'dash':
        const dashDataset: ChartDataset = {
          label: r.label,
          type: 'line',
          data: [],
          yAxisID: 'yAxis',
          pointRadius: 0,
          borderWidth: r.lineWidth,
          borderDash: [3, 2],
          borderColor: r.color,
          backgroundColor: r.color,
          order: r.order
        };
        return dashDataset;

      case 'dots':
        const dotsDataset: ChartDataset = {
          label: r.label,
          type: 'line',
          data: [],
          yAxisID: 'yAxis',
          pointRadius: 2,
          pointBorderWidth: 0,
          pointBorderColor: r.color,
          pointBackgroundColor: r.color,
          showLine: false,
          order: r.order
        };
        return dotsDataset;

      case 'bar':
        const barDataset: ChartDataset = {
          label: r.label,
          type: 'bar',
          data: [],
          yAxisID: 'yAxis',
          borderWidth: 0,
          borderColor: r.color,
          backgroundColor: r.color,
          order: r.order
        };
        return barDataset;
    }
  }

  // HELPERS
  requestHeader(): { headers?: HttpHeaders } {

    const simpleHeaders = new HttpHeaders()
      .set('Content-Type', 'application/json');

    return { headers: simpleHeaders };
  }
}
