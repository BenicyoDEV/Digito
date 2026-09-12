using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaReset : MonoBehaviour
{

private Vector3[] posicoes;
private Quaternion[] rotacoes;
private Transform[] filhos;

    // Start is called before the first frame update
    void Start()
    {
	/*int quantidade = transform.childCount;
	
	filhos = new Transform[quantidade];
	posicoes = new Vector3[quantidade];
	rotacoes = new Quaternion[quantidade];      
	
	for (int i = 0; i < quantidade; i++)
	{
	filhos[i] = transform.GetChild(i);
	posicoes[i] = filhos[i].position;
	rotacoes[i] = filhos[i].rotation;
	}*/
	
	filhos = GetComponentsInChildren<Transform>(true);
	
	posicoes = new Vector3[filhos.Length];
	rotacoes = new Quaternion[filhos.Length];      
	
	for (int i = 1; i < filhos.Length; i++) //começa em 1 pq a zona se conta
	{
	posicoes[i] = filhos[i].position;
	rotacoes[i] = filhos[i].rotation;
	}
	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
public void ResetarZona()
{
    // PASSADA 1: reativa e reposiciona tudo primeiro
    for (int i = 1; i < filhos.Length; i++)
    {
        InimigoCurado paiCurado = filhos[i].GetComponentInParent<InimigoCurado>();
        bool ehPaiCurado = filhos[i].GetComponent<InimigoCurado>() != null;
        if (paiCurado != null && !ehPaiCurado)
        continue;

        filhos[i].gameObject.SetActive(true);
        filhos[i].position = posicoes[i];
        filhos[i].rotation = rotacoes[i];
    }

    // PASSADA 2: só agora chama todos os ResetarEstado()
    for (int i = 1; i < filhos.Length; i++)
    {
        InimigoCurado paiCurado = filhos[i].GetComponentInParent<InimigoCurado>();
        bool ehPaiCurado = filhos[i].GetComponent<InimigoCurado>() != null;
        if (paiCurado != null && !ehPaiCurado)
        continue;

        Raspberry_sc rasp = filhos[i].GetComponent<Raspberry_sc>();
        if (rasp != null)
        rasp.ResetarEstado();

        Movimento_inimigo javali = filhos[i].GetComponent<Movimento_inimigo>();
        if (javali != null)
        javali.ResetarEstado();

        Movimento_passaro passaro = filhos[i].GetComponent<Movimento_passaro>();
        if (passaro != null)
        passaro.ResetarEstado();

        Cenario cenario = filhos[i].GetComponent<Cenario>();
        if (cenario != null)
        cenario.ResetarEstado();

        ArvoreAnimacao arvore = filhos[i].GetComponent<ArvoreAnimacao>();
        if (arvore != null)
        arvore.ResetarEstado();

        PainelProgramacao painel = filhos[i].GetComponent<PainelProgramacao>();
        if (painel != null)
        painel.ResetarEstado();

        InimigoCurado iC = filhos[i].GetComponent<InimigoCurado>();
        if (iC != null)
        iC.ResetarEstado();

        EmergirIlha emergir = filhos[i].GetComponent<EmergirIlha>();
        if (emergir != null)
        emergir.ResetarEstado();

        InimigoAgressivo iA = filhos[i].GetComponent<InimigoAgressivo>();
        if (iA != null)
        iA.ResetarEstado();

        CogumeloGrande cogGrande = filhos[i].GetComponent<CogumeloGrande>();
        if (cogGrande != null)
        cogGrande.ResetarEstado();

        Cogumelo cogumelo = filhos[i].GetComponent<Cogumelo>();
        if (cogumelo != null)
        cogumelo.ResetarEstado();

        Script script = filhos[i].GetComponent<Script>();
        if (script != null)
        {
        script.ResetarEstado();
        script.ResetarCanva();
        }

        RaposaP raposa = filhos[i].GetComponent<RaposaP>();
        if (raposa != null)
        raposa.ResetarEstado();
    }
}

}
