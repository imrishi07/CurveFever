using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 200f;

    public float horizontal = 0f;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
        transform.Rotate(Vector3.forward * -horizontal * rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerKiller")
        {
            speed = 0;
            rotationSpeed = 0;
            FindObjectOfType<GameManager>().EndGame();
        }
       
    }
}
