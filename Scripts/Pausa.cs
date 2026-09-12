using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cinemachine;

public class Pausa : MonoBehaviour
{
    [SerializeField] private Image imgBgPreto;
    [SerializeField] private GameObject bgPreto;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuOpcoes;
    [SerializeField] private GameObject confirmarSair;
    [SerializeField] private Slider sensi;
    [SerializeField] private GameObject menuScripts;
    
    
    [SerializeField] public GameObject script1com;
    [SerializeField] public GameObject script1sem;
    
    [SerializeField] public GameObject script2com;
    [SerializeField] public GameObject script2sem;
    
    [SerializeField] public GameObject script3com;
    [SerializeField] public GameObject script3sem;
    
    [SerializeField] public GameObject script4com;
    [SerializeField] public GameObject script4sem;
    
    [SerializeField] public GameObject script5com;
    [SerializeField] public GameObject script5sem;
    
    [SerializeField] public GameObject script6com;
    [SerializeField] public GameObject script6sem;
    
    [SerializeField] public GameObject script7com;
    [SerializeField] public GameObject script7sem;
    
    [SerializeField] public GameObject script8com;
    [SerializeField] public GameObject script8sem;
    
    [SerializeField] public GameObject script9com;
    [SerializeField] public GameObject script9sem;
    
    [SerializeField] public GameObject script10com;
    [SerializeField] public GameObject script10sem;
    
    [SerializeField] public GameObject script11com;
    [SerializeField] public GameObject script11sem;
    
    
    [SerializeField] public GameObject grandeScript1;
    [SerializeField] public GameObject grandeScript2;
    [SerializeField] public GameObject grandeScript3;
    [SerializeField] public GameObject grandeScript4;
    [SerializeField] public GameObject grandeScript5;
    [SerializeField] public GameObject grandeScript6;
    [SerializeField] public GameObject grandeScript7;
    [SerializeField] public GameObject grandeScript8;
    [SerializeField] public GameObject grandeScript9;
    [SerializeField] public GameObject grandeScript10;
    [SerializeField] public GameObject grandeScript11;
    
    public bool jogoPausado = false;
    private bool algumPainelAtivo = false;
    
    public float sensiX = 300f;
    public float sensiY = 4f;
    
    [SerializeField] private CinemachineFreeLook freeLook;
    
    private TransicaoIris transicao;
    
    private PainelProgramacao[] paineis;

    // Start is called before the first frame update
    void Start()
    {
        transicao = FindObjectOfType<TransicaoIris>();
        paineis = FindObjectsOfType<PainelProgramacao>();
        
        imgBgPreto.color = new Color (0f, 0f, 0f, 0.80f);
        
        menu.SetActive(false);
        bgPreto.SetActive(false);
        menuScripts.SetActive(false);
        
        jogoPausado = false;
        algumPainelAtivo = false;
        
	sensi.value = 50f;
	sensiX = 300f;
        sensiY = 4f;
        
        
    }

