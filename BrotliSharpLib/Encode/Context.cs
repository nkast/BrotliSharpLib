﻿using size_t = BrotliSharpLib.Brotli.SizeT;

namespace BrotliSharpLib
{
    public static partial class Brotli
    {
        /* Second-order context lookup table for UTF8 byte streams.

           If p1 and p2 are the previous two bytes, we calculate the context as

             context = kUTF8ContextLookup[p1] | kUTF8ContextLookup[p2 + 256].

           If the previous two bytes are ASCII characters (i.e. < 128), this will be
           equivalent to

             context = 4 * context1(p1) + context2(p2),

           where context1 is based on the previous byte in the following way:

             0  : non-ASCII control
             1  : \t, \n, \r
             2  : space
             3  : other punctuation
             4  : " '
             5  : %
             6  : ( < [ {
             7  : ) > ] }
             8  : , ; :
             9  : .
             10 : =
             11 : number
             12 : upper-case vowel
             13 : upper-case consonant
             14 : lower-case vowel
             15 : lower-case consonant

           and context2 is based on the second last byte:

             0 : control, space
             1 : punctuation
             2 : upper-case letter, number
             3 : lower-case letter

           If the last byte is ASCII, and the second last byte is not (in a valid UTF8
           stream it will be a continuation byte, value between 128 and 191), the
           context is the same as if the second last byte was an ASCII control or space.

           If the last byte is a UTF8 lead byte (value >= 192), then the next byte will
           be a continuation byte and the context id is 2 or 3 depending on the LSB of
           the last byte and to a lesser extent on the second last byte if it is ASCII.

           If the last byte is a UTF8 continuation byte, the second last byte can be:
             - continuation byte: the next byte is probably ASCII or lead byte (assuming
               4-byte UTF8 characters are rare) and the context id is 0 or 1.
             - lead byte (192 - 207): next byte is ASCII or lead byte, context is 0 or 1
             - lead byte (208 - 255): next byte is continuation byte, context is 2 or 3

           The possible value combinations of the previous two bytes, the range of
           context ids and the type of the next byte is summarized in the table below:

           |--------\-----------------------------------------------------------------|
           |         \                         Last byte                              |
           | Second   \---------------------------------------------------------------|
           | last byte \    ASCII            |   cont. byte        |   lead byte      |
           |            \   (0-127)          |   (128-191)         |   (192-)         |
           |=============|===================|=====================|==================|
           |  ASCII      | next: ASCII/lead  |  not valid          |  next: cont.     |
           |  (0-127)    | context: 4 - 63   |                     |  context: 2 - 3  |
           |-------------|-------------------|---------------------|------------------|
           |  cont. byte | next: ASCII/lead  |  next: ASCII/lead   |  next: cont.     |
           |  (128-191)  | context: 4 - 63   |  context: 0 - 1     |  context: 2 - 3  |
           |-------------|-------------------|---------------------|------------------|
           |  lead byte  | not valid         |  next: ASCII/lead   |  not valid       |
           |  (192-207)  |                   |  context: 0 - 1     |                  |
           |-------------|-------------------|---------------------|------------------|
           |  lead byte  | not valid         |  next: cont.        |  not valid       |
           |  (208-)     |                   |  context: 2 - 3     |                  |
           |-------------|-------------------|---------------------|------------------|
        */
        private static readonly byte[] kUTF8ContextLookup = {
            /* Last byte. */
            /* */
            /* ASCII range. */
            0,  0,  0,  0,  0,  0,  0,  0,  0,  4,  4,  0,  0,  4,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
            8, 12, 16, 12, 12, 20, 12, 16, 24, 28, 12, 12, 32, 12, 36, 12,
            44, 44, 44, 44, 44, 44, 44, 44, 44, 44, 32, 32, 24, 40, 28, 12,
            12, 48, 52, 52, 52, 48, 52, 52, 52, 48, 52, 52, 52, 52, 52, 48,
            52, 52, 52, 52, 52, 48, 52, 52, 52, 52, 52, 24, 12, 28, 12, 12,
            12, 56, 60, 60, 60, 56, 60, 60, 60, 56, 60, 60, 60, 60, 60, 56,
            60, 60, 60, 60, 60, 56, 60, 60, 60, 60, 60, 24, 12, 28, 12,  0,
            /* UTF8 continuation byte range. */
            0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
            0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
            0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
            0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1,
            /* UTF8 lead byte range. */
            2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3,
            2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3,
            2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3,
            2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3, 2, 3,
            /* Second last byte. */
            /* */
            /* ASCII range. */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1,
            1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1,
            1, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
            3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 1, 1, 1, 1, 0,
            /* UTF8 continuation byte range. */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            /* UTF8 lead byte range. */
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
        };

        /* Context lookup table for small signed integers. */
        private static readonly byte[] kSigned3BitContextLookup = {
            0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
            3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
            3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
            3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
            6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7,
        };

        private enum ContextType
        {
            CONTEXT_LSB6 = 0,
            CONTEXT_MSB6 = 1,
            CONTEXT_UTF8 = 2,
            CONTEXT_SIGNED = 3
        }

        private static unsafe byte Context(byte p1, byte p2, ContextType mode)
        {
            switch (mode)
            {
                case ContextType.CONTEXT_LSB6:
                    return (byte)(p1 & 0x3f);
                case ContextType.CONTEXT_MSB6:
                    return (byte)(p1 >> 2);
                case ContextType.CONTEXT_UTF8:
                    return (byte)(kUTF8ContextLookup[p1] | kUTF8ContextLookup[p2 + 256]);
                case ContextType.CONTEXT_SIGNED:
                    return (byte)((kSigned3BitContextLookup[p1] << 3) +
                                  kSigned3BitContextLookup[p2]);
                default:
                    return 0;
            }
        }
    }
}