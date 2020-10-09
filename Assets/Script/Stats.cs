using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public DLLMiddleMan middleMan;

    public TextMeshProUGUI totalRuntime;
    public TextMeshProUGUI diffText;


    // Start is called before the first frame update
    void Start()
    {
        totalRuntime.text = "Total Runtime:" + middleMan.LoadTotalTime().ToString();

        diffText.text = "RTBC: ";
        for(int i = 0; i < middleMan.CheckpointCount(); i++)
        {
            diffText.text += "Checkpoint #" + i.ToString() + ": " + middleMan.LoadTime(i) + "\n";
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
