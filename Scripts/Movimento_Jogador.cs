using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;


public class Movimento_Jogador : MonoBehaviour
{

	public CharacterController controller;	
	private Transform myCamera;
	public Animator animator;
	
	[SerializeField] private TransicaoIris transicao;
	private bool fazendoTransicao = false;
	
	private bool estaNoChao;
	private bool estavaCaindo;
	[SerializeField] private Transform peDoPersonagem;
	[SerializeField] private LayerMask colisaoLayer;
	
	private float forcaY;
	private int pulosRestantes;
	
	public bool rVisivel = true;
	private bool ocultarFinal;
		
		
	public Image imagemRaspberry;
	public TextMeshProUGUI textoRaspberry;
	public int QuantidadeRaspberrys = 0;
	
	public TextMeshProUGUI textoVida;
	public int QuantidadeVidas = 5;
	
	private int dano = 0;
	public bool invencivel;
	
	public Image imgcabecadigitodano;
	
	Vector3 knockback;
	
	    private Holograma holograma;
	    
	    private CheckPoint checkpoint;
	    private ZonaReset zona;
	    
	    public float tempoParado = 0f;
	    
	    public float forcaMovimento = 0f;
	    
	    


	
	
    // Start is called before the first frame update
    void Start()
    {
       holograma = GetComponentInParent<Holograma>();
       checkpoint = FindObjectOfType<CheckPoint>();
              zona = FindObjectOfType<ZonaReset>();
    
        controller = GetComponent<CharacterController>();
        myCamera = Camera.main.transform;
        animator = GetComponent<Animator>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        imgcabecadigitodano.color = new Color(1f, 1f, 1f, 0f);
 
        	AtualizarHUD();
        	dano = 0;
        	invencivel = false;
        	
	
       
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool caindoAgora = !estaNoChao && forcaY < 0;
        
        tempoParado += Time.deltaTime;
        
        if (tempoParado >= 20)
        {
        animator.SetTrigger("Dancou");
        tempoParado = -20;
        }
         
                
        //estaNoChao = Physics.CheckSphere(peDoPersonagem.position, 0.5f, colisaoLayer);
   
        RaycastHit hit;
estaNoChao = Physics.SphereCast(peDoPersonagem.position,0.4f,Vector3.down,out hit, 0.6f, colisaoLayer);
	
        
        
        if (caindoAgora && !estavaCaindo)
        {
        animator.SetTrigger("IniciarQueda");
        tempoParado = 0f;
        }
        
        animator.SetBool("Caindo", caindoAgora);
        
        estavaCaindo = caindoAgora;
        
        
if (estaNoChao && forcaY <= 0f)
{
pulosRestantes = 2;
}
        
 
        
        Vector3 forward = myCamera.forward;
        Vector3 right = myCamera.right;
        
        forward.y = 0;
        right.y = 0;
        
        forward.Normalize();
        right.Normalize();
        
  	Vector3 movimento = forward * vertical + right * horizontal;
  	
  	movimento = Vector3.ClampMagnitude(movimento, 1f);
        
        //controller.Move(movimento * Time.deltaTime * 8);
        
        Vector3 movimentoFinal = movimento + knockback;
        
        controller.Move(movimentoFinal * Time.deltaTime * (8+forcaMovimento));
        
        knockback = Vector3.Lerp(knockback, Vector3.zero, Time.deltaTime * 5f);
        
        
        if(movimento != Vector3.zero)
        {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimento), Time.deltaTime * 10);
        tempoParado = 0f;
        forcaMovimento += (0.5f * Time.deltaTime);
        if (forcaMovimento > 4)
        {
        forcaMovimento = 4;
        }
        
        }
        else
        forcaMovimento = 0f;
        
        animator.SetBool("Mover", movimento != Vector3.zero);


        animator.SetBool("EstaNoChao", estaNoChao);
        

        if (holograma.modoProgramacao == false)
        {
        if(Input.GetKeyDown(KeyCode.Space) && pulosRestantes > 0)
        {	
      	Saltar();
        }
        }


	if (!estaNoChao)
	{
		animator.SetBool("EstaNoChao", estaNoChao);
		tempoParado = 0f;
	}
	
	
	
	if (!estaNoChao)
        {
        	if (forcaY < 0)
       		{
        	animator.SetBool("Caindo", true);
        	}
        	else
       		{
        	animator.SetBool("Caindo", false);
        	}
        	
        }
        else
        {
        animator.SetBool("Caindo", false);
        }
        
        
	

        if(forcaY > -20)
        {
        forcaY += -20 * Time.deltaTime;
        }
        controller.Move(new Vector3(0, forcaY, 0) * Time.deltaTime);
        estavaCaindo = caindoAgora;
 
 
 

     
     if (dano >= 2)
     {
     QuantidadeVidas--;
     AtualizarHUD();
     dano = 0;
     Debug.Log("Morreu :c");
     QuantidadeRaspberrys = 0;

if (!fazendoTransicao)
StartCoroutine(TransicaoMorte()); //////////////////
     }
 
     if (dano > 0)
    {
    imgcabecadigitodano.color = new Color(1f, 1f, 1f);
    }
    else
    {
        imgcabecadigitodano.color = new Color(1f, 1f, 1f, 0f);
    }
    
    
    if (rVisivel)
{
CancelInvoke(nameof(OcultarRaspberry1));
MostrarRaspberry();
ocultarFinal = false;
}

