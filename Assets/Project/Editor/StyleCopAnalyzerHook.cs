using SyntaxTree.VisualStudio.Unity.Bridge;
using System.IO;
using System.Text;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class StyleCopAnalyzerHook : MonoBehaviour
{

    class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }

    static StyleCopAnalyzerHook()
    {
        ProjectFilesGenerator.ProjectFileGeneration += (string name, string content) =>
        {
            var document = XDocument.Parse(content);
            var x = new XElement("ItemGroup",
             new XElement("Analyzer", new XAttribute("Include", "packages\\StyleCop.Analyzers.1.0.0\\analyzers\\dotnet\\cs\\StyleCop.Analyzers.CodeFixes.dll")),
             new XElement("Analyzer", new XAttribute("Include", "packages\\StyleCop.Analyzers.1.0.0\\analyzers\\dotnet\\cs\\StyleCop.Analyzers.dll"))
             );


            Debug.Log("[Hook]" + name + " " + document);

            XElement projectNode = FindElement(document, "Project");
            if (projectNode == null)
            {
                Debug.LogError("Could not find project node");
            }

            XElement includeNode = FindElement(projectNode, "Import");
            if (includeNode == null)
            {
                Debug.LogError("Could not find import node");
            }

            includeNode.AddBeforeSelf(x);
            // Prevents the save adding a xmlns attribute by inheriting the namespace (xmlns) of the parent, removing the need for it in the child
            x.Attributes("xmlns").Remove();
            x.Name = x.Parent.Name.Namespace + x.Name.LocalName;

            var str = new Utf8StringWriter();
            document.Save(str);

            return str.ToString();
        };
    }

    private static XElement FindElement(XContainer root, string searchString)
    {
        foreach (XElement ele in root.Elements())
        {
            if (ele.Name.ToString().Contains(searchString))
            {
                return ele;
            }
        }

        return null;
    }
}
