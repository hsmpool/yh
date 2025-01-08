using Yh.Interop;

namespace Yh;

public sealed class ObjectRefInfo
{
    public required int Id { get; init; }
    public required YhObjectType Type { get; init; }
    public required int Sequence { get; init; }

    internal static ObjectRefInfo FromDescriptor(NativeMethods.yh_object_descriptor descriptor)
    {
        return new ObjectRefInfo
        {
            Id = descriptor.id,
            Type = descriptor.type,
            Sequence = descriptor.sequence,
        };
    }
}