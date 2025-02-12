using System;
using System.Collections.Generic; 
using System.IO;
using System.Xml.Serialization;

namespace MechanicsMaterials
{
    /// <summary>
    /// Class that centralizes the material data.
    /// Loads and saves data in the MaterialsDB.xml file.
    /// </summary>
    [XmlRoot("MaterialDatabase")]
    public class MaterialDatabase
    {
        // Campos estáticos para armazenar o diretório base e o caminho completo do XML.
        private static readonly string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string XmlFilePath = Path.Combine(baseDirectory, "MaterialsDB.xml");

        /// <summary>
        /// Material list stored in the Database.
        /// Each material is represented by the Material class.
        /// </summary>
        [XmlElement("Material")]
        public List<MechanicsMaterials.Material> Materials { get; set; } = new List<MechanicsMaterials.Material>();

        /// <summary>
        /// Loads the material data from the XML.
        /// </summary>
        /// <param name="filePath">Path of the XML file.</param>
        /// <returns>Instance of MaterialDatabase with loaded materials.</returns>
        public static MaterialDatabase LoadFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MaterialDatabase));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (MaterialDatabase)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Saves the material data to an XML file.
        /// </summary>
        /// <param name="filePath">Path of the file where data will be saved.</param>
        public void SaveToXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MaterialDatabase));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, this);
            }
        }

        /// <summary>
        /// Returns a material by name, ignoring case differences.
        /// </summary>
        /// <param name="name">Name of the material to search for.</param>
        /// <returns>Corresponding Material or null if not found.</returns>
        public Material GetMaterialByName(string name)
        {
            return Materials.Find(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
