using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaliDetectaPlayer : MonoBehaviour
{

	private Movimento_inimigo javali;
	public Transform player;
	public bool perseguindo;
	private PainelProgramacao[] paineis;
	public bool algumPainelAtivo = false; 


    // Start is called before the first frame update
    void Start()
    {
    	paineis = FindObjectsOfType<PainelProgramacao>();
       javali = GetComponentInParent<Movimento_inimigo>();
    }

    // Update is called once per frame
    void Update()
    {
    	algumPainelAtivo = false;
        foreach (PainelProgramacao painel in paineis)
        {
        if (painel.programandoPainel)
        {
		algumPainelAtivo = true;
		}
        }
        
        if (perseguindo && algumPainelAtivo)
        {
        perseguindo = false;
        javali.voltandoWayPoint = true;
        }
    }
    
        private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
        {
        perseguindo = true;
        player = other.transform;
        javali.voltandoWayPoint = false;
        }
    }
    
    
      private void OnTriggerExit(Collider other)
    {
         if (other.CompareTag("Player"))
        {
        perseguindo = false;
        javali.voltandoWayPoint = true;
        }
    }
    
    
    public void VerificarJogadorNoRaio()
{
CapsuleCollider capsule = GetComponent<CapsuleCollider>();
float raio = capsule.radius * transform.lossyScale.x;
Collider[] hits = Physics.OverlapSphere( transform.position, raio);

foreach (Collider hit in hits)
{
if (hit.CompareTag("Player"))
{
perseguindo = true;
player = hit.transform;
javali.voltandoWayPoint = false;
return;
}
}
perseguindo = false;
player = null;
}

}
