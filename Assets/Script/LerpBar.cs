using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpBar : MonoBehaviour
{
    public Checkpoint endpoint;
    public Image bar;
    public GameObject player;

    Vector3 startScale;
    float maxDist = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        startScale = bar.transform.localScale;
        maxDist = Vector3.Distance(player.transform.position, endpoint.gameObject.transform.position);
    }

    float u = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if (u <= 0.0f)
            u = 0.0f;
        else if (u >= 1.0f)
            u = 1.0f;

        float dist = Vector3.Distance(player.transform.position, endpoint.gameObject.transform.position);
        u = dist / maxDist;

        bar.transform.localScale = Vector3.Lerp(startScale, new Vector3(0.01f, startScale.y, startScale.z), u);

    }
}
