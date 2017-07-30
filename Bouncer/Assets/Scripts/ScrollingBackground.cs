using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    public float speed = 0.1f;
    const float speedDef = 0.1f;
    float speedMult = 1;
    const float speedMultDef = 1;
    float speedDecayTime = 1.12f;
    public MeshRenderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
        EventManager.Release += Release;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(Time.time * speed * speedMult, 0);
        rend.material.mainTextureOffset = offset;
       
	}

    public void Release(float bonusMult)
    {
        StartCoroutine(MultDecay(bonusMult));
    }

    IEnumerator MultDecay(float mult)
    {
        //speedMult += mult;
        float startTime = Time.time;
        float endTime = startTime + speedDecayTime;

        while (Time.time < endTime)
        {
            float perc = (Time.time - startTime) / speedDecayTime;
            speedMult = Mathf.Lerp(speedMultDef + mult, speedMultDef, perc);
            //speedMult = speedMultDef + mult * (1 - perc);
            print(speedMult);
            yield return new WaitForEndOfFrame();
        }
        speedMult = speedMultDef;

    }
}
