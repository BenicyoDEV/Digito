using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento_passaro : MonoBehaviour
{
	
	public float speed;
	public float speedPatrulha = 3.5f;
	public float speedPerseguicao = 7f;
	public float velocidade = 7f;
	public float speedDash = 10f;
	
	public bool rDash = false;
	
	public bool boolMovimento = true;
	private bool bMDA;
	public bool boolGravidade = false;
	public float gravidade = -3.5f;
	
	public float velocidadeSubida = 2f;
	public float velocidadeDescida = 2f;
	public float velocidadeDash1 = 7f;
	public float velocidadeDash2 = 7f;
	public float velocidadeFlutuacao = 1.75f;
	
	public float distanciaWayPoint = 3f;
	private bool paredeFrente;
	
	private Quaternion rotacaoAlvo; //onde unity guarda um "vector3" para rotação
	
	public CharacterController controller;
	private Animator animator;
	
	private bool estaNoChao;
	
	private Transform waypointAlvo; 
	public bool voltandoWayPoint;
	
	private bool parado;
	
	private Vector3 direcao;
	private Vector3 posicaoAlvo;
	
	private bool preparandoDash;
	public bool emDash;
	
	private float yPlayer;
	
	private bool flutuando;
	
	private bool campoMedio;
	private bool campoPequeno;
	
	private float tempo;
	
	private Vector3 direcaoDash;
	
	private float margem1;
	private float margem2;
	
	
	private bool morto;
	
	[SerializeField] private Transform PeDoPassaro;
	[SerializeField] private Transform DetectaParede;
	[SerializeField] private LayerMask WayPointLayer;
	//[SerializeField] private LayerMask DetectaParede;
	[SerializeField] public LayerMask colisaoLayer;

	
	//tudo para delisgar colliders
	[SerializeField] public Collider colliderDano;
	[SerializeField] public Collider colliderMorte;
	[SerializeField] public Dano_sc danoScript;
	
	private DetectaPlayer detector;
	private DetectaWPPoximo detectorWaypoint;
	
	//render dele, para faze-lo desaparecer
	[SerializeField] private Material[] materiaisMorto;
	private SkinnedMeshRenderer[] renderPassaro;
	
	private Vector3 escalaInicial;
	private Quaternion rotacaoInicial;
	private Material[][] materiaisOriginais;
	private Color[][] coresIniciais;
	
    // Start is called before the first frame update
    void Start()
    {
         controller = GetComponent<CharacterController>();
         animator = GetComponent<Animator>();
         detector = GetComponentInChildren<DetectaPlayer>();
         detectorWaypoint = GetComponentInChildren<DetectaWPPoximo>();
         rotacaoAlvo = transform.rotation;
         
         
         //para ele evaporar
 renderPassaro = GetComponentsInChildren<SkinnedMeshRenderer>();
for (int r = 0; r < renderPassaro.Length; r++)
{
    Material[] mats = renderPassaro[r].materials;

    for (int i = 0; i < mats.Length; i++)
    {
        mats[i] = new Material(mats[i]);
    }

    renderPassaro[r].materials = mats;
}


escalaInicial = transform.localScale;
rotacaoInicial = transform.rotation;
// salvar materiais e cores originais
materiaisOriginais = new Material[renderPassaro.Length][];
coresIniciais = new Color[renderPassaro.Length][];
for (int r = 0; r < renderPassaro.Length; r++)
{
 	Material[] mats = renderPassaro[r].materials;
 	materiaisOriginais[r] = new Material[mats.Length];
 	coresIniciais[r] = new Color[mats.Length];
 	for (int i = 0; i < mats.Length; i++)
	 {
		 materiaisOriginais[r][i] = mats[i];
		 coresIniciais[r][i] = mats[i].color;
	 }
 }
Patrulha();

    }

    // Update is called once per frame
    void Update()
    {

//cair quando morrer    
    estaNoChao = Physics.CheckSphere(PeDoPassaro.position, 0.25f, colisaoLayer);
    
    if (!estaNoChao && morto)
{
	Vector3 movimento = transform.position;
	movimento.y -= (6f * Time.deltaTime);
	transform.position = movimento;
	
	transform.rotation = Quaternion.Euler(0, 0, 0);
	animator.SetBool("caindoMachucado", true);
}
	else if (estaNoChao && morto)
	{
	animator.SetBool("caindoMachucado", false);
	animator.SetTrigger("chaoMachucado");
	}


//cancela tudo se o passaro bater as botas
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
 
if (boolGravidade)
{
    controller.Move(Vector3.down * gravidade * Time.deltaTime);
}
     
     //rotas
if (boolMovimento)
{
     if (detector.perseguindo) {
     speed = speedPerseguicao;
     Perseguicao();
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
     
     //movimento padrao
if (boolMovimento)
{
     if (!parado)
     {
     Vector3 movimento = Vector3.zero; //cria um vetor vazio
     movimento = transform.forward * speed; //ira aumentar o "z"(frente) do movimento    
     controller.Move(movimento * Time.deltaTime); //ira passar o vetor de movimento para o controle.
     }
}

}

    public void Patrulha()
    {
    
if (morto)
{
return;
}
    animator.SetBool("perseguicao", false);
    animator.SetBool("patrulha", true);
    Vector3 origem = transform.position + (Vector3.up * 0.5f) + (transform.forward * -0.5f); //posição do detector
    
    RaycastHit hit; //laser que da hit em objetos(e a unity guarda informção do objeto)
    if
    (Physics.Raycast( //laser em pratica
    origem,	//de onde o laser sai
    transform.forward, //qual direcao laser vai
    out hit, //onde guardar a informação se acertar algo
    distanciaWayPoint, //qual alcance do laser
    WayPointLayer)) //qual objeto devo considerar
    {
    rotacaoAlvo = hit.transform.rotation; //rotacaoAlvo guarda a rotacao do objeto que sofreu hit
    }
    //bastante coisa só para ele virar suavemente
  transform.rotation = Quaternion.Slerp( //slerp serve para ele virar aos poucos, deixar mais lento
  transform.rotation, //rotacao atual
  rotacaoAlvo, //onde quer chegar
  Time.deltaTime * 5); //velocidade rotação
    }

    
    public void Perseguicao()
    {
    
if (morto)
{
return;
}
Vector3 centroCampo = detector.player.position + Vector3.up * 10f;
float distancia = Vector3.Distance(transform.position, centroCampo);
if (distancia <= 5.5f)
{
campoPequeno = true;
campoMedio = false;
}
else if (distancia <= 6)
{
campoMedio = true;
campoPequeno = false;
}
else {
campoPequeno = false;
campoMedio = false;
}


if (!emDash) //se nao estiver em dash
{
if (!campoMedio && !campoPequeno)
{
//direcao do player
flutuando = false;
    animator.SetBool("patrulha", false);
    animator.SetBool("perseguicao", true);
direcao = (detector.player.position - transform.position).normalized;
direcao.y = 0;
parado = false;
}

else if (campoMedio && !campoPequeno)
{
//parado
    animator.SetBool("perseguicao", false);
    animator.SetBool("patrulha", false);

parado = true;

Vector3 direcaoPlayer =
detector.player.position - transform.position;

direcaoPlayer.y = 0;

Quaternion rotacaoAlvo =
Quaternion.LookRotation(direcaoPlayer);

transform.rotation = Quaternion.Slerp(
transform.rotation,
rotacaoAlvo,
Time.deltaTime * 5
);

//passaro ficar subindo e descendo levemente enquanto parado
if (!boolGravidade)
{
float flutuar = Mathf.Sin(Time.time * velocidadeFlutuacao);
Vector3 movimentoVertical = Vector3.down * (flutuar * 0.35f);
controller.Move(movimentoVertical * Time.deltaTime);
flutuando = true;
}


    
}


else 
{
//direcao oposta do player
flutuando = false;
    animator.SetBool("patrulha", false);
    animator.SetBool("perseguicao", true);
    
direcao = (transform.position - detector.player.position).normalized;
direcao.y = 0;
parado = false;
}


if (!parado)
{
//rotacao alvo
 Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);
 
 //gira suavemente
 transform.rotation = Quaternion.Slerp(
 transform.rotation,
 rotacaoAlvo,
 Time.deltaTime * 5);
}


 //desce passaro
 if (!boolGravidade)
 {
 if (!flutuando) //se o passaro nao esta flutuando, ent faz.
 {
 yPlayer = detector.player.transform.position.y; //peguei o transform do player pelo detector
 if (transform.position.y > (yPlayer + 4.5f))
 {
 Vector3 movimentoVertical = Vector3.down * velocidadeDescida;
 controller.Move(movimentoVertical * Time.deltaTime);
 }
 
  if (transform.position.y < (yPlayer + 5.5f))
 {
  Vector3 movimentoVertical = Vector3.up * velocidadeSubida;
 controller.Move(movimentoVertical * Time.deltaTime);
 }
 }
 }
 
 
 }
 
 
 //Dash
 if (!preparandoDash && !emDash) //se ele não estiver em evento de dash
 {
 preparandoDash = true;
 Invoke(nameof(IniciarDash), 10f); //delay para começar o coroutine 
 }
   
    }
    
     public void IniciarDash()
    {
         CancelInvoke(nameof(IniciarDash));
     if (emDash)
     {
        return;
     }
    posicaoAlvo = detector.player.transform.position;
    StartCoroutine(Dash1());


    }
    
   
         IEnumerator Dash1()
    {
            if (morto)
  {
  yield break;
  }
  
  
          if (!boolMovimento)
  {
  yield break;
  }
  
    Debug.Log("dashando");
    emDash = true;
    preparandoDash = false;
    

    
    direcao = (posicaoAlvo - transform.position).normalized;
    	
   tempo = 0.9f;
   float alturaAlvo = posicaoAlvo.y + 1.7f;
   while (tempo > 0 && Mathf.Abs(transform.position.y - alturaAlvo) > 0.5f)
	{    
	 	if(rDash)
  	{
  	emDash = false;
  	rDash = false;
  	yield break;
  	}
    tempo -= Time.deltaTime;


    Vector3 pontoOlhar = transform.position + Vector3.down * 10f;


Quaternion rotacaoAlvo = Quaternion.LookRotation(pontoOlhar - transform.position);

transform.rotation = Quaternion.Slerp(
    transform.rotation,
    rotacaoAlvo,
    Time.deltaTime * 3f
);


    controller.Move(transform.forward * velocidadeDash1 * Time.deltaTime);

    yield return null;
}
    	
yield return StartCoroutine(Dash2());
    }
    
    
    IEnumerator Dash2()
    {

  	
     if (!boolMovimento)
{
   yield break;
}
     Debug.Log("dashando2");
     
         direcao = (posicaoAlvo - transform.position).normalized;
    direcao.y = 0;
    
    Vector3 posicaoFinal = posicaoAlvo + direcao * 8f;
    tempo = 0.9f;
	while (tempo > 0)
	{
	 	if(rDash)
  	{
  	emDash = false;
  	rDash = false;
  	yield break;
  	}

  	    
    tempo -= Time.deltaTime;
     controller.Move(transform.forward * speedDash * Time.deltaTime);
    if (!boolMovimento)
{
   yield break;
}
    
        Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao); //"qual rotação eu preciso para olhar nessa direção?"
    transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, Time.deltaTime * 5); //gira suavemente
controller.Move(direcao * velocidadeDash2 * Time.deltaTime);
    
    if (morto)
  {
  yield break;
  }
    
    yield return null;
    	}
yield return StartCoroutine(Dash3());
    	
    }
    
        IEnumerator Dash3()
    {

  	
        if (morto)
  {
  yield break;
  }
   if (!boolMovimento)
{
   yield break;
}
    Debug.Log("dashando3");
    
    
    Vector3 posicaoCima = transform.position + Vector3.up * 10f; // melhor q Vector3 posicaoCima; posicaoCima.y = transform.position.y + 10f;

    
	   tempo = 0.7f;
   while (tempo > 0)
	{
	 	if(rDash)
  	{
  	rDash = false;
  	emDash = false;
  	yield break;
  	}
	
    tempo -= Time.deltaTime;

	
    Vector3 pontoOlhar = transform.position + transform.forward * 10f + Vector3.up * 8f;

    Quaternion rotacaoAlvo = Quaternion.LookRotation(pontoOlhar - transform.position); //"qual rotação eu preciso para olhar nessa direção?"
    transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, Time.deltaTime * 3f); //gira suavemente
    
    if (boolGravidade)
{
    yield break;
}

    controller.Move(transform.forward * velocidade * Time.deltaTime);//ele se move para onde esta olhando. 
    
    
    yield return null;
    	}
    emDash = false;
	yield break;
    }    

    
    public void Morrer()
    {
    morto = true;
    StartCoroutine(FadeMorte()); //inicia ele se dissolvendo
Debug.Log("bateu no passaro");


//desativar caixas de colisões
controller.enabled = false;
colliderDano.enabled = false;
colliderMorte.enabled = false;
detector.enabled = false;
danoScript.enabled = false;
    }
     
     
     
    IEnumerator FadeMorte()
    {
      float alpha = 1f;

    yield return new WaitForSeconds(5f);
    
    for (int r = 0; r < renderPassaro.Length; r++)
 	{
 	 renderPassaro[r].materials = materiaisMorto;
 	}

    while(alpha > 0)
    {
        alpha -= Time.deltaTime;

        for(int r = 0; (r) < renderPassaro.Length; r++)
        {
            Material[] mats =
            renderPassaro[r].materials;
            
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
  animator.SetBool("patrulha", true);
    animator.SetBool("perseguicao", false);
//direcao
Vector3 direcao =
(waypointAlvo.position - transform.position).normalized;

//direcao.y = 0;

transform.rotation = Quaternion.Slerp(
transform.rotation,
Quaternion.LookRotation(direcao),
Time.deltaTime * 5);

float distancia = Vector3.Distance(transform.position, waypointAlvo.position);
if(distancia < 1.5f)
{
    voltandoWayPoint = false;
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
    
    
    
            public void EscalonarPara(Vector3 destino)
    {
    StartCoroutine(Escalonar(destino));
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
    speedPatrulha = 3.5f;
    speedPerseguicao = 7f;
    velocidade = 7f;
    speedDash = 10f;
    rDash = false;
    boolMovimento = true;
    boolGravidade = false;
    gravidade = -3.5f;
    velocidadeSubida = 2f;
    velocidadeDescida = 2f;
    velocidadeDash1 = 7f;
    velocidadeDash2 = 7f;
    velocidadeFlutuacao = 1.75f;
    distanciaWayPoint = 3f;
    
    // estados
    morto = false;
    parado = false;
    preparandoDash = false;
    emDash = false;
    flutuando = false;
    voltandoWayPoint = false;
    campoMedio = false;
    campoPequeno = false;
    tempo = 0f;
    
    // limpar perseguição
    detector.perseguindo = false;
    detector.player = null;
    
StartCoroutine(RecalcularWaypointDepoisDoReset());
    
    // restaurar transform
    transform.localScale = escalaInicial;
    transform.rotation = rotacaoInicial;
    
    // reativar componentes
    controller.enabled = true;
    colliderDano.enabled = true;
    colliderMorte.enabled = true;
    detector.enabled = true;
    danoScript.enabled = true;
    
    gameObject.layer = LayerMask.NameToLayer("Default");
    	
    // restaurar materiais originais
    for (int r = 0; r < renderPassaro.Length; r++)
    {
    	renderPassaro[r].materials = materiaisOriginais[r];
    	Material[] mats = renderPassaro[r].materials;
    	for (int i = 0; i < mats.Length; i++)
    	{
    		mats[i].color = coresIniciais[r][i];
    	}
    }
    
    // resetar animação
    animator.Rebind();
    animator.Update(0f);
    animator.SetBool("patrulha", false);
    animator.SetBool("perseguicao", false);
    animator.SetBool("caindoMachucado", false);
    
detector.VerificarJogadorNoRaio();
}

private IEnumerator RecalcularWaypointDepoisDoReset()
{
    waypointAlvo = null;
    voltandoWayPoint = false;

    // Espera a posição do pássaro ser aplicada e a física atualizar
    yield return new WaitForFixedUpdate();

    if (detectorWaypoint != null)
    {
        detectorWaypoint.RecalcularWaypoints();
    }

    // Espera o detector reconstruir a lista e escolher o mais próximo
    yield return null;

    voltandoWayPoint = false;
}

}
