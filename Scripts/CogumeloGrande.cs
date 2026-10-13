using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogumeloGrande : MonoBehaviour, IProgramavel
{

[SerializeField] private GameObject paredeCogumelo;

private Vector3 posicaoInicial;
private Vector3 posicaoEscondida;

private bool descendo = false;

private float distancia = 15f;
private float velocidade = 4f;

    // Start is called before the first frame update
    void Start()
    {
    posicaoInicial = transform.position;
    posicaoEscondida = posicaoInicial + Vector3.down * distancia;
    }

    // Update is called once per frame
    void Update()
    {
    if (descendo)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            posicaoEscondida,
            velocidade * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, posicaoEscondida) < 0.01f)
        {
            gameObject.SetActive(false);
        }
    }
    }
    
    	 public void RestaurarRegiao()
	 {
	        descendo = true;
	 }
	 
	 public void DesativarInfestacaoCogumelo()
	 {
	        descendo = true;
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
	 
	 }
	 
	 public void MudarCogumelos(int quantidade)
	 {
	 
	 }
	 
	     public void ResetarEstado()
{
StopAllCoroutines();
CancelInvoke();

descendo = false;
gameObject.SetActive(true);
transform.position = posicaoInicial;
}
	 
	 
	 
}
