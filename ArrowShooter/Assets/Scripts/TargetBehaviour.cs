using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour {

    void Update()
    {
        ShrinkSize(this.gameObject);
        Destroy(this.gameObject, 2.5f);
    }

   


    void ShrinkSize(GameObject x)
    {
        float ShrinkSpeed = Random.Range(0.1f,2.5f);  
            x.transform.localScale = Vector3.Lerp(transform.localScale,Vector3.zero,ShrinkSpeed * Time.deltaTime) ;
        
    }




    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            GameObject.Find("_UI_Manager").GetComponent<ScoreManager>().Score++;
        }
    }


}
