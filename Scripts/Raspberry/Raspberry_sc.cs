using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raspberry_sc : MonoBehaviour
{
    public float velocidade = 2.5f;
    float altura = 0.175f;
    
    	public bool boolMovimento = true;
    		private bool bMDA;
	public bool boolGravidade = false;
	public float gravidade = 5f;
	private bool boolDesativarRotacao = false;

    private bool magnetismoAtivo = false;
    private Transform jogador;
    public bool boolColisao = true;

    private Vector3 posInicialLocal;
    private Vector3 posInicialLocalReset;

    private RaspberryGiro_sc grupo;
    
    private Transform paiInicial;
    private Vector3 escalaInicial;
    private Quaternion rotacaoInicial;

    void Start()
    {
  posInicialLocal = transform.localPosition;
    posInicialLocalReset = transform.localPosition;
  grupo = GetComponentInParent<RaspberryGiro_sc>();
  paiInicial = transform.parent;
  escalaInicial = transform.localScale;
  rotacaoInicial = transform.rotation;
    }

    void Update()
    {
  if (boolMovimento)
 {
    if (boolGravidade)
{
                if (!Physics.Raycast(transform.position, Vector3.down, 0.35f) && boolColisao)
                {
                    transform.position += Vector3.down * gravidade * Time.deltaTime;
                }
                else if (!boolColisao)
                {
                    transform.position += Vector3.down * gravidade * Time.deltaTime;
                }
    
}
      
        if (!magnetismoAtivo)
        {
          if (!boolGravidade)
{
            Vector3 pos = transform.localPosition;

            pos.y = posInicialLocal.y + Mathf.Sin(Time.time * velocidade) * altura;

            transform.localPosition = pos;
if (!boolDesativarRotacao)
            {
            transform.Rotate(new Vector3(0, 50, 10) * Time.deltaTime);
            }
}
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                jogador.position,
                14.5f * Time.deltaTime
            );
        }
       }
      }
    

    public void AtivarMagnetismo(Transform player)
    {
        if (magnetismoAtivo) return;

        magnetismoAtivo = true;
        jogador = player;

        if (grupo != null)
            grupo.RemoverDaOrbita(transform);

        transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Movimento_Jogador player = other.GetComponent<Movimento_Jogador>();
            player.QuantidadeRaspberrys++;
            player.rVisivel = true;
            player.AtualizarHUD();

            gameObject.SetActive(false);
        }
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
    posInicialLocal = transform.localPosition;
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
    
            public void GirarPara(Vector3 destino) 
    {
    StartCoroutine(Girar(destino));
    }
    
    
         private IEnumerator Girar(Vector3 destino)
    {

   while (Quaternion.Angle(transform.rotation, Quaternion.Euler(destino)) > 0.1f)
{
    boolDesativarRotacao = true;
    transform.rotation = Quaternion.RotateTowards(
        transform.rotation,
        Quaternion.Euler(destino),
        90f * Time.deltaTime
    );

    yield return null;
}
    boolDesativarRotacao = false;
transform.rotation = Quaternion.Euler(destino);
    }
    
    public void ResetarEstado()
    {
{
	// Para qualquer coroutine em andamento
	StopAllCoroutines();
	
	// Volta ao comportamento padrão
	velocidade = 2.5f;
	altura = 0.175f;
	boolMovimento = true;
	bMDA = false;
	boolGravidade = false;
	gravidade = 5f;
	boolDesativarRotacao = false;
	boolColisao = true;
	
	gameObject.layer = LayerMask.NameToLayer("Default");
	
	// Magnetismo
	magnetismoAtivo = false;
	jogador = null;
	
	// Volta para o pai original (órbita)
	transform.SetParent(paiInicial);
	
	// Restaura transformaçõe
	 transform.localPosition = posInicialLocalReset;
	 transform.localScale = escalaInicial;
	 transform.rotation = rotacaoInicial;
	 posInicialLocal = posInicialLocalReset;
	 
	 // Reativa o slot da órbita
	 if (grupo != null)
	 {
		 for (int i = 0; i < grupo.slots.Count; i++)
	 	{
		    if (grupo.slots[i].raspberry == transform)
		    {
		        grupo.slots[i].ativa = true;
		        break;
		    }
		}
	 }
}
    }
    

}
