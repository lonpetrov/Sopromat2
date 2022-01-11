using QuantityTypes;
using System;
using GalaSoft.MvvmLight;

namespace Sopromat2.Data
{
    [Serializable]
    public class Shape : ViewModelBase
    {

        public Shape()
        {

        }

        public Shape(string name, string number, double firstMOF,
                    double secondMOFX, double secondMOFY, 
                    double sectionModX, double sectionModY)
        {
            Name = name;
            Number = number;

            FirstMomentOfInertia = firstMOF*FirstMomentOfArea.MetreCubed;

            SecondMomentOfInertiaX = secondMOFX*SecondMomentOfArea.CentimetreToTheFourth;
            SecondMomentOfInertiaY = secondMOFY*SecondMomentOfArea.CentimetreToTheFourth;
            //SecondMomentOfInertiaZero = secondMOFZero*SecondMomentOfArea.CentimetreToTheFourth;
            SectionModulusX = sectionModX*SectionModulus.MetreCubed;
            SectionModulusY = sectionModY*SectionModulus.MetreCubed;
            //IsRotatedToNinetyDegrees = IsRotate90;
            //IsRotatedToFourtyFiveDegrees = IsRotate45;
            Rotation = false;
        }



        public string FullName
        {
            get { return Name + " " + Number; }

        }
        public string Name { get; set; }

        public string Number { get; set; }

        private bool rotation;

        public bool Rotation 
        {
            get 
            {
                return rotation;
            }
            set 
            {               
                rotation = value;

                RaisePropertyChanged(nameof(Rotation));
                RaisePropertyChanged(nameof(InformationAboutSection));
            }
        }

        public FirstMomentOfArea FirstMomentOfInertia { get; set; }//Статический момент инерции

        public SecondMomentOfArea SecondMomentOfInertiaX;

        public SecondMomentOfArea SecondMomentOfInertiaY;

        public SecondMomentOfArea SecondMomentOfInertia 
        {
            get
            {
                if (Rotation)
                {
                    return SecondMomentOfInertiaY;
                }
                else
                {
                    return SecondMomentOfInertiaX;
                }               
            }
            set
            {
                if (Rotation)
                {
                    SecondMomentOfInertiaY = value;
                }
                else
                {
                    SecondMomentOfInertiaX = value;
                }

                RaisePropertyChanged(nameof(SecondMomentOfInertia));
            }
        }

        //public SecondMomentOfArea SecondMomentOfInertiaZero { get; set; }//Момент Инерции 0 (для уголков под 45 градусов)

        private SectionModulus SectionModulusX;

        private SectionModulus SectionModulusY;

        public SectionModulus SectionModulus 
        {
            get
            {
                if (Rotation)
                {
                    return SectionModulusY;
                }
                else
                {
                    return SectionModulusX;
                }
            }
            set
            {
                if (Rotation)
                {
                    SectionModulusY = value;
                }
                else
                {
                    SectionModulusX = value;
                }

                RaisePropertyChanged(nameof(SectionModulus));
            }
        }//Момент сопротивления Y


        //public bool IsRotatedToFourtyFiveDegrees { get; set; } = false;//Повернуто ли сечение на 45

        private string informationAboutSection;

        public string InformationAboutSection
        {
            get
            {
                return "Момент инерции: " + SecondMomentOfInertia.ToString("0 [!cm^4]см⁴ ") + "\n" +
                       "Момент сопротивления: " + SectionModulus.ToString("0 [!m^3]м³ ");
            }
            set 
            {
                informationAboutSection = value;
                RaisePropertyChanged(nameof(InformationAboutSection));
            }
        }

    }
}
