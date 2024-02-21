using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl  : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    Vector3 offset;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime + 1);
    }
}
