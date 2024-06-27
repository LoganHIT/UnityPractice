using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -10);

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
