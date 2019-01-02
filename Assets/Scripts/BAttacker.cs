using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAttacker : MonoBehaviour {

    public double health;
    public double maxHealth;
    public Transform target;
    public float speed;
    public double DPS;
    public double DPSO;

    public AudioSource damageSound;

    public Plane_Brain Plane_B_script;
    public BDefender Base_script;

    public GameObject objDefender;  // grabs defender's parent obj 
    public GameObject plane;

    private Vector3 direction;
    private int countT;
    private GameObject TargetObj;

    public Image healthBarImage;
    private Image healthBar;

    void Start () 
    {
        healthBar = healthBarImage.GetComponent<Image>();

        TargetObj = target.transform.gameObject;
        countT = 1;

        //Plane_B_script = GameObject.Find("Plane").GetComponent<Plane_Brain>();
        Plane_B_script = plane.GetComponent<Plane_Brain>();
        Base_script = TargetObj.GetComponent<BDefender>();
    }
	

	// Update is called once per frame
	void Update () 
    {
        //if -- target.transform.hasChanged
        if (TargetObj == null && (GameObject.FindWithTag("Defender"))  )
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



    public void TurretDamage(double ammount, ref bool death)
    {
        health -= ammount;

        healthBar.fillAmount = (float)(health / maxHealth);

        if (health < 1)
        {
            Plane_B_script.KillCountUp();
            Destroy(this);
            //Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            death = true;
        }
        //Debug.Log("Damage Applied!");
    }



    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Defender")
        {

            Debug.Log("BASE COLIDE !!!!!!!");

            damageSound.Play();

            Base_script.AttackerDMG(DPSO);


            BDefender _hitDamage = target.GetComponent<BDefender>();
            health -= _hitDamage.DPSO;
            if (health < 1)
            {
                //Plane_B_script.KillCountUp();   no need since base kills dont count
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
