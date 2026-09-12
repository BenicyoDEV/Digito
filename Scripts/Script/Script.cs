using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{

    public float velocidade = 2.75f;
    public float altura = 0.25f;
    
    public bool boolMovimento = true;
    private bool bMDA;
    public bool boolGravidade = false;
    public float gravidade = 5f;
    private bool boolDesativarRotacao = false;
    private bool magnetismoAtivo = false;
    public bool boolColisao = true;
    
    private Transform jogador;

    private Vector3 posInicialLocal;
    private Vector3 posInicialLocalReset;
    private Vector3 escalaInicial;
    private Quaternion rotacaoInicial;
    
    public int idScript;
    private Pausa pausa;
    
    // Start is called before the first frame update
    void Awake()
    {
        pausa = FindObjectOfType<Pausa>();
        
        posInicialLocal = transform.localPosition;
        posInicialLocalReset = transform.localPosition;
        escalaInicial = transform.localScale;
        rotacaoInicial = transform.rotation;
    }

    // Update is called once per frame
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
                    transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(
                transform.position,
                jogador.position,
                14.5f * Time.deltaTime);
            }
        }
    }
    
    public void AtivarMagnetismo(Transform player)
    {
        if (magnetismoAtivo) return;

        magnetismoAtivo = true;
        jogador = player;
    }
    
    private void OnTriggerEnter(Collider other) //tocou no próprio script
    {
        if (other.CompareTag("Player"))
        {
        
           gameObject.SetActive(false);
           
           if (idScript == 1)
           {
               pausa.script1com.SetActive(true);
               pausa.script1sem.SetActive(false);
           }
          
           else if (idScript == 2)
           {
               pausa.script2com.SetActive(true);
               pausa.script2sem.SetActive(false);
           }
           
           else if (idScript == 3)
           {
               pausa.script3com.SetActive(true);
               pausa.script3sem.SetActive(false);
           }
           
           else if (idScript == 4)
           {
               pausa.script4com.SetActive(true);
               pausa.script4sem.SetActive(false);
           }
           
           else if (idScript == 5)
           {
               pausa.script5com.SetActive(true);
               pausa.script5sem.SetActive(false);
           }
           
           else if (idScript == 6)
           {
               pausa.script6com.SetActive(true);
               pausa.script6sem.SetActive(false);
           }
           
           else if (idScript == 7)
           {
               pausa.script7com.SetActive(true);
               pausa.script7sem.SetActive(false);
           }
           
           else if (idScript == 8)
           {
               pausa.script8com.SetActive(true);
               pausa.script8sem.SetActive(false);
           }
           
           else if (idScript == 9)
           {
               pausa.script9com.SetActive(true);
               pausa.script9sem.SetActive(false);
           }
           
           else if (idScript == 10)
           {
               pausa.script10com.SetActive(true);
               pausa.script10sem.SetActive(false);
           }
           
           else if (idScript == 11)
           {
               pausa.script11com.SetActive(true);
               pausa.script11sem.SetActive(false);
           }
           
           
           
        }   
    }
    
    
    public void MoverPara(Vector3 destino)
    {
        StartCoroutine(Mover(destino));
    }
    
    public void EscalonarPara(Vector3 destino)
    {
        StartCoroutine(Escalonar(destino));
    }
    
    public void GirarPara(Vector3 destino) 
    {
        StartCoroutine(Girar(destino));
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
        //posInicialLocal = transform.localPosition;
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
	// Para qualquer coroutine em andamento
	StopAllCoroutines();
	
	// Volta ao comportamento padrão
	velocidade = 2.75f;
	altura = 0.25f;
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
	
	
	// Restaura transformaçõe
	 transform.localPosition = posInicialLocalReset;
	 transform.localScale = escalaInicial;
	 transform.rotation = rotacaoInicial;
	 posInicialLocal = posInicialLocalReset;
    }
    
    public void ResetarCanva()
    {
    
    if (pausa == null)
    pausa = FindObjectOfType<Pausa>();
    if (pausa == null)
    {
    Debug.Log("Pausa nulo");
    return;
    }
    
               if (idScript == 1)
           {
               pausa.script1com.SetActive(false);
               pausa.script1sem.SetActive(true);
           }
          
           else if (idScript == 2)
           {
               pausa.script2com.SetActive(false);
               pausa.script2sem.SetActive(true);
           }
           
           else if (idScript == 3)
           {
               pausa.script3com.SetActive(false);
               pausa.script3sem.SetActive(true);
           }
           
           else if (idScript == 4)
           {
               pausa.script4com.SetActive(false);
               pausa.script4sem.SetActive(true);
           }
           
           else if (idScript == 5)
           {
               pausa.script5com.SetActive(false);
               pausa.script5sem.SetActive(true);
           }
           
           else if (idScript == 6)
           {
               pausa.script6com.SetActive(false);
               pausa.script6sem.SetActive(true);
           }
           
           else if (idScript == 7)
           {
               pausa.script7com.SetActive(false);
               pausa.script7sem.SetActive(true);
           }
           
           else if (idScript == 8)
           {
               pausa.script8com.SetActive(false);
               pausa.script8sem.SetActive(true);
           }
           
           else if (idScript == 9)
           {
               pausa.script9com.SetActive(false);
               pausa.script9sem.SetActive(true);
           }
           
           else if (idScript == 10)
           {
               pausa.script10com.SetActive(false);
               pausa.script10sem.SetActive(true);
           }
           
           else if (idScript == 11)
           {
               pausa.script11com.SetActive(false);
               pausa.script11sem.SetActive(true);
           }
    }
    
}
