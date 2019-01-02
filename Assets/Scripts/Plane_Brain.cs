using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Plane_Brain : MonoBehaviour
{
    public int start_money;

    public AudioSource song;

    public string nextScene;
    public Text kills;
    public Text timeNum;
    public Text spawnCount;
    public Text moneyCount;
    public Text turretCount;
    public Text killGoalNum;
    public int turretCost;
    public int killGoal;


    private int k_count;
    public float time_count;
    //private int spawn_count;
    private int money_count;


    public bool T1Press;
    public bool T2Press;

    public GameObject objectToinstantiate1;
    public GameObject objectToinstantiate2;


    // Use this for initialization
    void Start()
    {
        T1Press = false;
        T2Press = false;

      //  spawnCount.text = ""; //add spawn number or goal

        time_count = Time.time;
        timeNum.text = Math.Round(time_count, 2).ToString();

        turretCount.text = turretCost.ToString();

        money_count = start_money;
        moneyCount.text = money_count.ToString();

        killGoalNum.text = "Kill Goal: " + killGoal.ToString();

        k_count = 0;
        kills.text = "Kills Count: " + k_count.ToString();

        //need code with spawner to count enemies     


    }

    void Update()
    {
        if(k_count >= killGoal )
        {
            SceneManager.LoadScene(nextScene);
        }


        //KEEP UPDATING THE GAME TIME
        time_count = Time.time;
        timeNum.text = Math.Round(time_count, 2).ToString();



            Ray myRay;      // initializing the ray
            RaycastHit hit; // initializing the raycasthit
            myRay = Camera.main.ScreenPointToRay(Input.mousePosition); // telling my ray variable that the ray will go from the center of 

            if (Physics.Raycast(myRay, out hit))
            { // here I ask : if myRay hits something, store all the info you can find in the raycasthit varible.
                if (Input.GetMouseButtonDown(0))
                {// what to do if i press the left mouse button
                //GameObject temp = hit.collider.gameObject;
                //Debug.LogError("OUR HIT TAG:  " + temp.tag); 
                if ((T1Press == true || T2Press == true) && hit.collider.gameObject.tag != "Turret" && hit.collider.gameObject.tag != "Plane")
                {
                    Debug.Log("[tag]" + hit.collider.gameObject.tag);
                    if (money_count >= turretCost)
                    {
                        Vector3 blockTop = hit.collider.gameObject.transform.position;
                        blockTop.y += .20f;

                        if (T1Press == true)
                        {
                            Instantiate(objectToinstantiate1, blockTop, Quaternion.identity);// instatiate a prefab on the position where the ray hits the floor.
                        }
                        else if (T2Press == true)
                        {
                            Instantiate(objectToinstantiate2, blockTop, Quaternion.identity);// instatiate a prefab on the position where the ray hits the floor.
                        }

                        Debug.Log(hit.point);// debugs the vector3 of the position where I clicked

                        money_count -= turretCost;
                        moneyCount.text = money_count.ToString();
                    }
                    else
                    {
                        moneyCount.color = Color.red;

                    }
                    T1Press = false;
                    T2Press = false;
                } //end of t1press if
                }// end upMousebutton
            }// end physics.raycast
          

    }// end Update method

    public void KillCountUp()
    {
        Debug.Log("Kill Called");

        k_count++;
        kills.text = "Kills Count: " + k_count.ToString();

        money_count += 2;
        moneyCount.text = money_count.ToString();

        moneyCount.color = Color.yellow;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void Turret1Place()
    {
        T1Press = true;
    }

    public void Turret2Place()
    {
        T2Press = true;
    }
}