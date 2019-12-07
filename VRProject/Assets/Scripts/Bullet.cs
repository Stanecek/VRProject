using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool canDestroy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LeaveMuzzle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (canDestroy)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator LeaveMuzzle()
    {
        yield return new WaitForSeconds(0.01f);
        canDestroy = true;
    }
}
