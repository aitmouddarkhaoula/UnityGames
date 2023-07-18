using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 6, -7);
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
    
}
