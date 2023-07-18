using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    [SerializeField] PlayerController3 playerController;

    public GameObject obstaclePrefab;
    public Vector3 spawnPos = new Vector3(25,0,0);
    public float startDelay = 0.5f; 
    public float repeatRate = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
        playerController = GameObject.Find("Player").GetComponent<PlayerController3>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObstacle()
    {
        if(!playerController.gameOver) {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.gameObject.transform.rotation, transform);
        }
    }
}
