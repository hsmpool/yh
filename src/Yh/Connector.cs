using System;
using System.Linq;
using System.Text;
using Yh.Interop;

namespace Yh;

public sealed class Connector : IDisposable
{
    private readonly IntPtr _handle;

    static Connector()
    {
        NativeMethods.yh_init();
    }

    private Connector(IntPtr handle)
    {
        _handle = handle;
    }

    /// <summary>
    /// Instantiate a new Connector
    /// </summary>
    /// <param name="url">URL associated with this connector</param>
    public static Connector Init(string url)
    {
        YhException.ThrowIfNotSuccess(NativeMethods.yh_init_connector(url, out var handle));
        return new Connector(handle);
    }

    /// <summary>
    /// Connect to the device
    /// </summary>
    /// <param name="timeout">Connection timeout in seconds</param>
    public void Connect(int timeout)
    {
        YhException.ThrowIfNotSuccess(NativeMethods.yh_connect(_handle, timeout));
    }

    /// <summary>
    /// Create a <see cref="Session"/> that uses an encryption key and a MAC key derived from a password
    /// </summary>
    /// <param name="authenticationKey">Object ID of the Authentication Key used to authenticate the session</param>
    /// <param name="password">Password used to derive the session encryption key and MAC key</param>
    public Session CreateSession(ushort authenticationKey, string password)
    {
        var passwordBuffer = Encoding.UTF8.GetBytes(password);

        var rc = NativeMethods.yh_create_session_derived(
            _handle,
            authenticationKey,
            passwordBuffer.ToArray(),
            (UIntPtr)passwordBuffer.Length,
            false,
            out var session);

        YhException.ThrowIfNotSuccess(rc);

        return new Session(session);
    }

    public void Dispose()
    {
        YhException.ThrowIfNotSuccess(NativeMethods.yh_disconnect(_handle));
    }
}