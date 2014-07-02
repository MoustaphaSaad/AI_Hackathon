using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI_Hack.Core
{
    public abstract partial class Observer
    {
        protected abstract void Update(object arguments);
    }
}
