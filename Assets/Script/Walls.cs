using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public List<GameObject> list;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapAll()
    {
        foreach (var w in list)
            w.GetComponent<LerpScale>().SwitchBetweenBothLerps();
    }
}
 