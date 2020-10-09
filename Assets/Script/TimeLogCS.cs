using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLogCS : MonoBehaviour
{
    public List<float> diffs;
    public List<Checkpoint> touchOrder;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CalculateDiffs()
    {
        diffs.Clear();
        for (int i = 0; i < touchOrder.Count; i++)
        {
            if (i == 0 || touchOrder[i].touchTime == 0.0f)
                continue;

            float x1 = touchOrder[i - 1].touchTime;
            float x2 = touchOrder[i].touchTime;

            float diff = x2 - x1;
            diffs.Add(diff);
            Debug.Log(diffs[diffs.Count - 1]);
        }


    }

    public void FindTotalRuntime()
    {
        float result = 0.0f;
        foreach (var diff in diffs)
            result += diff;

    }

}
