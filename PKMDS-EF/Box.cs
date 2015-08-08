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
    public class Box
    {
        public Box()
        {
            _pokemon = new Pokemon[30];
            for (int i = 0; i < _pokemon.Length; i++)
            {
                _pokemon[i] = new Pokemon();
            }
        }
        public int BoxId { get; set; }
        public string Name { get; set; }
        private Pokemon[] _pokemon { get; set; }
        [NotMapped]
        public List<Pokemon> Pokemon
        {
            get
            {
                return _pokemon.ToList();
            }
            set
            {
                if (value.Count > 30)
                {
                    throw new Exception("");
                }
                Array.Copy(value.ToArray(), 0, _pokemon, 0, value.Count);
            }
        }
        public Pokemon this[int i]
        {
            get
            {
                return _pokemon[i];
            }
            set
            {
                _pokemon[i] = value;
            }
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
