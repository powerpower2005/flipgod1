using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public PadStrength padStrength;
    public PadDirection padDirection;
    public int rotateSpeed;

    private float strengthFactor = 10;


    //angrybird    
    private Vector2 endPos;
    public Vector2 initPos;
    private Rigidbody2D rigidbody;
    public GameObject trajectoryDot;
    private GameObject[] trajectoryDots;
    public int trajectoryNumber = 8;
    void OnCollisionEnter2D(Collision2D col)
    {
        padStrength.isJumped = false;
    }

    void Start()
    {
        initPos = gameObject.transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        trajectoryDots = new GameObject[trajectoryNumber];

        padDirection = GameObject.Find("Joystick").GetComponent<PadDirection>();
        rigidbody.gravityScale = 0;
        rotateSpeed = 300;

        for (int i = 0; i < trajectoryNumber; i++)
        {
            trajectoryDots[i] = Instantiate(trajectoryDot, gameObject.transform);
        }
    }

    void Update()
    {
        if (padDirection.isTouch) //click
        {
            endPos = initPos - padDirection.direction;
            for (int i = 0; i < trajectoryNumber; i++)
            {
                trajectoryDots[i].transform.position = calculatePosition(i * 0.1f);
            }
        }

        if (padStrength.isJumped) //leave
        {

            gameObject.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime, Space.World);

        }

        
    }

    public void Jump() //leave
    {
        strengthFactor = padStrength.strength_time / 5;
        Debug.Log(strengthFactor);
        rigidbody.gravityScale = 1;
        rigidbody.AddForce(padDirection.direction * strengthFactor, ForceMode2D.Impulse);
        for (int i = 0; i < trajectoryNumber; i++)
        {
            Destroy(trajectoryDots[i]);
        }
    }

    private Vector2 calculatePosition(float elapsedTime)
    {
        return endPos + //X0
                new Vector2(padDirection.direction.x * strengthFactor, padDirection.direction.y * strengthFactor) * elapsedTime + //ut
                0.5f * Physics2D.gravity * elapsedTime * elapsedTime;
    }

}
