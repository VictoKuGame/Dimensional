using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireBallControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] ParticleSystem effect;
    [SerializeField] ParticleSystem flyEffect;
    private Vector3 spawnLoc;
    // Update is called once per frame
    void Start()
    {
        transform.rotation *= Quaternion.Euler(0, 0, 49);
        spawnLoc = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Instantiate(flyEffect, transform.position, transform.rotation);
        if (Vector3.Distance(transform.position, spawnLoc) >= 49f)
        {
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}





