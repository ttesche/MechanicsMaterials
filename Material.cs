using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MechanicsMaterials
{

    /// <summary>
    /// THIS SECTION IMPLEMENTS THE MATERIAL CLASS
    /// YOUNG'S MODULUS
    /// POSSION'S RATIO
    /// SHEAR MODLUS
    /// YIELD STRENGTH
    /// TENSILE STRENGTH
    /// </summary>
    /// 
    internal class Material
    {
        /// <summary>
        /// Name or id of the material (ex.: ASTM A36, SAE 1020)
        /// </summary>
        /// 
        [XmlElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Young's Modulus, in Pascal (Pa)
        /// </summary>
        /// 
        [XmlElement("YoungModulus")]
        public double YoungModulus { get; set; }

        /// <summary>
        ///  PoissonRatio Unitless
        /// </summary>
        /// 
        [XmlElement("PoissonRatio")]
        public double PoissonRatio { get; set; }

        /// <summary>
        /// Yield Strength Pascal (Pa).
        /// </summary>
        /// 
        [XmlElement("YieldStrength")]
        public double YieldStrength { get; set; }

        /// <summary>
        /// Tensile Strength Pascal (Pa).
        /// </summary>
        [XmlElement("TensileStrength")]
        public double TensileStrength { get; set; }

        /// <summary>
        /// Módulo de Cisalhamento (Shear Modulus), calculado a partir de YoungModulus e PoissonRatio.
        /// Não é serializado, pois é um valor derivado.
        /// </summary>
        /// 
        [XmlIgnore]
        public double ShearModulus => YoungModulus / (2 * (1 + PoissonRatio));


    }
}
