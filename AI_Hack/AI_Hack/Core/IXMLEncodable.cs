using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace AI_Hack.Core
{
    public interface IXMLEncodable
    {
        XmlElement Encode();
        void Decode(XmlElement element);
    }
}
