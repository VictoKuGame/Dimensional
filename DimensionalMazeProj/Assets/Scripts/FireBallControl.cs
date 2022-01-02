using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallControl : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] ParticleSystem effect;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider collision)
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
