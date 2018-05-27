 using System.Collections.Generic;
 using System.Linq;
 using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string command;
            while ((command= Console.ReadLine()) != "HARVEST")
            {
                var fields = typeof(HarvestingFields).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                PrintFields(command, fields);
            }
        }

        private static void PrintFields(string command, FieldInfo[] fields)
        {

            //IEnumerable<FieldInfo> allFields = null;
            switch (command)
            {
                case "private":
                    //allFields = fields.Where(f => f.IsPrivate);
                    foreach (var field in fields)
                    {
                        if (field.IsPrivate)
                        {
                            Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        }
                    }
                    break;
                case "protected":
                    foreach (var field in fields)
                    {
                        var attribute = field.Attributes.ToString().ToLower();

                        if (field.IsFamily)
                        {
                            attribute = "protected";
                            Console.WriteLine($"{attribute} {field.FieldType.Name} {field.Name}");
                        }
                    }
                    break;
                case "public":
                    foreach (var field in fields)
                    {
                        if (field.IsPublic)
                        {
                            Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        }
                    }
                    break;
                case "all":
                    foreach (var field in fields)
                    {
                        var attribute = field.Attributes.ToString().ToLower();
                        if (field.IsFamily)
                        {
                            attribute = "protected";
                        }
                        Console.WriteLine($"{attribute} {field.FieldType.Name} {field.Name}");
                    }
                    break;
            }
        }
    }
}
