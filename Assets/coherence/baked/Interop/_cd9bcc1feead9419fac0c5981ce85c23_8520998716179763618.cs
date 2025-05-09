// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    using Coherence.ProtocolDef;
    using Coherence.Serializer;
    using Coherence.SimulationFrame;
    using Coherence.Entities;
    using Coherence.Utils;
    using Coherence.Brook;
    using Coherence.Core;
    using Logger = Coherence.Log.Logger;
    using UnityEngine;
    using Coherence.Toolkit;
    public struct _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618 : ICoherenceComponentData
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct Interop
        {
            [FieldOffset(0)]
            public System.Int32 currentBackpack;
            [FieldOffset(4)]
            public System.Int32 currentSkinTone;
            [FieldOffset(8)]
            public System.Int32 currentClothes;
            [FieldOffset(12)]
            public System.Int32 currentBody;
            [FieldOffset(16)]
            public System.Int32 currentHairstyle;
        }

        public void ResetFrame(AbsoluteSimulationFrame frame)
        {
            FieldsMask |= _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentBackpackMask;
            currentBackpackSimulationFrame = frame;
            FieldsMask |= _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentSkinToneMask;
            currentSkinToneSimulationFrame = frame;
            FieldsMask |= _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentClothesMask;
            currentClothesSimulationFrame = frame;
            FieldsMask |= _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentBodyMask;
            currentBodySimulationFrame = frame;
            FieldsMask |= _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentHairstyleMask;
            currentHairstyleSimulationFrame = frame;
        }

        public static unsafe _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618 FromInterop(IntPtr data, Int32 dataSize, InteropAbsoluteSimulationFrame* simFrames, Int32 simFramesCount)
        {
            if (dataSize != 20) {
                throw new Exception($"Given data size is not equal to the struct size. ({dataSize} != 20) " +
                    "for component with ID 49");
            }

            if (simFramesCount != 0) {
                throw new Exception($"Given simFrames size is not equal to the expected length. ({simFramesCount} != 0) " +
                    "for component with ID 49");
            }

            var orig = new _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618();

            var comp = (Interop*)data;

            orig.currentBackpack = comp->currentBackpack;
            orig.currentSkinTone = comp->currentSkinTone;
            orig.currentClothes = comp->currentClothes;
            orig.currentBody = comp->currentBody;
            orig.currentHairstyle = comp->currentHairstyle;

            return orig;
        }

        public static unsafe _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618 FromInteropArchetype_cd9bcc1feead9419fac0c5981ce85c23__cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618_LOD0(IntPtr data, Int32 dataSize, InteropAbsoluteSimulationFrame* simFrames, Int32 simFramesCount)
        {
            if (dataSize != 20) {
                throw new Exception($"Given data size is not equal to the struct size. ({dataSize} != 20) " +
                    "for component with ID 62");
            }

                
            if (simFramesCount != 0) {
                throw new Exception($"Given simFrames size is not equal to the expected length. ({simFramesCount} != 0) " +
                    "for component with ID 62");
            }

            var orig = new _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618();

            var comp = (Interop*)data;

            orig.currentBackpack = comp->currentBackpack;
            orig.currentSkinTone = comp->currentSkinTone;
            orig.currentClothes = comp->currentClothes;
            orig.currentBody = comp->currentBody;
            orig.currentHairstyle = comp->currentHairstyle;

            return orig;
        }

        public static uint currentBackpackMask => 0b00000000000000000000000000000001;
        public AbsoluteSimulationFrame currentBackpackSimulationFrame;
        public System.Int32 currentBackpack;
        public static uint currentSkinToneMask => 0b00000000000000000000000000000010;
        public AbsoluteSimulationFrame currentSkinToneSimulationFrame;
        public System.Int32 currentSkinTone;
        public static uint currentClothesMask => 0b00000000000000000000000000000100;
        public AbsoluteSimulationFrame currentClothesSimulationFrame;
        public System.Int32 currentClothes;
        public static uint currentBodyMask => 0b00000000000000000000000000001000;
        public AbsoluteSimulationFrame currentBodySimulationFrame;
        public System.Int32 currentBody;
        public static uint currentHairstyleMask => 0b00000000000000000000000000010000;
        public AbsoluteSimulationFrame currentHairstyleSimulationFrame;
        public System.Int32 currentHairstyle;

        public uint FieldsMask { get; set; }
        public uint StoppedMask { get; set; }
        public uint GetComponentType() => 49;
        public int PriorityLevel() => 100;
        public const int order = 0;
        public uint InitialFieldsMask() => 0b00000000000000000000000000011111;
        public bool HasFields() => true;
        public bool HasRefFields() => false;


        public long[] GetSimulationFrames() {
            return null;
        }

        public int GetFieldCount() => 5;


        
        public HashSet<Entity> GetEntityRefs()
        {
            return default;
        }

        public uint ReplaceReferences(Entity fromEntity, Entity toEntity)
        {
            return 0;
        }
        
        public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper)
        {
            return IEntityMapper.Error.None;
        }

        public IEntityMapper.Error MapToRelative(IEntityMapper mapper)
        {
            return IEntityMapper.Error.None;
        }

        public ICoherenceComponentData Clone() => this;
        public int GetComponentOrder() => order;
        public bool IsSendOrdered() => false;

        private static readonly System.Int32 _currentBackpack_Min = -2;
        private static readonly System.Int32 _currentBackpack_Max = 3;
        private static readonly System.Int32 _currentSkinTone_Min = -2;
        private static readonly System.Int32 _currentSkinTone_Max = 20;
        private static readonly System.Int32 _currentClothes_Min = -2147483648;
        private static readonly System.Int32 _currentClothes_Max = 2147483647;
        private static readonly System.Int32 _currentBody_Min = -2147483648;
        private static readonly System.Int32 _currentBody_Max = 2147483647;
        private static readonly System.Int32 _currentHairstyle_Min = -2147483648;
        private static readonly System.Int32 _currentHairstyle_Max = 2147483647;

        public AbsoluteSimulationFrame? GetMinSimulationFrame()
        {
            AbsoluteSimulationFrame? min = null;


            return min;
        }

        public ICoherenceComponentData MergeWith(ICoherenceComponentData data)
        {
            var other = (_cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618)data;
            var otherMask = other.FieldsMask;

            FieldsMask |= otherMask;
            StoppedMask &= ~(otherMask);

            if ((otherMask & 0x01) != 0)
            {
                this.currentBackpackSimulationFrame = other.currentBackpackSimulationFrame;
                this.currentBackpack = other.currentBackpack;
            }

            otherMask >>= 1;
            if ((otherMask & 0x01) != 0)
            {
                this.currentSkinToneSimulationFrame = other.currentSkinToneSimulationFrame;
                this.currentSkinTone = other.currentSkinTone;
            }

            otherMask >>= 1;
            if ((otherMask & 0x01) != 0)
            {
                this.currentClothesSimulationFrame = other.currentClothesSimulationFrame;
                this.currentClothes = other.currentClothes;
            }

            otherMask >>= 1;
            if ((otherMask & 0x01) != 0)
            {
                this.currentBodySimulationFrame = other.currentBodySimulationFrame;
                this.currentBody = other.currentBody;
            }

            otherMask >>= 1;
            if ((otherMask & 0x01) != 0)
            {
                this.currentHairstyleSimulationFrame = other.currentHairstyleSimulationFrame;
                this.currentHairstyle = other.currentHairstyle;
            }

            otherMask >>= 1;
            StoppedMask |= other.StoppedMask;

            return this;
        }

        public uint DiffWith(ICoherenceComponentData data)
        {
            throw new System.NotSupportedException($"{nameof(DiffWith)} is not supported in Unity");
        }

        public static uint Serialize(_cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618 data, bool isRefSimFrameValid, AbsoluteSimulationFrame referenceSimulationFrame, IOutProtocolBitStream bitStream, Logger logger)
        {
            if (bitStream.WriteMask(data.StoppedMask != 0))
            {
                bitStream.WriteMaskBits(data.StoppedMask, 5);
            }

            var mask = data.FieldsMask;

            if (bitStream.WriteMask((mask & 0x01) != 0))
            {

                Coherence.Utils.Bounds.Check(data.currentBackpack, _currentBackpack_Min, _currentBackpack_Max, "_cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentBackpack", logger);

                data.currentBackpack = Coherence.Utils.Bounds.Clamp(data.currentBackpack, _currentBackpack_Min, _currentBackpack_Max);

                var fieldValue = data.currentBackpack;



                bitStream.WriteIntegerRange(fieldValue, 3, -2);
            }

            mask >>= 1;
            if (bitStream.WriteMask((mask & 0x01) != 0))
            {

                Coherence.Utils.Bounds.Check(data.currentSkinTone, _currentSkinTone_Min, _currentSkinTone_Max, "_cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentSkinTone", logger);

                data.currentSkinTone = Coherence.Utils.Bounds.Clamp(data.currentSkinTone, _currentSkinTone_Min, _currentSkinTone_Max);

                var fieldValue = data.currentSkinTone;



                bitStream.WriteIntegerRange(fieldValue, 5, -2);
            }

            mask >>= 1;
            if (bitStream.WriteMask((mask & 0x01) != 0))
            {

                Coherence.Utils.Bounds.Check(data.currentClothes, _currentClothes_Min, _currentClothes_Max, "_cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentClothes", logger);

                data.currentClothes = Coherence.Utils.Bounds.Clamp(data.currentClothes, _currentClothes_Min, _currentClothes_Max);

                var fieldValue = data.currentClothes;



                bitStream.WriteIntegerRange(fieldValue, 32, -2147483648);
            }

            mask >>= 1;
            if (bitStream.WriteMask((mask & 0x01) != 0))
            {

                Coherence.Utils.Bounds.Check(data.currentBody, _currentBody_Min, _currentBody_Max, "_cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentBody", logger);

                data.currentBody = Coherence.Utils.Bounds.Clamp(data.currentBody, _currentBody_Min, _currentBody_Max);

                var fieldValue = data.currentBody;



                bitStream.WriteIntegerRange(fieldValue, 32, -2147483648);
            }

            mask >>= 1;
            if (bitStream.WriteMask((mask & 0x01) != 0))
            {

                Coherence.Utils.Bounds.Check(data.currentHairstyle, _currentHairstyle_Min, _currentHairstyle_Max, "_cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentHairstyle", logger);

                data.currentHairstyle = Coherence.Utils.Bounds.Clamp(data.currentHairstyle, _currentHairstyle_Min, _currentHairstyle_Max);

                var fieldValue = data.currentHairstyle;



                bitStream.WriteIntegerRange(fieldValue, 32, -2147483648);
            }

            mask >>= 1;

            return mask;
        }

        public static _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618 Deserialize(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
        {
            var stoppedMask = (uint)0;
            if (bitStream.ReadMask())
            {
                stoppedMask = bitStream.ReadMaskBits(5);
            }

            var val = new _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618();
            if (bitStream.ReadMask())
            {

                val.currentBackpack = bitStream.ReadIntegerRange(3, -2);
                val.FieldsMask |= _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentBackpackMask;
            }
            if (bitStream.ReadMask())
            {

                val.currentSkinTone = bitStream.ReadIntegerRange(5, -2);
                val.FieldsMask |= _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentSkinToneMask;
            }
            if (bitStream.ReadMask())
            {

                val.currentClothes = bitStream.ReadIntegerRange(32, -2147483648);
                val.FieldsMask |= _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentClothesMask;
            }
            if (bitStream.ReadMask())
            {

                val.currentBody = bitStream.ReadIntegerRange(32, -2147483648);
                val.FieldsMask |= _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentBodyMask;
            }
            if (bitStream.ReadMask())
            {

                val.currentHairstyle = bitStream.ReadIntegerRange(32, -2147483648);
                val.FieldsMask |= _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618.currentHairstyleMask;
            }

            val.StoppedMask = stoppedMask;

            return val;
        }

        public static _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618 DeserializeArchetype_cd9bcc1feead9419fac0c5981ce85c23__cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618_LOD0(AbsoluteSimulationFrame referenceSimulationFrame, InProtocolBitStream bitStream)
        {
            var stoppedMask = (uint)0;
            if (bitStream.ReadMask())
            {
                stoppedMask = bitStream.ReadMaskBits(5);
            }

            var val = new _cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618();
            if (bitStream.ReadMask())
            {

                val.currentBackpack = bitStream.ReadIntegerRange(3, -2);
                val.FieldsMask |= currentBackpackMask;
            }
            if (bitStream.ReadMask())
            {

                val.currentSkinTone = bitStream.ReadIntegerRange(5, -2);
                val.FieldsMask |= currentSkinToneMask;
            }
            if (bitStream.ReadMask())
            {

                val.currentClothes = bitStream.ReadIntegerRange(32, -2147483648);
                val.FieldsMask |= currentClothesMask;
            }
            if (bitStream.ReadMask())
            {

                val.currentBody = bitStream.ReadIntegerRange(32, -2147483648);
                val.FieldsMask |= currentBodyMask;
            }
            if (bitStream.ReadMask())
            {

                val.currentHairstyle = bitStream.ReadIntegerRange(32, -2147483648);
                val.FieldsMask |= currentHairstyleMask;
            }

            val.StoppedMask = stoppedMask;

            return val;
        }

        public override string ToString()
        {
            return $"_cd9bcc1feead9419fac0c5981ce85c23_8520998716179763618(" +
                $" currentBackpack: { this.currentBackpack }" +
                $" currentSkinTone: { this.currentSkinTone }" +
                $" currentClothes: { this.currentClothes }" +
                $" currentBody: { this.currentBody }" +
                $" currentHairstyle: { this.currentHairstyle }" +
                $" Mask: { System.Convert.ToString(FieldsMask, 2).PadLeft(5, '0') }, " +
                $"Stopped: { System.Convert.ToString(StoppedMask, 2).PadLeft(5, '0') })";
        }
    }

}
