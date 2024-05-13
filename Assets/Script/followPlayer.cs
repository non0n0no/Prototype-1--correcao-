using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject playerToFollow ;
    public Vector3 cameraOffset = new Vector3(0, 7, -15);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerToFollow.transform.position + cameraOffset;
    }
}
