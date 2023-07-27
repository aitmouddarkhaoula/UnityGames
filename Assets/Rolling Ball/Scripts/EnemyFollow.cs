using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] float _speed = 3f;

     private Transform _player;
     private Rigidbody _enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _player=GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (_player.position-transform.position).normalized;
        _enemyRb.AddForce(lookDirection*_speed);
        if(transform.position.y<-10)
            Destroy(gameObject);
    }
}
