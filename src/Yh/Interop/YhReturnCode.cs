namespace Yh.Interop;

public enum YhReturnCode
{
    Success = 0,
    MemoryError = -1,
    InitError = -2,
    ConnectionError = -3,
    ConnectorNotFound = -4,
    InvalidParameters = -5,
    WrongLength = -6,
    BufferTooSmall = -7,
    CryptogramMismatch = -8,
    SessionAuthenticationFailed = -9,
    MacMismatch = -10,
    DeviceOk = -11,
    DeviceInvalidCommand = -12,
    DeviceInvalidData = -13,
    DeviceInvalidSession = -14,
    DeviceAuthenticationFailed = -15,
    DeviceSessionsFull = -16,
    DeviceSessionFailed = -17,
    DeviceStorageFailed = -18,
    DeviceWrongLength = -19,
    DeviceInsufficientPermissions = -20,
    DeviceLogFull = -21,
    DeviceObjectNotFound = -22,
    DeviceInvalidId = -23,
    DeviceInvalidOtp = -24,
    DeviceDemoMode = -25,
    DeviceCommandUnexecuted = -26,
    GenericError = -27,
    DeviceObjectExists = -28,
    ConnectorError = -29,
    DeviceSshCaConstraintViolation = -30,
    DeviceAlgorithmDisabled = -31
}