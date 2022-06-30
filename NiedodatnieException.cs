using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    public class NiedodatnieException : Exception
    {
        public NiedodatnieException() { }
        public NiedodatnieException(string msg) : base(msg)
        {

        }
    }
}
