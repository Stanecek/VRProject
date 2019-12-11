using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSwitch : MonoBehaviour {
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button lightSwitch;
    public Light lt;


    AudioSource flashlight_Click;
    bool LightOn = false;
    bool LightOff = true;
    float off = 0.0f;
    float on = 4.0f;


	// Use this for initialization
	void Start () {
        lt = GetComponentInChildren<Light>();
        ovrGrabbable = GetComponent<OVRGrabbable>();

        flashlight_Click = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(lightSwitch, ovrGrabbable.grabbedBy.GetController()) && LightOn)
        {
            LightOn = false;
            LightOff = true;
            lt.intensity = off;
            flashlight_Click.Play();
            return;
        }

        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(lightSwitch, ovrGrabbable.grabbedBy.GetController()) && LightOff)
        {
            LightOn = true;
            LightOff = false;
            lt.intensity = on;
            flashlight_Click.Play();
            return;
        }
    }
}
