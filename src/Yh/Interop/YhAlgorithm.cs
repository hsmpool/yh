namespace Yh.Interop;

public enum YhAlgorithm : uint
{
    /// rsa-pkcs1-sha1
    YH_ALGO_RSA_PKCS1_SHA1 = 1,

    /// rsa-pkcs1-sha256
    YH_ALGO_RSA_PKCS1_SHA256 = 2,

    /// rsa-pkcs1-sha384
    YH_ALGO_RSA_PKCS1_SHA384 = 3,

    /// rsa-pkcs1-sha512
    YH_ALGO_RSA_PKCS1_SHA512 = 4,

    /// rsa-pss-sha1
    YH_ALGO_RSA_PSS_SHA1 = 5,

    /// rsa-pss-sha256
    YH_ALGO_RSA_PSS_SHA256 = 6,

    /// rsa-pss-sha384
    YH_ALGO_RSA_PSS_SHA384 = 7,

    /// rsa-pss-sha512
    YH_ALGO_RSA_PSS_SHA512 = 8,

    /// rsa2048
    YH_ALGO_RSA_2048 = 9,

    /// rsa3072
    YH_ALGO_RSA_3072 = 10,

    /// rsa4096
    YH_ALGO_RSA_4096 = 11,

    /// ecp256
    YH_ALGO_EC_P256 = 12,

    /// ecp384
    YH_ALGO_EC_P384 = 13,

    /// ecp521
    YH_ALGO_EC_P521 = 14,

    /// eck256
    YH_ALGO_EC_K256 = 15,

    /// ecbp256
    YH_ALGO_EC_BP256 = 16,

    /// ecbp384
    YH_ALGO_EC_BP384 = 17,

    /// ecbp512
    YH_ALGO_EC_BP512 = 18,

    /// hmac-sha1
    YH_ALGO_HMAC_SHA1 = 19,

    /// hmac-sha256
    YH_ALGO_HMAC_SHA256 = 20,

    /// hmac-sha384
    YH_ALGO_HMAC_SHA384 = 21,

    /// hmac-sha512
    YH_ALGO_HMAC_SHA512 = 22,

    /// ecdsa-sha1
    YH_ALGO_EC_ECDSA_SHA1 = 23,

    /// ecdh
    YH_ALGO_EC_ECDH = 24,

    /// rsa-oaep-sha1
    YH_ALGO_RSA_OAEP_SHA1 = 25,

    /// rsa-oaep-sha256
    YH_ALGO_RSA_OAEP_SHA256 = 26,

    /// rsa-oaep-sha384
    YH_ALGO_RSA_OAEP_SHA384 = 27,

    /// rsa-oaep-sha512
    YH_ALGO_RSA_OAEP_SHA512 = 28,

    /// aes128-ccm-wrap
    YH_ALGO_AES128_CCM_WRAP = 29,

    /// opaque-data
    YH_ALGO_OPAQUE_DATA = 30,

    /// opaque-x509-certificate
    YH_ALGO_OPAQUE_X509_CERTIFICATE = 31,

    /// mgf1-sha1
    YH_ALGO_MGF1_SHA1 = 32,

    /// mgf1-sha256
    YH_ALGO_MGF1_SHA256 = 33,

    /// mgf1-sha384
    YH_ALGO_MGF1_SHA384 = 34,

    /// mgf1-sha512
    YH_ALGO_MGF1_SHA512 = 35,

    /// template-ssh
    YH_ALGO_TEMPLATE_SSH = 36,

    /// aes128-yubico-otp
    YH_ALGO_AES128_YUBICO_OTP = 37,

    /// aes128-yubico-authentication
    YH_ALGO_AES128_YUBICO_AUTHENTICATION = 38,

    /// aes192-yubico-otp
    YH_ALGO_AES192_YUBICO_OTP = 39,

    /// aes256-yubico-otp
    YH_ALGO_AES256_YUBICO_OTP = 40,

    /// aes192-ccm-wrap
    YH_ALGO_AES192_CCM_WRAP = 41,

    /// aes256-ccm-wrap
    YH_ALGO_AES256_CCM_WRAP = 42,

    /// ecdsa-sha256
    YH_ALGO_EC_ECDSA_SHA256 = 43,

    /// ecdsa-sha384
    YH_ALGO_EC_ECDSA_SHA384 = 44,

    /// ecdsa-sha512
    YH_ALGO_EC_ECDSA_SHA512 = 45,

    /// ed25519
    YH_ALGO_EC_ED25519 = 46,

    /// ecp224
    YH_ALGO_EC_P224 = 47,

    /// rsa-pkcs1-decrypt
    YH_ALGO_RSA_PKCS1_DECRYPT = 48,

    /// ec-p256-yubico-authentication
    YH_ALGO_EC_P256_YUBICO_AUTHENTICATION = 49,

    /// aes128
    YH_ALGO_AES128 = 50,

    /// aes192
    YH_ALGO_AES192 = 51,

    /// aes256
    YH_ALGO_AES256 = 52,

    /// aes-ecb
    YH_ALGO_AES_ECB = 53,

    /// aes-cbc
    YH_ALGO_AES_CBC = 54,

    /// aes-kwp
    YH_ALGO_AES_KWP = 55,
}