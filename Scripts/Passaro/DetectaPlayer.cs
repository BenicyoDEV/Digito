using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaPlayer : MonoBehaviour
{
	public bool perseguindo;
	private Movimento_passaro passaro;
	public Transform player; //referencia para o player
	
		private PainelProgramacao[] paineis;
	public bool algumPainelAtivo = false; 
    // Start is called before the first frame update
    void Start()
    {
         passaro = GetComponentInParent<Movimento_passaro>();
             	paineis = FindObjectsOfType<PainelProgramacao>();
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
        passaro.voltandoWayPoint = true;
        }
    }
    
      private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
        {
        perseguindo = true;
        player = other.transform;
        //passaro.voltandoWayPoint = false;
        }
    }
    
      private void OnTriggerExit(Collider other)
    {
         if (other.CompareTag("Player"))
        {
        perseguindo = false;
       passaro.voltandoWayPoint = true;
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
passaro.voltandoWayPoint = false;
return;
}
}
perseguindo = false;
player = null;
}

    
}
