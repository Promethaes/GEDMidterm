using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScale : MonoBehaviour
{
    public float from = 3.0f;
    public float to = 0.5f;
    public Walls walls;

    public bool interactable = false;

    // Start is called before the first frame update
    void Start()
    {
        from = transform.localScale.y;
        to = from == 3.0f ? 0.5f : 3.0f;
        if (walls != null)
            walls.list.Add(gameObject);
    }

    float u = 0.0f;
    bool lerping = false;
    bool backLerp = false;
    bool done = false;
    // Update is called once per frame
    void Update()
    {
        if (lerping)
            forwardLerp();
        else if (backLerp)
            backwardLerp();
    }

    void forwardLerp()
    {
        u += Time.deltaTime;
        if (u >= 1.0f)
        {
            u = 1.0f;
            lerping = false;
        }

        gameObject.transform.localScale = new Vector3(1.0f, Mathf.Lerp(from, to, u), 1.0f);
    }

    void backwardLerp()
    {
        u -= Time.deltaTime;
        if (u <= 0.0f)
        {
            u = 0.0f;
            backLerp = false;
        }

        gameObject.transform.localScale = new Vector3(1.0f, Mathf.Lerp(from, to, u), 1.0f);
    }

    public void DoLerp()
    {
        lerping = true;
        backLerp = false;
        u = 0.0f;
    }

    public void BackLerp()
    {
        lerping = false;
        backLerp = true;
        u = 1.0f;
    }

    public void SwitchBetweenBothLerps()
    {
        if (done)
        {
            lerping = false;
            backLerp = true;
            done = false;
        }
        else
        {
            lerping = true;
            backLerp = false;
            done = true;
        }


    }
}
