using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Yh.Interop;

internal static class NativeMethods
{
    private const string LibraryName = "yubihsm";

    private const int YH_CAPABILITIES_LEN = 8;
    private const int YH_OBJ_LABEL_LEN = 40;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct yh_capabilities
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = YH_CAPABILITIES_LEN)]
        public byte[] capabilities;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct yh_object_descriptor
    {
        public yh_capabilities capabilities;
        public ushort id;
        public ushort len;
        public ushort domains;
        public YhObjectType type;
        public YhAlgorithm algorithm;
        public byte sequence;
        public YhOrigin origin;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = YH_OBJ_LABEL_LEN + 1)]
        public byte[] label;
        public yh_capabilities delegated_capabilities;
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern YhReturnCode yh_connect(IntPtr connector, int timeout);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern YhReturnCode yh_create_session_derived(
        IntPtr connector,
        ushort authKeyId,
        [In] byte[] passwordBuffer,
        UIntPtr passwordLength,
        [MarshalAs(UnmanagedType.Bool)] bool recreate,
        out IntPtr session);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern YhReturnCode yh_destroy_session(ref IntPtr session);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern YhReturnCode yh_disconnect(IntPtr connector);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern YhReturnCode yh_exit();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern YhReturnCode yh_util_get_object_info(
        IntPtr session,
        ushort id,
        byte type,
        ref yh_object_descriptor obj);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern YhReturnCode yh_util_get_opaque(
        IntPtr session,
        ushort objectId,
        [Out] byte[] output,
        ref UIntPtr outputLength);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern YhReturnCode yh_init();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern YhReturnCode yh_init_connector(string url, out IntPtr connector);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr yh_strerror(YhReturnCode rc);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    public static extern YhReturnCode yh_util_close_session(IntPtr session);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    public static extern YhReturnCode yh_util_generate_rsa_key(
        IntPtr session,
        ref ushort keyId,
        [In, MarshalAs(UnmanagedType.LPStr)] string label,
        ushort domains,
        in IntPtr capabilities,
        YhAlgorithm algorithm);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    public static extern YhReturnCode yh_util_list_objects(
        IntPtr session,
        ushort id,
        YhObjectType type,
        ushort domains,
        in IntPtr capabilities,
        YhAlgorithm algorithm,
        [In, MarshalAs(UnmanagedType.LPStr)] string? label,
        [Out] yh_object_descriptor[] objects,
        ref UIntPtr n_objects);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    public static extern YhReturnCode yh_util_sign_pkcs1v1_5(
        IntPtr session,
        ushort keyId,
        [MarshalAs(UnmanagedType.Bool)] bool hashed,
        [In] byte[] input,
        UIntPtr inputLength,
        [Out] byte[] output,
        ref UIntPtr outputLength);
}