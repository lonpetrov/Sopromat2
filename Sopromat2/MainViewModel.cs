using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sopromat2.Data;
using QuantityTypes;
using System.Diagnostics;
using System.Windows;

namespace Sopromat2
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Material = new ObservableCollection<Material>()
            {
                new Material(){ Name="Сталь", YoungsModulus=210000*Pressure.Megapascal, DesignStrength=240*Pressure.Megapascal, Mark = "C245" },
                new Material(){ Name="Алюминий", YoungsModulus=70000*Pressure.Megapascal, DesignStrength=70*Pressure.Megapascal },
                new Material(){ Name="Дерево", YoungsModulus=10000*Pressure.Megapascal, DesignStrength=13*Pressure.Megapascal }
            };

            Shape = new ObservableCollection<Shape>()
            {
                new Shape("Швеллер","24П", 139, 2910, 248, 193, 39.5 ),
                new Shape("Швеллер","27П", 178, 4180, 310, 314, 46.7 ),
            };

            LenghtType = new ObservableCollection<string>()
            {
                 "м",
                "см",
                "мм"

            };

            DistLoanType = new ObservableCollection<string>()
            {
                "Н/м",
                "кг/м",
                "т/м"

            };

            //нужно будет потом изменить

            //if (IsUserSecSeleted)
            //{
            //    IsShapeSelectionVisible = "Collapsed";
            //    IsUserSelectionVisible = "Visible";
            //}
            //else
            //{
            //    IsShapeSelectionVisible = "Visible";
            //    IsUserSelectionVisible = "Collapsed";
            //}

            turnSec = new RelayCommand(DoTurnSec);
            calculate = new RelayCommand(DoCalculate);

            
            
        }


        #region Выбор материала

        private ObservableCollection<Material> material = new ObservableCollection<Material>();
        public ObservableCollection<Material> Material
        {
            get
            {
                return material;
            }
            set
            {
                material = value;

                SelectedMaterial = material.FirstOrDefault();

                RaisePropertyChanged(nameof(Material));
            }
        }
        private Material selectedMaterial = null;
        public Material SelectedMaterial
        {
            get
            {
                return selectedMaterial;
            }
            set
            {
                selectedMaterial = value;
                RaisePropertyChanged(nameof(SelectedMaterial));
            }
        }
        #endregion

        #region Выбор типа Сечения (Сортамент)

        private ObservableCollection<Shape> shape = new ObservableCollection<Shape>();
        public ObservableCollection<Shape> Shape
        {
            get
            {
                return shape;
            }
            set
            {
                shape = value;
                SelectedShape = shape.FirstOrDefault();
                RaisePropertyChanged(nameof(Shape));
            }
        }

        private Shape selectedShape = null;
        public Shape SelectedShape
        {
            get
            {
                return selectedShape;
            }
            set
            {
                selectedShape = value;
                RaisePropertyChanged(nameof(SelectedMaterial));
            }
        }


        #endregion

        #region Выбор типа длины
        private ObservableCollection<string> lenghtType = new ObservableCollection<string>();
        public ObservableCollection<string> LenghtType
        {
            get
            {
                return lenghtType;
            }
            set
            {
                lenghtType = value;

                FirstLenghtType = lenghtType.FirstOrDefault();

                RaisePropertyChanged(nameof(LenghtType));
            }
        }
        private string firstLenghtType;
        public string FirstLenghtType
        {
            get
            {
                return firstLenghtType;
            }
            set
            {
                firstLenghtType = value;
                RaisePropertyChanged(nameof(FirstLenghtType));
            }
        }
        #endregion

        #region Выбор типа распределенной силы

        private ObservableCollection<string> distLoanType = new ObservableCollection<string>();
        public ObservableCollection<string> DistLoanType
        {
            get
            {
                return distLoanType;
            }
            set
            {
                distLoanType = value;

                FirstDistLoanType = distLoanType.FirstOrDefault();

                RaisePropertyChanged(nameof(DistLoanType));
            }
        }
        private string firstDistLoanType;
        public string FirstDistLoanType
        {
            get
            {
                return firstDistLoanType;
            }
            set
            {
                firstDistLoanType = value;
                RaisePropertyChanged(nameof(FirstDistLoanType));
            }
        }
        #endregion

        #region Получение значений

        public double distLoad;
        public double DistLoad
        {
            get
            {
                

               
                    return distLoad;
                

               
            }

            set
            {

                distLoad = value;
                
                RaisePropertyChanged(nameof(FirstDistLoanType));
                RaisePropertyChanged(nameof(DistLoad));
            }
        }

        private double lenght;
        public double Lenght
        {
            get
            {
               
                    return lenght;
                
                
            }
            set
            {
                lenght = value;

                //RaisePropertyChanged(nameof(FirstLenghtType));
                RaisePropertyChanged(nameof(Lenght));
            }

        }


        private string isShapeSelectionVisible;

        public string IsShapeSelectionVisible
        {
            get
            {
                return isShapeSelectionVisible;
            }
            set
            {
                isShapeSelectionVisible = value;
                RaisePropertyChanged(nameof(IsShapeSelectionVisible));
            }
        }

        private string isUserSelectionVisible;

        public string IsUserSelectionVisible
        {
            get
            {
                return isUserSelectionVisible;
            }
            set
            {
                isUserSelectionVisible = value;
                RaisePropertyChanged(nameof(IsUserSelectionVisible));
            }
        }


        #endregion

       

        private bool isSecTurned = false;
        public bool IsSecTurned
        { 
            get => isSecTurned;
            set
            {

                isSecTurned = value;
                RaisePropertyChanged(nameof(IsSecTurned));
            }

        }




        #region Команды
        private RelayCommand turnSec;
        public RelayCommand TurnSec
        {
            get { return turnSec; }
            //set { turnSec = value; }
        }
        private void DoTurnSec()
        {
            IsSecTurned = !IsSecTurned;

            if (!IsSecTurned)
            {
                foreach (Shape i in Shape)
                    i.Rotation = false;
            }
            else
            {
                foreach (Shape i in Shape)
                    i.Rotation = true;
            }      

        }


        private RelayCommand calculate;         
        public RelayCommand Calculate
        {
            get 
            { 
                return calculate; 
            }
            set 
            { 
                calculate = value; 
            }
        }

        private void DoCalculate()
        {

            double chngdLength;
            double chngdDisLoad;

            if (FirstLenghtType == "см")
            {
               chngdLength = Lenght / 100;
            }
            else if (FirstLenghtType == "мм")
            {
                chngdLength = Lenght / 1000;
            }
            else
            {
                chngdLength = Lenght;
            }

            if (FirstDistLoanType == "кг/м")
            {
                chngdDisLoad =  DistLoad *10;
            }
            else if (FirstDistLoanType == "т/м")
            {
                chngdDisLoad = DistLoad *10000;
            }
            else
            {
                chngdDisLoad =  DistLoad;
            }



            Beam beam = new Beam
            {
                Length = chngdLength * Length.Metre,
                DistLoad = chngdDisLoad * Stiffness.NewtonPerMetre,
                Section = SelectedShape,
                Material = SelectedMaterial
            };

            beam.Deflection = Calculation.CalcDeflection(beam)*Length.Millimetre;
            deflection = beam.Deflection;
            beam.NormalStress = Calculation.CalcNormalStress(beam)*Pressure.Megapascal;
            nrmStress = beam.NormalStress;
            RaisePropertyChanged(nameof(Deflection));
            RaisePropertyChanged(nameof(NrmStress));


        }

        private Length deflection;

        public Length Deflection
        {
            get 
            {
                return deflection;

            }
            //set 
            //{ 
            //    deflection = value;
            //}
        }

        private Pressure nrmStress;

        public Pressure NrmStress
        {
            get
            {
                return nrmStress;
            }
            //set 
            //{ 
            //    nrmStress = value;
            //}
        }





        #endregion

    }
}
