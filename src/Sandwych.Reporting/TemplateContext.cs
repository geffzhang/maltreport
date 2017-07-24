﻿using Sandwych.Reporting.Textilize;
using System.Collections.Generic;

namespace Sandwych.Reporting
{
    public class TemplateContext
    {
        private readonly FluidTemplateContext _fluidContext;

        public FluidTemplateContext FluidContext => _fluidContext;

        public TemplateContext(IReadOnlyDictionary<string, object> values, IEnumerable<ISyncFilter> filters = null)
        {
            _fluidContext = new FluidTemplateContext(values);

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    _fluidContext.Filters.AddFilter(filter.Name, filter.Execute);
                }
            }
        }
    }
}