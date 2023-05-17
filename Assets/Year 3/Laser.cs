using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private float timer;

    private LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {

        timer += Time.deltaTime;
        if(timer >3.5f)
        {
            lr.enabled = !lr.enabled;
            timer = 0f; 
        }

        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        }
        else
        {
            lr.SetPosition(1, transform.forward * 5000);
        }  

      
    }
    private void OnTriggerEnter(Collider other)
    {
        if(lr.enabled == false)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().laserdamage();
        }
    }
}