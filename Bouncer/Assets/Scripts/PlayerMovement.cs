using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float releaseForce = 6f;
    public float timeScaleSlow = 0.33f;
    public float timeScaleDef = 1.5f;
    public Vector2 bounce = new Vector2();
    public Vector2 touchDown = new Vector2();
    public Vector2 arrowEnd = new Vector2();

    private Rigidbody2D rb;
    private Vector2 position;
    private float arrowLength = 2f;
    private const float touchDistThreshold = 50;
    private bool aimReady = false;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        position = new Vector2(transform.position.x, transform.position.y);
        Time.timeScale = timeScaleDef;
    }

    private void Update()
    {
        position = new Vector2(transform.position.x, transform.position.y);

        
        
        TouchBegin();
        TouchHeld();
        TouchEnd();
    }


    //When finger/mouse first hits screen
    void TouchBegin()
    {
        if (Input.GetMouseButtonDown(0))
        {
            aimReady = false;
            //touchDown = position;
            touchDown = Input.mousePosition;
            Time.timeScale = timeScaleSlow;

        }
    }


    //When finger/mouse is released
    void TouchEnd()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = timeScaleDef;
            if(aimReady)
                Aim();
        }
    }


    //When finger/mouse is kept down
    void TouchHeld()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            if (Vector3.Distance(mousePos, touchDown) > touchDistThreshold)
            {
                aimReady = true;
            }
            else
                aimReady = false;

            arrowEnd = (mousePos - touchDown).normalized;
            Debug.DrawRay(position, arrowEnd * arrowLength, Color.green);
        }
    }


    void Aim()
    {
        Vector2 force = arrowEnd * releaseForce;
        rb.velocity = Vector2.zero;

        rb.AddForce(force, ForceMode2D.Impulse);
        print("Force: " + arrowEnd.x);
        //print("Force: " + force);
        //EventManager.Aim(arrowEnd.x);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Floor")
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(bounce, ForceMode2D.Impulse);
        }
    }
}
