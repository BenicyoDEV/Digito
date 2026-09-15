using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.UI;
using System.Globalization;
using System.Text.RegularExpressions;

public class Holograma : MonoBehaviour
{
	public bool modoProgramacao;
	public bool digitandoCodigo;
	[SerializeField] private GameObject holograma;
	[SerializeField] private CinemachineFreeLook freeLook;
	//[SerializeField] private Camera camerajogador;
	[SerializeField] private GameObject painelProgramacao;
	[SerializeField] private TMP_InputField inputCodigo;
	[SerializeField] private Image imagemPainelHud;
		[SerializeField] private Image imagemXis;
	[SerializeField] private TMPro.TextMeshPro codigo3d;
	
	[SerializeField] private Transform player;
	
	
	[SerializeField] private TextMeshProUGUI codigoCerto;
	[SerializeField] private TextMeshProUGUI codigoErro;
	[SerializeField] private TextMeshProUGUI objetoLonge;
	[SerializeField] private TextMeshProUGUI objetoInvalido;
	
	private string campo;
	private string valor;
	private float numero;
	private bool boolReturn;
	private bool boolMetodo;
	private string vector1;
	private string vector2;
	private string vector3;
	private string nomeMetodo;
	
	private string[] voltarComando = new string[5];
	private int posicaoHistorico = 0;
	
	private Programavel objetoSelecionado;
	
	private PainelProgramacao[] paineis;
	private bool algumPainelAtivo = false;
	
	private TransicaoIris transicao;
        private Pausa pausa;
	
	
    // Start is called before the first frame update
    void Start()
    {
    paineis = FindObjectsOfType<PainelProgramacao>();
    transicao = FindObjectOfType<TransicaoIris>();
    pausa = FindObjectOfType<Pausa>();
     
        	
        	imagemPainelHud.color = new Color (1f, 1f, 1f, 0.5f);
        	
        	imagemXis.color = new Color (1f, 1f, 1f, 0.75f);
        	
        	inputCodigo.onValidateInput = ValidarEnter;
    }

    // Update is called once per frame
    void Update()
    {
    algumPainelAtivo = false;
    foreach (PainelProgramacao painel in paineis)
    {
    if(painel.estaNaAreaPainel)
    {
    algumPainelAtivo = true;
    break;
    }
    }
    
    if (pausa.jogoPausado)
    {
        painelProgramacao.SetActive(false);
	LimparSelecao();
	StartCoroutine(DemoraClicar());
	
        digitandoCodigo = false;
	modoProgramacao = false;
	holograma.SetActive(false);
    }
    
        if (!digitandoCodigo && objetoSelecionado == null)
        {
            if(Input.GetKeyDown(KeyCode.E) && algumPainelAtivo == false && transicao.fazendo == false && pausa.jogoPausado == false)
        {
        
        if (!modoProgramacao)
        {
        EntrarModoProgramacao();
        }
        else
        {int layerIgnorar = LayerMask.GetMask("ignorarClick", "Waypoint");
        SairModoProgramacao();
        }
        
        }
        }
   
        
       codigo3d.text = inputCodigo.text;
        
    if (modoProgramacao)
    {
    if (Input.GetMouseButton(1))
    {
        if (!pausa.jogoPausado)
        {
        freeLook.m_XAxis.m_MaxSpeed = pausa.sensiX;
        freeLook.m_YAxis.m_MaxSpeed = pausa.sensiY;
        }
    }
    else
    {
    freeLook.m_XAxis.m_MaxSpeed = 0;
    freeLook.m_YAxis.m_MaxSpeed = 0;
    }
    }
    
if (Input.GetKeyDown(KeyCode.UpArrow))
{
    if (posicaoHistorico < voltarComando.Length && voltarComando[posicaoHistorico] != null)
    {
        inputCodigo.text = voltarComando[posicaoHistorico];
        posicaoHistorico++;
    }
}


if (Input.GetKeyDown(KeyCode.DownArrow))
{
    if (posicaoHistorico > 0)
    {
        posicaoHistorico--;
        inputCodigo.text = voltarComando[posicaoHistorico];
    }
    else
    {
    inputCodigo.text = "";
    }
}

     if (modoProgramacao && Input.GetMouseButtonDown(0) && objetoSelecionado == null && !pausa.jogoPausado)
        {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition); //um laser q sai da camera e vai onde ta o mouse
        
    int layerIgnorar = LayerMask.GetMask("ignorarClick", "WayPoint");
    int mascara = ~layerIgnorar;

    RaycastHit[] hits = Physics.RaycastAll(raio, Mathf.Infinity, mascara);

System.Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));

