using System.IO;
using UnityEditor;

public class PresetType : CreatorProfile
{
    [MenuItem("Assets/Create/ComprehensiveParallax/PresetType", priority = 20)]
    public static void CreateMenu()
    {
        FileCreator.GenerateWindow<PresetType>();
    }

    public override void GenerateFile(string path, string scriptName)
    {
        using StreamWriter outfile = new StreamWriter(path);
        outfile.WriteLine("using Arcturus.Parallax;");
        outfile.WriteLine("using Arcturus.Parallax.Internal;");
        outfile.WriteLine("using UnityEngine;");
        outfile.WriteLine("");
        outfile.WriteLine($"public class {scriptName} : PresetBase");
        outfile.WriteLine("{");
        outfile.WriteLine($"    public {scriptName}(ParallaxConfig config) : base(config)");
        outfile.WriteLine("    {");
        outfile.WriteLine("        ");
        outfile.WriteLine("    }");
        outfile.WriteLine("");
        outfile.WriteLine("    public override void OperateParallax(Camera cam, Vector2 previousCamPos)");
        outfile.WriteLine("    {");
        outfile.WriteLine("        ");
        outfile.WriteLine("    }");
        outfile.WriteLine("}");
    }
}