using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public Rigidbody2D bottle;
    public PadStrength padStrength;
    public PadDirection direction;
    public int rotateSpeed;

    void OnCollisionEnter2D(Collision2D col)
    {
        padStrength.isJumped = false;
    }

    void Start()
    {
        direction = GameObject.Find("Joystick").GetComponent<PadDirection>();
        bottle = GameObject.Find("Bottle").GetComponent<Rigidbody2D>();
        bottle.gravityScale = 0;
        rotateSpeed = 300;
    }

    void Update()
    {
        if (padStrength.isJumped)
        {
            bottle.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime, Space.World);
        }
    }

    public void Jump()
    {
        Debug.Log(padStrength.strength_time);
        bottle.gravityScale = 1;
        bottle.AddForce(direction.direction * padStrength.strength_time / 5, ForceMode2D.Impulse);

    }

}
