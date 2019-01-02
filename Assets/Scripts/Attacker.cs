using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    public double health;
    public Transform target;
    public float speed;
    public double DPS;
    public double DPSO;

    private Vector3 direction;
    private int countT;
    private GameObject TargetObj;

	// Use this for initialization
	void Start () {
        //target.transform.hasChanged = false;  //since we change transform in public(unity) lets ignore it!
        TargetObj = target.transform.gameObject;
        countT = 1;

    }
	
	// Update is called once per frame
	void Update () {
        //if -- target.transform.hasChanged
        if (TargetObj == null && (GameObject.Find("Defender (" + countT + ")"))  )
        {
            target  = GameObject.Find("Defender ("+countT+")").transform;
            TargetObj = target.transform.gameObject;
            countT++;
        }

        if (TargetObj != null) // if the target remains unchanged due to discovery issues
        {
            transform.LookAt(target, Vector3.up);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        

    }

    /*
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


    public void TurretDamage(double ammount)
    {
        health -= ammount;
       //Debug.Log("Damage Applied!");
    }



    void OnCollisionStay(Collision col)
    {
       
        if (col.gameObject.tag == "Defender")
        {
            health -= (DPS/60);
            if (health < 1)
            {
                Destroy(this);
                //Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
