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
    float fireForce = 7.5f;

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
        fireDelay = Random.Range(0.5f, 3.0f);
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
        GameObject spawnedPorq = Instantiate(porq, transform.position, Quaternion.Euler(0, 0, angle));
        spawnedPorq.GetComponent<Rigidbody>().AddForce(0, fireForce * Mathf.Sin(Mathf.Deg2Rad * angle), -1 * fireForce * Mathf.Cos(Mathf.Deg2Rad * angle), ForceMode.Impulse);
        //Debug.Log("Angle: " + angle + ":  " + Mathf.Abs(fireForce * Mathf.Sin(Mathf.Deg2Rad * angle)) + ":" + Mathf.Abs(fireForce * Mathf.Cos(Mathf.Deg2Rad * angle)));
    }

    IEnumerator Fire(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnPorq();
        readyToFire = true;
    }
}
