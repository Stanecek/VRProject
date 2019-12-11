using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource src = GetComponent<AudioSource>();
        src.Play();
        StartCoroutine(DestructYoSelf());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestructYoSelf()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
