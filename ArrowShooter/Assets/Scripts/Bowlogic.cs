using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowlogic : MonoBehaviour {

    [SerializeField]
    private float RotSpeed;

    [HideInInspector]
    public Vector2 Dir
    {
        get { return (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized; }
    }

    public GameObject ArrowPrefab;

    [SerializeField]
    private float ShootPower;

    void Update()
    {
        RotateBow();
        if (Input.GetButtonUp("Fire1"))
            Shoot();
    }



    void RotateBow()
    {
        // Calculate the angle and never forget to convert it to degrees with Mathf.Rad2Deg
        float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;


        //create a quaternion to express the rotation that we want 
        Quaternion rot = Quaternion.AngleAxis(angle - 180f, Vector3.forward);

        //feeding the rotation that we created to our Bow
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * RotSpeed);
    }

    public void Shoot()
    {
        GameObject GO = Instantiate(ArrowPrefab, GameObject.Find("Arrow").transform.position, transform.rotation);
        GO.AddComponent(typeof(Rigidbody2D));
        GO.GetComponent<Rigidbody2D>().gravityScale = 0f;
        GO.GetComponent<Rigidbody2D>().velocity = Dir.normalized * ShootPower;
    }


}
