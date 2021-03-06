﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Internal.NativeFormat;
using Debug = System.Diagnostics.Debug;

namespace Internal.Metadata.NativeFormat.Writer
{
    internal static partial class MdBinaryWriter
    {
        public static void Write(this NativeWriter writer, bool value)
        {
            writer.WriteUInt8((byte)(value ? 1 : 0));
        }

        public static void Write(this NativeWriter writer, byte value)
        {
            writer.WriteUInt8(value);
        }

        public static void Write(this NativeWriter writer, sbyte value)
        {
            writer.WriteUInt8((byte)value);
        }

        public static void Write(this NativeWriter writer, short value)
        {
            writer.WriteSigned(value);
        }

        public static void Write(this NativeWriter writer, ushort value)
        {
            writer.WriteUnsigned(value);
        }

        public static void Write(this NativeWriter writer, int value)
        {
            writer.WriteSigned(value);
        }

        public static void Write(this NativeWriter writer, uint value)
        {
            writer.WriteUnsigned(value);
        }

        public static void Write(this NativeWriter writer, ulong value)
        {
            writer.WriteUnsignedLong(value);
        }

        public static void Write(this NativeWriter writer, long value)
        {
            writer.WriteSignedLong(value);
        }

        public static void Write(this NativeWriter writer, string value)
        {
            Debug.Assert(value != null);
            writer.WriteString(value);
        }

        public static void Write(this NativeWriter writer, char value)
        {
            writer.WriteUnsigned((uint)value);
        }

        public static void Write(this NativeWriter writer, float value)
        {
            writer.WriteFloat(value);
        }

        public static void Write(this NativeWriter writer, double value)
        {
            writer.WriteDouble(value);
        }

        public static void Write(this NativeWriter writer, MetadataRecord record)
        {
            if (record != null)
                writer.WriteUnsigned((uint)record.HandleType | (uint)(record.HandleOffset << 8));
            else
                writer.WriteUnsigned(0);
        }
    }
}
