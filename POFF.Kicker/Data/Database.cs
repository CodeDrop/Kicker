using System;
using System.Xml.Serialization;

namespace POFF.Kicker.Data;


internal class Database
{

    public static object Load(Type @type)
    {
        if (!System.IO.File.Exists(GetDataFileName(type)))
            return null;

        var reader = new System.IO.StreamReader(GetDataFileName(type));

        try
        {
            var objectGenerator = new XmlSerializer(type);
            return objectGenerator.Deserialize(reader);
        }
        finally
        {
            reader.Close();
        }
    }

    public static void Save(Type @type, object data)
    {
        var writer = new System.IO.StreamWriter(GetDataFileName(type), false);

        try
        {
            var xmlGenerator = new XmlSerializer(type);
            xmlGenerator.Serialize(writer, data);
        }
        finally
        {
            writer.Close();
        }
    }

    private static string GetDataFileName(Type @type)
    {
        return string.Format(@".\{0}.xml", type.Name);
    }

}