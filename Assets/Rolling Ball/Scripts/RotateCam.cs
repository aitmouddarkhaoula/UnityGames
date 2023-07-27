using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 45f;
    [SerializeField] private GameObject _focalPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput= Input.GetAxis("Horizontal");
        transform.RotateAround(_focalPoint.transform.position,Vector3.up,  Time.deltaTime * _rotationSpeed * horizontalInput);
    }
}
