using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMagnetismo : MonoBehaviour
{
private Script script;

    // Start is called before the first frame update
    void Start()
    {
        script = GetComponentInParent<Script>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            script.AtivarMagnetismo(other.transform);
        }
    }
}
