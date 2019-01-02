using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {
    public GameObject[] Enemies;
    public GameObject parentObj;
    //public GameObject Enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop; //can use this in while loop as !stop


   // public Text spawnCount;
    //private int spawn_count;

    int RandomEnemy;

	// Use this for initialization
	void Start () {
        
        StartCoroutine(Spawner());
        

    }
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
	}
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startWait);//wait amount of time

        while(true)
        {
            RandomEnemy = Random.Range(0, 2);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            var newEnemy = Instantiate(Enemies[RandomEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            newEnemy.transform.parent = parentObj.transform;

            

            yield return new WaitForSeconds(spawnWait);
        }

    }
}
