using System;
using System.Collections.Generic;
using System.Text;

namespace SpookVooper.Api
{
    class VooperException : Exception
    {
        public VooperException(string message) : base(message)
        {
            
        }
    }
}
