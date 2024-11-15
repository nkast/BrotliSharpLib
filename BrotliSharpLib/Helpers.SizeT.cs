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
                return new size_t(s.ToPointer());
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
                return Is64Bit ? (ulong)s : (uint)s;
            }

            public static explicit operator double(size_t s)
            {
                return Is64Bit ? (ulong)s : (uint)s;
            }

            public static implicit operator size_t(ushort i)
            {
                return new size_t((void*)i);
            }

            public static implicit operator size_t(byte i)
            {
                return new size_t((void*)i);
            }

            public static implicit operator size_t(int i)
            {
                return new size_t((void*)i);
            }

            public static implicit operator size_t(uint i)
            {
                return new size_t((void*)i);
            }

            public static implicit operator size_t(long i)
            {
                return new size_t((void*)i);
            }

            public static implicit operator size_t(ulong i)
            {
                return new size_t((void*)i);
            }

            public static explicit operator size_t(void* p)
            {
                return new size_t(p);
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static explicit operator size_t(double p)
            {
                return new size_t(Is64Bit ? (void*)(ulong)p : (void*)(uint)p);
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static explicit operator size_t(float p)
            {
                return new size_t(Is64Bit ? (void*)(ulong)p : (void*)(uint)p);
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator +(size_t a, size_t b)
            {
                return Is64Bit
                    ? new size_t((byte*)a + (ulong)b)
                    : new size_t((byte*)a + b);
            }

            public static size_t operator +(size_t a, int b)
            {
                return new size_t((byte*)a + b);
            }

            public static size_t operator +(size_t a, uint b)
            {
                return new size_t((byte*)a + b);
            }

            public static size_t operator +(size_t a, long b)
            {
                return new size_t((byte*)a + b);
            }

            public static size_t operator +(size_t a, ulong b)
            {
                return new size_t((byte*)a + b);
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
                return Is64Bit
                    ? new size_t((byte*)a - (ulong)b)
                    : new size_t((byte*)a - b);
            }

            public static size_t operator -(size_t a, int b)
            {
                return new size_t((byte*)a.Value - b);
            }

            public static size_t operator -(size_t a, uint b)
            {
                return new size_t((byte*)a.Value - b);
            }

            public static size_t operator -(size_t a, long b)
            {
                return new size_t((byte*)a.Value - b);
            }

            public static size_t operator -(size_t a, ulong b)
            {
                return new size_t((byte*)a.Value - b);
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator /(size_t a, size_t b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a / (ulong)b) : (void*)((uint)a / (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator /(size_t a, int b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a / (uint)b) : (void*)((uint)a / (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator /(size_t a, uint b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a / b) : (void*)((uint)a / b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator /(size_t a, long b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a / (ulong)b) : (void*)((uint)a / (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator /(size_t a, ulong b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a / b) : (void*)((uint)a / (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator *(size_t a, size_t b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a * (ulong)b) : (void*)((uint)a * (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator *(size_t a, int b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a * (ulong)b) : (void*)((uint)a * (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator *(size_t a, uint b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a * b) : (void*)((uint)a * b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator *(size_t a, long b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a * (ulong)b) : (void*)((uint)a * (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator *(size_t a, ulong b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a * b) : (void*)((uint)a * (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator %(size_t a, size_t b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a % (ulong)b) : (void*)((uint)a % (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator %(size_t a, int b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a % (ulong)b) : (void*)((uint)a % (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif

            public static size_t operator %(size_t a, uint b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a % b) : (void*)((uint)a % b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator %(size_t a, long b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a % (ulong)b) : (void*)((uint)a % (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator %(size_t a, ulong b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a % b) : (void*)((uint)a % (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator &(size_t a, size_t b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a & (ulong)b) : (void*)((uint)a & (uint)b));
            }

            public static size_t operator &(size_t a, int b)
            {
                return new size_t((void*)((uint)a & (uint)b));
            }

            public static size_t operator &(size_t a, uint b)
            {
                return new size_t((void*)((uint)a & b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator &(size_t a, long b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a & (uint)b) : (void*)((uint)a & (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator &(size_t a, ulong b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a & b) : (void*)((uint)a & b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator |(size_t a, size_t b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a | (ulong)b) : (void*)((uint)a | (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator |(size_t a, int b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a | (uint)b) : (void*)((uint)a | (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator |(size_t a, uint b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a | b) : (void*)((uint)a | b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator |(size_t a, long b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a | (uint)b) : (void*)((uint)a | (uint)b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator |(size_t a, ulong b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a | b) : (void*)((uint)a | b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator >>(size_t a, int b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a >> b) : (void*)((uint)a >> b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator <<(size_t a, int b)
            {
                return new size_t(Is64Bit ? (void*)((ulong)a << b) : (void*)((uint)a << b));
            }

#if AGGRESSIVE_INLINING
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
            public static size_t operator ~(size_t a)
            {
                return new size_t(Is64Bit ? (void*)(~(ulong)a) : (void*)(~(uint)a));
            }

            public override string ToString()
            {
                return Is64Bit ? ((ulong)Value).ToString() : ((uint)Value).ToString();
            }
        }
    }
}