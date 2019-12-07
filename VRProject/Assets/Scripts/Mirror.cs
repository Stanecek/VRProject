using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
	[SerializeField]
	GameObject shatteredMirror;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            shatteredMirror.SetActive(true);
            gameObject.SetActive(false);
            shatteredMirror.GetComponent<AudioSource>().Play();
            shatteredMirror.GetComponent<MirrorShard>().BecameActive(transform.position);
        }

    }

    void OnCollisionEnter(Collision coll)
	{
        if (coll.gameObject.GetComponent<Bullet>() == true)
		{
			shatteredMirror.SetActive(true);
			gameObject.SetActive(false);
            shatteredMirror.GetComponent<AudioSource>().Play();
            shatteredMirror.GetComponent<MirrorShard>().BecameActive(coll.contacts[0].point);
		}
	}
}
