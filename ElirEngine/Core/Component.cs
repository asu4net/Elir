using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElirEngine.Core
{
    public abstract class Component
    {
        #pragma warning disable CS8618 
        public Entity entity;
        #pragma warning restore CS8618

        public virtual void OnLoad() { }
        public virtual void Update() { }
        public virtual void OnUnload() { }
    }
}
