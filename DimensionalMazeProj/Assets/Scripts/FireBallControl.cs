using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallControl : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] ParticleSystem effect;
    [SerializeField] ParticleSystem flyEffect;
    // Update is called once per frame
    void Start() {
        transform.rotation*=Quaternion.Euler(0,0,49);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
        Instantiate(flyEffect, transform.position, transform.rotation);
    }
    private void OnTriggerEnter(Collider collision)
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
