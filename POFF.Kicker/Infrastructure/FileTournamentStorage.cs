using POFF.Kicker.View.Model;
using System;
using System.IO;
using System.Xml.Serialization;

namespace POFF.Kicker.Infrastructure;

public class FileTournamentStorage : ITournamentStorage
{
    private readonly string _filename;

    public FileTournamentStorage(string filename = "Tournament.xml")
    {
        _filename = filename;
    }

    public Tournament Load()
    {
        if (File.Exists(_filename))
        {
            using var reader = new StreamReader(_filename);
            var serializer = new XmlSerializer(typeof(TournamentFile));
            var file = (TournamentFile)serializer.Deserialize(reader);
            reader.Close();
            return new Tournament(file.Teams);
        }
        return new Tournament();
    }

    public void Save(Tournament tournament)
    {
        throw new NotImplementedException();
    }

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