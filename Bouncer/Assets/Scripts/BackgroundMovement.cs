using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

    private SpriteRenderer sp;

	void Start () {
        sp = GetComponent<SpriteRenderer>();
	}

    //Does not work when scene view can still see the object...... Play in fullscreen mode or move scene camera so it does not show object
    private void OnBecameInvisible()
    {
        //calculate current position
        Vector3 curPos = transform.position;
        //calculate new position
        float newX = curPos.x + sp.bounds.size.x * 2;
        //Move to next position
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
