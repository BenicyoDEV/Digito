using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArvoreAnimacao : MonoBehaviour, IProgramavel
{
private UnityEngine.Animator anim;

public float variacaoVida;
public bool boolVida = false;
public bool boolVidaInicial;
[SerializeField] public Collider colisaoTrigger;
[SerializeField] public Collider colisaoTriggerViva;
[SerializeField] public GameObject raspRecompensa;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<UnityEngine.Animator>();
        anim.SetFloat("variacaoVida", variacaoVida);
        
          if (raspRecompensa != null)
	 {
	 raspRecompensa.SetActive(false);
	 }
	 
	 boolVidaInicial = boolVida;
    }

    // Update is called once per frame
    void Update()
    {
	if (boolVida)
	{
	 anim.SetBool("estaViva", true);
	 colisaoTrigger.enabled = false;
	 colisaoTriggerViva.enabled = true;
	 
	
	 Invoke(nameof(AparecerRec), 2.82f);
	 
	}
	else
	{
	 anim.SetBool("estaViva", false);
	 colisaoTrigger.enabled = true;
	 colisaoTriggerViva.enabled = false;
	 
	Invoke(nameof(DesaparecerRec), 0.3f);
	  
	}
    }
    
     private void AparecerRec()
	 {
	   if (raspRecompensa != null)
	 {
	 raspRecompensa.SetActive(true);
	 }
	 }
	 
	      private void DesaparecerRec()
	 {
	  
	   if (raspRecompensa != null)
	 {
	 raspRecompensa.SetActive(false);
	 }
	 }
	 
	 public void RestaurarRegiao()
	 {
	 boolVida = true;
	 }
	 
	 public void DesativarInfestacaoCogumelo()
	 {
	   
	 }
	 
    	 public void EmergirIlhaMet1()
	 {

	 }
	 
	     	 public void EmergirIlhaMet2()
	 {
	 
	 }
	 
	     	 public void EmergirIlhaMet3()
	 {

	 }
	 
	 public void CurarInimigos()
	 {
	 
	 }
	 
	 public void RestaurarArvores()
	 {
	 boolVida = true;
	 }
	 
         public void MudarCogumelos(int quantidade)
	 {
	 
	 }
	 
	 public void ResetarEstado()
{
boolVida = boolVidaInicial;
}

    
	 
	 
}
