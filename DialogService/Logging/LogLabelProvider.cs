using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog.Sinks.Loki;
using Serilog.Sinks.Loki.Labels;

namespace DialogService.Logging
{
    public class LogLabelProvider : ILogLabelProvider
    {
        public IList<LokiLabel> GetLabels()
        {
            return new List<LokiLabel>
            {
                new LokiLabel("app", "demo"),
                new LokiLabel("namespace", "prod")
            };
        }

        public IList<string> PropertiesAsLabels { get; set; } = new List<string>
        {
            "level", // Since 3.0.0, you need to explicitly add level if you want it!
            "MyLabelPropertyName"
        };
        public IList<string> PropertiesToAppend { get; set; } = new List<string>
        {
            "MyAppendPropertyName"
        };
        public LokiFormatterStrategy FormatterStrategy { get; set; } = LokiFormatterStrategy.SpecificPropertiesAsLabelsOrAppended;

        LokiFormatterStrategy ILogLabelProvider.FormatterStrategy => LokiFormatterStrategy.SpecificPropertiesAsLabelsOrAppended;
    }  

}