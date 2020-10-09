using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissapear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    float timer = 3.0f;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        int chance = Random.Range(0, 3);

        if (chance > 0)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            timer = 3.0f;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

}
