using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento_inimigo : MonoBehaviour
{

	public float speed;
	public float speedPerseguicao = 7f;
	public float speedPatrulha = 3f;
	public float velocidadeDash = 22.5f;
	
	public bool rDash = false;
	
	public float distanciaParede = 3f;
	public float gravidade = 1.75f; 
	
	public bool boolGravidade = true;
	public bool boolMovimento = true;
	private bool bMDA;
	
	public CharacterController controller;
	private Animator animator;
	
	public bool voltandoWayPoint;
	private Transform waypointAlvo; 
	
	public float forcaY;
	private bool estaNoChao;
	private bool chaoFrente;
	private bool paredeFrente;
	
	public bool dandoDash;
	public bool preparandoDash;
	private bool cancelaMovimento;
	public bool preparandoPreparandoDash;
	
	private bool morto; //estado de morto
	
	private Quaternion rotacaoAlvo;
	
	[SerializeField] private Transform PeDoJavali;
	[SerializeField] private Transform DetectaChao;
	[SerializeField] private Transform DetectaParede;
	[SerializeField] private LayerMask WayPointLayer;
	[SerializeField] private LayerMask colisaoLayer;
	[SerializeField] private LayerMask colisaoLayerParede;
	
	//tudo para delisgar colliders
	[SerializeField] public Collider colliderDano;
	[SerializeField] public Collider colliderMorte;
	[SerializeField] public Collider colliderMorte2;
	[SerializeField] public Dano_sc danoScript;
	
	private JavaliDetectaPlayer detector;
	private JavaliDetectaWayPointProximo detectorWaypoint;
	
	//render dele, para faze-lo desaparecer
	[SerializeField] private Material[] materiaisMorto;
	private SkinnedMeshRenderer[] renderJavali;
	private Material[][] materiaisOriginais;
	
	private Vector3 escalaInicial;
	private Quaternion rotacaoInicial; 
	private Color[][] coresIniciais;


    void Start()
    {
 controller = GetComponent<CharacterController>();
 animator = GetComponent<Animator>();
 detector = GetComponentInChildren<JavaliDetectaPlayer>();
 detectorWaypoint = GetComponentInChildren<JavaliDetectaWayPointProximo>();
 rotacaoAlvo = transform.rotation;
 
 //para ele evaporar
 renderJavali = GetComponentsInChildren<SkinnedMeshRenderer>();
for (int r = 0; r < renderJavali.Length; r++)
{
    Material[] mats = renderJavali[r].materials;

    for (int i = 0; i < mats.Length; i++)
    {
        mats[i] = new Material(mats[i]);
    }

    renderJavali[r].materials = mats;
}

escalaInicial = transform.localScale;
rotacaoInicial = transform.rotation;

coresIniciais = new Color[renderJavali.Length][];
for (int r = 0; r < renderJavali.Length; r++)
{
Material[] mats = renderJavali[r].materials;
coresIniciais[r] = new Color[mats.Length];
for (int i = 0; i < mats.Length; i++)
{
coresIniciais[r][i] = mats[i].color;
}
}

materiaisOriginais = new Material[renderJavali.Length][];
for (int r = 0; r < renderJavali.Length; r++)
{
Material[] mats = renderJavali[r].materials;
materiaisOriginais[r] = new Material[mats.Length];
for (int i = 0; i < mats.Length; i++)
{
materiaisOriginais[r][i] = mats[i];
}
}


Patrulha();
    }

    void Update()
{
//estado de morto, se esta, cancela tudo.    
  if (morto)
 {
 return;
 }

 
     if (!boolMovimento)
 {
 animator.speed = 0f;
 }
 else
 {
 animator.speed = 1f;
 }
 
//detecta o chão
	estaNoChao = Physics.CheckSphere(PeDoJavali.position, 0.75f, colisaoLayer);
	
	
//detecta chão a frente
	chaoFrente = Physics.CheckSphere(DetectaChao.position, 0.6f, colisaoLayer);
	
	
//detecta parede a frente
	paredeFrente = Physics.CheckSphere(DetectaParede.position, 0.75f, colisaoLayerParede);

//gravidade
if (boolGravidade)
{
	if (estaNoChao && forcaY < 0)
	{
	forcaY = -2f;
	}
	else
	{
	forcaY += (gravidade * (-1)) * Time.deltaTime;
	forcaY = Mathf.Clamp(forcaY, -20f, 8f); 
	}
}

//rotas
if (boolMovimento)
{
if (!dandoDash && !preparandoDash)
{
 if (detector.perseguindo)
 {
 speed = speedPerseguicao;
 EmPerseguicao();
 }
 else if (voltandoWayPoint)
 {
 speed = speedPatrulha;
 RetornarWayPointProximo();
 }
 else
 {
 speed = speedPatrulha;
 Patrulha();
 }
}
}

//movimento padrao
if (boolMovimento)
{
 if (!cancelaMovimento)
 {
Vector3 movimento = Vector3.zero;
if (chaoFrente)
 {
movimento = transform.forward * speed;
 }
 else
 {
 animator.SetBool("correndo", false);
  animator.SetBool("andando", false);
 }
if (boolGravidade)
{
movimento.y = forcaY;
}
controller.Move(movimento * Time.deltaTime);
}
}

    }
    

    
    private void Patrulha()
    {
    
     		   if (morto)
    {
        return;
    }
    
    if (!boolMovimento)
{
    return;
}

   Vector3 origem = transform.position + (Vector3.up * 0.5f) + (transform.forward * -0.5f); //posição do detector
  
  
   animator.SetBool("correndo", false);
   animator.SetBool("emDash", false);
 animator.SetBool("andando", true);
 
  //detecta waypoint
  RaycastHit hit;
  
  if (Physics.Raycast(origem, transform.forward, out hit, distanciaParede, WayPointLayer)) //se encostar num waypoint entao
  {
rotacaoAlvo = hit.transform.rotation; //ficar na mesma rotação q waypoint
  }
  
  transform.rotation = Quaternion.Slerp(
  transform.rotation,
  rotacaoAlvo,
  Time.deltaTime * 5);
    }


 private void EmPerseguicao()
 {
 if (!boolMovimento)
{
    return;
}
 
  		   if (morto)
    {
        return;
    }
 
  animator.SetBool("andando", false);
      animator.SetBool("emDash", false);
    animator.SetBool("correndo", true);

    
    
    //preparar dash
if (boolMovimento)
{
    if (!dandoDash && !preparandoDash && !preparandoPreparandoDash)
    {	
    	preparandoPreparandoDash = true;
        Invoke(nameof(IniciarPreparandoDash), 10f); //delay para começar o coroutine
    }
}


 if (!cancelaMovimento) //cadeado para ele ficar parado
 {
if (boolMovimento)
{
 //direcao do player
Vector3 direcao = (detector.player.position - transform.position).normalized;
 
 //remove inclinacao
 direcao.y = 0;
 
 //rotacao alvo
 Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);
 
 //gira suavemente
 transform.rotation = Quaternion.Slerp(
 transform.rotation,
 rotacaoAlvo,
 Time.deltaTime * 5);
 }
 }
 }
 
 public void IniciarPreparandoDash()
 {
     CancelInvoke(nameof(IniciarPreparandoDash));
     if (preparandoDash || dandoDash)
     {
        return;
     }
     
 if (chaoFrente && !paredeFrente)
 {
 StartCoroutine(PreparandoDash());
 }
 else
 {
 preparandoPreparandoDash = false;
 }
 
 
 }
 
 IEnumerator PreparandoDash()
 {
 	if(rDash)
  	{
  	rDash = false;
  	  cancelaMovimento = false;
  dandoDash = false;
  preparandoDash = false;
  preparandoPreparandoDash = false;
  	yield break;
  	}
  	
 if (!boolMovimento)
{
   yield break;
}
   if (!detector.perseguindo) //se o player fica longe 
  {
  cancelaMovimento = false;
  dandoDash = false;
  preparandoDash = false;
  preparandoPreparandoDash = false;
  yield break;
  }
    if (morto) //se o javali morre
  {
  preparandoPreparandoDash = false;
  yield break;
  }

  
 preparandoPreparandoDash = false;
  preparandoDash = true;
   animator.SetBool("correndo", false);
   animator.SetBool("andando", false);
 animator.SetTrigger("prepararDash");
 cancelaMovimento = true; //cancela todos os movimentos do javali
     if (morto) //se o javali morre
  {
  preparandoPreparandoDash = false;
  yield break;
  }
  
 if (!dandoDash)
 {
   if (morto) //se o javali morre
  {
     animator.SetBool("emDash", false);
     preparandoPreparandoDash = false;
  yield break;
  }
  
 dandoDash = true;
 preparandoDash = false;
 StartCoroutine(DandoDash());
 }
 }
 
 
  IEnumerator DandoDash()
 {
 	if(rDash)
  	{
  	dandoDash = false;
  	  preparandoDash = false;
  	cancelaMovimento = false;
  	rDash = false;
  	yield break;
  	}
 if (!boolMovimento)
{
    yield break;
}
 if (!detector.perseguindo || !boolMovimento) //se o player fica longe ou o boolMovimento ser desativado
  {
  cancelaMovimento = false;
  dandoDash = false;
  preparandoDash = false;
  animator.SetBool("emDash", false);
  yield break;
  }
  if (morto) //se o javali morre
  {
  yield break;
  }
  
 yield return new WaitForSeconds(1.2f);
 animator.SetBool("emDash", true);
 
 float tempoDash = 1.5f;
 
 while (tempoDash > 0) //javali dando dash
 {
 Vector3 movimento = transform.forward * velocidadeDash;
 if (boolGravidade)
 {
 movimento.y = forcaY;
 }
 controller.Move(movimento * Time.deltaTime);
 tempoDash -= Time.deltaTime;
 
 	if(rDash)
  	{
  	dandoDash = false;
  	  preparandoDash = false;
  	cancelaMovimento = false;
  	rDash = false;
  	yield break;
  	}
 
 if (!chaoFrente || paredeFrente) //se nao tiver chao ou tiver parede na frente, entao cancela tudo
 {
   cancelaMovimento = false;
  dandoDash = false;
  preparandoDash = false;
  animator.SetBool("emDash", false);
    yield break;
 }
 
 yield return null;
 } 
 
 
 if (dandoDash)
 {
 animator.SetBool("emDash", false);
 dandoDash = false;
 cancelaMovimento = false;
 }
 
 
 }
 
 public void Morrer()
 {
	morto = true;
	
		  animator.SetBool("andando", false);
 	    animator.SetBool("correndo", false);
 	    animator.SetBool("emDash", false);
 	animator.SetTrigger("foiMachucado");
 	
 	StartCoroutine(FadeMorte()); //inicia ele se dissolvendo
 	
 	Debug.Log("bateu no javali");
 	
//desativar caixas de colisões
controller.enabled = false;
colliderDano.enabled = false;
colliderMorte.enabled = false;
colliderMorte2.enabled = false;
detector.enabled = false;
danoScript.enabled = false;


    
 }
 
 //seu fadeout e apagar objeto
 //muda os materiais dele para uma categoria
 //no inspetor chmada materiais mortos, todos
 //compartilham de um preto que seja "transparent"
 //assim trocando os materiais para esse preto,
 //aumentando o transparent e por fim eliminando o objeto. 
 
 IEnumerator FadeMorte()
{
    float alpha = 1f;

    yield return new WaitForSeconds(5f);
    
    for (int r = 0; r < renderJavali.Length; r++)
 	{
 	 renderJavali[r].materials = materiaisMorto;
 	}

    while(alpha > 0)
    {
        alpha -= Time.deltaTime;

        for(int r = 0; (r) < renderJavali.Length; r++)
        {
            Material[] mats =
            renderJavali[r].materials;
            
            if (alpha <= 0.15f)
            {
            gameObject.SetActive(false);
            }

            for(int i = 0; (i) < mats.Length; i++)
            {
                Color cor = mats[i].color;

                cor.a = alpha;

                mats[i].color = cor;
                
            }
        }

        yield return null;
    }

    
}

