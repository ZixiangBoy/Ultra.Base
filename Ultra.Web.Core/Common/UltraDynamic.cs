using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;

namespace Ultra.Web.Core.Common
{
    public partial class UltraDynamic
    {
        private static UltraDynamic _def = new UltraDynamic();

        /// <summary>
        /// 默认实例
        /// </summary>
        public static UltraDynamic Default
        {
            get
            {
                return _def;
            }
        }

        /// <summary>
        /// 计算一个运算表达式,结果以字符串返回.
        /// </summary>
        /// <param name="src">运算表达式.例如:3*5+8/2-1</param>
        /// <returns>表达式计算完成后的结果</returns>
        public virtual string Calc(string src)
        {
             // 1.CSharpCodePrivoder
            CSharpCodeProvider objCSharpCodePrivoder = new CSharpCodeProvider();

            // 2.ICodeComplier
            //ICodeCompiler objICodeCompiler = objCSharpCodePrivoder.g

            // 3.CompilerParameters
            CompilerParameters objCompilerParameters = new CompilerParameters();
            objCompilerParameters.ReferencedAssemblies.Add("System.dll");
            objCompilerParameters.GenerateExecutable = false;
            objCompilerParameters.GenerateInMemory = true;

            // 4.CompilerResults
            CompilerResults cr = objCSharpCodePrivoder.CompileAssemblyFromSource(objCompilerParameters, GenCode(src));

            if (cr.Errors.HasErrors)
            {
                //Console.WriteLine("编译错误：");
                //foreach (CompilerError err in cr.Errors)
                //{
                //    Console.WriteLine(err.ErrorText);
                //}
                throw new Exception(cr.Errors[0].ErrorText);
            }
            else
            {
                // 通过反射，调用HelloWorld的实例
                Assembly objAssembly = cr.CompiledAssembly;
                object objHelloWorld = objAssembly.CreateInstance("dynamicrun");
                MethodInfo objMI = objHelloWorld.GetType().GetMethod("MathEval");
                return objMI.Invoke(objHelloWorld, null).ToString();
                //Console.WriteLine(objMI.Invoke(objHelloWorld, null));
            }
        }

        /// <summary>
        /// 调用代码模板(GencodeFormat中定义)生成源代码类文件源码
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        protected virtual string GenCode(string exp)
        {
            return string.Format(GencodeFormat, exp);
        }

        /// <summary>
        /// 生成的调用模板类代码模板
        /// </summary>
        protected virtual string GencodeFormat
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;             \n");
                sb.Append("public class dynamicrun   \n");
                sb.Append("{{                         \n");
                sb.Append("public decimal MathEval() \n");
                sb.Append("{{                         \n");
                sb.Append(" return {0};              \n");
                sb.Append("}}                         \n");
                sb.Append("}}                         \n");
                return sb.ToString();
            }
        }
        
    }
}
