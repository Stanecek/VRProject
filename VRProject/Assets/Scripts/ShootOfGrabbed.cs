using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOfGrabbed : MonoBehaviour {

    private SimpleShoot simpleShoot;
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootingButton;

    AudioSource a_gunShot;
    // Use this for initialization
    void Start () {
        simpleShoot = GetComponent<SimpleShoot>();
        ovrGrabbable = GetComponent<OVRGrabbable>();

        a_gunShot = GetComponent<AudioSource>();


    }
	
	// Update is called once per frame
	void Update () {
        if(ovrGrabbable.isGrabbed && OVRInput.GetDown(shootingButton, ovrGrabbable.grabbedBy.GetController()))
        {
            //shoot
            simpleShoot.TriggerShoot();
            a_gunShot.Play();

        }
		
	}
}