public void RetornarWayPointProximo()
{


//se nao estiver nenhum waypoint proximo, cancela.
if(waypointAlvo == null)
{
    return;
}
  animator.SetBool("andando", true);
    animator.SetBool("correndo", false);
    animator.SetBool("emDash", false);
//direcao
Vector3 direcao =
(waypointAlvo.position - transform.position).normalized;

direcao.y = 0;

transform.rotation = Quaternion.Slerp(
transform.rotation,
Quaternion.LookRotation(direcao),
Time.deltaTime * 5);

float distancia = Vector3.Distance(transform.position, waypointAlvo.position);
if(distancia < 1.5f)
{
    voltandoWayPoint = false;
    waypointAlvo = null;
}

}

public void DefinirWaypoint(Transform wp)
{
    waypointAlvo = wp;
}

    public void MoverPara(Vector3 destino) //metodo comum com sua variavel vector 3 chmada destino, q recebeu la da variavel vetor, digitada pelo player
    {
    StartCoroutine(Mover(destino)); //chama o corountine com o mesmo parametro
    }
    
        public void EscalonarPara(Vector3 destino)
    {
    StartCoroutine(Escalonar(destino));
    }
    
    private IEnumerator Mover(Vector3 destino) //corountine chamado Mover
    {
    if (!boolMovimento)
    {
    bMDA = true; //boolMovimento Desativo Antes, se tiver desativo, permanesce
    }
    else
    {
    bMDA = false;
    }
    while (Vector3.Distance(transform.position,destino) > 0.01f) //enquanto a distancia for maior que 0.0f da tranform.position e o destino(vetor)
    {
    boolMovimento = false;
    transform.position = Vector3.MoveTowards(transform.position, destino, 7.4f * Time.deltaTime); //MoveTowards para se mover
    yield return null; //a cada vez q roda o while e chega no final, ent roda dnv em outro frame (é a diferença de um metodo para p ienumerator)
    }
    if (!bMDA) //se boolMovimento estava desativo antes, ent continua desativo
    {
        boolMovimento = true;
    }
    transform.position = destino; //termina a missao
    }
    
     private IEnumerator Escalonar(Vector3 destino) 
    {
    while (Vector3.Distance(transform.localScale,destino) > 0.01f) 
    {
    transform.localScale = Vector3.MoveTowards(transform.localScale, destino, 7.4f * Time.deltaTime); 
    yield return null; 
    }
    transform.localScale = destino;
    }
    

