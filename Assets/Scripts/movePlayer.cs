using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    Transform transform;
    int playerSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) == true || Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.UpArrow) == true)
        {
            transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
        }
    }
}
