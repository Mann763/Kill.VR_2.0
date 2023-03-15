using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(LineRenderer))]
public class LaserSight : MonoBehaviour
{
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit))
        {
            if (hit.collider.tag == "Enemy")
            {
                lr.SetPosition(1, new Vector3(0, 0, hit.distance));
            }
            
        }
        else
        {
            lr.SetPosition(1, new Vector3(0, 0, 5000));
        }
    }

    public void LaserOn()
    {
        this.gameObject.SetActive(true);
    }
    public void LaserOff()
    {
        this.gameObject.SetActive(false);
    }
}
