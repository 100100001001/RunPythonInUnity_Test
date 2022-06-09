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
                // ���̽� ȯ�� ����
                psi.StartInfo.FileName = "C:/Users/MinJi/anaconda3/python.exe";
                
                // ������ ���̽� ����
                psi.StartInfo.Arguments = "D:/Unity/RunPythonTest/Holistic.py";

                // �� â���� ����
                psi.StartInfo.CreateNoWindow = true;

                // ���μ����� ������ �� �ü�� ���� �������
                psi.StartInfo.UseShellExecute = false;

                psi.Start();
                UnityEngine.Debug.Log("���̽� ����");
            }

            catch (Exception ex)
            {
                UnityEngine.Debug.LogError("���� �߻� : " + ex.Message);
                
                // ������ StandardError ��Ʈ���� ����
                psi.StartInfo.RedirectStandardError = true;

                // ����� StandardError ��Ʈ���� ����
                psi.StartInfo.RedirectStandardOutput = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // ���μ����� ����� �������̽��� �����ϴ��� Ȯ��
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
