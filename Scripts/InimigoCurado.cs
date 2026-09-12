using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoCurado : MonoBehaviour, IProgramavel
{

[SerializeField] private GameObject inimigo;
private InimigoCuradoOrb orb;

    // Start is called before the first frame update
    void Start()
    {
        orb = inimigo.GetComponent<InimigoCuradoOrb>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    	 public void RestaurarRegiao()
	 {
	    inimigo.SetActive(true);
	    
	    	    if (orb != null)
	    orb.ResetarEstado();
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
	 
	  public void RestaurarArvores()
	 {
	 
	 }
	 
	 public void CurarInimigos()
	 {
	 	    inimigo.SetActive(true);
	 	    
	    if (orb != null)
	    orb.ResetarEstado();

	 }
	 
	 public void MudarCogumelos(int quantidade)
	 {
	 
	 }
	 
    public void ResetarEstado()
{
StopAllCoroutines();
CancelInvoke();
	    
	    if (orb != null)
	    orb.ResetarEstado();
	    
inimigo.SetActive(false);
}
	 
}
