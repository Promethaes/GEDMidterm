using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    Vector3 lastMouse = new Vector3();
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            move(gameObject.transform.forward);
        else if (Input.GetKey(KeyCode.S))
            move(-gameObject.transform.forward);
        if (Input.GetKey(KeyCode.A))
            move(-gameObject.transform.right);
        if (Input.GetKey(KeyCode.D))
            move(gameObject.transform.right);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.rotation = Quaternion.AngleAxis(-500.0f * Time.deltaTime, Vector3.up) * transform.rotation;
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.rotation = Quaternion.AngleAxis(500.0f * Time.deltaTime, Vector3.up) * transform.rotation;
    }

    void move(Vector3 direction)
    {
        gameObject.transform.position = gameObject.transform.position + (direction * moveSpeed * Time.deltaTime);
    }



}
