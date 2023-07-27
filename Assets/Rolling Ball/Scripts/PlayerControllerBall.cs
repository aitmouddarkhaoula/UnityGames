using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBall : MonoBehaviour
{
    [SerializeField] private float _speed = 20f; 
    [SerializeField] private GameObject _focalPoint;
    [SerializeField] private GameObject _powerUpIndicator;
    private Rigidbody _playerRb;
    private bool _hasPowerUp=false;
    private float powerUpStrength = 15f;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        //_powerUpIndicator = transform.GetChild(0).gameObject;
        _powerUpIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput= Input.GetAxis("Vertical");
        Vector3 force = _focalPoint.transform.forward*verticalInput;
        _playerRb.AddForce(force*_speed );
        _powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            _hasPowerUp = true;
            _powerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpCountdownRoutine());

        }
    }
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        _hasPowerUp = false;
        _powerUpIndicator.SetActive(false);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy")&&_hasPowerUp)
        {
            GameObject enemy = other.gameObject;
            Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (enemy.transform.position - transform.position);
            enemyRb.AddForce(awayFromPlayer*powerUpStrength,ForceMode.Impulse);
        }
    }
}
