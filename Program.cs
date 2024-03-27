using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adapter
{    
        public class Program
        {
            public static void Main(string[] args)
            {
                
                Compound unknown = new Compound();
                unknown.Display();
                
                Compound Kalium = new RichCompound("Kalium");
                Kalium.Display();
                Compound Natrium = new RichCompound("Natrium");
                Natrium.Display();
                Compound Lithium = new RichCompound("Lithium");
                Lithium.Display();
                
                Console.ReadKey();
            }
        }
        
        public class Compound
        {
            protected float boilingPoint;
            protected float meltingPoint;
            protected string molecularFormula;
            public virtual void Display()
            {
                Console.WriteLine("\nCompound: Unknown ------ ");
            }
        }
       
        public class RichCompound : Compound
        {
            private string chemical;
            private ChemicalDatabank bank;
            
            public RichCompound(string chemical)
            {
                this.chemical = chemical;
            }
            public override void Display()
            {
                
                bank = new ChemicalDatabank();
                boilingPoint = bank.GetCriticalPoint(chemical, "B");
                meltingPoint = bank.GetCriticalPoint(chemical, "M");
                molecularFormula = bank.GetMolecularStructure(chemical);
                Console.WriteLine("\nCompound: {0} ------ ", chemical);
                Console.WriteLine(" Formula: {0}", molecularFormula);
                Console.WriteLine(" Melting Pt: {0}", meltingPoint);
                Console.WriteLine(" Boiling Pt: {0}", boilingPoint);
            }
        }
        
        public class ChemicalDatabank
        {
           
            public float GetCriticalPoint(string compound, string point)
            {
       
                if (point == "M")
                {
                    switch (compound.ToLower())
                    {
                        case "kalium": return 63.7f;
                        case "natrium": return 97.8f;
                        case "lithium": return 180.5f;
                        default: return 0f;
                    }
                }
              
                else
                {
                    switch (compound.ToLower())
                    {
                        case "kalium": return 774.0f;
                        case "natrium": return 892.0f;
                        case "lithium": return 1341.85f;
                        default: return 0f;
                    }
                }
            }
            public string GetMolecularStructure(string compound)
            {
                switch (compound.ToLower())
                {
                    case "kalium": return "K";
                    case "benzene": return "Na";
                    case "lithium": return "Li";
                    default: return "";
                }
            }
        }
    }

