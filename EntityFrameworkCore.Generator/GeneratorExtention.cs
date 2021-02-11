using System.IO;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Quantumart.QP8.EntityFrameworkCore.Generator
{
    public static class GeneratorExtention
    {
        public static GeneratorExecutionContext AddEmbeddedResource(this GeneratorExecutionContext context, string path, string name = null)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var resourcePath = $"{assembly.GetName().Name}.{path}";
            
            using var resource = assembly.GetManifestResourceStream(resourcePath);

            if (resource == null)
                throw new FileNotFoundException($"Could not find EmbeddedResource in path \"{path}\"");
                    
            using var reader = new StreamReader(resource);
            var content = reader.ReadToEnd();
            
            context.AddSource(name ?? path, SourceText.From(content, Encoding.UTF8));

            return context;
        }
    }
}