using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BALAORaposa : MonoBehaviour
{
	private Transform jogador;
	[SerializeField] private GameObject balao;
	[SerializeField] private TMPro.TextMeshPro dialogo3d;
	private float tempo;
	private bool estaNaAreaBalao;
	public bool balaoAtivado;
	
	public bool instrucaoUm;
	
	public int idRaposa;
	
	private Raposa raposa;
	
	private PainelProgramacao painel;
	
	public bool dialogueDenovo = false;
	
[SerializeField] public Collider colisao1;
[SerializeField] public Collider colisao2;
[SerializeField] public Collider colisaoTriggerOrb;
	
    // Start is called before the first frame update
    void Start()
    {   
        raposa = GetComponentInParent<Raposa>();
        painel = GetComponentInParent<PainelProgramacao>();
        jogador = GameObject.FindGameObjectWithTag("Camera").transform;
        tempo = 200f;
        
        
         colisao1.enabled = false;
        colisao2.enabled = false;
        colisaoTriggerOrb.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direcao = jogador.position - transform.position;
        direcao.y = 0;
        transform.forward = direcao;
      
if (!painel.painelResolvido)   
{
        tempo -= Time.deltaTime;
        if (tempo > 120f && tempo < 194f)
        {
        	if (!balaoAtivado && !instrucaoUm)
        	{
        	BalaoInstrucaoUm();
        	
        colisao1.enabled = true;
        colisao2.enabled = true;
        colisaoTriggerOrb.enabled = true; //sei q chegou, ent ativo
        	}
        }
        else if (tempo <= 120 && tempo > 10)
        {
        	if (instrucaoUm)
        	{
        	dialogueDenovo = true;
        	BalaoInstrucaoDois();
        	}
        }
        else if (tempo <= 10)
        {
        	instrucaoUm = false;
        	DesativarInstrucao();
        }
        	    
        if (tempo <= 0f)
        {
        tempo = 200f;
        }
}
else
{
instrucaoUm = false;
DesativarInstrucao();
}
        
        
        if (estaNaAreaBalao  && !raposa.escondendo)
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
    
        void BalaoInstrucaoUm()
    {
    	balaoAtivado = true;
    	instrucaoUm = true;

    	if (idRaposa == 1)
    	{
    	dialogo3d.text = "id1";
    	}
    	else if (idRaposa == 2)
    	{
    	dialogo3d.text = "id2";
    	}

    }
    
        void BalaoInstrucaoDois()
    {
    	balaoAtivado = true;
    	instrucaoUm = false;

    	if (idRaposa == 1)
    	{
    	dialogo3d.text = "id1 2";
    	}
    	else if (idRaposa == 2)
    	{
    	dialogo3d.text = "id2 2";
    	}

    }
    
    	void DesativarInstrucao()
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

