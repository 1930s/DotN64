﻿namespace N64Emu.CPU
{
    public partial class VR4300
    {
        public partial class Coprocessor0
        {
            public class ConfigRegister : Register
            {
                #region Fields
                private const int K0Shift = 0, K0Size = (1 << 3) - 1;
                private const int CUShift = 3, CUSize = (1 << 1) - 1;
                private const int BEShift = 15, BESize = (1 << 1) - 1;
                private const int EPShift = 24, EPSize = (1 << 4) - 1;
                private const int ECShift = 28, ECSize = (1 << 3) - 1;
                #endregion

                #region Properties
                protected override RegisterIndex Index => RegisterIndex.Config;

                /// <summary>
                /// Sets coherency algorithm of kseg0.
                /// </summary>
                public CoherencyAlgorithm K0
                {
                    get => (CoherencyAlgorithm)GetValue(K0Shift, K0Size);
                    set => SetValue(K0Shift, K0Size, (ulong)value);
                }

                /// <summary>
                /// RFU. However, can be read or written by software.
                /// </summary>
                public bool CU
                {
                    get => GetBoolean(CUShift, CUSize);
                    set => SetValue(CUShift, CUSize, value);
                }

                /// <summary>
                /// Sets BigEndianMem (endianness).
                /// </summary>
                public Endianness BE
                {
                    get => (Endianness)GetValue(BEShift, BESize);
                    set => SetValue(BEShift, BESize, (ulong)value);
                }

                /// <summary>
                /// Sets transfer data pattern (single/block write request).
                /// </summary>
                public TransferDataPattern EP
                {
                    get => (TransferDataPattern)GetValue(EPShift, EPSize);
                    set => SetValue(EPShift, EPSize, (ulong)value);
                }

                /// <summary>
                /// Operating frequency ratio (read-only). The value displayed corresponds to the frequency ratio set by the DivMode pins on power application.
                /// </summary>
                public byte EC
                {
                    get => (byte)GetValue(ECShift, ECSize);
                    set => SetValue(ECShift, ECSize, value);
                }
                #endregion

                #region Constructors
                public ConfigRegister(Coprocessor0 cp0)
                    : base(cp0)
                {
                    SetValue(4, (1 << 11) - 1, 0b11001000110);
                    SetValue(16, (1 << 8) - 1, 0b00000110);
                    SetValue(31, (1 << 1) - 1, 0);
                }
                #endregion

                #region Enumerations
                public enum CoherencyAlgorithm : byte
                {
                    CacheUnused = 0b010
                }

                public enum Endianness : byte
                {
                    LittleEndian,
                    BigEndian
                }

                public enum TransferDataPattern : byte
                {
                    D = 0,
                    DxxDxx = 6
                }
                #endregion
            }
        }
    }
}
