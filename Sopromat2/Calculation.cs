using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopromat2.Data;
using QuantityTypes;

namespace Sopromat2
{
    static class Calculation
    {

        //public Beam Beam { get; set; }

        static public double CalcNormalStress(Beam beam)
        {
            double NormalStress = ((beam.DistLoad.Value * Math.Pow(beam.Length.Value,2)  ) / (8 * beam.Section.SectionModulus.Value ));
            return NormalStress;
        }

        static public double CalcDeflection(Beam beam)
        {
            double Deflection = ((beam.DistLoad.Value * Math.Pow(beam.Length.Value, 4)*5) / (beam.Material.YoungsModulus.Value*beam.Section.SecondMomentOfInertia.Value * 384))*1000;
            return Deflection;
        }


    }
}
