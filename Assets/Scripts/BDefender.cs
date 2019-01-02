using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BDefender : MonoBehaviour
{

    public double health;
    public double maxHealth;
    public Transform target;
    //public double DPS;
    public double DPSO;
    public Transform HPbar;

    public Image healthBarImage;

    private Vector3 direction;
    //    private double preH;
    private Image healthBar;

    void Start()
    {
        
        healthBar = healthBarImage.GetComponent<Image>();
    }


    public void AttackerDMG(double damage)
    {
        health -= damage;
        //health -= _hitDamageAttacker.DPSO;

        healthBar.fillAmount = (float)(health / maxHealth);

        if (health < 1)
        {
            Destroy(this);
            Destroy(gameObject);

            SceneManager.LoadScene("GameOverBad");
        }
    }





/*
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Attacker")
        {
                BAttacker _hitDamageAttacker = col.gameObject.GetComponent<BAttacker>();
            //preH = health;
            health -= (_hitDamageAttacker.DPSO / 60);
            //health -= _hitDamageAttacker.DPSO;

            healthBar.fillAmount = (float)(health / maxHealth);

            if (health < 1)
            {

                Destroy(this);
                Destroy(gameObject);
            }

        }

    }
    */

}