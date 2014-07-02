using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI_Hack.Core
{
    public interface ISubject
    {
        void Attach(Observer obj);
        void Detach(Observer obj);
        void Notify(object msg);
    }
}
