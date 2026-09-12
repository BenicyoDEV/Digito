using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamposPerseguicao : MonoBehaviour
{
	[SerializeField] private LayerMask passaroLayer;
	public bool campoMedio;
	public bool campoPequeno;
	private float margem;
	
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posCampo = transform.position + (Vector3.up * 5f); 
    
    	campoMedio = Physics.CheckSphere(posCampo, 6f, passaroLayer);
    	
    	campoPequeno = Physics.CheckSphere(posCampo, 5.5f, passaroLayer);
    }
    
    void OnDrawGizmos ()
    {
    Vector3 posCampo = transform.position + (Vector3.up * 5f);
    
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(posCampo, 6f);
    
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(posCampo, 5.5f);
    }
    
}
