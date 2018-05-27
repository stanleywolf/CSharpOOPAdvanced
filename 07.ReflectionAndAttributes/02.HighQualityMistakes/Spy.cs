using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        var sb = new StringBuilder($"Class under investigation: {classToInvestigate}" + Environment.NewLine);
        var fields = Type.GetType(classToInvestigate)
            .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        var classInstance = Activator.CreateInstance(Type.GetType(classToInvestigate));
        foreach (var field in fields)
        {
            if (fieldsToInvestigate.Contains(field.Name))
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }
        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string classToInvestigate)
    {
        Type classType = Type.GetType(classToInvestigate);
        FieldInfo[] classFields =
            classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();
        foreach (var field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (var methodInfo in classNonPublicMethod.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be public!");
        }
        foreach (var methodInfo in classPublicMethod.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be private!");
        }
        return sb.ToString().Trim();
    }
    //public string AnalyzeAcessModifiers(string classToInvestigate)
    //{
    //    var type = Type.GetType(classToInvestigate);
    //    var sb = new StringBuilder();
    //    foreach (var field in type.GetFields())
    //    {
    //        sb.AppendLine(field.Name + " must be private!");
    //    }
    //    var properties = type.GetProperties(BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic);
    //    foreach (var property in properties)
    //    {
    //        if (property.GetMethod.IsPrivate)
    //        {
    //            sb.AppendLine($"{property.GetMethod.Name} have to be public!");
    //        }

    //    }
    //    foreach (var property in properties)
    //    {
    //        if (property.SetMethod.IsPublic)
    //        {
    //            sb.AppendLine($"{property.SetMethod.Name} have to be private!");
    //        }
    //    }
    //    return sb.ToString().Trim();
    //}
}