using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class DLLMiddleMan : MonoBehaviour
{
    const string DllName = "NickTut";

    [DllImport(DllName)]
    private static extern void ResetLogger();

    [DllImport(DllName)]
    private static extern void SaveCheckpointTime(float RTBC);

    [DllImport(DllName)]
    private static extern float GetTotalTime();

    [DllImport(DllName)]
    private static extern float GetCheckpointTime(int index);

    [DllImport(DllName)]
    private static extern int GetNumCheckpoints();



    public void SaveTimeTest(float checkpointTime)
    {
        SaveCheckpointTime(checkpointTime);
    }

    public float LoadTimeTest(int index)
    {
        if (index < 0 || index >= GetNumCheckpoints())
            return -1.0f;
        return GetCheckpointTime(index);
    }

    public float LoadTotalTimeTest()
    {
        return GetTotalTime();
    }

    public void ResetLoggerTest()
    {
        ResetLogger();
    }

    float lastTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float currentTime = Time.time;
            float checkpointTime = currentTime - lastTime;
            lastTime = currentTime;
            SaveTimeTest(checkpointTime);
        }

        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                Debug.Log(LoadTimeTest(i));
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(LoadTotalTimeTest());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLoggerTest();
        }
    }
}
