using Core.CommonMessage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel.Exceptions
{
    public class NullParameterException : Exception
    {
        public NullParameterException() : base(ParameterMsg.ParameterInvalid)
        {

        }
    }
}
