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
	
	private Coroutine respostaRaposa;
	
    // Start is called before the first frame update
    void Start()
    {
    	minhaCamera = GameObject.FindGameObjectWithTag("Camera").transform;
    }
    
    void LateUpdate()
    {
        Vector3 direcao = minhaCamera.position - transform.position;
        direcao.y = 0;
        transform.forward = direcao;
    }

    // Update is called once per frame
    void Update()
    {
if (balaoAtivado && 
    (
        (javali != null && javali.balaoAtivado && areaResposta) ||
        (raposa != null && raposa.balaoAtivado && areaRespostaRaposa)
    ))
        {
        	balao.SetActive(true);
        }
        else
        {
        	balao.SetActive(false);
        }
        
        
        if (raposa != null && raposa.dialogueDenovo)
        {
        respostaRaposa = StartCoroutine(AtivarDialogoRaposa());
        }
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
	balaoAtivado = true;
	
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
        
	balaoAtivado = true;
	
	
	if (raposa.idRaposa == 1)
	{
	if (raposa.instrucaoUm)
	dialogo3d.text = "id 1, instrucao 1";
	else
	dialogo3d.text = "id 1, instrucao 2";
	}
	
	else if (raposa.idRaposa == 2)
	{
	if (raposa.instrucaoUm)
	dialogo3d.text = "id 2, instrucao 1";
	else
	dialogo3d.text = "id 2, instrucao 2";
	}
	
	yield return new WaitForSeconds(5f);

    respostaRaposa = null;
	balaoAtivado = false;
}



}
