using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -0.1f);
        if (gameObject.transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
}
