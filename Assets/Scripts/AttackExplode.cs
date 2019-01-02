using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackExplode : MonoBehaviour {

    public double health;
    public Transform target;
    public float speed;
    public double DPS;
    public double DPSO;

    public GameObject objDefender;  // grabs defender's parent obj 

    private Vector3 direction;
    private int countT;
    private GameObject TargetObj;


    void Start()
    {
        TargetObj = target.transform.gameObject;
        countT = 1;
    }


    // Update is called once per frame
    void Update()
    {
        //if -- target.transform.hasChanged
        if (TargetObj == null && (GameObject.FindWithTag("Defender")))
        {
            target = GetClosestEnemy();
            TargetObj = target.transform.gameObject;
            countT++;
        }

        if (TargetObj != null) // if the target remains unchanged due to discovery issues
        {
            transform.LookAt(target, Vector3.up);

            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    //USING BULLETS
    /*
    public void TurretDamage(double ammount, ref bool death)
    {
        health -= ammount;
        if (health < 1)
        {
            Destroy(this);
            //Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            death = true;
        }
        //Debug.Log("Damage Applied!");
    }*/


    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Defender")
        {
            //CALL DAMAGE TURRET FUNCTION
            BDefender _hitDamage = col.gameObject.GetComponent<BDefender>();
            health -= _hitDamage.DPSO;   //set damage to 100 and health to 100
            if (health < 1)
            {
                //Instantiate(explosion, transform.position, transform.rotation);
                Destroy(this);
                Destroy(gameObject);
            }
        }
    }


    Transform GetClosestEnemy()
    {
        Debug.Log("Finding Closest");
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        var children = objDefender.GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            float dist = Vector3.Distance(child.position, currentPos);
            if (dist < minDist)
            {
                tMin = child;
                minDist = dist;
            }
        }
        Debug.Log("Closest is " + tMin);
        return tMin;
    }
}
