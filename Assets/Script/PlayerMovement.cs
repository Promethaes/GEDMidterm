using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public Walls allWalls;

    GameObject lastTouchedCheckpoint;

    public TimeLogCS timeLog;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

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

        transform.rotation = Quaternion.AngleAxis(Input.GetAxis("Mouse X"), Vector3.up) * transform.rotation;

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.rotation = Quaternion.AngleAxis(-500.0f * Time.deltaTime, Vector3.up) * transform.rotation;
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.rotation = Quaternion.AngleAxis(500.0f * Time.deltaTime, Vector3.up) * transform.rotation;

    }

    void move(Vector3 direction)
    {
        gameObject.transform.position = gameObject.transform.position + (direction * moveSpeed * Time.deltaTime);
    }

    public void SpawnReset()
    {
        transform.position = lastTouchedCheckpoint.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<LerpScale>() && other.gameObject.GetComponent<LerpScale>().interactable)
        {
            allWalls.SwapAll();
        }
        else if (other.gameObject.GetComponent<Checkpoint>())
        {

            foreach (var v in timeLog.touchOrder)
                if (v == other.gameObject)
                    return;

            lastTouchedCheckpoint = other.gameObject;
            lastTouchedCheckpoint.GetComponent<Checkpoint>().touchTime = Time.time;
            timeLog.touchOrder.Add(other.gameObject.GetComponent<Checkpoint>());
            timeLog.CalculateDiffs();

            lastTouchedCheckpoint.SetActive(false);

            if (other.gameObject.GetComponent<Exit>())
            {
                SceneManager.LoadScene("ExitScene");
            }
        }
    }


}
