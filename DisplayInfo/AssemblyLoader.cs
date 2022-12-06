using DisplayInfo.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DisplayInfo
{
    public class AssemblyLoader
    {
        public static AssemblyBrowser Load(string pathToAssembly)
        {
            var assembly = System.Reflection.Assembly.LoadFrom(pathToAssembly);
            var exportedNamespaces = new Dictionary<string, ExportedNsInfo>();
            var exportedNsTypes = new List<ExportedTypeInfo>();
            foreach (var exportedType in assembly.ExportedTypes)
            {
                /*                var fields = GetTypeFields(exportedType);*/
                var properties = GetTypeProperties(exportedType);
                var methods = GetTypeMethods(exportedType);

                if (exportedNamespaces.ContainsKey(exportedType.Namespace))
                {
                    exportedNamespaces[exportedType.Namespace].Types.Add(
                        new ExportedTypeInfo(
                            exportedType.FullName,
                            exportedType.Attributes.ToString(),
                            /*                            fields,*/
                            properties,
                            methods
                            )
                        );
                }
                else
                {
                    exportedNamespaces.Add(
                        exportedType.Namespace,
                        new ExportedNsInfo(
                            exportedType.Namespace,
                            new List<ExportedTypeInfo> {
                                new ExportedTypeInfo(
                                    exportedType.FullName,
                                    exportedType.Attributes.ToString(),/*
                                    fields,*/
                                    properties,
                                    methods
                                    )
                                }
                            )
                        );
                }
            }

            return new AssemblyBrowser(assembly.FullName, exportedNamespaces);
        }



        /* private static List<Field> GetTypeFields(Type exportedType)
         {
             var fields = new List<Field>();
             string name;
             string type;
             string attributes;
             foreach (var field in exportedType.GetRuntimeFields())
             {
                 name = field.Name;
                 attributes = field.Attributes.ToString();
                 type = field.FieldType.Name;
                 fields.Add(new Field(name, attributes, type));
             }

             return fields;
         }*/




        private static List<Property> GetTypeProperties(Type exportedType)
        {
            var properties = new List<Property>();
            string name;
            string setMethod;
            string getMethod;
            foreach (var property in exportedType.GetRuntimeProperties())
            {
                name = property.Name;
                setMethod = property.SetMethod != null ? property.SetMethod.ToString() : null;
                getMethod = property.GetMethod != null ? property.GetMethod.ToString() : null;
                properties.Add(new Property(name, setMethod, getMethod));
            }

            return properties;
        }


        private static List<Method> GetTypeMethods(Type exportedType)
        {
            var methods = new List<Method>();
            string name;
            string attributes;
            string returnType;
            string[] parameters;
            foreach (var method in exportedType.GetRuntimeMethods())
            {
                name = method.Name;
                var attrs = method.Attributes;
                string attrsStr = "";
                if (attrs.HasFlag(MethodAttributes.Public))
                    attrsStr += "public ";
                else
                {
                    if (attrs.HasFlag(MethodAttributes.Private))
                        attrsStr += "private ";
                    else
                        attrsStr += "protected ";
                }
                if (attrs.HasFlag(MethodAttributes.Static))
                    attrsStr += "static ";
                if (attrs.HasFlag(MethodAttributes.Virtual))
                {
                    if (attrs.HasFlag(MethodAttributes.Abstract))
                        attrsStr += "abstract ";
                    else
                        attrsStr += "virtual ";
                }

                attributes = attrsStr;
                returnType = method.ReturnType.Name;
                parameters = method.GetParameters().Select(parameter => "" + parameter.ParameterType.Name.ToString() + " " + parameter.Name).ToArray();
                methods.Add(new Method(attributes, returnType, name, parameters));
            }

            return methods;
        }
    }
}
