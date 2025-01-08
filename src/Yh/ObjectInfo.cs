using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Yh.Interop;

namespace Yh;

public sealed class ObjectInfo
{
    public required int Id { get; init; }
    public required int[] Domains { get; init; }
    public required string Label { get; init; }
    public required YhOrigin Origin { get; init; }
    public required YhObjectType Type { get; init; }
    public required YhAlgorithm Algorithm { get; init; }
    public required int Sequence { get; init; }
    public required int Length { get; init; }
    public required IReadOnlyCollection<YhCapability> Capabilities { get; init; }
    public required IReadOnlyCollection<YhCapability> DelegatedCapabilities { get; init; }

    internal static ObjectInfo FromDescriptor(NativeMethods.yh_object_descriptor descriptor)
    {
        return new ObjectInfo
        {
            Id = descriptor.id,
            Domains = [],
            Label = Encoding.UTF8.GetString(descriptor.label),
            Origin = descriptor.origin,
            Type = descriptor.type,
            Algorithm = descriptor.algorithm,
            Sequence = descriptor.sequence,
            Length = descriptor.len,
            Capabilities = ParseCapabilities(descriptor.capabilities),
            DelegatedCapabilities = descriptor.type is YhObjectType.AuthenticationKey or YhObjectType.WrapKey
                ? ParseCapabilities(descriptor.delegated_capabilities)
                : []
        };
    }

    private static IReadOnlyCollection<YhCapability> ParseCapabilities(NativeMethods.yh_capabilities num)
    {
        var result = new List<YhCapability>();

        foreach (var capability in Enum.GetValues<YhCapability>())
        {
            var c = (int)capability;

            if (c >= num.capabilities.Length * 8)
            {
                // bit is out of bounds
                continue;
            }

            var byteIndex = 7 - c / 8;
            var bitPosition = c % 8;
            var byteHasBitSet = ((1UL << bitPosition) & num.capabilities[byteIndex]) != 0;

            if (byteHasBitSet)
            {
                result.Add(capability);
            }
        }

        return result;
    }
}
