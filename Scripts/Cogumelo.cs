using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cogumelo : MonoBehaviour, IProgramavel
{
public GameObject[] cogumelos;

private int quantidadeAnterior;
private int quantidadeFora;
private Vector3 alvo;

private Vector3[] alvos;
private bool[] movendo;
private bool[] descendo;

private Vector3[] posicaoOriginal;

private bool[] ativoInicial;

    // Start is called before the first frame update
    void Start()
    {
        cogumelos = new GameObject[transform.childCount];
        
        for (int i = 0; i < transform.childCount; i++)
        {
        cogumelos[i] = transform.GetChild(i).gameObject;
        }
        
        
        
        alvos = new Vector3[cogumelos.Length];
        movendo = new bool[cogumelos.Length];
        
                posicaoOriginal= new Vector3[cogumelos.Length];
                
                ativoInicial = new bool[cogumelos.Length];
                
                for (int i = 0; i < cogumelos.Length; i++)
                {
                ativoInicial[i] = cogumelos[i].activeSelf;
                }
        
        for (int i = 0; i < cogumelos.Length; i++)
        {
        alvos[i] = cogumelos[i].transform.position;
        }

        
        descendo = new bool[cogumelos.Length];
        
        for (int i = 0; i < cogumelos.Length; i++) { posicaoOriginal[i] = cogumelos[i].transform.position; }
        
    }

    // Update is called once per frame
void Update()
{
    for (int i = 0; i < cogumelos.Length; i++)
    {
        if (movendo[i])
        {
            cogumelos[i].transform.position = Vector3.MoveTowards(
                cogumelos[i].transform.position,
                alvos[i],
                2f * Time.deltaTime
            );

            if (Vector3.Distance(cogumelos[i].transform.position, alvos[i]) < 0.01f)
            {
                movendo[i] = false;
                if (descendo[i])
                {
                cogumelos[i].SetActive(false);
                }
            }
        }
    }
}
    
    
public void RestaurarRegiao()
{
    for (int i = 0; i < cogumelos.Length; i++)
    {
        if (cogumelos[i].activeSelf)
        {
            alvos[i] = posicaoOriginal[i];
            movendo[i] = true;
            descendo[i] = true;
        }
    }
}
	 
	 public void DesativarInfestacaoCogumelo()
	 {
	       for (int i = 0; i < cogumelos.Length; i++)
    {
        if (cogumelos[i].activeSelf)
        {
            alvos[i] = posicaoOriginal[i];
            movendo[i] = true;
            descendo[i] = true;
        }
    }
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
	 quantidade = Mathf.Clamp(quantidade, 0, cogumelos.Length);
	 

	 quantidadeFora = quantidade;
	 
	 if (quantidadeAnterior<quantidade)
	 {
	 Aumentou();
	 }
	 else if (quantidadeAnterior>quantidade)
	 {
	 Diminuindo();
	 }
	 
	 quantidadeAnterior = quantidade;
	 }
	 
	 private void Aumentou()
	 {
	 
	 for (int i = quantidadeAnterior; i < quantidadeFora; i++)
	 {
	 cogumelos[i].SetActive(true);
	 alvos[i] = posicaoOriginal[i] + Vector3.up * 1f;
	 movendo[i] = true;
	 descendo[i] = false;
	 }
	 
	 }
	 
	 private void Diminuindo()
	 {
	 
	 for (int i = quantidadeFora; i < quantidadeAnterior; i++)
	 {
	 alvos[i] = posicaoOriginal[i];
	 movendo[i] = true;
	 descendo[i] = true;
	 }
	 
	 }
	 
	 
	 public void ResetarEstado()
	 {
	 StopAllCoroutines();
	 quantidadeAnterior = 0;
	 quantidadeFora = 0;
	 for (int i = 0; i < cogumelos.Length; i++)
	 {
	 cogumelos[i].SetActive(ativoInicial[i]);
	 cogumelos[i].transform.position = posicaoOriginal[i];
	 alvos[i] = posicaoOriginal[i];
	 movendo[i] = false;
	 descendo[i] = false;
	 }
	 }
	 

	 
	 
}
