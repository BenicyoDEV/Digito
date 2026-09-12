using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteVector : MonoBehaviour
{
	private Vector3 translate;
	
    // Start is called before the first frame update
    void Start()
    {
        translate = new Vector3(1f, 1F, 1);
        transform.position += translate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
