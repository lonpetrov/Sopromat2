using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantityTypes;

namespace Sopromat2.Data
{
    public class Beam
    {

        public Beam()
        {

        }

        public Beam(double length, double distload, double normstress, double deflec, Shape sec, Material mat)
        {
            Length = length * Length.Metre;
            DistLoad = distload * Stiffness.NewtonPerMetre;
            NormalStress = normstress * Pressure.Megapascal;
            Deflection = deflec * Length.Millimetre;
            Section = sec;
            Material = mat;
        }

        public Length Length { get; set; }

        public Length Deflection { get; set; }

        public Stiffness DistLoad { get; set; }

        public Pressure NormalStress { get; set; }

        public Shape Section { get; set; }

        public Material Material { get; set; }



    }
}
