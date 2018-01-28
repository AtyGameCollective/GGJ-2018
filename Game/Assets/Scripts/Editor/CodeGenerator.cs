using UnityEngine;
using System.IO;
using CodeGeneration;
using UnityEditor;
using System;
using System.Linq;

namespace AssemblyCSharpEditor
{
    /// <summary>
    /// A helper class for code generation in the editor.
    /// </summary>
    public class CodeGenerator
    {
        [MenuItem("Code Generation/Generate Tags")]
        public static void GenerateTags()
        {
            Generate("Tags", UnityEditorInternal.InternalEditorUtility.tags);
        }

        [MenuItem("Code Generation/Generate Layers")]
        public static void GenerateLayers()
        {
            Generate("Layers", UnityEditorInternal.InternalEditorUtility.layers);
        }

        public static void Generate(string name, string[] data)
        {
            // Build the generator with the class name and data source.
            StringItemsGenerator generator = new StringItemsGenerator(name, data);

            // Generate output (class definition).
            var classDefintion = generator.TransformText();

            var outputPath = Path.Combine(Application.dataPath + "/Scripts/AUTO_GEN/", name + ".cs");

            try
            {
                // Save new class to assets folder.
                File.WriteAllText(outputPath, classDefintion);

                // Refresh assets.
                AssetDatabase.Refresh();

                Debug.Log("File Generated: " + name + ".cs");
            }
            catch (Exception e)
            {
                Debug.Log("An error occurred while saving file: " + e);
            }
        }
    }
}