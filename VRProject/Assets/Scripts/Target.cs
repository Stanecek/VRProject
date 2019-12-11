using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    int spinAmount = 5;
    bool moveLeft;
    AudioSource src;

    GameObject TargetHitText;

    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
        TargetHitText = GameObject.FindGameObjectWithTag("TargetHit");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            transform.Translate(new Vector3(-0.01f, 0, 0));
        }
        else
        {
            transform.Translate(new Vector3(0.01f, 0, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() == true)
        {
            StartCoroutine(Spin());
            src.Play();
            int hits = int.Parse(TargetHitText.GetComponent<Text>().text) + 1;
            TargetHitText.GetComponent<Text>().text = hits.ToString();
        }
        else
        {
            Debug.Log("Changing direction...");
            moveLeft = !moveLeft;
        }
    }

    IEnumerator Spin()
    {
        for (int i = 0; i < 720; i+=spinAmount)
        {
            yield return null;
            transform.Rotate(new Vector3(0, spinAmount, 0));
        }
    }
}
