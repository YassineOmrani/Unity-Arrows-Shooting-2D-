using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour {

    public GameObject Targetprefab;
	
	void Start () {
        StartCoroutine(Spawner());
	}
	

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            transform.position = RandomizePos();
            Spawn();
            
        }
    }

    void Spawn()
    {
        Instantiate(Targetprefab,transform.position,Quaternion.identity);
    }

    Vector3 RandomizePos()
    {
        Vector3 pos = new Vector3(Random.Range(-3f, 3f), Random.Range(1f, 4.3f), 0f);
        return pos;
    }
	
}
