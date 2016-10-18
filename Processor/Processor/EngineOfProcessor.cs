using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    public class EngineOfProcessor<TEngine>
    {
        public EntityOfProcessor<TEngine,TEntity> For<TEntity>()
        {
            return new EntityOfProcessor<TEngine, TEntity>();
        }
    }
}
