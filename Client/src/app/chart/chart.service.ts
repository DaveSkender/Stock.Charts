import { Injectable } from '@angular/core';
import 'chartjs-adapter-date-fns';
import 'chartjs-chart-financial';

import {
    Chart,
    ChartConfiguration,
    Interaction,
    ScaleOptions
} from 'chart.js';

import {
    CandlestickController,
    CandlestickElement,
    OhlcController,
    OhlcElement
} from 'chartjs-chart-financial';

import {
    CrosshairPlugin,
    CrosshairOptions,
    Interpolate
} from 'chartjs-plugin-crosshair';

import { enUS } from 'date-fns/locale';
import { add, parseISO } from 'date-fns';

@Injectable()
export class ChartService {

    constructor() {
        Chart.register(
            CandlestickController,
            OhlcController,
            CandlestickElement,
            OhlcElement)

        // Chart.register(
        //     CrosshairPlugin,
        //     Interpolate);

        // Interaction.modes.interpolate = Interpolate;
    }

    baseConfig() {

        const commonXaxes = this.commonXAxes();
        const crosshairPluginOptions = this.crosshairPluginOptions();

        const config: ChartConfiguration = {

            type: 'line',
            data: {
                datasets: []
            },
            options: {
                plugins: {
                    title: {
                        font: {
                            family: 'Roboto'
                        },
                        display: false
                    },
                    legend: {
                        display: false
                    },
                    tooltip: {
                        enabled: true,
                        mode: 'index',  // TODO: should be 'interpolate'?
                        intersect: false
                    },
                    // crosshair: crosshairPluginOptions  // FIX: types not recognized
                },
                layout: {
                    padding: {
                        left: 10,
                        right: 10,
                        top: 5,
                        bottom: 0
                    }
                },
                responsive: true,
                maintainAspectRatio: false,

                scales: {
                    xAxis: commonXaxes,
                    yAxis: {
                        display: true,
                        type: 'linear',
                        axis: 'y',
                        position: 'right',
                        beginAtZero: false,
                        ticks: {
                            // autoSkip: true,
                            // autoSkipPadding: 5,
                            mirror: true,
                            padding: -5,
                            font: {
                                size: 10
                            },
                        },
                        grid: {
                            drawOnChartArea: true,
                            drawTicks: false
                        }
                    }
                }
            }
        };

        return config;
    }

    baseOverlayConfig(): ChartConfiguration {

        const config = this.baseConfig();
        config.type = 'candlestick';

        // aspect ratio
        config.options.maintainAspectRatio = true;

        // format y-axis, add dollar sign
        config.options.scales.yAxis.ticks.callback = (value, index, values) => {

            if (index === 0) return '';  // skip first label
            else
                return '$' + value;
        };

        // volume axis
        config.options.scales.volumeAxis = {
            display: false,
            type: 'linear',
            axis: 'y',
            position: 'left',
            beginAtZero: true
        } as ScaleOptions;

        return config;
    }

    baseOscillatorConfig(): ChartConfiguration {

        const config = this.baseConfig();

        // remove x-axis
        config.options.scales.xAxis.display = false;

        // format chart
        config.options.layout.padding = {
            left: 10,
            right: 10,
            top: 5,
            bottom: 5
        };

        return config;
    }

    commonXAxes(): ScaleOptions {

        const axes: ScaleOptions = {
            display: false,
            type: 'timeseries',
            time: {
                unit: 'day'
            },
            adapters: {
                date: {
                    locale: enUS
                },
            },
            ticks: {
                source: "auto",
                padding: 0,
                autoSkip: true,
                maxRotation: 0,
                minRotation: 0,
                font: {
                    size: 9
                },
            },
            grid: {
                drawOnChartArea: false,
                tickLength: 2
            }
        };

        return axes;
    }

    crosshairPluginOptions(): CrosshairOptions {

        const crosshairOptions: CrosshairOptions = {
            line: {
                color: '#F66',                                      // crosshair line color
                width: 1                                            // crosshair line width
            },
            sync: {
                enabled: true,                                      // enable trace line syncing with other charts
                group: 1,                                           // chart group (can be unique set of groups)
                suppressTooltips: true                              // suppress tooltips when showing a synced tracer
            },
            zoom: {
                enabled: false,                                     // enable zooming
                zoomboxBackgroundColor: 'rgba(66,133,244,0.2)',     // background color of zoom box
                zoomboxBorderColor: '#48F',                         // border color of zoom box
                zoomButtonText: 'Reset Zoom',                       // reset zoom button text
                zoomButtonClass: 'reset-zoom',                      // reset zoom button class
            },
            snap: {
                enabled: true
            },
            callbacks: {
                beforeZoom: (start, end) => {                       // called before zoom, return false to prevent zoom
                    return true;
                },
                afterZoom: (start, end) => {                        // called after zoom
                }
            }
        };

        return crosshairOptions;
    }
}