foreach (RaycastHit hit in hits)
{
    Debug.Log(hit.collider.name);

    Programavel p = hit.collider.GetComponent<Programavel>();
    
    if (!hit.collider.isTrigger)
    {
    Debug.Log("objeto invalido");
    ObjetoInvalido();
    return;
    }
    else if (p == null)
    {
    Debug.Log("objeto invalido");
    ObjetoInvalido();
    return;
    }
    else if (Vector3.Distance(p.transform.position, player.transform.position) > 60f)
    {
    Debug.Log("longe dms");
    ObjetoLonge();
    return;
    }
    else
    {
    objetoSelecionado = p;
    }    
        

   Outline outline = objetoSelecionado.GetComponent<Outline>();

    if (outline != null)
    {
    outline.enabled = true;
    }

        painelProgramacao.SetActive(true);
        holograma.SetActive(true);

        inputCodigo.text = "";
        inputCodigo.ActivateInputField();
        inputCodigo.Select();

        digitandoCodigo = true;

        return;
    }

}

        
        }
        
        
   /* if (painelProgramacao.activeSelf && Input.GetKeyDown(KeyCode.Return))
    {
    ExecutarCodigo();
    } */
    
    
    
    	private void EntrarModoProgramacao()
	{
	posicaoHistorico = 0;
	modoProgramacao = true;
	Debug.Log("modoProgramacao: " + modoProgramacao);
	Time.timeScale = 0f;
	
	Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
	}
	
	public void CodigoInvalido()
	{
	SairModoProgramacao();
	Debug.Log("Código inválido");
	
	codigoErro.gameObject.SetActive(true);
	StartCoroutine(DesativarMsgErro());
	LimparSelecao();
	}
	
	public void CodigoValido()
	{
	Debug.Log("Código válido");
	
	codigoCerto.gameObject.SetActive(true);
	StartCoroutine(DesativarMsgAcerto());
	LimparSelecao();
	}
	
	IEnumerator DemoraClicar()
	{
	yield return new WaitForSecondsRealtime(1.5f);
	objetoSelecionado = null;
	}
	
	
	IEnumerator DesativarMsgErro()
	{
	yield return new WaitForSecondsRealtime(1.5f);
	codigoErro.gameObject.SetActive(false);
	objetoSelecionado = null; //mesmo delay para nao conseguir programar denovo
	}
	
	IEnumerator DesativarMsgAcerto()
	{
	yield return new WaitForSecondsRealtime(1.5f);
	codigoCerto.gameObject.SetActive(false);
	objetoSelecionado = null;
	}
	
	public void ObjetoInvalido()
	{
	objetoInvalido.gameObject.SetActive(true);
	StartCoroutine(EsconderObjetoInvalido());
	}
	
	IEnumerator EsconderObjetoInvalido()
{
    yield return new WaitForSecondsRealtime(1f);
    objetoInvalido.gameObject.SetActive(false);
}
	
	public void ObjetoLonge()
	{
	objetoLonge.gameObject.SetActive(true);
	StartCoroutine(EsconderObjetoLonge());
	}
	
	IEnumerator EsconderObjetoLonge()
{
    yield return new WaitForSecondsRealtime(1f);
    objetoLonge.gameObject.SetActive(false);
}
	
	//nao valida o enter como caractere ao clica-lo
	private char ValidarEnter(string text, int index, char c)
{
    if (c == '\n' || c == '\r')
    {
        ExecutarCodigo();
        return '\0'; // Impede que a quebra de linha seja adicionada
    }

    return c;
}
	
	private void ExecutarCodigo()
	{
	string codigoDoJogador = inputCodigo.text;
	Debug.Log(codigoDoJogador);
	painelProgramacao.SetActive(false);
	
	//interpretador de codigo.
	codigoDoJogador = codigoDoJogador.Trim();
	if (codigoDoJogador != "")
	{
	AdicionarHistorico(codigoDoJogador);
	}
	if (codigoDoJogador == "exit;" || codigoDoJogador == "exit();")
	{
	CodigoValido();
	SairModoProgramacao();
	return;
	}
	if (codigoDoJogador.Replace(" ", "").EndsWith("();")) //se tirando os espaços, acabar com "();"
	{
	codigoDoJogador = codigoDoJogador.Trim(); //Tirar todos os espaços dos extremos
	campo = codigoDoJogador;
	InterpretadorMetodo();
	return;
	}
	
	if (codigoDoJogador.TrimStart().StartsWith("return")) //se tirando os espaços do começo, começar com "return"
	{
	codigoDoJogador = codigoDoJogador.TrimStart();
	campo = codigoDoJogador;
	InterpretadorReturn();
	return;
	}
	
	if (!codigoDoJogador.Contains("=")) //se não tiver "=" cancela
	{
	CodigoInvalido();
	return;
	}
	string[] partes = codigoDoJogador.Split('='); //no sinal de igual ira separar a string em duas partes, antes"partes[0]" e dps"partes[1]" do "="
	if (partes.Length != 2) //se separar em partes diferentes de 2, cancela
	{
	CodigoInvalido();
	return;
	} 
	campo = partes[0]; //campo e valor recebem as duas partes, exemplo: "speed"
	valor = partes[1]; //exemplo: "5f;"
	campo = campo.Trim(); //tira os espaços antes dos extremos
	if (!valor.Contains(";")) //se não tiver ";" cancela
	{
	CodigoInvalido();
	return;
	}
	valor = valor.TrimEnd(); //tira os espaços do final
	if (valor.Split(';').Length - 1 > 1) //se tiver mais de um ;, cancela.
	{
CodigoInvalido();
	return;
	}
	if(valor.EndsWith(";")) //se acaba com ;
	{
	valor = valor.Replace(";", ""); //tira os pontos e virgulas
	valor = valor.TrimEnd();//tira todos os espaços que sobraram no final.
	}
	else //se nao acabar com ; entao cancela
	{
CodigoInvalido();
	return;
	}
	
	if (valor.Trim().StartsWith("\"") && valor.Trim().EndsWith("\"")) //se depois de remover os espaços nos extremos, começar e terminar com aspas, inicia o método
	{
	InterpretadorString();
	return;
	}
	
	if (valor.TrimStart().StartsWith("new"))
	{
	if (valor.Contains(" f") || valor.Contains(" F"))
	{
	CodigoInvalido();
	return;
	}
	valor = valor.Replace(" ", ""); //tirar todos os espaços ex:newVector3(1,2,3)
	if (valor.Contains("newVector3")) //se ficar sem espaços e escrito newVector3, então vem método.
	{
	InterpretadorVector();
	return;
	}
	else
	{
	CodigoInvalido();
	return;
	}
	}
	 
	if (valor.Contains("true") || valor.Contains("false")) //se conter "true" ou "false" na variavel valor
	{
	while (valor[0] == ' ') //remove todos os espaços no comeco
	{
	valor = valor.Remove(0, 1);
	}
	if (valor == "true" || valor == "false")//se só sobrar "true" ou "false" inicia método InterpretadorBool.
	{
	InterpretadorBool();
	return;
	}
	}
	
	if (!ConverterFloat(valor, out numero)) //se nao conseguir converter oque sobrou em float com o metodo, cancela
{
CodigoInvalido();
	return;
}
	ConverterFloat(valor, out numero); //converte o valor em numero com o metodo.
	
	Debug.Log("Valor(string): " + valor);

	Debug.Log("Campo: " + campo);
	Debug.Log("Valor: " + numero);
	
	digitandoCodigo = false;
	SairModoProgramacao();
	}
	
	private bool ConverterFloat(string valorRecebido, out float numero, bool aplicar = true) //método que trabalha com a string valorRecebido e o tranforma em float numero. seu valor de aplicar é defaultmente true, mas o vetor chama isso e deixa false, restringindo a opcao de chamar metodo
	{
 numero = 0;
	valorRecebido = valorRecebido.Replace("F", "f"); //tranforma todos os F em f.
	if (valorRecebido.Split('f').Length - 1 > 1) //se tiver mais de um f, cancela.
	{
CodigoInvalido();
	return false;
	}
	if (valorRecebido.Contains(" f")) //se tiver um espaço antes do f, cancela
	{
	Debug.Log("era para retornar");
	CodigoInvalido();
	return false;
	}
	bool ehFloat = valorRecebido.Contains("."); //se conter ".", entao ehFloat se torna true.
	if(!valorRecebido.EndsWith("f") && ehFloat) //se o valor não acaba com f, e é float, entao cancela
	{
CodigoInvalido();
	return false;
	}
	else //caso for float e termine com f, ou nao for float e nem tiver o f, então só tira o f se tiver.
	{
	valorRecebido = valorRecebido.Replace("f", "");
	}
	if (ehFloat) //se é float, divide duas partes antes e depois do "." 
	{
	string[] partesFloat = valorRecebido.Split('.');
	if (partesFloat.Length != 2) //se tiver mais de dois valores entre a virgula, cancela.
	{
CodigoInvalido();
	return false;
	}
	string parteFloat2 = partesFloat[1];
	if (parteFloat2.Length == 0) //verifica se tem o valor depois da virgula, se nao houver, cancela.
	{
CodigoInvalido();
	return false;
	}
	}
	
	if (!float.TryParse(valorRecebido, //se nao conseguir transformar a string valorRecebido no float numero usando a variacao de idioma, cancela
    NumberStyles.Float,
    CultureInfo.InvariantCulture,
    out numero))
    {
CodigoInvalido();
	return false;
    }
    
    if (aplicar)
{
    objetoSelecionado.Alterar(campo, numero);
}

return true;
    //Debug.Log(float) e o ToString() nao usam a mesma forma de converter o numero para texto. o debug.log da unity costuma
    //formatar numeros de forma propria, enquanto o ToString() usa a cultura atual do sistema pt-BR -> vírgula
 
	}
	
	private void InterpretadorString()
	{
	valor = valor.Trim(); //tira os espaços antes dos extremos
	valor = valor.Trim('"'); //tira as aspas dos extremos
	
	if (valor.Contains('"')) //se ainda tiver alguma aspa solta, cancela.
	{
  CodigoInvalido();
	return;
	}
	
	Debug.Log("Campo: " + campo);
	Debug.Log("String: " + valor);
	
	digitandoCodigo = false;
	SairModoProgramacao();
	objetoSelecionado.Alterar(campo, valor);
	}
	
	private void InterpretadorReturn()
	{
	if (!campo.Contains(";")) //se não tiver ";" cancela
	{
CodigoInvalido();
	return;
	}
	campo = campo.TrimEnd(); //tira os espaços do final
	if (campo.Split(';').Length - 1 > 1) //se tiver mais de um ;, cancela.
	{
CodigoInvalido();
	return;
	}
	if(campo.EndsWith(";")) //se acaba com ;
	{
	campo = campo.Replace(";", ""); //tira os pontos e virgulas
	campo = campo.TrimEnd();//tira todos os espaços que sobraram no final.
	}
	else //se nao acabar com ; entao cancela
	{
CodigoInvalido();
	return;
	}
	if (!campo.Contains("return"))
	{
CodigoInvalido();
	return;
	}
	boolReturn = true;
	Debug.Log("Campo: " + campo);
	Debug.Log("Return: " + boolReturn);
	
	digitandoCodigo = false;
	SairModoProgramacao();
	objetoSelecionado.AlterarReturn(campo, boolReturn);
	}
	
	private void InterpretadorMetodo()
	{
	string[] partes = campo.Split('('); //cortar em duas partes no "(".
	if (partes.Length != 2) //se tiver mais de duas partes, cancela
	{
CodigoInvalido();
	return;
	} 
	string parteMetodo1 = partes[0]; //exemplo: Revive
	string parteMetodo2 = partes[1]; //exemplo: );
	parteMetodo2 = parteMetodo2.Replace(" ", "");//tirar espaços
	if (parteMetodo2 != ");")
	{
CodigoInvalido();
	return;
	} 
	parteMetodo1 = parteMetodo1.Trim(); //tirar todos os espaços do começo e fim do nome do método.
	nomeMetodo = parteMetodo1;
	boolMetodo = true;
	Debug.Log("Campo: " + nomeMetodo);
	Debug.Log("Metodo: " + boolMetodo);

	digitandoCodigo = false;
	SairModoProgramacao();
	objetoSelecionado.AlterarMetodo(nomeMetodo, boolMetodo);
	}
	
	
	private void InterpretadorBool() //se a string valor for "false" ou "true" a variavel bool booleano irá receber o respectivo valor.
	{
	bool booleano;
	if (valor == "false")
	{
	booleano = false;
	}
	else if (valor == "true")
	{
	booleano = true;
	}
	else
	{
CodigoInvalido();
	return;
	}
	
	Debug.Log("Campo: " + campo);
	Debug.Log("Valor: " + booleano);
	
	digitandoCodigo = false;
	SairModoProgramacao();
	
	objetoSelecionado.Alterar(campo, booleano);
	}
	
	private void InterpretadorVector() //newVector3(1,2,3)
	{
	valor = valor.Substring(10); //tiras as 10 primeiras letras, ex: (1,2,3)
	if(valor.StartsWith("(") && valor.EndsWith(")")) //se começar e encerrar com (), remova-os, caso não, cancele.
	{
	valor = valor.Trim('(', ')'); //ex: 1,2,3
	}
	else
	{
	CodigoInvalido();
	return;
	}
	
	if (!valor.Contains(",")) //se não tiver "," cancela
	{
CodigoInvalido();
	return;
	}
	string[] partesVector = valor.Split(','); //separar a string em partes entre as virgulas
	if (partesVector.Length != 3) //se separar em partes diferentes de 3, cancela
	{
CodigoInvalido();
	return;
	} 
	vector1 = partesVector[0]; //ex: 5.5f
	vector2 = partesVector[1]; //ex: 5f
	vector3 = partesVector[2]; //ex: 5

float x;
float y; //declaração de variaveis
float z;

if (!ConverterFloat(vector1, out x, false)) //chama o metodo de converter, vector1 vira o valorRecebido, e numero vira o x. se nao conseguir cancela
{
 CodigoInvalido();
	return;
}

if (!ConverterFloat(vector2, out y, false))
{
CodigoInvalido();
	return;
}

if (!ConverterFloat(vector3, out z, false))
{
   CodigoInvalido();
	return;
}

Vector3 vetor = new Vector3(x, y, z);

Debug.Log("Campo: " + campo);
Debug.Log("x: " + x);
Debug.Log("y: " + y);
Debug.Log("z: " + z);
Debug.Log("Vector: " + vetor);

	digitandoCodigo = false;
	objetoSelecionado.Alterar(campo, vetor);
		SairModoProgramacao();
	}
	
	
	
	
private void LimparSelecao()
{
	if (objetoSelecionado != null)
{
    Outline outline = objetoSelecionado.GetComponent<Outline>(); //limpa apenas quem ta com o outline azul

    if (outline != null)
        outline.enabled = false;
}

}

	private void SairModoProgramacao()
	{

	digitandoCodigo = false;
	modoProgramacao = false;
	Time.timeScale = 1f;
	holograma.SetActive(false);
	
	Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        freeLook.m_XAxis.m_MaxSpeed = pausa.sensiX;
        freeLook.m_YAxis.m_MaxSpeed = pausa.sensiY;
	}
	
	void AdicionarHistorico(string comando)
{
    for (int i = 4; i > 0; i--)
    {
        voltarComando[i] = voltarComando[i - 1];
    }

    voltarComando[0] = comando;
}

      public void FecharPelaHud()
        {
        painelProgramacao.SetActive(false);
	SairModoProgramacao();
	LimparSelecao();
	StartCoroutine(DemoraClicar());
        }
	
	
}
