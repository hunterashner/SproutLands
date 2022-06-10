using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableFloatBehavior : MonoBehaviour
{   
    Vector3 _startPosition;
    private float floatNormalizer = 0.02f;
    void Start(){
        _startPosition = this.transform.position;
    }
    void Update()
    {
        this.transform.position = _startPosition 
        + new Vector3(0.0f, Mathf.Sin(Time.time) * floatNormalizer, 0.0f);
    }
}
