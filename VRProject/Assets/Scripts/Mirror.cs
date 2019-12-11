using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mirror : MonoBehaviour
{
	[SerializeField]
	GameObject shatteredMirror;

    GameObject MirrorShatteredText;

    // Start is called before the first frame update
    void Start()
    {
        MirrorShatteredText = GameObject.FindGameObjectWithTag("MirrorShattered");
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
            MirrorShatteredText.GetComponent<Text>().text = "Yes";
			shatteredMirror.SetActive(true);
			gameObject.SetActive(false);
            shatteredMirror.GetComponent<AudioSource>().Play();
            shatteredMirror.GetComponent<MirrorShard>().BecameActive(coll.contacts[0].point);
		}
	}
}
