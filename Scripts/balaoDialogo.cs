using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;

public class balaoDialogo : MonoBehaviour
{
	private Transform jogador;
	[SerializeField] private GameObject balao;
	[SerializeField] private TMPro.TextMeshPro dialogo3d;
	private float tempo;
	private bool estaNaAreaBalao;
	public bool balaoAtivado;
	public int idDialogo;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Camera").transform;
        tempo = 20f;
    }
    
    void LateUpdate()
    {
        Vector3 direcao = jogador.position - transform.position;
        direcao.y = 0;
        transform.forward = direcao;
    }

    // Update is called once per frame
    void Update()
    {
        tempo -= Time.deltaTime;
        if (tempo >= 7.5f)
        {
        	if (!balaoAtivado)
        	AtivarBalao();
        }
        else
        {
        	if (balaoAtivado)
        	DesativarBalao();
        }      
        if (tempo <= 0f)
        {
        tempo = 20f;
        }
        
        
        if (estaNaAreaBalao)
        {
        if (balaoAtivado)
        balao.SetActive(true);
        else
        balao.SetActive(false); 
        }
        else
        {
        balao.SetActive(false); 
        }
    }
    
    
    void AtivarBalao()
    {
    	balaoAtivado = true;
    	
    	
    	int numero = Random.Range(1, 13);
    	
    	if (numero == 1)
    	{
    	idDialogo = 1;
    	dialogo3d.text = "Brigadão por me salvar!!";
    	}
    	else if (numero == 2)
    	{
    	idDialogo = 2;
    	dialogo3d.text = "Pera... eu tava tentando te comer? Foi mal aí";
    	}
    	else if (numero == 3)
    	{
    	idDialogo = 3;
    	dialogo3d.text = "Ué, por que eu tava correndo atrás de você mesmo?";
    	}
        else if (numero == 4)
        {
        idDialogo = 4;
    	dialogo3d.text = "Você me curou?! Valeu! ...Mas não encosta em mim.";
    	}
    	else if (numero == 5)
    	{
    	idDialogo = 5;
    	dialogo3d.text = "Cê me salvou? Tu é O CARA.";
    	}
    	else if (numero == 6)
    	{
    	idDialogo = 6;
    	dialogo3d.text = "Cara... eu tava com um bug muito feio.";
    	}
    	else if (numero == 7)
    	{
    	idDialogo = 7;
    	dialogo3d.text = "Valeu aí, robô. Agora sai daqui antes que eu mude de ideia.";
    	}
    	else if (numero == 8)
    	{
    	idDialogo = 8;
    	dialogo3d.text = "Vocẽ demorou, hein? Eu já tava começando a gostar de ser vilão.";
    	}
    	else if (numero == 9)
    	{
    	idDialogo = 9;
    	dialogo3d.text = "Tá, tá... obrigado. Mas não espera um abraço.";
    	}
        else if (numero == 10)
        {
        idDialogo = 10;
    	dialogo3d.text = "Ufa, ainda bem que você me salvou!";
    	}
    	else if (numero == 11)
    	{
    	idDialogo = 11;
    	dialogo3d.text = "Obrigado, robô!";
    	}
    	else if (numero == 12)
    	{
    	idDialogo = 12;
    	dialogo3d.text = "Mais um pouco infectado e eu ia falar mal desse jogo.";
    	}
    }
    
    void DesativarBalao()
    {
    	balaoAtivado = false;
    }
    
    
        private void OnTriggerEnter(Collider other) //entrou na area
    {
        if (other.CompareTag("Player") )
        {
           estaNaAreaBalao = true;
        }   
    }
    
       private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaNaAreaBalao = false;
        }   
    }
    
}
