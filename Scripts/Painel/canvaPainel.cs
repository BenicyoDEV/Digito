using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class canvaPainel : MonoBehaviour
{
[SerializeField] private Image imagemXis;
[SerializeField] private Image imagemRestart;

private PainelProgramacao painel;

public void DefinirPainel(PainelProgramacao painelAtual)
{
painel = painelAtual;
}

    void Start()
    {
    imagemXis.color = new Color (1f, 1f, 1f, 0.8f);
    imagemRestart.color = new Color (1f, 1f, 1f, 0.8f);
    }

    void Update()
    {

    }
    
    public void Reiniciar()
    {
    painel.ReiniciarPainel();    
    }
    
    public void Sair()
    {
    painel.SairProgramarPainel();
    }
        
        
}

