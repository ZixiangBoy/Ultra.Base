using System;

namespace Ultra.Log.Interface
{
    public interface IApplicationBaseLog
    {
        void DebugException(Exception exception);
    }
}

