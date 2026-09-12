using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergirIlha : MonoBehaviour, IProgramavel
{
private Vector3 destino;

private bool emergindo;

private float subir = 13.5f;

public int idPlat;

public CameraShake cameraShake;

    // Start is called before the first frame update
    void Start()
    {
      destino = transform.position + Vector3.up * subir;  
    }

    // Update is called once per frame
    void Update()
    {
        if(emergindo)
        {
        	 transform.position = Vector3.MoveTowards(transform.position, destino, 2f * Time.deltaTime);
        	 cameraShake.Tremer(3.3f, 3.6f);
        }
        
        if (Vector3.Distance(transform.position, destino) < 0.1f)
        {
        emergindo = false;
        } 
    }
    
    	 public void EmergirIlhaMet1()
	 {
	 	if (idPlat == 1)
		emergindo = true;
	 }
	 
	     	 public void EmergirIlhaMet2()
	 {
	 	 if (idPlat == 2)
		emergindo = true;
	 }
	 
	     	 public void EmergirIlhaMet3()
	 {
	 	if (idPlat == 3)
		emergindo = true;
	 }
	 
	 public void RestaurarRegiao()
	 {
	 
	 }
	 
	 public void DesativarInfestacaoCogumelo()
	 {
	   
	 }
	 
	  public void RestaurarArvores()
	 {
	 
	 }
	 
	 public void CurarInimigos()
	 {
	 
	 }
	 
	 public void MudarCogumelos(int quantidade)
	 {
	 
	 }

    public void ResetarEstado()
{
StopAllCoroutines();
CancelInvoke();

emergindo = false;
}
	 
	 
}
