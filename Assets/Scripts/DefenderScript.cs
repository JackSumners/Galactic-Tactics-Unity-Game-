using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderScript : MonoBehaviour
{

    public Attacker aScript;

    public double health;
    public Transform target;
    //public double DPS;
    //public double DPSO;

    private Vector3 direction;
    private Rigidbody rbody;
    /*
    // Use this for initialization
    void Start()
    {

        rbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(target, Vector3.up);
        transform.position += transform.forward * speed * Time.deltaTime;

    }


    void OnCollision(Collision col)
    {
        if (col.gameObject.tag == "Defender")
        {
            health -= 100;
            if (health < 1)
            {
                Destroy(this);
                //Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }*/

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Attacker")
        {
            //ScriptableObject TScript = col.gameObject.GetComponent.sc
            health -= (aScript.DPSO / 60);
            if (health < 1)
            {
                Destroy(this);
                //Instantiate(explosion, transform.position, transform.rotation);
                 Destroy(gameObject);
            }
        }
    }
}