using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xlsxGenerator.Classes
{
    [Serializable]
    public class Praktikum : IComparable<Praktikum>
    {
        String praktikumName;
        List<String> praktikan;
        List<String> kriteria;

        public Praktikum(String praktikumName, List<String> praktikan, List<String> kriteria)
        {
            Praktikan = new List<String>();
            Kriteria = new List<String>();
            this.PraktikumName = praktikumName;
            foreach (String item in praktikan)
            {
                Praktikan.Add(item);
            }
            foreach (String item in kriteria)
            {
                Kriteria.Add(item);
            }
        }

        public string PraktikumName
        {
            get
            {
                return praktikumName;
            }

            set
            {
                praktikumName = value;
            }
        }

        public List<String> Praktikan
        {
            get
            {
                return praktikan;
            }

            set
            {
                praktikan = value;
            }
        }

        public List<String> Kriteria
        {
            get
            {
                return kriteria;
            }

            set
            {
                kriteria = value;
            }
        }

        public int CompareTo(Praktikum obj)
        {
            return this.praktikumName.CompareTo(obj.praktikumName);
        }
    }
}
