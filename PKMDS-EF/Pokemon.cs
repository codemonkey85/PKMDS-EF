using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PKMDS
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, CharSet = CharSet.Unicode)]
    [Serializable]
    public class Pokemon
    {
        [FieldOffset(0x00)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 232)]
        [NotMapped]
        internal byte[] data;

        public Pokemon()
        {
            this.data = new byte[232];
        }

        public ushort species
        {
            get { return BitConverter.ToUInt16(data, 0x08); }
            set { Array.Copy(BitConverter.GetBytes(value), 0, data, 0x08, 2); }
        }

    }
}