public void ResetarEstado()
{
StopAllCoroutines();
CancelInvoke();
// valores básicos
speedPerseguicao = 7f;
speedPatrulha = 3f;
velocidadeDash = 22.5f;
rDash = false;
distanciaParede = 3f;
gravidade = 1.75f;
boolGravidade = true;
boolMovimento = true;
// estado de morte
morto = false;
// estados de dash
dandoDash = false;
preparandoDash = false;
preparandoPreparandoDash = false;
cancelaMovimento = false;
// perseguição
detector.perseguindo = false;
detector.player = null;

waypointAlvo = null;
voltandoWayPoint = false;

if (detectorWaypoint != null)
{
    detectorWaypoint.RecalcularWaypoints();
}
// física
forcaY = 0f;
// restaurar transform
transform.localScale = escalaInicial;
transform.rotation = rotacaoInicial;
// reativar componentes
controller.enabled = true;
colliderDano.enabled = true;
colliderMorte.enabled = true;
colliderMorte2.enabled = true;
detector.enabled = true;
danoScript.enabled = true;

gameObject.layer = LayerMask.NameToLayer("Default");
// resetar animação
animator.Rebind();
animator.Update(0f);
animator.SetBool("andando", false);
animator.SetBool("correndo", false);
animator.SetBool("emDash", false);

for (int r = 0; r < renderJavali.Length; r++)
{
	renderJavali[r].materials = materiaisOriginais[r];
}

// restaurar materiais e cor
for (int r = 0; r < renderJavali.Length; r++)
{
	Material[] mats = renderJavali[r].materials;
	for (int i = 0; i < mats.Length; i++)
	{
		Color cor = coresIniciais[r][i];
		mats[i].color = cor;
	}
}

detector.VerificarJogadorNoRaio();

}

/*
private IEnumerator RecalcularWaypoint()
{
	waypointAlvo = null;
	voltandoWayPoint = false;
	
	yield return new WaitForFixedUpdate();
	if (detectorWaypoint != null)
	{
	detectorWaypoint.ResetarWaypoints();
	}
	yield return new WaitForFixedUpdate();
	voltandoWayPoint = true;
}
*/

public Transform ObterWaypointAlvo()
{
    return waypointAlvo;
}

    
 
 }
