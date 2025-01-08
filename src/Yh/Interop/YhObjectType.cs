namespace Yh.Interop;

public enum YhObjectType : uint
{
    /// <summary>
    /// Opaque Object is an unchecked kind of Object, normally used to store raw data in the device
    /// </summary>
    Opaque = 0x01,

    /// <summary>
    /// Authentication Key is used to establish Sessions with a device
    /// </summary>
    AuthenticationKey = 0x02,

    /// <summary>
    /// Asymmetric Key is the private key of an asymmetric key-pair
    /// </summary>
    AsymmetricKey = 0x03,

    /// <summary>
    /// Wrap Key is a secret key used to wrap and unwrap Objects during the export and import process
    /// </summary>
    WrapKey = 0x04,

    /// <summary>
    /// HMAC Key is a secret key used when computing and verifying HMAC signatures
    /// </summary>
    HmacKey = 0x05,

    /// <summary>
    /// Template is a binary object used for example to validate SSH certificate requests
    /// </summary>
    Template = 0x06,

    /// <summary>
    /// OTP AEAD Key is a secret key used to decrypt Yubico OTP values
    /// </summary>
    OtpAeadKey = 0x07,

    /// <summary>
    /// Symmetric Key is a secret key used for encryption and decryption
    /// </summary>
    SymmetricKey = 0x08,

    /// <summary>
    /// Public Wrap Key is a public key used to wrap Objects during the export process
    /// </summary>
    PublicWrapKey = 0x09,

    /// <summary>
    /// Public Key is the public key of an asymmetric key-pair. The public key never exists in device and is mostly
    /// here for PKCS#11.
    /// </summary>
    PublicKey = 0x83,
}