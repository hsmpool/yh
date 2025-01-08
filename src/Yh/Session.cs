using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yh.Interop;

namespace Yh
{
    public sealed class Session : IDisposable
    {
        private IntPtr _handle;

        internal Session(IntPtr handle)
        {
            _handle = handle;
        }

        public ushort GenerateRsaKey(
            YhAlgorithm algorithm,
            ushort? keyId,
            string? label,
            ushort? domains,
            IList<YhCapability>? capabilities)
        {
            throw new NotImplementedException();
        }

        public ObjectInfo GetObjectInfo(ushort objectId, YhObjectType objectType)
        {
            var descriptor = new NativeMethods.yh_object_descriptor();

            var rc = NativeMethods.yh_util_get_object_info(
                _handle,
                objectId,
                (byte)objectType,
                ref descriptor);

            YhException.ThrowIfNotSuccess(rc);

            return ObjectInfo.FromDescriptor(descriptor);
        }

        public byte[] GetOpaque(ushort objectId)
        {
            var outputBuffer = new byte[2091];
            var outputLength = (UIntPtr)outputBuffer.Length;

            var rc = NativeMethods.yh_util_get_opaque(
                _handle,
                objectId,
                outputBuffer,
                ref outputLength);

            YhException.ThrowIfNotSuccess(rc);

            return outputBuffer.Take((int)outputLength).ToArray();
        }

        public ushort ImportAuthenticationKey(
            string password,
            ushort? keyId,
            string? label,
            ushort? domains,
            IList<YhCapability>? capabilities,
            IList<YhCapability>? delegatedCapabilities)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<ObjectRefInfo> ListObjects(
            ushort objectId = 0x0000,
            YhObjectType? objectType = null,
            ushort domains = 0x0000)
        {
            var objects = new NativeMethods.yh_object_descriptor[256];
            var objectsLength = new UIntPtr((uint)objects.Length);

            var rc = NativeMethods.yh_util_list_objects(
                _handle,
                objectId,
                objectType ?? 0,
                domains,
                in IntPtr.Zero,
                0,
                null,
                objects,
                ref objectsLength);

            YhException.ThrowIfNotSuccess(rc);

            return objects
                .Take((int)objectsLength)
                .Select(ObjectRefInfo.FromDescriptor)
                .ToList();
        }

        public byte[] SignPkcs1v1_5(ushort asymmetricKey, byte[] input)
        {
            var outputBuffer = new byte[512];
            var outputLength = (UIntPtr)outputBuffer.Length;

            var rc = NativeMethods.yh_util_sign_pkcs1v1_5(
                _handle,
                asymmetricKey,
                false,
                input.ToArray(),
                (UIntPtr)input.Length,
                outputBuffer,
                ref outputLength);

            YhException.ThrowIfNotSuccess(rc);

            return outputBuffer.Take((int)outputLength).ToArray();
        }

        public void Dispose()
        {
            YhException.ThrowIfNotSuccess(NativeMethods.yh_util_close_session(_handle));
            YhException.ThrowIfNotSuccess(NativeMethods.yh_destroy_session(ref _handle));
        }
    }
}