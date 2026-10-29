
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;
public class BalaoDialogoJogador : MonoBehaviour
{
	private Transform minhaCamera;
	[SerializeField] private TMPro.TextMeshPro dialogo3d;
	[SerializeField] private GameObject balao;
	
	bool balaoAtivado;
	bool areaResposta;
	bool areaRespostaRaposa;
	
	
	
	balaoDialogo javali;
	BALAORaposa raposa;
	
	private BALAORaposa falandoCom;
private bool respondendoFalaLivre;
	
	private Coroutine respostaRaposa;
	
	private Coroutine respostaFalaLivre;
	
    // Start is called before the first frame update
    void Start()
    {
    	minhaCamera = GameObject.FindGameObjectWithTag("Camera").transform;
    }
    
    void Update()
{
    bool mostrarOutros = balaoAtivado &&
    (
        (javali != null && javali.balaoAtivado && areaResposta) ||
        (raposa != null && raposa.balaoAtivado && areaRespostaRaposa)
    );

    bool mostrarFalaLivre = respondendoFalaLivre &&
                            falandoCom != null &&
                            falandoCom.balaoAtivado &&
                            falandoCom.estaNaAreaBalao;

    balao.SetActive(mostrarOutros || mostrarFalaLivre);

    if (raposa != null && raposa.dialogueDenovo)
    {
        respostaRaposa = StartCoroutine(AtivarDialogoRaposa());
        
    }
}
    
    void LateUpdate()
    {
        Vector3 direcao = minhaCamera.position - transform.position;
        direcao.y = 0;
        transform.forward = direcao;
    }

    
public void ResponderFalaLivre(BALAORaposa quemFalou, int fala)
{
    if (respostaFalaLivre != null)
    {
        StopCoroutine(respostaFalaLivre);
        respostaFalaLivre = null;
        respondendoFalaLivre = false;
    }

    string resposta = PegarRespostaFalaLivre(quemFalou.idRaposa, fala);
    if (resposta == null) return;

    respostaFalaLivre = StartCoroutine(AtivarRespostaFalaLivre(quemFalou, resposta));
}

private IEnumerator AtivarRespostaFalaLivre(BALAORaposa quemFalou, string resposta)
{
    yield return new WaitForSeconds(3f);

    if (quemFalou == null || !quemFalou.balaoAtivado || !quemFalou.estaNaAreaBalao)
    {
        respostaFalaLivre = null;
        yield break;
    }

    dialogo3d.text = resposta;
    falandoCom = quemFalou;
    respondendoFalaLivre = true;
    AudioManager.instancia.SomBalao();

    yield return new WaitForSeconds(3.7f);

    respondendoFalaLivre = false;
    falandoCom = null;
    respostaFalaLivre = null;
}

// retorna null quando o Dígito não responde
private string PegarRespostaFalaLivre(int idRaposa, int fala)
{
dialogo3d.fontSize = 26f;
    if (idRaposa == 1)
    {
        if (fala == 1) return "Me chamo Dígito, minha missão é salvar este mundo.";
        if (fala == 2)
        {
        dialogo3d.fontSize = 30f;
        return "Vírus cogumelos? ok.";
        }
        //if (fala == 3) return "...";
    }
    else if (idRaposa == 2)
    {
        // fala 1: sem resposta
        //if (fala == 2) return "Entendi!";
        // fala 3: sem resposta
    }

    return null;
}

    
    //problema, o dialogo desaparece mas nn conta q eu sai da area dele para o metodo reiniciar.
    private void OnTriggerEnter(Collider other)
{
	if (other.CompareTag("DialogoInimigo") )
        {
    areaResposta = true;
    
	javali = other.GetComponent<balaoDialogo>();
	if (javali == null)
		javali = other.GetComponentInParent<balaoDialogo>();
	if (javali == null)
		javali = other.GetComponentInChildren<balaoDialogo>();
		
	if (javali != null)
	{
		Debug.Log("encontrou alguem com dialogo");
		StartCoroutine(AtivarDialogo());
	}
	
		}
		

			if (other.CompareTag("DialogoRaposa") )
        {
    areaRespostaRaposa = true;
    
	raposa = other.GetComponent<BALAORaposa>();
	if (raposa == null)
		raposa = other.GetComponentInParent<BALAORaposa>();
	if (raposa == null)
		raposa = other.GetComponentInChildren<BALAORaposa>();
		
	if (raposa != null)
	{
		Debug.Log("encontrou raposa");
    if (respostaRaposa == null)
        respostaRaposa = StartCoroutine(AtivarDialogoRaposa());
	}
	
		}
}

