using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnestismo_Raspberry : MonoBehaviour
{
    private Raspberry_sc raspberry;

    void Start()
    {
        raspberry = GetComponentInParent<Raspberry_sc>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            raspberry.AtivarMagnetismo(other.transform);
        }
    }
}
