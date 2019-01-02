using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret_Tracking : MonoBehaviour {

    // Use this for initialization
    public Transform target;      //grabs target info
    public GameObject objEnemy;   // grabs all enemy parent obj

    public AudioSource turretdamageSound;
    public ParticleSystem laser;

    public float speed;
    public double DPSO;
    public double AttackSpeed;
    public double Health;
    public double viewDist;
    public Transform turretBarrel;
   

    BAttackerDMG AttackTarget;       //script instance for attackers

    //DISPLAYS
    public double distanceB;

    private bool death;
    private Vector3 direction;
    private int countT;
    private GameObject TargetObj;
    private double LastTime;
    //private bool previousTarget;


    //private LineRenderer LineOfSight;


    void Start()
    {
        //LineOfSight = GetComponent<LineRenderer>();
        LastTime = Time.time;
        death = false;
        countT = 1;
    }



    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;


        if (target != null && Vector3.Distance(this.transform.position, target.transform.position) <= viewDist)
        {
            distanceB = Vector3.Distance(this.transform.position, target.transform.position);  // just for show

            TargetObj = target.transform.gameObject;
           
            transform.LookAt(target, Vector3.up);
                
            if (target.tag == "Attacker")
                {
                //Debug.DrawRay(turretBarrel.position, transform.TransformDirection(Vector3.forward) * 10, Color.green);
                //Debug.Log("Did Hit");

                //tracks attack speed of obj, and attacks after wait time difference 
                if (Time.time - LastTime >= AttackSpeed)
                {
                    LastTime = Time.time;

                    AttackTarget = (BAttackerDMG)target.gameObject.GetComponent(typeof(BAttackerDMG));

                    turretdamageSound.Play();

                    if (!laser.isPlaying)
                    { laser.Play(); }

                            //calls turret damage from Attacker's script, applys damage, and returns death notification
                            AttackTarget.TurretDamage(DPSO,ref death); //ref needs to be used in call and funct. param.
                            
                            if (death) 
                            {
                                Debug.Log("Target " + target.gameObject.name + " Death => Null");

                             
                                TargetObj = null;
                                death = false;
                            } // if target dies to turret dmg/ set target to null after destroy

                    }

                }
        }
        else 
        {
            Debug.Log("Target => NULL");
            TargetObj = null; 
        }



        //if -- target.transform.hasChanged
        if (TargetObj == null && (GameObject.FindWithTag("Attacker")))
        {
            Debug.Log("Start Target Switch");
            target = GetClosestEnemy();

            if (Vector3.Distance(this.transform.position, target.transform.position) <= viewDist)
            {
                TargetObj = target.gameObject;
                countT++;
                Debug.Log("Target Switched Closest => " + target.name);
            }
        }

    }



    Transform GetClosestEnemy()
    {
        Debug.Log("Finding Closest");
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        var children = objEnemy.GetComponentsInChildren<Transform>();
        foreach (var child in children) 
        {
            if (child.tag == "Attacker")
            {
                float dist = Vector3.Distance(child.position, currentPos);
                if (dist < minDist)
                {
                    tMin = child;
                    minDist = dist;
                }
            }
        }
        Debug.Log("Closest is " + tMin);
        return tMin;
    }


}
