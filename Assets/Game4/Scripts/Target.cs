using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    [SerializeField] private float _minSpeed = 12;
    [SerializeField] private float _maxSpeed = 16;
    [SerializeField] private float _maxTorque = 10;
    [SerializeField] private float _xRange = 4;
    [SerializeField] private float _posY = -6;
    [SerializeField] private int _pointValue=1;
    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private Rigidbody _targeRigidbody;
    [SerializeField] private GameManagerF _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _targeRigidbody= GetComponent<Rigidbody>();
        _targeRigidbody.AddForce(RandomForce(),ForceMode.Impulse);
        _targeRigidbody.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerF>();
        
    }

    public Vector3 RandomForce()
    {
        Vector3 force = Vector3.up*Random.Range(_minSpeed,_maxSpeed);
        return force;
    }
    public float RandomTorque()
    {
        float randomTorque = Random.Range(-_maxTorque,_maxTorque);
        return randomTorque;
    }
    public Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-_xRange,_xRange),_posY);
    }

    private void OnMouseDown()
    {
        Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
        _gameManager.UpdateScore(_pointValue);
        Destroy(gameObject);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