    private void OnTriggerExit(Collider other)
{
	if (other.CompareTag("DialogoInimigo") )
        {
        areaResposta = false;
        }
        
  	if (other.CompareTag("DialogoRaposa") )
        {
        areaRespostaRaposa = false;
        }      
}

private IEnumerator AtivarDialogo()
{
	yield return new WaitForSeconds(3.5f);
dialogo3d.fontSize = 36f;
	
	balaoAtivado = true;
		AudioManager.instancia.SomBalao();
	
	if (javali.idDialogo == 1)
	{
	dialogo3d.text = "De nada.";
	}
	else if (javali.idDialogo == 2)
	{
	dialogo3d.text = "Acontece.";
	}
	else if (javali.idDialogo == 3)
	{
	dialogo3d.text = "Acho que queria um autógrafo.";
	}
	else if (javali.idDialogo == 4)
	{
	dialogo3d.text = "Nem um carinho?";
	}
	else if (javali.idDialogo == 5)
	{
	dialogo3d.text = "Eu sei.. eu sei.";
	}
	else if (javali.idDialogo == 6)
	{
	dialogo3d.text = "De nada.";
	}
	else if (javali.idDialogo == 7)
	{
	dialogo3d.text = "Já tô vazando.";
	}
	else if (javali.idDialogo == 8)
	{
	dialogo3d.text = "Ha-ha.";
	}
	else if (javali.idDialogo == 9)
	{
	dialogo3d.text = "Era tudo que eu mais esperava.";
	}
	else if (javali.idDialogo == 10)
	{
	dialogo3d.text = "Tamo junto!";
	}
	else if (javali.idDialogo == 11)
	{
	dialogo3d.text = "Tamo junto!";
	}
	else if (javali.idDialogo == 12)
	{
	dialogo3d.text = "Coé.";
	}
	
	
	yield return new WaitForSeconds(5f);
	balaoAtivado = false;
}



public IEnumerator AtivarDialogoRaposa()
{
	raposa.dialogueDenovo =false;
	yield return new WaitForSeconds(3.5f);
	
	    if (!areaRespostaRaposa || raposa == null || !raposa.balaoAtivado)
	    {
	        respostaRaposa = null;
        yield break;
        }
        


	
	if (raposa.idRaposa == 3)
	{
	balaoAtivado = true;
	AudioManager.instancia.SomBalao();
	if (raposa.instrucaoUm)
	dialogo3d.text = "Talvez se eu podesse fazer ficar verdadeira.";
	else
	dialogo3d.text = "Devo substituir \">\" por \"<\"! ";
	}
	
	/*else if (raposa.idRaposa == 2)
	{
	if (raposa.instrucaoUm)
	dialogo3d.text = "id 2, instrucao 1";
	else
	dialogo3d.text = "id 2, instrucao 2";
	}
	*/
	
	yield return new WaitForSeconds(9f);

    respostaRaposa = null;
	balaoAtivado = false;
}

public void ResetarEstado()
{
    StopAllCoroutines();

    respondendoFalaLivre = false;
    falandoCom = null;
    respostaRaposa = null;
    respostaFalaLivre = null;
    balaoAtivado = false;

    areaResposta = false;
    areaRespostaRaposa = false;

    raposa = null;
    javali = null;


    dialogo3d.text = "";
    dialogo3d.fontSize = 26f;

    balao.SetActive(false);
}


}

