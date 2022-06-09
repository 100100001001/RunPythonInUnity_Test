using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Scripting.Python;

// 버튼을 눌렀을 때 PythonManager를 실행하는 스크립트

// 사용자 정의 편집기
[CustomEditor(typeof(PythonManager))]
public class PythonManagerEditor : Editor
{
    // 대상
    PythonManager targetManager;

    private void OnEnable()
    {
        targetManager = (PythonManager)target;
    }

    public override void OnInspectorGUI()
    {
        // 버튼 생성
        if (GUILayout.Button("Launch Python Script", GUILayout.Height(35)))
        {
            //Debug.Log("This is Working!");
            string path = Application.dataPath + "/Python/log_names.py";
            PythonRunner.RunFile(path);
        }
    }
}
