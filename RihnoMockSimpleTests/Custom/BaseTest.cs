namespace RihnoMockSimpleTests.Custom
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Base test class
    /// </summary>
    /// <typeparam name="T">Test model</typeparam>
    /// <typeparam name="C">Calling class</typeparam>
    public abstract class BaseTest<T, C>
        where T : new()
        where C : new()
    {
        public abstract string GetDataFileName();
        public abstract TestContext GetTestContext();

        protected static string GetDataFile()
        {
            return typeof(C).GetMethod("GetDataFileName").Invoke(new C(), null).ToString();
        }

        protected static TestContext GetBaseTestContext()
        {
            return (TestContext)typeof(C).GetMethod("GetTestContext").Invoke(new C(), null);
        }

        protected static String GetFullPathToDataFile()
        {
            String basePath = Path.GetFullPath(Path.Combine(GetBaseTestContext().TestDirectory, @"..\..\"));
            String dataPath = String.Format("CsvData\\{0}", GetDataFile());
            return String.Format("{0}{1}", basePath, dataPath);
        }

        protected static IEnumerable<T> GetTestData()
        {
            using (var fileReader = File.OpenText(GetFullPathToDataFile()))
            using (var csvReader = new CsvHelper.CsvReader(fileReader))
            {
                csvReader.Configuration.IsHeaderCaseSensitive = false;

                var assemblyTypes = Assembly.GetExecutingAssembly().DefinedTypes.GetEnumerator();
                while (assemblyTypes.MoveNext())
                {
                    var type = assemblyTypes.Current;
                    if (type.FullName.Contains("CsvMap"))
                    {
                        //69 method = {CsvHelper.Configuration.CsvClassMap RegisterClassMap(System.Type)}
                        int genericMethodPlaceInTheMethodsList = 69;
                        MethodInfo method = csvReader.Configuration
                                                     .GetType()
                                                     .GetMethods()[genericMethodPlaceInTheMethodsList];
                        method.Invoke(csvReader.Configuration, new object[] { type });
                    }
                }

                while (csvReader.Read())
                {
                    var record = csvReader.GetRecord<T>();
                    yield return record;
                }
            }
        }
    }
}
