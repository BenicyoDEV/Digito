using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TransicaoIris : MonoBehaviour
{
    [SerializeField] private RectTransform iris;

    [SerializeField] private float duracaoFechar = 3f;
    [SerializeField] private float duracaoAbrir = 3f;
    [SerializeField] private GameObject fundoPreto;
    [SerializeField] private GameObject buraco;
    [SerializeField] private float escalaAberta = 400f;
    
    public bool fazendo = false;
    
	[SerializeField] private CinemachineFreeLook freeLook;
    
    	private float MaxX;
	private float MaxY;
    
    private void Awake()
    {
        iris.localScale = Vector3.one * escalaAberta;
        fundoPreto.SetActive(false);
        buraco.SetActive(true);
    }
    
    private void Start()
    {
            
        MaxX = freeLook.m_XAxis.m_MaxSpeed;
        MaxY = freeLook.m_YAxis.m_MaxSpeed;
    }

    public IEnumerator FecharAbrir(System.Action aoFechar)
    {
    fazendo = true;
    
    Time.timeScale = 0f;
    
    freeLook.m_XAxis.m_MaxSpeed = 0;
    freeLook.m_YAxis.m_MaxSpeed = 0;
    
    buraco.SetActive(true);
    
    StartCoroutine(TelaPreta());
                   
        // FECHA
        yield return StartCoroutine(AnimarEscala(escalaAberta, 0.5f, duracaoFechar));

        aoFechar?.Invoke();
        yield return new WaitForSecondsRealtime(1f);
	
        // ABRE
        yield return StartCoroutine(AnimarEscala( 0.5f, escalaAberta, duracaoAbrir));
        buraco.SetActive(false);
        
    fazendo = false;
    }

    private IEnumerator AnimarEscala(
        float escalaInicial,
        float escalaFinal,
        float duracao
    )
    {
        float tempo = 0f;

        while (tempo < duracao)
        {
            tempo += Time.unscaledDeltaTime;

            float progresso = tempo / duracao;

            progresso = Mathf.SmoothStep(
                0f,
                1f,
                progresso
            );

            float escala = Mathf.Lerp(
                escalaInicial,
                escalaFinal,
                progresso
            );

            iris.localScale = Vector3.one * escala;

            yield return null;
        }

        iris.localScale = Vector3.one * escalaFinal;
    }
    
    
    private IEnumerator TelaPreta()
    {
       yield return new WaitForSecondsRealtime(1.9f);
          fundoPreto.SetActive(true);
              Time.timeScale = 1f;
    freeLook.m_XAxis.m_MaxSpeed = MaxX;
    freeLook.m_YAxis.m_MaxSpeed = MaxY;
       yield return new WaitForSecondsRealtime(2.6f); //qualquer coisa, aumentar esse
          fundoPreto.SetActive(false);
    }
    
}

//pausar o jogo para aniação
