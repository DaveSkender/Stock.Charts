namespace WebApi.Services;

public static class Metadata
{
    public static List<IndicatorList> IndicatorList(string baseUrl)
    {
        string standardRed = "#DD2C00";
        string standardOrange = "#EF6C00";
        string standardGreen = "#2E7D32";
        string standardBlue = "#1E88E5";
        string standardPurple = "#8E24AA";
        //string standardGray = "#9E9E9E";
        string standardGrayTransparent = "#9E9E9E50";
        string darkGray = "#757575";
        string darkGrayTransparent = "#75757515";
        string thresholdRed = "#B71C1C70";
        string thresholdGreen = "#1B5E2070";

        return new List<IndicatorList>()
        {
            // Average Directional Index (ADX)
            new IndicatorList
            {
                Name = "Average Directional Index (ADX)",
                Uiid = "ADX",
                LabelTemplate = "ADX([P1])",
                Endpoint = $"{baseUrl}/ADX/",
                Category = "price-trend",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    //MinimumYAxis = 0,
                    //MaximumYAxis = 100,

                    Thresholds = new List<ChartThreshold>
                    {
                        //new ChartThreshold {
                        //    Value = 50,
                        //    Color = standardGrayTransparent,
                        //    Style = "dash"
                        //},
                        new ChartThreshold {
                            Value = 40,
                            Color = standardGrayTransparent,
                            Style = "dash"
                        },
                        new ChartThreshold {
                            Value = 20,
                            Color = standardGrayTransparent,
                            Style = "dash"
                        }
                    }
                },
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 14,
                        Minimum = 2,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "ADX([P1])",
                        DisplayName = "ADX",
                        DataName = "adx",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "DI+([P1])",
                        DisplayName = "DI+",
                        DataName = "pdi",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardGreen
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "DI-([P1])",
                        DisplayName= "DI-",
                        DataName = "mdi",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardRed
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "ADXR([P1])",
                        DisplayName = "ADX Rating",
                        DataName = "adxr",
                        DataType = "number",
                        LineType = "dash",
                        DefaultColor = darkGrayTransparent
                    }

                }
            },

            // Aroon Up/Down
            new IndicatorList
            {
                Name = "Aroon Up/Down",
                Uiid = "AROON UP/DOWN",
                LabelTemplate = "AROON([P1]) Up/Down",
                Endpoint = $"{baseUrl}/AROON/",
                Category = "price-trend",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    MinimumYAxis = 0,
                    MaximumYAxis = 100,

                    Thresholds = new List<ChartThreshold>
                    {
                        new ChartThreshold {
                            Value = 70,
                            Color = standardGrayTransparent,
                            Style = "solid"
                        },
                        new ChartThreshold {
                            Value = 50,
                            Color = standardGrayTransparent,
                            Style = "dash"
                        },
                        new ChartThreshold {
                            Value = 30,
                            Color = standardGrayTransparent,
                            Style = "solid"
                        }
                    }
                },
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 25,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "UP([P1])",
                        DisplayName = "Aroon Up",
                        DataName = "aroonUp",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardGreen
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "DOWN([P1])",
                        DisplayName= "Aroon Down",
                        DataName = "aroonDown",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardRed
                    }
                }
            },

            // Aroon Oscillator
            new IndicatorList
            {
                Name = "Aroon Oscillator",
                Uiid = "AROON OSC",
                LabelTemplate = "AROON([P1]) Oscillator",
                Endpoint = $"{baseUrl}/AROON/",
                Category = "price-trend",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    MinimumYAxis = -100,
                    MaximumYAxis = 100,

                    Thresholds = new List<ChartThreshold>
                    {
                        new ChartThreshold {
                            Value = 0,
                            Color = standardGrayTransparent,
                            Style = "dash"
                        }
                    }
                },
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 25,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "OSC([P1])",
                        DisplayName = "Oscillator",
                        DataName = "oscillator",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Bollinger Bands
            new IndicatorList
            {
                Name = "Bollinger Bands®",
                Uiid = "BB",
                LabelTemplate = "BB([P1],[P2])",
                Endpoint = $"{baseUrl}/BB/",
                Category = "price-channel",
                ChartType = "overlay",
                Order = Order.BehindPrice,
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 20,
                        Minimum = 2,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Standard Deviations",
                        ParamName= "standardDeviations",
                        DataType = "number",
                        Order = 2,
                        Required = true,
                        DefaultValue = 2,
                        Minimum = 0.01,
                        Maximum = 10
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "BB([P1],[P2]) Upper Band",
                        DisplayName = "Upper Band",
                        DataName = "upperBand",
                        DataType = "number",
                        LineType = "solid",
                        LineWidth = 1,
                        DefaultColor = darkGray,
                        Fill = new ChartFill
                        {
                            Target = "+2",
                            ColorAbove = darkGrayTransparent,
                            ColorBelow = darkGrayTransparent
                        }
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "BB([P1],[P2]) Centerline",
                        DisplayName = "Centerline",
                        DataName = "sma",
                        DataType = "number",
                        LineType = "dash",
                        LineWidth = 1,
                        DefaultColor = darkGray
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "BB([P1],[P2]) Lower Band",
                        DisplayName = "Lower Band",
                        DataName = "lowerBand",
                        DataType = "number",
                        LineType = "solid",
                        LineWidth = 1,
                        DefaultColor = darkGray
                    }
                }
            },

            // Chandelier Exit (long)
            new IndicatorList
            {
                Name = "Chandelier Exit (long)",
                Uiid = "CHEXIT-LONG",
                LabelTemplate = "CHANDELIER([P1],[P2],LONG)",
                Endpoint = $"{baseUrl}/CHEXIT-LONG/",
                Category = "stop-and-reverse",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 22,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Multiplier",
                        ParamName = "multiplier",
                        DataType = "number",
                        Order = 2,
                        Required = true,
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 10
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "CHANDELIER([P1],[P2],LONG)",
                        DisplayName = "Chandelier Exit",
                        DataName = "chandelierExit",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardOrange
                    }
                }
            },

            // Chandelier Exit (short)
            new IndicatorList
            {
                Name = "Chandelier Exit (short)",
                Uiid = "CHEXIT-SHORT",
                LabelTemplate = "CHANDELIER([P1],[P2],SHORT)",
                Endpoint = $"{baseUrl}/CHEXIT-SHORT/",
                Category = "stop-and-reverse",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 22,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Multiplier",
                        ParamName = "multiplier",
                        DataType = "number",
                        Order = 2,
                        Required = true,
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 10
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "CHANDELIER([P1],[P2],LONG)",
                        DisplayName = "Chandelier Exit",
                        DataName = "chandelierExit",
                        DataType = "number",
                        LineType = "dash",
                        DefaultColor = standardOrange
                    }
                }
            },

            // Choppiness Index
            new IndicatorList
            {
                Name = "Choppiness Index",
                Uiid = "CHOP",
                LabelTemplate = "CHOP([P1])",
                Endpoint = $"{baseUrl}/CHOP/",
                Category = "oscillator",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    MinimumYAxis = 0,
                    MaximumYAxis = 100,

                    Thresholds = new List<ChartThreshold>
                    {
                        new ChartThreshold {
                            Value = 61.8,
                            Color = darkGrayTransparent,
                            Style = "dash",
                            Fill = new ChartFill
                            {
                                Target = "+2",
                                ColorAbove = "transparent",
                                ColorBelow = thresholdRed
                            }
                        },
                        new ChartThreshold {
                            Value = 38.2,
                            Color = darkGrayTransparent,
                            Style = "dash",
                            Fill = new ChartFill
                            {
                                Target = "+1",
                                ColorAbove = thresholdGreen,
                                ColorBelow = "transparent"
                            }
                        }
                    }
                },
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "CHOP([P1])",
                        DisplayName = "Choppiness",
                        DataName = "chop",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Elder-ray
            new IndicatorList
            {
                Name = "Elder-ray Index",
                Uiid = "ELDER-RAY",
                LabelTemplate = "ELDER-RAY([P1])",
                Endpoint = $"{baseUrl}/ELDER-RAY/",
                Category = "price-trend",
                ChartType = "oscillator",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 13,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "Elder-ray Bull Power ([P1])",
                        DisplayName = "Bull Power",
                        DataName = "bullPower",
                        DataType = "number",
                        LineType = "bar",
                        Stack = "eray",
                        DefaultColor = standardGreen
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "Elder-ray Bear Power ([P1])",
                        DisplayName = "Bear Power",
                        DataName = "bearPower",
                        DataType = "number",
                        LineType = "bar",
                        Stack = "eray",
                        DefaultColor = standardRed
                    }
                }
            },

            // Exponential Moving Average
            new IndicatorList
            {
                Name = "Exponential Moving Average (EMA)",
                Uiid = "EMA",
                LabelTemplate = "EMA([P1])",
                Endpoint = $"{baseUrl}/EMA/",
                Category = "moving-average",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 20,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "EMA([P1])",
                        DisplayName = "EMA",
                        DataName = "ema",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Fractal (Williams)
            new IndicatorList
            {
                Name = "Williams Fractal (high/low)",
                Uiid = "FRACTAL",
                LabelTemplate = "FRACTAL([P1])",
                Endpoint = $"{baseUrl}/FRACTAL/",
                Category = "price-pattern",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Window Span",
                        ParamName = "windowSpan",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 2,
                        Minimum = 1,
                        Maximum = 100
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "Fractal Bull ([P1])",
                        DisplayName = "Fractal Bull",
                        DataName = "fractalBull",
                        DataType = "number",
                        LineType = "dots",
                        LineWidth = 3,
                        DefaultColor = standardRed
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "Fractal Bear ([P1])",
                        DisplayName = "Fractal Bear",
                        DataName = "fractalBear",
                        DataType = "number",
                        LineType = "dots",
                        LineWidth = 3,
                        DefaultColor = standardGreen
                    }
                }
            },

            // Hilbert Transform Instantaneous Trendline
            new IndicatorList
            {
                Name = "Hilbert Transform Instantaneous Trendline",
                Uiid = "HT Trendline",
                LabelTemplate = "HT Trendline",
                Endpoint = $"{baseUrl}/HTL/",
                Category = "moving-average",
                ChartType = "overlay",
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "HT Trendline",
                        DisplayName = "HT Trendline",
                        DataName = "trendline",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardOrange
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "HT Smooth Price",
                        DisplayName = "HT Smoothed Price",
                        DataName = "smoothPrice",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardRed
                    }
                }
            },

            // Keltner Channels
            new IndicatorList
            {
                Name = "Keltner Channels",
                Uiid = "KELTNER",
                LabelTemplate = "KELTNER([P1],[P2])",
                Endpoint = $"{baseUrl}/KELTNER/",
                Category = "price-channel",
                ChartType = "overlay",
                Order = Order.BehindPrice,
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "EMA Periods",
                        ParamName = "emaPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 20,
                        Minimum = 2,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Multiplier",
                        ParamName= "multiplier",
                        DataType = "number",
                        Order = 2,
                        Required = true,
                        DefaultValue = 2,
                        Minimum = 0.01,
                        Maximum = 10
                    },
                    new IndicatorParamConfig {
                        DisplayName = "ATR Periods",
                        ParamName= "atrPeriods",
                        DataType = "number",
                        Order = 3,
                        Required = true,
                        DefaultValue = 10,
                        Minimum = 2,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "KELTNER([P1],[P2]) Upper Band",
                        DisplayName = "Upper Band",
                        DataName = "upperBand",
                        DataType = "number",
                        LineType = "solid",
                        LineWidth = 1,
                        DefaultColor = standardOrange,
                        Fill = new ChartFill
                        {
                            Target = "+2",
                            ColorAbove = darkGrayTransparent,
                            ColorBelow = darkGrayTransparent
                        }
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "KELTNER([P1],[P2]) Centerline",
                        DisplayName = "Centerline",
                        DataName = "centerline",
                        DataType = "number",
                        LineType = "dash",
                        LineWidth = 1,
                        DefaultColor = standardOrange
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "KELTNER([P1],[P2]) Lower Band",
                        DisplayName = "Lower Band",
                        DataName = "lowerBand",
                        DataType = "number",
                        LineType = "solid",
                        LineWidth = 1,
                        DefaultColor = standardOrange
                    }
                }
            },

            // Moving Average Convergence/Divergence
            new IndicatorList
            {
                Name = "Moving Average Convergence/Divergence (MACD)",
                Uiid = "MACD",
                LabelTemplate = "MACD([P1],[P2],[P3])",
                Endpoint = $"{baseUrl}/MACD/",
                Category = "price-trend",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    Thresholds = new List<ChartThreshold>
                    {
                        new ChartThreshold {
                            Value = 0,
                            Color = darkGrayTransparent,
                            Style = "dash"
                        }
                    }
                },
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Fast Periods",
                        ParamName = "fastPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 12,
                        Minimum = 1,
                        Maximum = 200
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Slow Periods",
                        ParamName = "slowPeriods",
                        DataType = "int",
                        Order = 2,
                        Required = true,
                        DefaultValue = 26,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Signal Periods",
                        ParamName = "signalPeriods",
                        DataType = "int",
                        Order = 3,
                        Required = true,
                        DefaultValue = 9,
                        Minimum = 1,
                        Maximum = 50
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "MACD",
                        DisplayName  = "MACD",
                        DataName = "macd",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "Signal",
                        DisplayName = "Signal",
                        DataName = "signal",
                        DataType = "number",
                        LineType= "solid",
                        DefaultColor = standardRed
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "Histogram",
                        DisplayName = "Histogram",
                        DataName = "histogram",
                        DataType = "number",
                        LineType = "bar",
                        DefaultColor = standardGrayTransparent
                    }
                }
            },

            // Parabolic SAR
            new IndicatorList
            {
                Name = "Parabolic Stop and Reverse (SAR)",
                Uiid = "PSAR",
                LabelTemplate = "PSAR([P1],[P2])",
                Endpoint = $"{baseUrl}/PSAR/",
                Category = "stop-and-reverse",
                ChartType = "overlay",

                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Step Size",
                        ParamName= "accelerationStep",
                        DataType = "number",
                        Order = 1,
                        Required = true,
                        DefaultValue = 0.02,
                        Minimum = 0.000001,
                        Maximum = 2500
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Max Factor",
                        ParamName= "maxAccelerationFactor",
                        DataType = "number",
                        Order = 2,
                        Required = true,
                        DefaultValue = 0.2,
                        Minimum = 0.000001,
                        Maximum = 2500
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "PSAR([P1],[P2])",
                        DisplayName = "Parabolic SAR",
                        DataName = "sar",
                        DataType = "number",
                        LineType= "dots",
                        LineWidth = 2,
                        DefaultColor = standardPurple
                    }
                }
            },

            // Relative Strength Index
            new IndicatorList
            {
                Name = "Relative Strength Index (RSI)",
                Uiid = "RSI",
                LabelTemplate = "RSI([P1])",
                Endpoint = $"{baseUrl}/RSI/",
                Category = "oscillator",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    MinimumYAxis = 0,
                    MaximumYAxis = 100,

                    Thresholds = new List<ChartThreshold>
                    {
                        new ChartThreshold {
                            Value = 70,
                            Color = thresholdRed,
                            Style = "dash",
                            Fill = new ChartFill
                            {
                                Target = "+2",
                                ColorAbove = "transparent",
                                ColorBelow = thresholdGreen
                            }
                        },
                        new ChartThreshold {
                            Value = 30,
                            Color = thresholdGreen,
                            Style = "dash",
                            Fill = new ChartFill
                            {
                                Target = "+1",
                                ColorAbove = thresholdRed,
                                ColorBelow = "transparent"
                            }
                        }
                    }
                },
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "RSI([P1])",
                        DisplayName = "RSI",
                        DataName = "rsi",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Stochastic Oscillator
            new IndicatorList
            {
                Name = "Stochastic Oscillator",
                Uiid = "STO",
                LabelTemplate = "STO %K([P1]) %D([P2])",
                Endpoint = $"{baseUrl}/STO/",
                Category = "oscillator",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    Thresholds = new List<ChartThreshold>
                    {
                        new ChartThreshold {
                            Value = 80,
                            Color = thresholdRed,
                            Style = "dash",
                            Fill = new ChartFill
                            {
                                Target = "+2",
                                ColorAbove = "transparent",
                                ColorBelow = thresholdGreen
                            }
                        },
                        new ChartThreshold {
                            Value = 20,
                            Color = thresholdGreen,
                            Style = "dash",
                            Fill = new ChartFill
                            {
                                Target = "+1",
                                ColorAbove = thresholdRed,
                                ColorBelow = "transparent"
                            }
                        }
                    }
                },
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods (%K)",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Signal Periods (%D)",
                        ParamName = "signalPeriods",
                        DataType = "int",
                        Order = 2,
                        Required = true,
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "STO %K([P1])",
                        DisplayName  = "%K",
                        DataName = "k",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "STO %D([P2])",
                        DisplayName = "%D",
                        DataName = "d",
                        DataType = "number",
                        LineType= "solid",
                        DefaultColor = standardRed
                    },
                    //new IndicatorResultConfig {
                    //    LabelTemplate = "STO %J",
                    //    DisplayName = "%J",
                    //    DataName = "j",
                    //    DataType = "number",
                    //    LineType = "dash",
                    //    DefaultColor = standardGreen
                    //}
                }
            },

            // Stochastic RSI
            new IndicatorList
            {
                Name = "Stochastic RSI",
                Uiid = "STOCHRSI",
                LabelTemplate = "StochRSI ([P1],[P2],[P3],[P4])",
                Endpoint = $"{baseUrl}/STORSI/",
                Category = "oscillator",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    Thresholds = new List<ChartThreshold>
                    {
                        new ChartThreshold {
                            Value = 80,
                            Color = thresholdRed,
                            Style = "dash",
                            Fill = new ChartFill
                            {
                                Target = "+2",
                                ColorAbove = "transparent",
                                ColorBelow = thresholdGreen
                            }
                        },
                        new ChartThreshold {
                            Value = 20,
                            Color = thresholdGreen,
                            Style = "dash",
                            Fill = new ChartFill
                            {
                                Target = "+1",
                                ColorAbove = thresholdRed,
                                ColorBelow = "transparent"
                            }
                        }
                    }
                },
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "RSI Periods",
                        ParamName = "rsiPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Stochastic Periods",
                        ParamName = "stochPeriods",
                        DataType = "int",
                        Order = 2,
                        Required = true,
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Signal Periods",
                        ParamName = "signalPeriods",
                        DataType = "int",
                        Order = 3,
                        Required = true,
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 50
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Smooth Periods",
                        ParamName = "stochPeriods",
                        DataType = "int",
                        Order = 4,
                        Required = true,
                        DefaultValue = 1,
                        Minimum = 1,
                        Maximum = 50
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "StochRSI ([P1],[P2],[P3],[P4]) Oscillator",
                        DisplayName  = "Oscillator",
                        DataName = "stochRsi",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "StochRSI ([P1],[P2],[P3],[P4]) Signal",
                        DisplayName = "Signal line",
                        DataName = "signal",
                        DataType = "number",
                        LineType= "solid",
                        DefaultColor = standardRed
                    }
                }
            },

            // SuperTrend
            new IndicatorList
            {
                Name = "SuperTrend",
                Uiid = "SUPERTREND",
                LabelTemplate = "SUPERTREND([P1],[P2])",
                Endpoint = $"{baseUrl}/SUPERTREND/",
                Category = "price-trend",
                ChartType = "overlay",
                Order = Order.Front,
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        Order = 1,
                        Required = true,
                        DefaultValue = 10,
                        Minimum = 1,
                        Maximum = 50
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Multiplier",
                        ParamName= "multiplier",
                        DataType = "number",
                        Order = 2,
                        Required = true,
                        DefaultValue = 3,
                        Minimum = 0.1,
                        Maximum = 10
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "ST Upper Band",
                        DisplayName = "ST Upper Band",
                        DataName = "upperBand",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardRed
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "ST Lower Band",
                        DisplayName = "ST Lower Band",
                        DataName = "lowerBand",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardGreen
                    },
                    new IndicatorResultConfig {
                        LabelTemplate = "SuperTrend",
                        DisplayName = "SuperTrend (transition line)",
                        DataName = "superTrend",
                        DataType = "number",
                        LineType = "dash",
                        LineWidth = 1,
                        DefaultColor = darkGrayTransparent
                    }
                }
            },

            // Zig Zag (close)
            new IndicatorList
            {
                Name = "Zig Zag (close)",
                Uiid = "ZIGZAG-CL",
                LabelTemplate = "ZIGZAG([P1]% CLOSE)",
                Endpoint = $"{baseUrl}/ZIGZAG-CLOSE/",
                Category = "price-transform",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Percent Change",
                        ParamName = "percentChange",
                        DataType = "number",
                        Order = 1,
                        Required = true,
                        DefaultValue = 5,
                        Minimum = 1,
                        Maximum = 200
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "ZIGZAG([P1]% CLOSE)",
                        DisplayName = "Zig Zag",
                        DataName = "zigZag",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Zig Zag (high/low)
            new IndicatorList
            {
                Name = "Zig Zag (high/low)",
                Uiid = "ZIGZAG-HL",
                LabelTemplate = "ZIGZAG([P1]% HIGH/LOW)",
                Endpoint = $"{baseUrl}/ZIGZAG-HIGHLOW/",
                Category = "price-transform",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Percent Change",
                        ParamName = "percentChange",
                        DataType = "number",
                        Order = 1,
                        Required = true,
                        DefaultValue = 5,
                        Minimum = 1,
                        Maximum = 200
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        LabelTemplate = "ZIGZAG([P1]% HIGH/LOW)",
                        DisplayName = "Zig Zag",
                        DataName = "zigZag",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            }
        };
    }
}
