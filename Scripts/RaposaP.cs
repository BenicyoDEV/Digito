using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaposaP : MonoBehaviour
{
[SerializeField] public Collider colisao;
[SerializeField] public Collider colisao2;
[SerializeField] public Rigidbody rb;

private Animator animator;
private bool mexendo = false;
public bool boolGravidade = false;
public float gravidade = 9.81f;
public bool boolMovimento = true;

	private Vector3 escalaInicial;
	private Quaternion rotacaoInicial; 
	private Vector3 posicaoInicial;
	
[SerializeField] private RaposaAtivacao raposaat;

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;
         animator = GetComponentInChildren<Animator>();
         
escalaInicial = transform.localScale;
rotacaoInicial = transform.localRotation;
posicaoInicial = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    
if (boolMovimento)
{

float volume = (transform.localScale.x * transform.localScale.y * transform.localScale.z) /3f;
rb.mass = volume * 2f;
 animator.speed = 1f;
}
else
{
 animator.speed = 0f;
}

    }
    
    void FixedUpdate()
{

if (boolMovimento)
{
if (!mexendo)
{
if (boolGravidade)
{
    rb.velocity += Vector3.down * gravidade * Time.fixedDeltaTime;
    rb.isKinematic = false;
}
}
else
{
rb.angularVelocity = Vector3.zero;
rb.velocity = Vector3.zero;
rb.isKinematic = true;
}


}

}
    
    public void MoverPara(Vector3 destino) //metodo comum com sua variavel vector 3 chmada destino, q recebeu la da variavel vetor, digitada pelo player
    {
    StartCoroutine(Mover(destino)); //chama o corountine com o mesmo parametro
    }
    
        public void GirarPara(Vector3 destino) 
    {
    StartCoroutine(Girar(destino));
    }
    
        public void EscalonarPara(Vector3 destino)
    {
    StartCoroutine(Escalonar(destino));
    }
    
    private IEnumerator Mover(Vector3 destino) //corountine chamado Mover
    {
    mexendo = true;
    while (Vector3.Distance(transform.position,destino) > 0.01f) //enquanto a distancia for maior que 0.0f da tranform.position e o destino(vetor)
    {
    transform.position = Vector3.MoveTowards(transform.position, destino, 7.4f * Time.deltaTime); //MoveTowards para se mover
    yield return null; //a cada vez q roda o while e chega no final, ent roda dnv em outro frame (é a diferença de um metodo para p ienumerator)
    }
    transform.position = destino; //termina a missao
    mexendo = false;
    }
    
     private IEnumerator Girar(Vector3 destino)
    {
    mexendo = true;
   while (Quaternion.Angle(transform.rotation, Quaternion.Euler(destino)) > 0.1f)
{
    transform.rotation = Quaternion.RotateTowards(
        transform.rotation,
        Quaternion.Euler(destino),
        90f * Time.deltaTime
    );

    yield return null;
}
transform.rotation = Quaternion.Euler(destino);
mexendo = false;
    }
    
     private IEnumerator Escalonar(Vector3 destino) 
    {
    mexendo = true;
    while (Vector3.Distance(transform.localScale,destino) > 0.01f) 
    {
    transform.localScale = Vector3.MoveTowards(transform.localScale, destino, 7.4f * Time.deltaTime); 
    yield return null; 
    }
    transform.localScale = destino;
    mexendo = false;
    }
    
    public void ResetarEstado()
{

StopAllCoroutines();
CancelInvoke();

gravidade = 9.81f;
boolGravidade = false;
boolMovimento = true;


colisao.enabled = true;
colisao2.enabled = true;

gameObject.layer = LayerMask.NameToLayer("Ground");

mexendo = false;


transform.localPosition = posicaoInicial;
transform.localScale = new Vector3(1,1,1);
transform.localRotation = rotacaoInicial;

    if (raposaat != null)
    {
    raposaat.DesativarRaposa();
    }
}
    
}