    // Update is called once per frame
    void Update()
    {    
 	algumPainelAtivo = false;
        foreach (PainelProgramacao painel in paineis)
        {
            if(painel.programandoPainel)
            {
                algumPainelAtivo = true;
                break;
            }
        }
    
    
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogoPausado)
            {
		Despausar();
            }
            else
            {   
                if (!transicao.fazendo && !algumPainelAtivo)
                Pausar();
            }
        }
    }
    
    
    public void Pausar()
    {
        menu.SetActive(true);
        bgPreto.SetActive(true);
        menuOpcoes.SetActive(false);
        confirmarSair.SetActive(false);
        menuScripts.SetActive(false);
        
        freeLook.m_XAxis.m_MaxSpeed = 0;
        freeLook.m_YAxis.m_MaxSpeed = 0;
        
        Time.timeScale = 0f;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        jogoPausado = true;
    }
    
    public void Despausar()
    {
        menu.SetActive(false);
        bgPreto.SetActive(false);
        menuOpcoes.SetActive(false);
        confirmarSair.SetActive(false);
        menuScripts.SetActive(false);
        
        grandeScript1.SetActive(false);
        grandeScript2.SetActive(false);
        grandeScript3.SetActive(false);
        grandeScript4.SetActive(false);
        grandeScript5.SetActive(false);
        grandeScript6.SetActive(false);
        grandeScript7.SetActive(false);
        grandeScript8.SetActive(false);
        grandeScript9.SetActive(false);
        grandeScript10.SetActive(false);
        grandeScript11.SetActive(false);
            
        freeLook.m_XAxis.m_MaxSpeed = sensiX;
        freeLook.m_YAxis.m_MaxSpeed = sensiY;

        Time.timeScale = 1f;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        jogoPausado = false;
        AtualizarSensibilidade();
    }
    
    public void MenuOpcoes()
    {
        menuOpcoes.SetActive(true);
        menu.SetActive(false);
        
        freeLook.m_XAxis.m_MaxSpeed = 0;
        freeLook.m_YAxis.m_MaxSpeed = 0;
        
        Time.timeScale = 0f;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        jogoPausado = true;
    }
    
    public void AtualizarSensibilidade()
    {
    	float t = sensi.value / 50f;
    	
    	sensiX = 300f * t;
    	sensiY = 4f * t; 
    	
        freeLook.m_XAxis.m_MaxSpeed = sensiX;
        freeLook.m_YAxis.m_MaxSpeed = sensiY;
    }
    
    public void MenuScripts()
    {
    	menuScripts.SetActive(true);
        menu.SetActive(false);
        
        freeLook.m_XAxis.m_MaxSpeed = 0;
        freeLook.m_YAxis.m_MaxSpeed = 0;
        
        Time.timeScale = 0f;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        jogoPausado = true;
        
        grandeScript1.SetActive(false);
        grandeScript2.SetActive(false);
        grandeScript3.SetActive(false);
        grandeScript4.SetActive(false);
        grandeScript5.SetActive(false);
        grandeScript6.SetActive(false);
        grandeScript7.SetActive(false);
        grandeScript8.SetActive(false);
        grandeScript9.SetActive(false);
        grandeScript10.SetActive(false);
        grandeScript11.SetActive(false);
    }
    
    public void ConfirmarSair()
    {
        menu.SetActive(false);
        confirmarSair.SetActive(true);
        
        freeLook.m_XAxis.m_MaxSpeed = 0;
        freeLook.m_YAxis.m_MaxSpeed = 0;
        
        Time.timeScale = 0f;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        jogoPausado = true;
    }
    
    public void Sair()
    {
        UnityEditor.EditorApplication.isPlaying = false;//por enquanto
    }
    
    public void NaoSair()
    {
        Pausar();
    }
    
    public void AbrirScript1()
    {
        menuScripts.SetActive(false);
	grandeScript1.SetActive(true);
    }
    public void AbrirScript2()
    {
        menuScripts.SetActive(false);
	grandeScript2.SetActive(true);
    }
    public void AbrirScript3()
    {
        menuScripts.SetActive(false);
	grandeScript3.SetActive(true);
    }
    public void AbrirScript4()
    {
        menuScripts.SetActive(false);
	grandeScript4.SetActive(true);
    }
    public void AbrirScript5()
    {
        menuScripts.SetActive(false);
	grandeScript5.SetActive(true);
    }
    public void AbrirScript6()
    {
        menuScripts.SetActive(false);
	grandeScript6.SetActive(true);
    }
    public void AbrirScript7()
    {
        menuScripts.SetActive(false);
	grandeScript7.SetActive(true);
    }
    public void AbrirScript8()
    {
        menuScripts.SetActive(false);
	grandeScript8.SetActive(true);
    }
    public void AbrirScript9()
    {
        menuScripts.SetActive(false);
	grandeScript9.SetActive(true);
    }
    public void AbrirScript10()
    {
        menuScripts.SetActive(false);
	grandeScript10.SetActive(true);
    }
    public void AbrirScript11()
    {
        menuScripts.SetActive(false);
	grandeScript11.SetActive(true);
    }
    
    

}
