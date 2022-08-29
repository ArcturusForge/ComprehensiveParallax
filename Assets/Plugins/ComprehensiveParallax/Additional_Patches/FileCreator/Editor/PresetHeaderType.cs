using System.IO;
using UnityEditor;

public class PresetHeaderType : CreatorProfile
{
    [MenuItem("Assets/Create/ComprehensiveParallax/PresetHeaderType", priority = 20)]
    public static void CreateMenu()
    {
        FileCreator.GenerateWindow<PresetHeaderType>();
    }

    public override void GenerateFile(string path, string scriptName)
    {
        using StreamWriter outfile = new StreamWriter(path);
        outfile.WriteLine("using Arcturus.Parallax;");
        outfile.WriteLine("using Arcturus.Parallax.Internal;");
        outfile.WriteLine("");
        outfile.WriteLine($"public class {scriptName} : PresetHeaderBase");
        outfile.WriteLine("{");
        outfile.WriteLine("    // Please ensure your preset inherits from the \"PresetBase\" class before trying to use it.");
        outfile.WriteLine("    public override PresetBase GeneratePresetClass(ParallaxConfig config)");
        outfile.WriteLine("    {");
        outfile.WriteLine("        return null;");
        outfile.WriteLine("    }");
        outfile.WriteLine("");
        outfile.WriteLine("    // Returns the preset name that is displayed as a selectable option in the inspector.");
        outfile.WriteLine("    public override string GetPresetName()");
        outfile.WriteLine("    {");
        outfile.WriteLine("        return \"\";");
        outfile.WriteLine("    }");
        outfile.WriteLine("}");
    }
}