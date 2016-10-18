using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    public class ProcessorBuilder
    {
        public static EngineOfProcessor<TEngine> CreateEngine<TEngine>()
        {
            return new EngineOfProcessor<TEngine>();
        }
    }
}
