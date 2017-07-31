using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void MouseRelease(float power);
    public static MouseRelease Release;

	

    public static void Aim(float power)
    {
        if (Release != null)
            Release(power);
    }
}
