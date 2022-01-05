using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExplosionScript : MonoBehaviour
{
    void Update()
    {
        transform.localScale = transform.localScale + new Vector3(0.1f,0.1f,0.1f) * Time.deltaTime*15f;
        if(transform.localScale.x>=0.5f){
            Destroy(gameObject);
        }
    }
}