if (ocultarFinal)
{
OcultarRaspberry2();
}




}




	public void Saltar()
	{
	pulosRestantes = (pulosRestantes -1);
      	forcaY = 9f;
      	animator.SetTrigger("Saltar");
	}

	public void levarDano(Vector3 direcao)
	{
	dano++;
	knockback = direcao * 4f;
	animator.SetTrigger("LevouDano");
	
	
	Vector3 olhar = -direcao;
	olhar.y = 0;
	transform.rotation = Quaternion.LookRotation(olhar);
	
	if (dano == 1)
	{
        StartCoroutine(ResetarDano());
        invencivel = true;
        StartCoroutine(Invencibilidade());

        
  
        Debug.Log("invencivel e regenerando");
        }
        
        
	}


    IEnumerator ResetarDano()
     {
     yield return new WaitForSeconds(8f);
     dano = 0;
     Debug.Log("Não-Machucado :3");
     }
     
     
     
    IEnumerator Invencibilidade()
     {
     yield return new WaitForSeconds(0.30f);
     invencivel = false;
     }
    
    
     
     
     public void levarDanoForte()
     {
     dano = 10;
     }
     

     public void AtualizarHUD()
{
if (QuantidadeRaspberrys > 99)
     {
     QuantidadeRaspberrys = 0;
     QuantidadeVidas++;
     
     Debug.Log("+1 de vida :D");
    
    
     }

textoRaspberry.text = "x " + QuantidadeRaspberrys;
textoVida.text = "x " + QuantidadeVidas;

}

/*public void OcultarRaspberry()
{
imagemRaspberry.rectTransform.anchoredPosition = new Vector2(-5, 200);
textoRaspberry.rectTransform.anchoredPosition = new Vector2(185, 170);
}
*/

public void MostrarRaspberry()
{
imagemRaspberry.rectTransform.anchoredPosition = new Vector2(-5, 0);
textoRaspberry.rectTransform.anchoredPosition = new Vector2(185, -30);

Invoke(nameof(OcultarRaspberry1), 2.5f);
rVisivel = false;
}


//estrutura MoveTowards: Vector3.MoveTowards(posicaoAtual, posicaoAlvo, velocidade * Time.deltaTime);
public void OcultarRaspberry1()
{ 
ocultarFinal = true;
}

public void OcultarRaspberry2()
{
imagemRaspberry.rectTransform.anchoredPosition = Vector2.MoveTowards(
imagemRaspberry.rectTransform.anchoredPosition,
 new Vector2(-5, 100),
180f * Time.unscaledDeltaTime);

textoRaspberry.rectTransform.anchoredPosition = Vector2.MoveTowards(
textoRaspberry.rectTransform.anchoredPosition,
 new Vector2(185, 70),
180f * Time.unscaledDeltaTime);
}

/*
public void MostrarRaspberry()
{
imagemRaspberry.rectTransform.anchoredPosition = Vector2.MoveTowards(
    imagemRaspberry.rectTransform.anchoredPosition,
    new Vector2(-5, 0),
    100f * Time.deltaTime);

textoRaspberry.rectTransform.anchoredPosition = Vector2.MoveTowards(
textoRaspberry.rectTransform.anchoredPosition,
 new Vector2(185, -30),
100f * Time.deltaTime);

Invoke(nameof(OcultarRaspberry1), 5.5f);
rVisivel = false;
}
*/

private IEnumerator TransicaoMorte()
{

fazendoTransicao = true;

yield return StartCoroutine(transicao.FecharAbrir(
() =>
{

//reset   
     foreach (var zona in CheckPoint.zonasAtuais)
     {
     zona.ResetarZona(); //resetar zona de acordo com cada zona atual
     }
     checkpoint.Respawn();
	 ResetarJogador();
}));

fazendoTransicao = false;
}


public void ResetarJogador()
{
    dano = 0;
    invencivel = false;
    knockback = Vector3.zero;
    forcaY = 0f;
    pulosRestantes = 1;

    imgcabecadigitodano.color = new Color(1f, 1f, 1f, 0f);

    StopCoroutine(nameof(ResetarDano));
    StopCoroutine(nameof(Invencibilidade));
    
    tempoParado = 0f;
	forcaMovimento = 0f;
	    
    
    
    
        BalaoDialogoJogador balaoDialogoJogador = GetComponentInChildren<BalaoDialogoJogador>(true);
        if (balaoDialogoJogador != null)
        {
        balaoDialogoJogador.ResetarEstado();
        }
}

 
}
