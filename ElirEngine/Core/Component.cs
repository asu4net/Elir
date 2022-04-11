using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElirEngine.Core
{
    public class Component
    {
        public Entity entity;

        public virtual void Start() { }
        public virtual void Update(TimeSpan delta) { }
    }
}
