using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using size_t = BrotliSharpLib.Brotli.SizeT;

namespace BrotliSharpLib
{
    public static partial class Brotli
    {
        [DebuggerDisplay("{Value}")]
        internal unsafe struct SizeT
        {
            private void* Value;

            public SizeT(void* v)
            {
                Value = v;
            }

            public static implicit operator UIntPtr(size_t s)
            {
                return (UIntPtr)s.Value;
            }

            public static implicit operator size_t(UIntPtr s)
            {
                size_t result;
                result.Value = s.ToPointer();
                return result;
            }

            public static implicit operator ulong(size_t s)
            {
                return (ulong)s.Value;
            }

            public static implicit operator uint(size_t s)
            {
                return (uint)s.Value;
            }

            public static explicit operator ushort(size_t s)
            {
                return (ushort)s.Value;
            }

            public static explicit operator short(size_t s)
            {
                return (short)s.Value;
            }

            public static explicit operator long(size_t s)
            {
                return (long)s.Value;
            }

            public static explicit operator int(size_t s)
            {
                return (int)s.Value;
            }

            public static explicit operator byte(size_t s)
            {
                return (byte)s.Value;
            }

            public static explicit operator sbyte(size_t s)
            {
                return (sbyte)s.Value;
            }

            public static explicit operator void*(size_t s)
            {
                return s.Value;
            }

            public static explicit operator float(size_t s)
            {
                return (Is64Bit) ? (ulong)s 
                                 : (uint)s;
            }

            public static explicit operator double(size_t s)
            {
                return (Is64Bit) ? (ulong)s 
                                 : (uint)s;
            }

            public static implicit operator size_t(ushort i)
            {
                size_t result;
                result.Value = (void*)i;
                return result;
            }

            public static implicit operator size_t(byte i)
            {
                size_t result;
                result.Value = (void*)i;
                return result;
            }

            public static implicit operator size_t(int i)
            {
                size_t result;
                result.Value = (void*)i;
                return result;
            }

            public static implicit operator size_t(uint i)
            {
                size_t result;
                result.Value = (void*)i;
                return result;
            }

            public static implicit operator size_t(long i)
            {
                size_t result;
                result.Value = (void*)i;
                return result;
            }

            public static implicit operator size_t(ulong i)
            {
                size_t result;
                result.Value = (void*)i;
                return result;
            }

            public static explicit operator size_t(void* p)
            {
                size_t result;
                result.Value = p;
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static explicit operator size_t(double p)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)(ulong)p 
                             : (void*)(uint)p;
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static explicit operator size_t(float p)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)(ulong)p 
                             : (void*)(uint)p;
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator +(size_t a, size_t b)
            {
                size_t result;
                result.Value = (Is64Bit)
                             ? (byte*)a + (ulong)b
                             : (byte*)a + b;
                return result;
            }

            public static size_t operator +(size_t a, int b)
            {
                size_t result;
                result.Value = (byte*)a + b;
                return result;
            }

            public static size_t operator +(size_t a, uint b)
            {
                size_t result;
                result.Value = (byte*)a + b;
                return result;
            }

            public static size_t operator +(size_t a, long b)
            {
                size_t result;
                result.Value = (byte*)a + b;
                return result;
            }

            public static size_t operator +(size_t a, ulong b)
            {
                size_t result;
                result.Value = (byte*)a + b;
                return result;
            }

            public static bool operator >(size_t a, size_t b)
            {
                return a.Value > b.Value;
            }

            public static bool operator >=(size_t a, size_t b)
            {
                return a.Value >= b.Value;
            }

            public static bool operator <=(size_t a, size_t b)
            {
                return a.Value <= b.Value;
            }

            public static bool operator <(size_t a, size_t b)
            {
                return a.Value < b.Value;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator -(size_t a, size_t b)
            {
                size_t result;
                result.Value = (Is64Bit)
                             ? (byte*)a - (ulong)b
                             : (byte*)a - b;
                return result;
            }

            public static size_t operator -(size_t a, int b)
            {
                size_t result;
                result.Value = (byte*)a.Value - b;
                return result;
            }

            public static size_t operator -(size_t a, uint b)
            {
                size_t result;
                result.Value = (byte*)a.Value - b;
                return result;
            }

            public static size_t operator -(size_t a, long b)
            {
                size_t result;
                result.Value = (byte*)a.Value - b;
                return result;
            }

            public static size_t operator -(size_t a, ulong b)
            {
                size_t result;
                result.Value = (byte*)a.Value - b;
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator /(size_t a, size_t b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a / (ulong)b) 
                             : (void*)((uint)a / (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator /(size_t a, int b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a / (uint)b) 
                             : (void*)((uint)a / (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator /(size_t a, uint b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a / b) 
                             : (void*)((uint)a / b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator /(size_t a, long b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a / (ulong)b) 
                             : (void*)((uint)a / (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator /(size_t a, ulong b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a / b) 
                             : (void*)((uint)a / (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator *(size_t a, size_t b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a * (ulong)b) 
                             : (void*)((uint)a * (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator *(size_t a, int b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a * (ulong)b) 
                             : (void*)((uint)a * (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator *(size_t a, uint b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a * b) 
                             : (void*)((uint)a * b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator *(size_t a, long b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a * (ulong)b) 
                             : (void*)((uint)a * (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator *(size_t a, ulong b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a * b) 
                             : (void*)((uint)a * (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator %(size_t a, size_t b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a % (ulong)b) 
                             : (void*)((uint)a % (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator %(size_t a, int b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a % (ulong)b) 
                             : (void*)((uint)a % (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif

            public static size_t operator %(size_t a, uint b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a % b) 
                             : (void*)((uint)a % b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator %(size_t a, long b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a % (ulong)b) 
                             : (void*)((uint)a % (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator %(size_t a, ulong b)
            {
                size_t result;
                result.Value = (Is64Bit)
                             ? (void*)((ulong)a % b) 
                             : (void*)((uint)a % (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator &(size_t a, size_t b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a & (ulong)b) 
                             : (void*)((uint)a & (uint)b);
                return result;
            }

            public static size_t operator &(size_t a, int b)
            {
                size_t result;
                result.Value = (void*)((uint)a & (uint)b);
                return result;
            }

            public static size_t operator &(size_t a, uint b)
            {
                size_t result;
                result.Value = (void*)((uint)a & b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator &(size_t a, long b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a & (uint)b) 
                             : (void*)((uint)a & (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator &(size_t a, ulong b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a & b) 
                             : (void*)((uint)a & b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator |(size_t a, size_t b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a | (ulong)b) 
                             : (void*)((uint)a | (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator |(size_t a, int b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a | (uint)b) 
                             : (void*)((uint)a | (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator |(size_t a, uint b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a | b) 
                             : (void*)((uint)a | b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator |(size_t a, long b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a | (uint)b) 
                             : (void*)((uint)a | (uint)b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator |(size_t a, ulong b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a | b) 
                             : (void*)((uint)a | b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator >>(size_t a, int b)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)((ulong)a >> b) 
                             : (void*)((uint)a >> b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator <<(size_t a, int b)
            {
                size_t result;
                result.Value = (Is64Bit)
                             ? (void*)((ulong)a << b) 
                             : (void*)((uint)a << b);
                return result;
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator ~(size_t a)
            {
                size_t result;
                result.Value = (Is64Bit) 
                             ? (void*)(~(ulong)a) 
                             : (void*)(~(uint)a);
                return result;
            }

            public override string ToString()
            {
                return (Is64Bit) ? ((ulong)Value).ToString() 
                                 : ((uint)Value).ToString();
            }
        }
    }
}