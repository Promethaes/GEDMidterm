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

    public void SaveTime(float checkpointTime)
    {
        SaveCheckpointTime(checkpointTime);
    }

    public float LoadTime(int index)
    {
        if (index < 0 || index >= GetNumCheckpoints())
            return -1.0f;
        return GetCheckpointTime(index);
    }

    public float LoadTotalTime()
    {
        return GetTotalTime();
    }

    public void ResetLog()
    {
        ResetLogger();
    }

    
}
