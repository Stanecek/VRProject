using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorShard : MonoBehaviour
{
    float magnitude = 10f;
    float radius = 2f;
    float upForce = 1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BecameActive(Vector3 bulletHitPoint)
    {
        bulletHitPoint += new Vector3(-1, 0, 0);
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.AddExplosionForce(magnitude, bulletHitPoint, radius, upForce, ForceMode.Impulse);
        }

    }
}
