namespace WebApi.Services;

public static class Metadata
{
    public static IEnumerable<IndicatorList> IndicatorList(string baseUrl)
    {
        string standardRed = "#DD2C00";
        string standardOrange = "#EF6C00";
        string standardGreen = "#2E7D32";
        string standardBlue = "#1E88E5";
        string standardPurple = "#8E24AA";
        string standardGrayTransparent = "#9E9E9E50";
        string darkGray = "#757575";
        string darkGrayTransparent = "#75757515";
        string thresholdRed = "#B71C1C70";
        string thresholdGreen = "#1B5E2070";

        List<IndicatorList> listing = new()
        {
            // Accumulation Distribution Line (ADL)
            new IndicatorList
            {
                Name = "Accumulation Distribution Line (ADL)",
                Uiid = "ADL",
                LegendTemplate = "ADL w/ SMA([P1])",
                Endpoint = $"{baseUrl}/ADL/",
                Category = "volume-based",
                ChartType = "oscillator",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "SMA Periods",
                        ParamName = "smaPeriods",
                        DataType = "int",
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 50
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Accumulation Distribution Line",
                        TooltipTemplate = "ADL",
                        DataName = "adl",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "SMA of ADL",
                        TooltipTemplate = "ADL SMA([P1])",
                        DataName = "adlSma",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardRed
                    }
                }
            },

