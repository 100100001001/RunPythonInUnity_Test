using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class RunIronPython : MonoBehaviour
{
    static void Main(string[] args)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            try
            {
                //���μ��� ���ϸ� ����
                //���̽� exe�� ���� �����ؼ� ���̽� �ڵ尡 ����ǵ��� �Ѵ�.
                var psi = new ProcessStartInfo();
                psi.FileName = @"C:\Users\MinJi\anaconda3\python.exe"; //���̽� ��ġ ���
                psi.Arguments = $"\"D:\\Unity\\RunPythonTest\\Holistic.py\""; //���ϰ��

                //3) Proecss configuration
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;

                //4) return value def
                var erros = "";
                var results = "";

                using (var process = Process.Start(psi))
                {
                    erros = process.StandardError.ReadToEnd();
                    results = process.StandardOutput.ReadToEnd();
                }

                Console.WriteLine(erros);
                Console.WriteLine(results);
            }

            catch (Exception ex)
            {
                UnityEngine.Debug.LogError("���� �߻� : " + ex.Message);
            }
        }
    }
}


//using System;
//using System.Diagnostics;

//namespace pythonTest
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            var engine = IronPython.Hosting.Python.CreateEngine();
//            var scope = engine.CreateScope();

//            try
//            {
//                //������ ���� �ʰ� ��ũ��Ʈ�� �ٷ��ۼ�
//                var source = engine.CreateScriptSourceFromFile(@"test.py");
//                source.Execute(scope);

//                var getPythonFuncResult = scope.GetVariable<Func<string>>("getPythonFunc");
//                Console.WriteLine("def ���� �׽�Ʈ : " + getPythonFuncResult());

//                var sum = scope.GetVariable<Func<int, int, int>>("sum");
//                Console.WriteLine(sum(1, 2));

//                //������ ���� �ʰ� ��ũ��Ʈ�� �ٷ��ۼ�
//                var source2 = engine.CreateScriptSourceFromString(@"print('��ũ��Ʈ�� �����ۼ��� ��� �׽�Ʈ')");
//                source2.Execute(scope);

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//        }
//    }
//}
