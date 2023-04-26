using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    public BBDGuards guard;
    private MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var targetPosition = guard.SetNextTarget();
            
            //Check nextTarget is its current position
            var x = Mathf.Approximately(transform.position.x, targetPosition.x);
            var z = Mathf.Approximately(transform.position.z, targetPosition.z);
            if (x && z)
            {
                guard.SetNextTarget();
            }
        }
    }
}