            // Average Directional Index (ADX)
            new IndicatorList
            {
                Name = "Average Directional Index (ADX)",
                Uiid = "ADX",
                LegendTemplate = "ADX([P1])",
                Endpoint = $"{baseUrl}/ADX/",
                Category = "price-trend",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    Thresholds = new List<ChartThreshold>
                    {
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
                        DefaultValue = 14,
                        Minimum = 2,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "ADX",
                        TooltipTemplate = "ADX([P1])",
                        DataName = "adx",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "DI+",
                        TooltipTemplate = "DI+([P1])",
                        DataName = "pdi",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardGreen
                    },
                    new IndicatorResultConfig {
                        DisplayName= "DI-",
                        TooltipTemplate = "DI-([P1])",
                        DataName = "mdi",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardRed
                    },
                    new IndicatorResultConfig {
                        DisplayName = "ADX Rating",
                        TooltipTemplate = "ADXR([P1])",
                        DataName = "adxr",
                        DataType = "number",
                        LineType = "dash",
                        DefaultColor = darkGrayTransparent
                    }

                }
            },

            // Arnaud Legoux Moving Average (ALMA)
            new IndicatorList
            {
                Name = "Arnaud Legoux Moving Average (ALMA)",
                Uiid = "ALMA",
                LegendTemplate = "ALMA([P1],[P2],[P3])",
                Endpoint = $"{baseUrl}/ALMA/",
                Category = "moving-average",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 9,
                        Minimum = 2,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Offset",
                        ParamName = "offset",
                        DataType = "number",
                        DefaultValue = 0.85,
                        Minimum = 0,
                        Maximum = 1
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Sigma",
                        ParamName = "sigma",
                        DataType = "number",
                        DefaultValue = 6,
                        Minimum = 0.1,
                        Maximum = 10
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "ALMA",
                        TooltipTemplate = "ALMA([P1],[P2],[P3])",
                        DataName = "alma",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Aroon Up/Down
            new IndicatorList
            {
                Name = "Aroon Up/Down",
                Uiid = "AROON UP/DOWN",
                LegendTemplate = "AROON([P1]) Up/Down",
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
                        DefaultValue = 25,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Aroon Up",
                        TooltipTemplate = "Aroon Up",
                        DataName = "aroonUp",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardGreen
                    },
                    new IndicatorResultConfig {
                        DisplayName= "Aroon Down",
                        TooltipTemplate = "Aroon Down",
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
                LegendTemplate = "AROON([P1]) Oscillator",
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
                        DefaultValue = 25,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Oscillator",
                        TooltipTemplate = "AROON([P1]) Oscillator",
                        DataName = "oscillator",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Average True Range
            new IndicatorList
            {
                Name = "Average True Range (ATR)",
                Uiid = "ATR",
                LegendTemplate = "ATR([P1])",
                Endpoint = $"{baseUrl}/ATR/",
                Category = "price-characteristic",
                ChartType = "oscillator",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 14,
                        Minimum = 2,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Average True Range",
                        TooltipTemplate = "ATR([P1])",
                        DataName = "atr",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Average True Range Percent
            new IndicatorList
            {
                Name = "Average True Range (ATR) Percent",
                Uiid = "ATRP",
                LegendTemplate = "ATR([P1]) %",
                Endpoint = $"{baseUrl}/ATR/",
                Category = "price-characteristic",
                ChartType = "oscillator",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 14,
                        Minimum = 2,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Average True Range Percent",
                        TooltipTemplate = "ATR([P1]) %",
                        DataName = "atrp",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Beta
            new IndicatorList
            {
                Name = "Beta",
                Uiid = "BETA",
                LegendTemplate = "BETA([P1])",
                Endpoint = $"{baseUrl}/BETA/",
                Category = "price-characteristic",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    Thresholds = new List<ChartThreshold>
                    {
                        new ChartThreshold {
                            Value = 1,
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
                        DefaultValue = 50,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Beta",
                        TooltipTemplate = "Beta",
                        DataName = "beta",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Beta+",
                        TooltipTemplate = "Beta+",
                        DataName = "betaUp",
                        DataType = "number",
                        LineType = "dash",
                        DefaultColor = standardGreen
                    },
                    new IndicatorResultConfig {
                        DisplayName= "Beta-",
                        TooltipTemplate = "Beta-",
                        DataName = "betaDown",
                        DataType = "number",
                        LineType = "dash",
                        DefaultColor = standardRed
                    }
                }
            },

            // Bollinger Bands
            new IndicatorList
            {
                Name = "Bollinger Bands®",
                Uiid = "BB",
                LegendTemplate = "BB([P1],[P2])",
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
                        DefaultValue = 20,
                        Minimum = 2,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Standard Deviations",
                        ParamName= "standardDeviations",
                        DataType = "number",
                        DefaultValue = 2,
                        Minimum = 0.01,
                        Maximum = 10
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Upper Band",
                        TooltipTemplate = "BB([P1],[P2]) Upper Band",
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
                        DisplayName = "Centerline",
                        TooltipTemplate = "BB([P1],[P2]) Centerline",
                        DataName = "sma",
                        DataType = "number",
                        LineType = "dash",
                        LineWidth = 1,
                        DefaultColor = darkGray
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Lower Band",
                        TooltipTemplate = "BB([P1],[P2]) Lower Band",
                        DataName = "lowerBand",
                        DataType = "number",
                        LineType = "solid",
                        LineWidth = 1,
                        DefaultColor = darkGray
                    }
                }
            },

            // Bollinger Bands %B
            new IndicatorList
            {
                Name = "Bollinger Bands® %B",
                Uiid = "BB-PCTB",
                LegendTemplate = "BB([P1],[P2]) %B",
                Endpoint = $"{baseUrl}/BB/",
                Category = "oscillator",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    Thresholds = new List<ChartThreshold>
                    {
                        new ChartThreshold {
                            Value = 1,
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
                            Value = 0,
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
                        DefaultValue = 20,
                        Minimum = 2,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Standard Deviations",
                        ParamName= "standardDeviations",
                        DataType = "number",
                        DefaultValue = 2,
                        Minimum = 0.01,
                        Maximum = 10
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "%B",
                        TooltipTemplate = "BB([P1],[P2]) %B",
                        DataName = "percentB",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue,
                    }
                }
            },

            // Chaikin Money Flow
            new IndicatorList
            {
                Name = "Chaikin Money Flow (CMF)",
                Uiid = "CMF",
                LegendTemplate = "CMF([P1])",
                Endpoint = $"{baseUrl}/CMF/",
                Category = "volume-based",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
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
                        DefaultValue = 20,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "CMF",
                        TooltipTemplate = "Chaikin Money Flow",
                        DataName = "cmf",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Chandelier Exit (long)
            new IndicatorList
            {
                Name = "Chandelier Exit (long)",
                Uiid = "CHEXIT-LONG",
                LegendTemplate = "CHANDELIER([P1],[P2],LONG)",
                Endpoint = $"{baseUrl}/CHEXIT-LONG/",
                Category = "stop-and-reverse",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 22,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Multiplier",
                        ParamName = "multiplier",
                        DataType = "number",
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 10
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Chandelier Exit",
                        TooltipTemplate = "CHANDELIER([P1],[P2],LONG)",
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
                LegendTemplate = "CHANDELIER([P1],[P2],SHORT)",
                Endpoint = $"{baseUrl}/CHEXIT-SHORT/",
                Category = "stop-and-reverse",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 22,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Multiplier",
                        ParamName = "multiplier",
                        DataType = "number",
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 10
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Chandelier Exit",
                        TooltipTemplate = "CHANDELIER([P1],[P2],LONG)",
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
                LegendTemplate = "CHOP([P1])",
                Endpoint = $"{baseUrl}/CHOP/",
                Category = "oscillator",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    //MinimumYAxis = 0,
                    //MaximumYAxis = 100,

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
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Choppiness",
                        TooltipTemplate = "Choppiness",
                        DataName = "chop",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Doji
            new IndicatorList
            {
                Name = "Doji",
                Uiid = "DOJI",
                LegendTemplate = "DOJI([P1]%)",
                Endpoint = $"{baseUrl}/DOJI/",
                Category = "candlestick-pattern",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Max Price Change %",
                        ParamName = "maxPriceChangePercent",
                        DataType = "number",
                        DefaultValue = 0.1,
                        Minimum = 0,
                        Maximum = 0.5
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        TooltipTemplate = "DOJI([P1]%)",
                        DisplayName = "Doji",
                        DataName = "price",
                        DataType = "number",
                        LineType = "pointer",
                        LineWidth = 8,
                        DefaultColor = darkGray
                    }
                }
            },

            // Donchian Channels
            new IndicatorList
            {
                Name = "Donchian Channels",
                Uiid = "DONCHIAN",
                LegendTemplate = "DONCHIAN([P1])",
                Endpoint = $"{baseUrl}/DONCHIAN/",
                Category = "price-channel",
                ChartType = "overlay",
                Order = Order.BehindPrice,
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 20,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Upper Band",
                        TooltipTemplate = "DONCHIAN([P1]) Upper Band",
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
                        DisplayName = "Centerline",
                        TooltipTemplate = "DONCHIAN([P1]) Centerline",
                        DataName = "centerline",
                        DataType = "number",
                        LineType = "dash",
                        LineWidth = 1,
                        DefaultColor = standardOrange
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Lower Band",
                        TooltipTemplate = "DONCHIAN([P1]) Lower Band",
                        DataName = "lowerBand",
                        DataType = "number",
                        LineType = "solid",
                        LineWidth = 1,
                        DefaultColor = standardOrange
                    }
                }
            },

            // Elder-ray
            new IndicatorList
            {
                Name = "Elder-ray Index",
                Uiid = "ELDER-RAY",
                LegendTemplate = "ELDER-RAY([P1])",
                Endpoint = $"{baseUrl}/ELDER-RAY/",
                Category = "price-trend",
                ChartType = "oscillator",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 13,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Bull Power",
                        TooltipTemplate = "Bull Power",
                        DataName = "bullPower",
                        DataType = "number",
                        LineType = "bar",
                        Stack = "eray",
                        DefaultColor = standardGreen
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Bear Power",
                        TooltipTemplate = "Bear Power",
                        DataName = "bearPower",
                        DataType = "number",
                        LineType = "bar",
                        Stack = "eray",
                        DefaultColor = standardRed
                    }
                }
            },

            // Endpoint Moving Average
            new IndicatorList
            {
                Name = "Endpoint Moving Average (EPMA)",
                Uiid = "EPMA",
                LegendTemplate = "EPMA([P1])",
                Endpoint = $"{baseUrl}/EPMA/",
                Category = "moving-average",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 10,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "EPMA",
                        TooltipTemplate = "EPMA([P1])",
                        DataName = "epma",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Exponential Moving Average
            new IndicatorList
            {
                Name = "Exponential Moving Average (EMA)",
                Uiid = "EMA",
                LegendTemplate = "EMA([P1])",
                Endpoint = $"{baseUrl}/EMA/",
                Category = "moving-average",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 20,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "EMA",
                        TooltipTemplate = "EMA([P1])",
                        DataName = "ema",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Fisher Transform
            new IndicatorList
            {
                Name = "Ehlers Fisher Transform",
                Uiid = "FISHER",
                LegendTemplate = "FISHER([P1])",
                Endpoint = $"{baseUrl}/FISHER/",
                Category = "price-transform",
                ChartType = "oscillator",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 10,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Fisher Transform",
                        TooltipTemplate = "Fisher Transform",
                        DataName = "fisher",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Trigger",
                        TooltipTemplate = "Trigger",
                        DataName = "trigger",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardRed
                    }
                }
            },

            // Fractal (Williams)
            new IndicatorList
            {
                Name = "Williams Fractal (high/low)",
                Uiid = "FRACTAL",
                LegendTemplate = "FRACTAL([P1])",
                Endpoint = $"{baseUrl}/FRACTAL/",
                Category = "price-pattern",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Window Span",
                        ParamName = "windowSpan",
                        DataType = "int",
                        DefaultValue = 2,
                        Minimum = 1,
                        Maximum = 100
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        TooltipTemplate = "Fractal Bull ([P1])",
                        DisplayName = "Fractal Bull",
                        DataName = "fractalBull",
                        DataType = "number",
                        LineType = "dots",
                        LineWidth = 3,
                        DefaultColor = standardRed
                    },
                    new IndicatorResultConfig {
                        TooltipTemplate = "Fractal Bear ([P1])",
                        DisplayName = "Fractal Bear",
                        DataName = "fractalBear",
                        DataType = "number",
                        LineType = "dots",
                        LineWidth = 3,
                        DefaultColor = standardGreen
                    }
                }
            },

            // Fractal Chaos Bands (FCB)
            new IndicatorList
            {
                Name = "Fractal Chaos Bands",
                Uiid = "FCB",
                LegendTemplate = "FCB([P1])",
                Endpoint = $"{baseUrl}/FCB/",
                Category = "price-channels",
                ChartType = "overlay",
                Order = Order.Front,
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Window Span",
                        ParamName = "windowSpan",
                        DataType = "int",
                        DefaultValue = 2,
                        Minimum = 2,
                        Maximum = 30
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        TooltipTemplate = "Upper Band",
                        DisplayName = "FCB([P1]) Upper Band",
                        DataName = "upperBand",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardGreen
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Lower Band",
                        TooltipTemplate = "FCB([P1]) Lower Band",
                        DataName = "lowerBand",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardRed
                    }
                }
            },

            // Hilbert Transform Instantaneous Trendline
            new IndicatorList
            {
                Name = "Hilbert Transform Instantaneous Trendline",
                Uiid = "HT Trendline",
                LegendTemplate = "HT TRENDLINE",
                Endpoint = $"{baseUrl}/HTL/",
                Category = "moving-average",
                ChartType = "overlay",
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "HT Trendline",
                        TooltipTemplate = "HT Trendline",
                        DataName = "trendline",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "HT Smoothed Price",
                        TooltipTemplate = "HT Smooth Price",
                        DataName = "smoothPrice",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardOrange
                    }
                }
            },

            // Keltner Channels
            new IndicatorList
            {
                Name = "Keltner Channels",
                Uiid = "KELTNER",
                LegendTemplate = "KELTNER([P1],[P2],[P3])",
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
                        DefaultValue = 20,
                        Minimum = 2,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Multiplier",
                        ParamName= "multiplier",
                        DataType = "number",
                        DefaultValue = 2,
                        Minimum = 0.01,
                        Maximum = 10
                    },
                    new IndicatorParamConfig {
                        DisplayName = "ATR Periods",
                        ParamName= "atrPeriods",
                        DataType = "number",
                        DefaultValue = 10,
                        Minimum = 2,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Upper Band",
                        TooltipTemplate = "KELTNER([P1],[P2],[P3]) Upper Band",
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
                        DisplayName = "Centerline",
                        TooltipTemplate = "KELTNER([P1],[P2],[P3]) Centerline",
                        DataName = "centerline",
                        DataType = "number",
                        LineType = "dash",
                        LineWidth = 1,
                        DefaultColor = standardOrange
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Lower Band",
                        TooltipTemplate = "KELTNER([P1],[P2],[P3]) Lower Band",
                        DataName = "lowerBand",
                        DataType = "number",
                        LineType = "solid",
                        LineWidth = 1,
                        DefaultColor = standardOrange
                    }
                }
            },

            // Marubozu
            new IndicatorList
            {
                Name = "Marubozu",
                Uiid = "MARUBOZU",
                LegendTemplate = "MARUBOZU([P1]%)",
                Endpoint = $"{baseUrl}/MARUBOZU/",
                Category = "candlestick-pattern",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Min Body Percent %",
                        ParamName = "minBodyPercent",
                        DataType = "number",
                        DefaultValue = 90,
                        Minimum = 80,
                        Maximum = 100
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        TooltipTemplate = "MARUBOZU([P1]%)",
                        DisplayName = "Marubozu",
                        DataName = "price",
                        DataType = "number",
                        LineType = "pointer",
                        LineWidth = 8,
                        DefaultColor = darkGray
                    }
                }
            },

            // Money Flow Index
            new IndicatorList
            {
                Name = "Money Flow Index (MFI)",
                Uiid = "MFI",
                LegendTemplate = "MFI([P1])",
                Endpoint = $"{baseUrl}/MFI/",
                Category = "oscillator",
                ChartType = "volume-based",
                ChartConfig = new ChartConfig
                {
                    MinimumYAxis = 0,
                    MaximumYAxis = 100,

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
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "MFI",
                        TooltipTemplate = "MFI([P1])",
                        DataName = "mfi",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Moving Average Convergence/Divergence
            new IndicatorList
            {
                Name = "Moving Average Convergence/Divergence (MACD)",
                Uiid = "MACD",
                LegendTemplate = "MACD([P1],[P2],[P3])",
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
                        DefaultValue = 12,
                        Minimum = 1,
                        Maximum = 200
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Slow Periods",
                        ParamName = "slowPeriods",
                        DataType = "int",
                        DefaultValue = 26,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Signal Periods",
                        ParamName = "signalPeriods",
                        DataType = "int",
                        DefaultValue = 9,
                        Minimum = 1,
                        Maximum = 50
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName  = "MACD",
                        TooltipTemplate = "MACD",
                        DataName = "macd",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Signal",
                        TooltipTemplate = "Signal",
                        DataName = "signal",
                        DataType = "number",
                        LineType= "solid",
                        DefaultColor = standardRed
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Histogram",
                        TooltipTemplate = "Histogram",
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
                LegendTemplate = "PSAR([P1],[P2])",
                Endpoint = $"{baseUrl}/PSAR/",
                Category = "stop-and-reverse",
                ChartType = "overlay",

                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Step Size",
                        ParamName= "accelerationStep",
                        DataType = "number",
                        DefaultValue = 0.02,
                        Minimum = 0.000001,
                        Maximum = 2500
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Max Factor",
                        ParamName= "maxAccelerationFactor",
                        DataType = "number",
                        DefaultValue = 0.2,
                        Minimum = 0.000001,
                        Maximum = 2500
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Parabolic SAR",
                        TooltipTemplate = "PSAR([P1],[P2])",
                        DataName = "sar",
                        DataType = "number",
                        LineType= "dots",
                        LineWidth = 2,
                        DefaultColor = standardPurple
                    }
                }
            },

            // Rate of Change
            new IndicatorList
            {
                Name = "Rate of Change",
                Uiid = "ROC",
                LegendTemplate = "ROC([P1],[P2])",
                Endpoint = $"{baseUrl}/ROC/",
                Category = "oscillator",
                ChartType = "oscillator",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "SMA Periods",
                        ParamName = "smaPeriods",
                        DataType = "int",
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 50
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName  = "Rate of Change",
                        TooltipTemplate = "ROC([P1],[P2])",
                        DataName = "roc",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "SMA of ROC",
                        TooltipTemplate = "STO %D([P2])",
                        DataName = "rocSma",
                        DataType = "number",
                        LineType= "solid",
                        DefaultColor = standardRed
                    }
                }
            },

            // Relative Strength Index
            new IndicatorList
            {
                Name = "Relative Strength Index (RSI)",
                Uiid = "RSI",
                LegendTemplate = "RSI([P1])",
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
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "RSI",
                        TooltipTemplate = "RSI([P1])",
                        DataName = "rsi",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Schaff Trend Cycle (STC)
            new IndicatorList
            {
                Name = "Schaff Trend Cycle (STC)",
                Uiid = "STC",
                LegendTemplate = "STC([P1],[P2],[P3])",
                Endpoint = $"{baseUrl}/STC/",
                Category = "oscillator",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    MinimumYAxis = 0,
                    MaximumYAxis = 100,

                    Thresholds = new List<ChartThreshold>
                    {
                        new ChartThreshold {
                            Value = 75,
                            Color = thresholdGreen,
                            Style = "solid",
                            Fill = new ChartFill
                            {
                                Target = "+2",
                                ColorAbove = "transparent",
                                ColorBelow = thresholdGreen
                            }
                        },
                        new ChartThreshold {
                            Value = 25,
                            Color = thresholdRed,
                            Style = "solid",
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
                        DisplayName = "Cycle Periods",
                        ParamName = "cyclePeriods",
                        DataType = "int",
                        DefaultValue = 10,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Fast Periods",
                        ParamName = "fastPeriods",
                        DataType = "int",
                        DefaultValue = 23,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Slow Periods",
                        ParamName = "slowPeriods",
                        DataType = "int",
                        DefaultValue = 50,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Schaff Trend Cycle",
                        TooltipTemplate = "Schaff Trend Cycle",
                        DataName = "stc",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Slope
            new IndicatorList
            {
                Name = "Slope",
                Uiid = "SLOPE",
                LegendTemplate = "SLOPE([P1])",
                Endpoint = $"{baseUrl}/SLOPE/",
                Category = "price-characteristic",
                ChartType = "oscillator",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Slope",
                        TooltipTemplate = "SLOPE([P1])",
                        DataName = "slope",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Linear Regression
            new IndicatorList
            {
                Name = "Linear Regression",
                Uiid = "LINEAR",
                LegendTemplate = "LINEAR([P1])",
                Endpoint = $"{baseUrl}/SLOPE/",
                Category = "price-characteristic",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Linear Regression",
                        TooltipTemplate = "LINEAR([P1])",
                        DataName = "line",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Simple Moving Average
            new IndicatorList
            {
                Name = "Simple Moving Average (SMA)",
                Uiid = "SMA",
                LegendTemplate = "SMA([P1])",
                Endpoint = $"{baseUrl}/SMA/",
                Category = "moving-average",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 10,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "SMA",
                        TooltipTemplate = "SMA([P1])",
                        DataName = "sma",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // Standard Deviation (absolute)
            new IndicatorList
            {
                Name = "Standard Deviation (absolute)",
                Uiid = "STDEV",
                LegendTemplate = "STDEV([P1])",
                Endpoint = $"{baseUrl}/STDEV/",
                Category = "price-characteristic",
                ChartType = "oscillator",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "SMA Periods",
                        ParamName = "smaPeriods",
                        DataType = "int",
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 50
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Standard Deviation",
                        TooltipTemplate = "STDEV([P1])",
                        DataName = "stdDev",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "SMA of Standard Deviation",
                        TooltipTemplate = "STDEV([P1]) SMA",
                        DataName = "stdDevSma",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardRed
                    }
                }
            },

            // Standard Deviation (z-score)
            new IndicatorList
            {
                Name = "Standard Deviation (Z-Score)",
                Uiid = "STDEV-ZSCORE",
                LegendTemplate = "STDEV-ZSCORE([P1])",
                Endpoint = $"{baseUrl}/STDEV/",
                Category = "price-characteristic",
                ChartType = "oscillator",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Standard Deviation (absolute)",
                        TooltipTemplate = "Z-Score",
                        DataName = "zScore",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    }
                }
            },

            // STARC Bands
            new IndicatorList
            {
                Name = "STARC Bands",
                Uiid = "STARC",
                LegendTemplate = "STARC([P1],[P2],[P3])",
                Endpoint = $"{baseUrl}/STARC/",
                Category = "price-channel",
                ChartType = "overlay",
                Order = Order.BehindPrice,
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "SMA Periods",
                        ParamName = "smaPeriods",
                        DataType = "int",
                        DefaultValue = 5,
                        Minimum = 1,
                        Maximum = 50
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Multiplier",
                        ParamName = "multiplier",
                        DataType = "number",
                        DefaultValue = 2,
                        Minimum = 1,
                        Maximum = 10
                    },
                    new IndicatorParamConfig {
                        DisplayName = "ATR Periods",
                        ParamName = "atrPeriods",
                        DataType = "int",
                        DefaultValue = 10,
                        Minimum = 1,
                        Maximum = 50
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Upper Band",
                        TooltipTemplate = "STARC([P1],[P2],[P3]) Upper Band",
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
                        DisplayName = "Centerline",
                        TooltipTemplate = "STARC([P1],[P2],[P3]) Centerline",
                        DataName = "centerline",
                        DataType = "number",
                        LineType = "dash",
                        LineWidth = 1,
                        DefaultColor = standardOrange
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Lower Band",
                        TooltipTemplate = "STARC([P1],[P2],[P3]) Lower Band",
                        DataName = "lowerBand",
                        DataType = "number",
                        LineType = "solid",
                        LineWidth = 1,
                        DefaultColor = standardOrange
                    }
                }
            },

            // Stochastic Momentum Index
            new IndicatorList
            {
                Name = "Stochastic Momentum Index",
                Uiid = "SMI",
                LegendTemplate = "SMI([P1],[P2],[P3],[P4])",
                Endpoint = $"{baseUrl}/SMI/",
                Category = "oscillator",
                ChartType = "oscillator",
                ChartConfig = new ChartConfig
                {
                    Thresholds = new List<ChartThreshold>
                    {
                        new ChartThreshold {
                            Value = 40,
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
                            Value = -40,
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
                        DefaultValue = 10,
                        Minimum = 1,
                        Maximum = 50
                    },
                    new IndicatorParamConfig {
                        DisplayName = "First Smooth Periods",
                        ParamName = "firstSmoothPeriods",
                        DataType = "int",
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 30
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Second Smooth Periods",
                        ParamName = "secondSmoothPeriods",
                        DataType = "int",
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 30
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Signal Periods",
                        ParamName = "signalPeriods",
                        DataType = "int",
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 30
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName  = "SMI",
                        TooltipTemplate = "SMI",
                        DataName = "smi",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Signal",
                        TooltipTemplate = "Signal",
                        DataName = "signal",
                        DataType = "number",
                        LineType= "solid",
                        DefaultColor = standardRed
                    }
                }
            },

            // Stochastic Oscillator
            new IndicatorList
            {
                Name = "Stochastic Oscillator",
                Uiid = "STO",
                LegendTemplate = "STOCH %K([P1]) %D([P2])",
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
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Signal Periods (%D)",
                        ParamName = "signalPeriods",
                        DataType = "int",
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 250
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName  = "%K",
                        TooltipTemplate = "STO %K([P1])",
                        DataName = "k",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "%D",
                        TooltipTemplate = "STO %D([P2])",
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
                LegendTemplate = "STOCH-RSI ([P1],[P2],[P3],[P4])",
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
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Stochastic Periods",
                        ParamName = "stochPeriods",
                        DataType = "int",
                        DefaultValue = 14,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Signal Periods",
                        ParamName = "signalPeriods",
                        DataType = "int",
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 50
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Smooth Periods",
                        ParamName = "stochPeriods",
                        DataType = "int",
                        DefaultValue = 1,
                        Minimum = 1,
                        Maximum = 50
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName  = "Oscillator",
                        TooltipTemplate = "StochRSI Oscillator",
                        DataName = "stochRsi",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Signal line",
                        TooltipTemplate = "Signal line",
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
                LegendTemplate = "SUPERTREND([P1],[P2])",
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
                        DefaultValue = 10,
                        Minimum = 1,
                        Maximum = 50
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Multiplier",
                        ParamName= "multiplier",
                        DataType = "number",
                        DefaultValue = 3,
                        Minimum = 0.1,
                        Maximum = 10
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        TooltipTemplate = "Upper Band",
                        DisplayName = "SUPERTREND([P1],[P2]) Upper Band",
                        DataName = "upperBand",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardRed
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Lower Band",
                        TooltipTemplate = "SUPERTREND([P1],[P2]) Lower Band",
                        DataName = "lowerBand",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardGreen
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Transition line",
                        TooltipTemplate = "SUPERTREND([P1],[P2]) Transition Line",
                        DataName = "superTrend",
                        DataType = "number",
                        LineType = "dash",
                        LineWidth = 1,
                        DefaultColor = darkGrayTransparent
                    }
                }
            },

            // Vortex Indicator
            new IndicatorList
            {
                Name = "Vortex Indicator",
                Uiid = "VORTEX",
                LegendTemplate = "VORTEX([P1])",
                Endpoint = $"{baseUrl}/VORTEX/",
                Category = "price-trend",
                ChartType = "oscillator",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Lookback Periods",
                        ParamName = "lookbackPeriods",
                        DataType = "int",
                        DefaultValue = 14,
                        Minimum = 2,
                        Maximum = 100
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "VI+",
                        TooltipTemplate = "VI+",
                        DataName = "pvi",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardGreen
                    },
                    new IndicatorResultConfig {
                        DisplayName = "VI+",
                        TooltipTemplate = "VI-",
                        DataName = "nvi",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardRed
                    }
                }
            },

            // Williams Alligator
            new IndicatorList
            {
                Name = "Williams Alligator",
                Uiid = "ALLIGATOR",
                LegendTemplate = "ALLIGATOR([P1],[P2],[P3],[P4],[P5],[P6])",
                Endpoint = $"{baseUrl}/ALLIGATOR/",
                Category = "price-trend",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Jaw Periods",
                        ParamName = "jawPeriods",
                        DataType = "int",
                        DefaultValue = 13,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Jaw Offset",
                        ParamName = "jawOffset",
                        DataType = "int",
                        DefaultValue = 8,
                        Minimum = 1,
                        Maximum = 30
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Teeth Periods",
                        ParamName = "teethPeriods",
                        DataType = "int",
                        DefaultValue = 8,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Teeth Offset",
                        ParamName = "teethOffset",
                        DataType = "int",
                        DefaultValue = 5,
                        Minimum = 1,
                        Maximum = 30
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Lips Periods",
                        ParamName = "lipsPeriods",
                        DataType = "int",
                        DefaultValue = 5,
                        Minimum = 1,
                        Maximum = 250
                    },
                    new IndicatorParamConfig {
                        DisplayName = "Lips Offset",
                        ParamName = "lipsOffset",
                        DataType = "int",
                        DefaultValue = 3,
                        Minimum = 1,
                        Maximum = 30
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Jaw",
                        TooltipTemplate = "ALLIGATOR([P1],[P2],[P3],[P4],[P5],[P6]) Jaw",
                        DataName = "jaw",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Jaw",
                        TooltipTemplate = "ALLIGATOR([P1],[P2],[P3],[P4],[P5],[P6]) Teeth",
                        DataName = "teeth",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardRed
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Jaw",
                        TooltipTemplate = "ALLIGATOR([P1],[P2],[P3],[P4],[P5],[P6]) Lips",
                        DataName = "lips",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardGreen
                    }
                }
            },

            // Zig Zag (close)
            new IndicatorList
            {
                Name = "Zig Zag (close)",
                Uiid = "ZIGZAG-CL",
                LegendTemplate = "ZIGZAG([P1]% CLOSE)",
                Endpoint = $"{baseUrl}/ZIGZAG-CLOSE/",
                Category = "price-transform",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Percent Change",
                        ParamName = "percentChange",
                        DataType = "number",
                        DefaultValue = 5,
                        Minimum = 1,
                        Maximum = 200
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Zig Zag",
                        TooltipTemplate = "ZIGZAG([P1]% CLOSE)",
                        DataName = "zigZag",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Zig Zag Retrace High",
                        TooltipTemplate = "ZIGZAG([P1]% CLOSE) Retrace High",
                        DataName = "retraceHigh",
                        DataType = "number",
                        LineType = "dash",
                        DefaultColor = standardGrayTransparent
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Zig Zag Retrace Low",
                        TooltipTemplate = "ZIGZAG([P1]% CLOSE) Retrace Low",
                        DataName = "retraceLow",
                        DataType = "number",
                        LineType = "dash",
                        DefaultColor = standardGrayTransparent
                    }
                }
            },

            // Zig Zag (high/low)
            new IndicatorList
            {
                Name = "Zig Zag (high/low)",
                Uiid = "ZIGZAG-HL",
                LegendTemplate = "ZIGZAG([P1]% HIGH/LOW)",
                Endpoint = $"{baseUrl}/ZIGZAG-HIGHLOW/",
                Category = "price-transform",
                ChartType = "overlay",
                Parameters = new List<IndicatorParamConfig>
                {
                    new IndicatorParamConfig {
                        DisplayName = "Percent Change",
                        ParamName = "percentChange",
                        DataType = "number",
                        DefaultValue = 5,
                        Minimum = 1,
                        Maximum = 200
                    }
                },
                Results = new List<IndicatorResultConfig>{
                    new IndicatorResultConfig {
                        DisplayName = "Zig Zag",
                        TooltipTemplate = "ZIGZAG([P1]% HIGH/LOW)",
                        DataName = "zigZag",
                        DataType = "number",
                        LineType = "solid",
                        DefaultColor = standardBlue
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Zig Zag Retrace High",
                        TooltipTemplate = "ZIGZAG([P1]% HIGH/LOW) Retrace High",
                        DataName = "retraceHigh",
                        DataType = "number",
                        LineType = "dash",
                        DefaultColor = standardGrayTransparent
                    },
                    new IndicatorResultConfig {
                        DisplayName = "Zig Zag Retrace Low",
                        TooltipTemplate = "ZIGZAG([P1]% HIGH/LOW) Retrace Low",
                        DataName = "retraceLow",
                        DataType = "number",
                        LineType = "dash",
                        DefaultColor = standardGrayTransparent
                    }
                }
            }
        };

        return listing
            .OrderBy(x => x.Name)
            .ToList();
    }
}
