using System;
using GameDatabase.CodeGeneration.Settings;
using UnityEngine;
using UnityEngine.Assertions;

namespace GameDatabase.CodeGeneration
{
    public class CodeBuilder
    {
        public CodeBuilder(
            DatabaseSchema schema, 
            CodeWriter writer,
            IEnumCodeGenerator enumCodeGenerator,
            IDatabaseCodeGenerator databaseCodeGenerator,
            IObjectCodeGenerator objectCodeGenerator)
        {
            Assert.IsNotNull(schema);
            Assert.IsNotNull(writer);

            _schema = schema;
            _codeWriter = writer;
            Settings = new GeneratorSettings();
            DatabaseCodeGenerator = databaseCodeGenerator;
            EnumCodeGenerator = enumCodeGenerator;
            ObjectCodeGenerator = objectCodeGenerator;
        }

        public GeneratorSettings Settings { get; }
        public IDatabaseCodeGenerator DatabaseCodeGenerator { get; }
        public IEnumCodeGenerator EnumCodeGenerator { get; }
        public IObjectCodeGenerator ObjectCodeGenerator { get; }

        public void Build()
        {
            GenerateCode();
            Debug.Log("Done!");
        }

        private void GenerateCode()
        {
            try
            {
                _codeWriter.DeleteGeneratedFiles();

                foreach (var item in _schema.Enums)
                    EnumCodeGenerator.Generate(item, Settings);
                foreach (var item in _schema.Structs)
                {
                    if (string.IsNullOrEmpty(item.switchEnum))
                        ObjectCodeGenerator.Generate(item, ObjectType.SimpleStruct, Settings);
                    else
                        ObjectCodeGenerator.Generate(item, ObjectType.MutableStruct, Settings);
                }
                foreach (var item in _schema.Configurations)
                {
                    ObjectCodeGenerator.Generate(item, ObjectType.SimpleObject, Settings);
                    DatabaseCodeGenerator.AddConfiguration(item.name, item.typeid);
                }

                foreach (var item in _schema.Objects)
                {
                    if (string.IsNullOrEmpty(item.switchEnum))
                        ObjectCodeGenerator.Generate(item, ObjectType.SimpleObject, Settings);
                    else
                        ObjectCodeGenerator.Generate(item, ObjectType.MutableObject, Settings);

                    DatabaseCodeGenerator.AddClass(item.name, item.typeid);
                }

                DatabaseCodeGenerator.Generate(Settings);
            }
            catch (Exception e)
            {
                Debug.LogError("Code generation falied");
                Debug.LogException(e);

                _codeWriter.DeleteGeneratedFiles();
            }
        }

        private readonly string _codePath;
        private readonly CodeWriter _codeWriter;
        private readonly DatabaseSchema _schema;
    }
}
