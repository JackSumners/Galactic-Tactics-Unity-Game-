using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMovement : MonoBehaviour
{

    public Transform[] checkPoints;
    public float speed;

    public int current;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != checkPoints[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, checkPoints[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else current = (current + 1) % checkPoints.Length;

        //For roatating towards checkpoint

        //transform.LookAt(checkPoints[current].position);

        Vector3 direction = checkPoints[current].position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}