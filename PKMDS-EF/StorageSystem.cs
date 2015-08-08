using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace PKMDS
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
    [Serializable]
    public class StorageSystem
    {
        public StorageSystem()
        {
            _boxes = new Box[31];
            for(int i = 0; i < _boxes.Length;i++)
            {
                _boxes[i] = new Box() { BoxId = i + 1, Name = string.Format("Box {0}", i + 1) };
            }
        }
        private Box[] _boxes { get; set; }
        [NotMapped]
        public List<Box> Boxes
        {
            get
            {
                return _boxes.ToList();
            }
            set
            {
                if (value.Count > 31)
                {
                    throw new Exception("");
                }
                Array.Copy(value.ToArray(), 0, _boxes, 0, value.Count);
            }
        }
        public Box this[int i]
        {
            get
            {
                return _boxes[i];
            }
            set
            {
                _boxes[i] = value;
            }
        }

    }
}
