using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamari : MonoBehaviour
{
    
    
        public float rotateSpeed,rotateAngle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateAngle *  Time.deltaTime * rotateSpeed, 0 );
    }

    

}
