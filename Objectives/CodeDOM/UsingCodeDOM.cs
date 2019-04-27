using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CSharp;

namespace UsingCodeDOM
{
    public static class GenerateCode
    {
        public static void GenerateHelloWorld()
        {
            var compileUnit = new CodeCompileUnit();
            var myNamespace = new CodeNamespace("MyNamespace");
            var myClass = new CodeTypeDeclaration("MyClass");
            var start = new CodeEntryPointMethod();

            var cs1 = new CodeMethodInvokeExpression
            (
                new CodeTypeReferenceExpression("Console"),
                "WriteLine",
                new CodePrimitiveExpression("Hello World!")
            );

            myNamespace.Imports.Add(new CodeNamespaceImport("System"));

            compileUnit.Namespaces.Add(myNamespace);
            myNamespace.Types.Add(myClass);
            myClass.Members.Add(start);
            start.Statements.Add(cs1);

            SaveCode(compileUnit);
        }

        private static void SaveCode(CodeCompileUnit compileUnit)
        {
            var provider = new CSharpCodeProvider();
            using (var sw = new StreamWriter("HelloWorld.cs", false))
            {
                var tw = new IndentedTextWriter(sw, " ");
                provider.GenerateCodeFromCompileUnit(compileUnit, tw, new CodeGeneratorOptions());
                tw.Close();
            }
        }
    }
}