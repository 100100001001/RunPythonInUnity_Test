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
                //프로세스 파일명 정의
                //파이썬 exe를 직접 실행해서 파이썬 코드가 실행되도록 한다.
                var psi = new ProcessStartInfo();
                psi.FileName = @"C:\Users\MinJi\anaconda3\python.exe"; //파이썬 설치 경로
                psi.Arguments = $"\"D:\\Unity\\RunPythonTest\\Holistic.py\""; //파일경로

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
                UnityEngine.Debug.LogError("에러 발생 : " + ex.Message);
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
//                //파일을 읽지 않고 스크립트를 바로작성
//                var source = engine.CreateScriptSourceFromFile(@"test.py");
//                source.Execute(scope);

//                var getPythonFuncResult = scope.GetVariable<Func<string>>("getPythonFunc");
//                Console.WriteLine("def 실행 테스트 : " + getPythonFuncResult());

//                var sum = scope.GetVariable<Func<int, int, int>>("sum");
//                Console.WriteLine(sum(1, 2));

//                //파일을 읽지 않고 스크립트를 바로작성
//                var source2 = engine.CreateScriptSourceFromString(@"print('스크립트를 직접작성해 출력 테스트')");
//                source2.Execute(scope);

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//        }
//    }
//}
