using System;
using System.Runtime.InteropServices;

namespace Yh.Interop;

public sealed class YhException : Exception
{
    private YhException(YhReturnCode rc, string? message) : base(message)
    {
        Code = rc;
    }

    public YhReturnCode Code { get; }

    private static YhException FromYhReturnCode(YhReturnCode returnCode)
    {
        var ptr = NativeMethods.yh_strerror(returnCode);
        return new YhException(returnCode, Marshal.PtrToStringAnsi(ptr));
    }

    public static void ThrowIfNotSuccess(YhReturnCode returnCode)
    {
        if (returnCode == YhReturnCode.Success)
        {
            return;
        }

        var exception = FromYhReturnCode(returnCode);
        throw exception;
    }
}