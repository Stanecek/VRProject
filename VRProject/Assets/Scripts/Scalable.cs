using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalable : MonoBehaviour {
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button scaleUp;
    public OVRInput.Button scaleDown;

    // Use this for initialization
    void Start () {
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }
	
	// Update is called once per frame
	void Update () {

        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(scaleUp, ovrGrabbable.grabbedBy.GetController()))
        {
            //scale object up
            ovrGrabbable.transform.localScale = ovrGrabbable.transform.localScale + new Vector3(.1f,.1f,.1f);

        }

        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(scaleDown, ovrGrabbable.grabbedBy.GetController()))
        {
            //scale object down
            ovrGrabbable.transform.localScale = ovrGrabbable.transform.localScale - new Vector3(.1f, .1f, .1f);
        }
    }
}
