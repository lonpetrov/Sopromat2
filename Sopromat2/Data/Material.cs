using QuantityTypes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Sopromat2.Data
{
    [Serializable]
    public class Material
    {


        public Material()
        {

        }

        public Material(string name, string mark, double designstrenth, double youngsmodulus)
        {
            Name = name;
            Mark = mark;
            DesignStrength = designstrenth * Pressure.Megapascal;
            YoungsModulus = youngsmodulus * Pressure.Megapascal;

        }



        public string FullName
        {
            get { return Name + " " + Mark; }
            
        }


        public string Name { get; set; } = string.Empty;

        public string Mark { get; set; } = string.Empty;

        public Pressure DesignStrength { get; set; } = Pressure.Megapascal; //Расчетное напряжение

        public Pressure YoungsModulus { get; set; } = Pressure.Megapascal;//Модуль Юнга
        
        public string DesignStrengthStr
        {
            get
            {
                return DesignStrength.ToString("Расчетное напряжение: 0 [!Megapascal] МПа");
            }
 
        }
        public string YoungsModulusStr
        { 
            get
            {
                return YoungsModulus.ToString("Модуль Юнга: 0.###E+0 [!Pa]Па");
            }


        }


    }
}