using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    enum PipePosition
    {
        Left,
        Middle,
        Right
    }

    [SerializeField]
    PipePosition pipePosition = PipePosition.Left;

    [SerializeField]
    GameObject porq;

    float angle;
    bool readyToFire;
    float fireDelay;
    int fireForce = 15;

    // Start is called before the first frame update
    private void Start()
    {
        WaitToFire();
    }

    void WaitToFire()
    {
        switch(pipePosition)
        {
            case PipePosition.Left:
                angle = Random.Range(75.0f, 90.0f);
                break;
            case PipePosition.Middle:
                angle = Random.Range(75.0f, 105.0f);
                break;
            case PipePosition.Right:
                angle = Random.Range(90.0f, 105.0f);
                break;
        }
        fireDelay = Random.Range(0.5f, 5.0f);
        StartCoroutine(Fire(fireDelay));
    }

    private void Update()
    {
        if (readyToFire)
        {
            readyToFire = false;
            WaitToFire();
        }
    }

    void SpawnPorq()
    {
        Debug.Log(angle);
        GameObject spawnedPorq = Instantiate(porq, transform.position, Quaternion.Euler(0, 180, angle));
        spawnedPorq.GetComponent<Rigidbody>().AddForce(0, fireForce * Mathf.Sin(angle), fireForce * Mathf.Cos(angle),ForceMode.Impulse);
    }

    IEnumerator Fire(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnPorq();
        readyToFire = true;
    }
}
