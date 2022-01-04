using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionWavePulse : MonoBehaviour
{
    void Update()
    {
        transform.localScale = transform.localScale + new Vector3(1.5f, 1.5f, 1.5f) * Time.deltaTime * 79f;
        if (transform.localScale.x >= 95f)
        {
            Destroy(gameObject);
        }
    }
}
