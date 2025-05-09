// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
    using Coherence.ProtocolDef;
    using Coherence.Serializer;
    using Coherence.Brook;
    using Coherence.Entities;
    using Coherence.Log;
    using Coherence.Core;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using UnityEngine;

    public struct _3889a458e94666d4784df30d8dd06d7d_df8fe4d8a6104b7ab780e439afba5391 : IEntityCommand
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct Interop
        {
            [FieldOffset(0)]
            public System.Int32 oldEffectID;
            [FieldOffset(4)]
            public System.Int32 newEffectID;
            [FieldOffset(8)]
            public ByteArray syncConfigID;
        }

        public static unsafe _3889a458e94666d4784df30d8dd06d7d_df8fe4d8a6104b7ab780e439afba5391 FromInterop(System.IntPtr data, System.Int32 dataSize) 
        {
            if (dataSize != 24) {
                throw new System.Exception($"Given data size is not equal to the struct size. ({dataSize} != 24) " +
                    "for command with ID 10");
            }

            var orig = new _3889a458e94666d4784df30d8dd06d7d_df8fe4d8a6104b7ab780e439afba5391();
            var comp = (Interop*)data;
            orig.oldEffectID = comp->oldEffectID;
            orig.newEffectID = comp->newEffectID;
            orig.syncConfigID = comp->syncConfigID.Data != null ? System.Text.Encoding.UTF8.GetString((byte*)comp->syncConfigID.Data, (int)comp->syncConfigID.Length) : null;
            return orig;
        }

        public System.Int32 oldEffectID;
        public System.Int32 newEffectID;
        public System.String syncConfigID;
        
        public Entity Entity { get; set; }
        public Coherence.ChannelID ChannelID { get; set; }
        public MessageTarget Routing { get; set; }
        public uint Sender { get; set; }
        public uint GetComponentType() => 10;
        
        public IEntityMessage Clone()
        {
            // This is a struct, so we can safely return
            // a struct copy.
            return this;
        }
        
        public IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Coherence.Log.Logger logger)
        {
            var err = mapper.MapToAbsoluteEntity(Entity, false, out var absoluteEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            Entity = absoluteEntity;
            return IEntityMapper.Error.None;
        }
        
        public IEntityMapper.Error MapToRelative(IEntityMapper mapper, Coherence.Log.Logger logger)
        {
            var err = mapper.MapToRelativeEntity(Entity, false, out var relativeEntity);
            if (err != IEntityMapper.Error.None)
            {
                return err;
            }
            Entity = relativeEntity;
            return IEntityMapper.Error.None;
        }

        public HashSet<Entity> GetEntityRefs() {
            return default;
        }

        public void NullEntityRefs(Entity entity) {
        }
        
        public _3889a458e94666d4784df30d8dd06d7d_df8fe4d8a6104b7ab780e439afba5391(
        Entity entity,
        System.Int32 oldEffectID,
        System.Int32 newEffectID,
        System.String syncConfigID
)
        {
            Entity = entity;
            ChannelID = Coherence.ChannelID.Default;
            Routing = MessageTarget.All;
            Sender = 0;
            
            this.oldEffectID = oldEffectID; 
            this.newEffectID = newEffectID; 
            this.syncConfigID = syncConfigID; 
        }
        
        public static void Serialize(_3889a458e94666d4784df30d8dd06d7d_df8fe4d8a6104b7ab780e439afba5391 commandData, IOutProtocolBitStream bitStream)
        {
            bitStream.WriteIntegerRange(commandData.oldEffectID, 32, -2147483648);
            bitStream.WriteIntegerRange(commandData.newEffectID, 32, -2147483648);
            bitStream.WriteShortString(commandData.syncConfigID);
        }
        
        public static _3889a458e94666d4784df30d8dd06d7d_df8fe4d8a6104b7ab780e439afba5391 Deserialize(IInProtocolBitStream bitStream, Entity entity, MessageTarget target)
        {
            var dataoldEffectID = bitStream.ReadIntegerRange(32, -2147483648);
            var datanewEffectID = bitStream.ReadIntegerRange(32, -2147483648);
            var datasyncConfigID = bitStream.ReadShortString();
    
            return new _3889a458e94666d4784df30d8dd06d7d_df8fe4d8a6104b7ab780e439afba5391()
            {
                Entity = entity,
                Routing = target,
                oldEffectID = dataoldEffectID,
                newEffectID = datanewEffectID,
                syncConfigID = datasyncConfigID
            };   
        }
    }

}
