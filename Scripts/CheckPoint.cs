using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
public int idCheck;
public static int checkAtual;
[SerializeField] GameObject spawn1;
[SerializeField] GameObject spawn2;
[SerializeField] GameObject spawn3;
[SerializeField] GameObject spawn4;

[SerializeField] private ZonaReset[] zonasParaResetar;

public static ZonaReset[] zonasAtuais;

public LayerMask playerLayer;
private Movimento_Jogador jogador;


    // Start is called before the first frame update
    void Start()
    {
         jogador = FindObjectOfType<Movimento_Jogador>();
    }

    // Update is called once per frame
    void Update()
    {
    	

    }
    
        private void OnTriggerEnter(Collider other) //entrou na area do painel
    {
    
        if (other.CompareTag("Player"))
        {
          if (idCheck > checkAtual)
          {
          checkAtual = idCheck;
          zonasAtuais = zonasParaResetar;
          Debug.Log("CheckPoint Atual: "+idCheck);
          }
        }   
        
    }
    
    public void Respawn()
    {
	        if (checkAtual == 1)
        {
		jogador.transform.position = spawn1.transform.position;
        }
        
       	        if (checkAtual == 2)
        {
		jogador.transform.position = spawn2.transform.position;
        }
        
       	        if (checkAtual == 3)
        {
		jogador.transform.position = spawn3.transform.position;
        }
        
       	        if (checkAtual == 4)
        {
		jogador.transform.position = spawn4.transform.position;
        }
    }
    
}
