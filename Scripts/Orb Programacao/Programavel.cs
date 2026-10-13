using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Programavel : MonoBehaviour
{

 public bool programavel = true;
 
 public float speed;
 public bool inDash;
 public Vector3 translate;
 public string nome;
 
 private Movimento_inimigo javali;
 private Movimento_passaro passaro;
 private Cenario cenario;
 private ArvoreAnimacao arvore;
 private Raspberry_sc rasp;
 private InimigoCuradoOrb inimigocu;
 private Holograma holograma;
 private Script script;
 private RaposaP raposa;
    // Start is called before the first frame update
    void Start()
    {
    javali = GetComponent<Movimento_inimigo>(); 
    passaro = GetComponent<Movimento_passaro>(); 
    cenario = GetComponent<Cenario>(); 
    arvore = GetComponent<ArvoreAnimacao>(); 
    rasp = GetComponent<Raspberry_sc>();
    inimigocu = GetComponent<InimigoCuradoOrb>();
    holograma = FindObjectOfType<Holograma>();
    script = GetComponent<Script>();
    raposa = GetComponent<RaposaP>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Alterar(string campo, float numero)
    {
    
    if (campo == "speed")
    {
    
    if (javali != null)
    {
    javali.speed = numero;
    javali.speedPatrulha = numero;
    javali.speedPerseguicao = numero;
    javali.velocidadeDash = numero;
    holograma.CodigoValido();
    }
    
    else if (rasp != null)
    {
    rasp.velocidade = numero;
        holograma.CodigoValido();
    }
    
    else if (script != null)
    {
    script.velocidade = numero;
        holograma.CodigoValido();
    }
    
    else if (passaro != null)
    {
    passaro.speed = numero;
    passaro.speedPatrulha = numero;
    passaro.speedPerseguicao = numero;
    passaro.velocidade = numero;
    passaro.speedDash = numero;
    passaro.velocidadeSubida = numero;
    passaro.velocidadeDescida = numero;
    passaro.velocidadeDash1 = numero;
    passaro.velocidadeDash2 = numero;
    passaro.velocidadeFlutuacao = numero;
        holograma.CodigoValido();
    }
    
        else 
    {
    holograma.CodigoInvalido();
    }
    
    }
   
    
    else if (campo == "gravity")
    {
    
    if (javali != null)
    {
    javali.forcaY = numero;
    javali.gravidade = numero;
        holograma.CodigoValido();
    }
    
    else if (cenario != null)
    {
    cenario.gravidade = numero;
        holograma.CodigoValido();
    }
    
    else if (rasp != null)
    {
    rasp.gravidade = numero;
    holograma.CodigoValido();
    }
    
    else if (script != null)
    {
    script.gravidade = numero;
    holograma.CodigoValido();
    }
    
    else if (inimigocu != null)
    {
    inimigocu.gravidade = numero;
    holograma.CodigoValido();
    }
        else if (raposa != null)
    {
    raposa.gravidade = numero;
    holograma.CodigoValido();
    }
    
    else if (passaro != null)
{
passaro.gravidade = numero;
    holograma.CodigoValido();
}

    else 
    {
    holograma.CodigoInvalido();
    }

    }
    
    else 
    {
    holograma.CodigoInvalido();
    }
    
    }
    
    public void AlterarMetodo(string nomeMetodo, bool boolMetodo)
    {
    
      if (nomeMetodo == "Revive")
    {
        if (arvore != null && arvore.boolVida == false)
{
arvore.boolVida = true;
    holograma.CodigoValido();
}
    else 
    {
    holograma.CodigoInvalido();
    }
    }
    
    
         else if (nomeMetodo == "Dash")
    {
        if (passaro != null)
{
passaro.IniciarDash();
    holograma.CodigoValido();
}

      else if (javali != null)
{
javali.IniciarPreparandoDash();
    holograma.CodigoValido();
}
    else 
    {
    holograma.CodigoInvalido();
    }
    }
    
        else 
    {
    holograma.CodigoInvalido();
    }
    
    
    

    }
    
    public void AlterarReturn(string campo, bool boolReturn)
    {
    if (campo == "return")
    {
    
    if (arvore != null && arvore.boolVida)
    {
    arvore.boolVida = false;
        holograma.CodigoValido();
    }
    
      else if (passaro != null && passaro.emDash)
    {
    passaro.rDash = true;
        holograma.CodigoValido();
    }
    
      else if (javali != null && (javali.dandoDash || javali.preparandoDash))
    {
    javali.rDash = true;
        holograma.CodigoValido();
    }
    
        else 
    {
    holograma.CodigoInvalido();
    }
    
    }
    
      else 
    {
    holograma.CodigoInvalido();
    }
    
    }
    
    public void Alterar(string campo, bool booleano)
    {

     if (campo == "movement.enabled")
    {
    if (passaro != null)
    {
    passaro.boolMovimento = booleano;
        holograma.CodigoValido();
    }
    
     else if (rasp != null)
    {
    rasp.boolMovimento = booleano;
        holograma.CodigoValido();
    }
    
    else if (script != null)
    {
    script.boolMovimento = booleano;
        holograma.CodigoValido();
    }
    
    else if (javali != null)
    {
    javali.boolMovimento = booleano;
        holograma.CodigoValido();
    }
    
        else if (inimigocu != null)
    {
    inimigocu.boolMovimento = booleano;
        holograma.CodigoValido();
    }
    
            else if (raposa!= null)
    {
    raposa.boolMovimento = booleano;
        holograma.CodigoValido();
    }
    
        else 
    {
    holograma.CodigoInvalido();
    }
    }
    
    else if (campo == "collider.enabled")
    {
    if (javali != null)
    {
javali.colliderDano.enabled = booleano;
javali.colliderMorte.enabled = booleano;
javali.colliderMorte2.enabled = booleano;
javali.danoScript.enabled = booleano;
javali.controller.detectCollisions = booleano;
if (!booleano)
{
javali.gameObject.layer = LayerMask.NameToLayer("semColisao");
}
else
{
javali.gameObject.layer = LayerMask.NameToLayer("Default");
}
    holograma.CodigoValido();
    }
    
    else if (rasp != null)
    {
if (!booleano)
{
rasp.gameObject.layer = LayerMask.NameToLayer("semColisao");
rasp.boolColisao = false;
}
else
{
rasp.gameObject.layer = LayerMask.NameToLayer("Default");
rasp.boolColisao = true;
}
    holograma.CodigoValido();
    }
    
        else if (script != null)
    {
if (!booleano)
{
script.gameObject.layer = LayerMask.NameToLayer("semColisao");
script.boolColisao = false;
}
else
{
script.gameObject.layer = LayerMask.NameToLayer("Default");
script.boolColisao = true;
}
    holograma.CodigoValido();
    }
    
    
else if (passaro != null)
    {
passaro.colliderDano.enabled = booleano;
passaro.colliderMorte.enabled = booleano;
passaro.danoScript.enabled = booleano;
passaro.controller.detectCollisions = booleano;
if (!booleano)
{
passaro.gameObject.layer = LayerMask.NameToLayer("semColisao");
}
else
{
passaro.gameObject.layer = LayerMask.NameToLayer("Default");
}
    holograma.CodigoValido();
    }
    
else if (cenario != null)
    {
cenario.colisao.enabled = booleano;
cenario.colisaoPisavel.enabled = booleano;
if (!booleano)
{
cenario.gameObject.layer = LayerMask.NameToLayer("semColisao");
}
else
{
cenario.gameObject.layer = LayerMask.NameToLayer("Ground");
}


    holograma.CodigoValido();
    }
    
else if (inimigocu != null)
    {
inimigocu.colisao.enabled = booleano;
inimigocu.colisao2.enabled = booleano;
if (!booleano)
{
inimigocu.gameObject.layer = LayerMask.NameToLayer("semColisao");


}
else
{
inimigocu.gameObject.layer = LayerMask.NameToLayer("Ground");
}
    holograma.CodigoValido();
    }
    
    
else if (raposa != null)
    {
raposa.colisao.enabled = booleano;
raposa.colisao2.enabled = booleano;
if (!booleano)
{
raposa.gameObject.layer = LayerMask.NameToLayer("semColisao");


}
else
{
raposa.gameObject.layer = LayerMask.NameToLayer("Ground");
}
    holograma.CodigoValido();
    }
    
        else 
    {
    holograma.CodigoInvalido();
    }

}

else if (campo == "gravity.enabled")
{
if (javali != null)
{
javali.boolGravidade = booleano;
    holograma.CodigoValido();
}

else if (cenario != null)
{
cenario.boolGravidade = booleano;
    holograma.CodigoValido();
}

else if (passaro != null)
{
passaro.boolGravidade = booleano;
    holograma.CodigoValido();
}

else if (rasp != null)
{
rasp.boolGravidade = booleano;
    holograma.CodigoValido();
}

else if (script != null)
{
script.boolGravidade = booleano;
    holograma.CodigoValido();
}

else if (inimigocu != null)
{
inimigocu.boolGravidade = booleano;
    holograma.CodigoValido();
}

else if (raposa != null)
{
raposa.boolGravidade = booleano;
    holograma.CodigoValido();
}

    else 
    {
    holograma.CodigoInvalido();
    }
}

else if (campo == "gizmo.enabled")
{

if (booleano == true)
{
holograma.CodigoValido();
holograma.hudGizmo.SetActive(true);
}
else
{
holograma.CodigoValido();
holograma.hudGizmo.SetActive(false);
}

}


    else 
    {
    holograma.CodigoInvalido();
    }

}
    
    public void Alterar(string campo, string valor)
    {
    
    
    }
    
    public void Alterar(string campo, Vector3 vetor)
      {
    
if (javali != null)
{
    if (campo == "position")
    {
      javali.MoverPara(javali.transform.position + vetor);
        holograma.CodigoValido();
    }
    
    else if (campo == "rotation")
    {
       javali.transform.eulerAngles += vetor;
        holograma.CodigoValido();
    }
    
    else if (campo == "scale")
    {
   javali.EscalonarPara(javali.transform.localScale + vetor);
        holograma.CodigoValido();
    }
    
        else 
    {
    holograma.CodigoInvalido();
    }
}

else if (passaro != null)
{
    if (campo == "position")
    {
     passaro.MoverPara(passaro.transform.position + vetor);
        holograma.CodigoValido();
    }
    
    else if (campo == "rotation")
    {
    passaro.transform.eulerAngles += vetor;
        holograma.CodigoValido();
    }
    
    else if (campo == "scale")
    {
    passaro.EscalonarPara(passaro.transform.localScale + vetor);
        holograma.CodigoValido();
    }
    
        else 
    {
    holograma.CodigoInvalido();
    }
}

else if (cenario != null)
{
    if (campo == "position")
    {
    cenario.MoverPara(cenario.transform.position + vetor);
        holograma.CodigoValido();
    }
    
    else if (campo == "rotation")
    {
    cenario.GirarPara(cenario.transform.eulerAngles + vetor);
        holograma.CodigoValido();
    }
    
    else if (campo == "scale")
    {
    cenario.EscalonarPara(cenario.transform.localScale + vetor);
        holograma.CodigoValido();
    }
    
        else 
    {
    holograma.CodigoInvalido();
    }
}

else if (rasp != null)
{
    if (campo == "position")
    {
    rasp.MoverPara(rasp.transform.position + vetor);
        holograma.CodigoValido();
    }
    
    else if (campo == "rotation")
    {
    rasp.GirarPara(rasp.transform.eulerAngles + vetor);
        holograma.CodigoValido();
    }
    
    else if (campo == "scale")
    {
    rasp.EscalonarPara(rasp.transform.localScale + vetor);
        holograma.CodigoValido();
    }
    
    else 
    {
    holograma.CodigoInvalido();
    }
}


else if (script != null)
{
    if (campo == "position")
    {
    script.MoverPara(script.transform.position + vetor);
        holograma.CodigoValido();
    }
    
    else if (campo == "rotation")
    {
    script.GirarPara(script.transform.eulerAngles + vetor);
        holograma.CodigoValido();
    }
    
    else if (campo == "scale")
    {
    script.EscalonarPara(script.transform.localScale + vetor);
        holograma.CodigoValido();
    }
    
    else 
    {
    holograma.CodigoInvalido();
    }
}

else if (inimigocu != null)
{
    if (campo == "position")
    {
    inimigocu.MoverPara(inimigocu.transform.position + vetor);
        holograma.CodigoValido();
    }
    
    else if (campo == "rotation")
    {
    inimigocu.GirarPara(inimigocu.transform.eulerAngles + vetor);
        holograma.CodigoValido();
    }
    
    else if (campo == "scale")
    {
    inimigocu.EscalonarPara(inimigocu.transform.localScale + vetor);
        holograma.CodigoValido();
    }
    
    else 
    {
    holograma.CodigoInvalido();
    }
}

else if (raposa != null)
{
    if (campo == "position")
    {
    raposa.MoverPara(raposa.transform.position + vetor);
        holograma.CodigoValido();
    }
    
    else if (campo == "rotation")
    {
    raposa.GirarPara(raposa.transform.eulerAngles + vetor);
        holograma.CodigoValido();
    }
    
    else if (campo == "scale")
    {
    raposa.EscalonarPara(raposa.transform.localScale + vetor);
        holograma.CodigoValido();
    }
    
    else 
    {
    holograma.CodigoInvalido();
    }
}

    else 
    {
    holograma.CodigoInvalido();
    }
    
    }
    
    
    
}
