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
    public class StorageSystem
    {
        public StorageSystem()
        {
            _boxes = new Box[31];
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
