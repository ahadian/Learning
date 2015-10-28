using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JScript;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ReflectionTest.DataDefination.Core.PrimaryEntities;
using Convert = System.Convert;

namespace ReflectionTest
{
    public static class Program
    {
        //public static Assembly LoadAssemblies()
        //{
        //    Process pr = Process.GetCurrentProcess();
        //    var sAssemName = pr.ProcessName + ".exe";
        //    //sAssemName="ReflectionTest.DataDefination.Core.PrimaryEntities";
        //    sAssemName = "ReflectionTest.exe";
        //    return Assembly.LoadFrom(sAssemName);
        //}

        //static void Main(string[] args)
        //{
        //    Process pr = Process.GetCurrentProcess();
        //    var sAssemName = pr.ProcessName + ".exe";
        //    //sAssemName="ReflectionTest.DataDefination.Core.PrimaryEntities";
        //    sAssemName = "ReflectionTest.exe";
        //    Assembly assem = Assembly.LoadFrom(sAssemName);
        //    Type[] types = assem.GetTypes();
        //    var obj = new Widget()
        //    {
        //        CustomerId = "1",
        //        HelplineNumber = "2",
        //        IsActive = true
        //    };
        //    Type myType = assem.GetTypes().FirstOrDefault(x => x.Name == "Widget") ;
        //    string aqn = assem.GetTypes().FirstOrDefault(x => x.Name == "Widget").AssemblyQualifiedName ;
        //    var type = Type.GetType( aqn );





        //    string jsonString = JsonConvert.SerializeObject(obj);

        //    //var dynInst = Activator.CreateInstance(myType);
        //    var backProp = JsonConvert.DeserializeObject(jsonString,myType);

        //    MethodInfo method = myType.GetMethod(myType.Name.ToString());
        //    method.Invoke(myType, new object[] { backProp });

        //    //var xx = Cast(backProp,myType); 

        //}
        //public static dynamic Cast(dynamic obj, Type castTo)
        //{
        //    return Convert.ChangeType(obj, castTo);
        //}
    }
}
