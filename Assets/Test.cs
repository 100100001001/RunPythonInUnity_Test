using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class Test : MonoBehaviour
{
    Process psi;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            try
            {
                psi = new Process();
                // 파이썬 환경 설정
                psi.StartInfo.FileName = "C:/Users/MinJi/anaconda3/python.exe";
                
                // 실행할 파이썬 파일
                psi.StartInfo.Arguments = "D:/Unity/RunPythonTest/Holistic.py";

                // 새 창에서 시작
                psi.StartInfo.CreateNoWindow = true;

                // 프로세스를 시작할 때 운영체제 셀을 사용할지
                psi.StartInfo.UseShellExecute = false;

                psi.Start();
                UnityEngine.Debug.Log("파이썬 실행");
            }

            catch (Exception ex)
            {
                UnityEngine.Debug.LogError("에러 발생 : " + ex.Message);
                
                // 에러를 StandardError 스트림에 쓸지
                psi.StartInfo.RedirectStandardError = true;

                // 출력을 StandardError 스트림에 쓸지
                psi.StartInfo.RedirectStandardOutput = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // 프로세스의 사용자 인터페이스가 응답하는지 확인
            if (psi.Responding)
            {
                UnityEngine.Debug.Log("Status - Runnig");
            }
            else
            {
                psi.Close();
                UnityEngine.Debug.Log("Status - Not Responding");
            }
        }
    }
}
