using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    public Vector2 bounce = new Vector2();
    public float timeScaleSlow = 0.33f;
    public float timeScaleDef = 1.5f;
    public Vector2 touchDown = new Vector2();
    private float arrowLength = 2f;
    public Vector2 arrowEnd = new Vector2();
    private Vector2 position;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        position = new Vector2(transform.position.x, transform.position.y);
        Time.timeScale = timeScaleDef;

    }

    private void Update()
    {
        position = new Vector2(transform.position.x, transform.position.y);

        if (Input.GetMouseButtonDown(0))
        {
            //spider square
            //touchDown = position;
            touchDown = Input.mousePosition;
            Time.timeScale = timeScaleSlow;

        }
        if (Input.GetMouseButton(0))
        {
            //print("Held down");
            //spider square
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            arrowEnd = (mousePos - touchDown).normalized;
            Debug.DrawRay(position, arrowEnd * arrowLength, Color.green);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = timeScaleDef;
        }
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
