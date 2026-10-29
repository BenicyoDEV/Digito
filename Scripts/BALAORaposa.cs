using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BALAORaposa : MonoBehaviour
{
	private Transform jogador;
	[SerializeField] private GameObject balao;
	[SerializeField] private TMPro.TextMeshPro dialogo3d;
	private float tempo;
public bool estaNaAreaBalao;   
private BalaoDialogoJogador digito;
	public bool balaoAtivado;
	
	public bool instrucaoUm;
	
	public int idRaposa;
	
	private Raposa raposa;
	
	private PainelProgramacao painel;
	
	public bool dialogueDenovo = false;
	
	public bool semPainel = false;
	
	public bool falaLivre;
	public bool fala1;
	public bool fala2;
	public bool fala3;
	
	
	bool estabeleceuPosicao = false;
	
	public bool jaSpawna = false;
	
[SerializeField] public Collider colisao1;
[SerializeField] public Collider colisao2;
[SerializeField] public Collider colisaoTriggerOrb;

	public bool falarUmaVez;
	bool podeFalarOutraVez = true;
	

public int falaNova; // 0 = nenhuma, 1/2/3 = fala que acabou de ser dita


	
    // Start is called before the first frame update
    void Start()
    {   
    	podeFalarOutraVez = true;
        raposa = GetComponentInParent<Raposa>();
        digito = FindObjectOfType<BalaoDialogoJogador>(true);
        
        if (!semPainel)
{
    painel = GetComponentInParent<PainelProgramacao>();
}

        jogador = GameObject.FindGameObjectWithTag("Camera").transform;
        
  tempo = CalcularTempoInicial();
   
   
   if (jaSpawna)
   estabeleceuPosicao = true;
   
 
    }

    // Update is called once per frame
    void Update()
    {
        if (raposa.escondendo || !estabeleceuPosicao)
        {
        colisao1.enabled = false;
        colisao2.enabled = false;
        }
        
        if (!raposa.escondendo && estabeleceuPosicao)
        {
        colisao1.enabled = true;
        colisao2.enabled = true;
        }
    
    
    
        Vector3 direcao = jogador.position - transform.position;
        direcao.y = 0;
        transform.forward = direcao;
        
        
if (!falaLivre && podeFalarOutraVez)
{

if (semPainel || (painel != null && !painel.painelResolvido)) 
{
        tempo -= Time.deltaTime;
        
        			 if (tempo <= 196)
        			{
       				 estabeleceuPosicao = true;
      			    }

        
        if (tempo > 120f && tempo < 194f)
        {
        	if (!balaoAtivado && !instrucaoUm)
        	{
        	BalaoInstrucaoUm();
        

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
        
        if (falarUmaVez)
podeFalarOutraVez = false;
        
        }
}
else
{
DesativarInstrucao();
}
     

      
        
}
else if (podeFalarOutraVez)
{
//////////se a fala for livre

        tempo -= Time.deltaTime;
        
                if (tempo <= 36)
        {
        estabeleceuPosicao = true;
        }

        
        if (tempo > 31.9f && tempo < 40f)
        {
        	if (!balaoAtivado && !fala1 && !fala2 && !fala3)
        	{
        	BalaoFala1();
        	

        	}
        }
        else if (tempo <= 31.9f && tempo > 25.8f)
        {
            if (fala1 && !fala2 && !fala3)
        	{
        	BalaoFala2();
        	}
        }
        else if (tempo <= 25.8f && tempo > 17.7f)
        {
            if (fala1 && fala2 && !fala3)
        	{
        	BalaoFala3();
        	}
        }
        else if (tempo <= 17)
        {
        	fala1 = false;
        	fala2 = false;
        	fala3 = false;
        	DesativarInstrucao();
        }
        	    
        if (tempo <= 0f)
        {
        tempo =43.8f;
        
        if (falarUmaVez)
podeFalarOutraVez = false;
        }
        

        
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


    void BalaoFala1()
    {
        AudioManager.instancia.SomBalao();
    	balaoAtivado = true;
    	fala1 = true;
    	if (estaNaAreaBalao && digito != null)
    digito.ResponderFalaLivre(this, 1);   // N = 1, 2 ou 3

		if (idRaposa == 1)
    	{
    	dialogo3d.text = "Forasteiro, oque te trás aqui no meu mundo?";
    	}
    	else if (idRaposa == 2)
    	{
    	dialogo3d.text = "Dígito, esta folha se chama Script.";
    	}
    }
    
        void BalaoFala2()
    {
        AudioManager.instancia.SomBalao();
    	balaoAtivado = true;
    	fala2 = true;
    	if (estaNaAreaBalao && digito != null)
    digito.ResponderFalaLivre(this, 2);   // N = 1, 2 ou 3

		if (idRaposa == 1)
    	{
    	dialogo3d.text = "Finalmente um herói! Meu mundo está infestado por cogumelos.";
    	}
    	else if (idRaposa == 2)
    	{
    	dialogo3d.text = "ela te dará instruções e te mostrará como prosseguir.";
    	}
    }
    
        void BalaoFala3()
    {
        AudioManager.instancia.SomBalao();
    	balaoAtivado = true;
    	fala3 = true;
    	if (estaNaAreaBalao && digito != null)
    digito.ResponderFalaLivre(this, 3);   // N = 1, 2 ou 3
		
		if (idRaposa == 1)
    	{
    	dialogo3d.text = "Muito obrigado, herói Dígito.";
    	}
    	else if (idRaposa == 2)
    	{
    	dialogo3d.text = "Acesse ela no seu menu de scripts.";
    	}
    }
    
    
    
    
        void BalaoInstrucaoUm()
    {
    	AudioManager.instancia.SomBalao();
    	balaoAtivado = true;
    	instrucaoUm = true;

    	if (idRaposa == 3)
    	{
    	dialogo3d.text = "Parece que a condição está sendo falsa...";
    	}
    	/*else if (idRaposa == 2)
    	{
    	dialogo3d.text = "id2";
    	}*/

    }
   
    
        void BalaoInstrucaoDois()
    {
    	AudioManager.instancia.SomBalao();
    	balaoAtivado = true;
    	instrucaoUm = false;

    	if (idRaposa == 3)
    	{
    	dialogo3d.text = "E se ao invés de \"maior que\" fosse \"menor que\"?";
    	}
    	/*else if (idRaposa == 2)
    	{
    	dialogo3d.text = "id2 2";
    	}*/

    }
    
    	void DesativarInstrucao()
    {
    	balaoAtivado = false;
    }
    
    private float CalcularTempoInicial()
{
    if (falaLivre && idRaposa == 1) return 43.8f;
    if (falaLivre) return 40.0f;
    return 200f;
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
            estabeleceuPosicao = false;
        }   
    }
    
    
    public void ResetarEstado()
{
    tempo = CalcularTempoInicial();

    balaoAtivado = false;
    instrucaoUm = false;
    dialogueDenovo = false;
    fala1 = false;
    fala2 = false;
    fala3 = false;
    falaNova = 0;

    estaNaAreaBalao = false;
    podeFalarOutraVez = true;
    estabeleceuPosicao = jaSpawna;

    if (colisao1 != null) colisao1.enabled = false;
    if (colisao2 != null) colisao2.enabled = false;
    if (colisaoTriggerOrb != null) colisaoTriggerOrb.enabled = false;

    if (balao != null) balao.SetActive(false);
}

    
    
}
