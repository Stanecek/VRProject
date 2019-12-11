using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class porq : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;

    GameObject PorqHitText;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        PorqHitText = GameObject.FindGameObjectWithTag("PorqHit");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(0, 4.905f, 0);
    }

    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            int hits = int.Parse(PorqHitText.GetComponent<Text>().text) + 1;
            PorqHitText.GetComponent<Text>().text = hits.ToString();
        }
        Destroy(gameObject);
    }
}
