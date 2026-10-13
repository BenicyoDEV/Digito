using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;

public class PainelProgramacao : MonoBehaviour
{
public bool estaNaAreaPainel = false;
public bool programandoPainel = false;

public int idPainel;

private int mushroomVirus = 1;

private float timer;

private string valor1;
private string valor2;

private string console;
private string consoleInicio;

public bool painelResolvido = false;

private bool ehChamadoFloat;

private bool funcionando;


private string codigoInicio;

private string digitandoPainelSete; 

private string codigo3dPainelInicial;
private string inputCodPainelInicial;
private int mushroomVirusInicial;
private bool painelUmLinhaErroAtivoInicial;
private bool painelLuzAzulAtivaInicial;
private bool painelLuzVermelhaAtivaInicial;
private bool colliderPainelAreaAtivoInicial;

public float raioRender = 20f;
public LayerMask playerLayer;

[SerializeField] private GameObject corpoDigito;
[SerializeField] private GameObject olhoDigito;
[SerializeField] private GameObject esqueletoDigito;

[SerializeField] private CinemachineVirtualCamera cameraPainel;
[SerializeField] private CinemachineFreeLook freeLook;

[SerializeField] private GameObject canvaPainelHUD;
[SerializeField] private RectTransform canvaPainelFundo;
[SerializeField] private RectTransform canvaPainelTexto;

[SerializeField] private TMP_InputField inputCodPainel;
[SerializeField] private TMPro.TextMeshPro codigo3dPainel;

[SerializeField] private GameObject painelUmLinhaErro;

[SerializeField] private GameObject painelLuzAzul;
[SerializeField] private GameObject painelLuzVermelha;

[SerializeField] public Collider colliderPainelArea;

[SerializeField] private SphereCollider colliderLimparArea;

[SerializeField] private SphereCollider colliderAreaRender;

[SerializeField] private canvaPainel canvaPainel;


private Movimento_Jogador jogador;
private TransicaoIris transicao;
private Pausa pausa;
private BalaoDialogoJogador balaoDialogoJogador;


    // Start is called before the first frame update
    void Start()
    {
        transicao = FindObjectOfType<TransicaoIris>();
        pausa = FindObjectOfType<Pausa>();
        balaoDialogoJogador = FindObjectOfType<BalaoDialogoJogador>(true);

    
        if (idPainel == 1)
    {
consoleInicio = "-----------------------------------------------\n" +
"\n";

codigoInicio = "int mushroomVirus = 100;\n"+
"\n"+
"if (mushroomVirus > 50)\n"+
"{\n"+
"    region.infection = true;\n"+
"}\n"+ 
"else\n"+
"{\n"+
"    region.infection = false;\n"+
"}\n";


    codigo3dPainel.text = codigoInicio + consoleInicio;
    
    console = "<color=#aa0003>Região Infectada</color>";
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
    }
    
    
        if (idPainel == 2)
    {
consoleInicio = "-----------------------------------------------\n" +
"\n";

codigoInicio = "int mushroomVirus = 50 + 50;\n"+
"\n"+
"if (mushroomVirus > 50)\n"+
"{\n"+
"    mushroom.infection = true;\n"+
"}\n"+ 
"else\n"+
"{\n"+
"    mushroom.infection = false;\n"+
"}\n";


    codigo3dPainel.text = codigoInicio + consoleInicio;
    
    console = "<color=#aa0003>Cogumelos no Caminho</color>";
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
    }
    
    
        if (idPainel == 3)
    {
consoleInicio = "-----------------------------------------------\n" +
"\n";

codigoInicio = "bool infection = true;\n"+
"\n"+
"if (infection == true)\n"+
"{\n"+
"    region.infection = true;\n"+
"}\n"+ 
"else\n"+
"{\n"+
"    region.infection = false;\n"+
"}\n";


    codigo3dPainel.text = codigoInicio + consoleInicio;
    
    console = "<color=#aa0003>Região Infectada</color>";
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
    }
    
          if (idPainel == 4)
    {
consoleInicio = "-----------------------------------------------\n" +
"\n";

codigoInicio = "int mushroomVirus = 100;\n"+
"\n"+
"if (mushroomVirus < 50)\n"+
"{\n"+
"    island.Emerge();\n"+
"    mushroom.infected = false;\n"+
"}\n"+
"\n"+
"\n"+
"\n";

    codigo3dPainel.text = codigoInicio + consoleInicio;
    
    console = "<color=#aa0003>Ilha Submersa</color>";
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
    
    }

          if (idPainel == 5)
    {
consoleInicio = "-----------------------------------------------\n" +
"\n";

codigoInicio = "bool infection = true;\n"+
"\n"+
"if (!infection)\n"+
"{\n"+
"    island.Emerge();\n"+
"    tree.infected = false;\n"+
"}\n"+
"\n"+
"\n"+
"\n";


    codigo3dPainel.text = codigoInicio + consoleInicio;
    
    console = "<color=#aa0003>Ilha Submersa</color>";
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
    }
    
              if (idPainel == 6)
    {
consoleInicio = "-----------------------------------------------\n" +
"\n";

codigoInicio = "bool infection = true;\n"+
"int mushroomVirus = 25;\n"+
"\n"+
"if (infection || mushroomVirus > 50)\n"+
"    region.infection = true;\n"+
"else\n"+
"{\n"+
"    island.Emerge();\n"+
"    enemy.infection = false;\n"+
"}\n";


    codigo3dPainel.text = codigoInicio + consoleInicio;
    
    console = "<color=#aa0003>Ilha Submersa</color>";
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
    }
    
          if (idPainel == 7)
    {
consoleInicio = "-----------------------------------------------\n" +
"\n";

codigoInicio = "bool mushroom.infection = true;\n"+
"\n"+
"while(mushroomVirus > 0)\n"+
"{\n"+
"    mushroomVirus++;\n"+
"    Debug.Log(mushroomVirus);\n"+
"}\n"+
"mushroom.infection = false;"+
"\n"+
"\n"+
"\n";


    codigo3dPainel.text = codigoInicio + consoleInicio;
    
    console = "<color=#aa0003>Cogumelos no Caminho</color>";
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
    }
    
     if (idPainel == 8)
    {
consoleInicio = "-----------------------------------------------\n" +
"\n";

codigoInicio = "bool region.infection = true;\n"+
"\n"+
"while(mushroomVirus > 0)\n"+
"{\n"+
"    mushroomVirus += 3;\n"+
"    Debug.Log(mushroomVirus);\n"+
"}\n"+
"region.infection = false;"+
"\n"+
"\n"+
"\n";


    codigo3dPainel.text = codigoInicio + consoleInicio;
    
    console = "<color=#aa0003>Região Infectada</color>";
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
    }
    
         if (idPainel == 9)
    {
consoleInicio = "-----------------------------------------------\n" +
"\n";

codigoInicio = "while (mushroomVirus > 0)\n"+
"{\n"+
"    mushroomVirus++;\n"+
"    Debug.Log(mushroomVirus);\n"+
"    if (mushroomVirus == 1)\n"+
"    {\n"+
"        mushroomVirus = 3\n"+
"    }\n"+
"}\n"+
"region.infection = false;\n";


    codigo3dPainel.text = codigoInicio + consoleInicio;
    
    console = "<color=#aa0003>Região Infectada</color>";
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
    }
    
    
    
             jogador = FindObjectOfType<Movimento_Jogador>();
             
// salva o estado inicial exatamente como ficou montado no Start
codigo3dPainelInicial = codigo3dPainel.text;
inputCodPainelInicial = inputCodPainel.text;
mushroomVirusInicial = mushroomVirus;

painelUmLinhaErroAtivoInicial = painelUmLinhaErro.activeSelf;
painelLuzAzulAtivaInicial = painelLuzAzul.activeSelf;
painelLuzVermelhaAtivaInicial = painelLuzVermelha.activeSelf;
colliderPainelAreaAtivoInicial = colliderPainelArea.enabled;
             
    }

    // Update is called once per frame
    void Update()
    {
    bool playerDentro = Physics.CheckSphere(transform.position,raioRender, playerLayer);
    
                    if(Input.GetKeyDown(KeyCode.E) && estaNaAreaPainel && !transicao.fazendo && !pausa.jogoPausado)
            {
        
                if (!programandoPainel)
                {
                    EntrarProgramarPainel();
                }
        
            }
            
      //interpretadores em tempo real      
     if (idPainel == 1 && programandoPainel)
     {
         string digitandoPainelUm = inputCodPainel.text;
     
     
         if(!digitandoPainelUm.Trim().StartsWith("if"))
         {
             console = "<color=#aa0003>Comando não identificado</color>";
         }
         else if(!digitandoPainelUm.Contains("(") || !digitandoPainelUm.Contains(")"))
         {
             console = "<color=#aa0003>Parâmetro não identificado</color>";
         }
         else if(!digitandoPainelUm.Contains("==") && !digitandoPainelUm.Contains("!=") && !digitandoPainelUm.Contains("<") &&
            !digitandoPainelUm.Contains(">") && !digitandoPainelUm.Contains("<=") && !digitandoPainelUm.Contains(">="))
         {
             console = "<color=#aa0003>Operador não identificado</color>";
         }
         else if (digitandoPainelUm.Split("(").Length - 1 > 1 || digitandoPainelUm.Split(")").Length - 1 > 1)
         {
             console = "<color=#aa0003>Mais de um parâmetro identificado</color>";
         }
         else if(!digitandoPainelUm.Contains("mushroomVirus"))
         {
             console = "<color=#aa0003>Variável mushroomVirus não identificada.</color>";
         }
         else
         {
             console = "<color=#aa0003>Região Infectada</color>";
         }
         codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         
        
         if (digitandoPainelUm.Trim().StartsWith("if"))//"     if  (  mushroomVirus   >  101  )     "
         {
            digitandoPainelUm = digitandoPainelUm.Trim();//"if  (  mushroomVirus   >  101  )"
                 digitandoPainelUm = digitandoPainelUm.Substring(2);
		 digitandoPainelUm = digitandoPainelUm.Trim(); //(  mushroomVirus   >  101  )
		 
	     if (digitandoPainelUm.Contains("(") && digitandoPainelUm.Contains(")"))
	     {
	     
		 if (digitandoPainelUm.Split("(").Length - 1 <= 1 && digitandoPainelUm.Split(")").Length - 1 <= 1)// no maximo um ( e )
	         {
		     digitandoPainelUm = digitandoPainelUm.Trim('(', ')');
		     digitandoPainelUm = digitandoPainelUm.Trim(); //mushroomVirus      >    101
		  
		     if (digitandoPainelUm.Contains("mushroomVirus")) //se tiver a variavel
		     {
		         //preciso de uma condição falsa para dar que painel está correto
		         if (digitandoPainelUm.Contains("=="))
		         {
		            string[] partes = digitandoPainelUm.Split("==");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                         int numero = int.Parse(valor2);
	                             if(numero != 100)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero != 100)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                     }
		         }
		         
		         else if (digitandoPainelUm.Contains("!="))
		         {
		             string[] partes = digitandoPainelUm.Split("!=");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                         int numero = int.Parse(valor2);
	                             if(numero == 100)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero == 100)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                     }
		         }
		         
		         else if (digitandoPainelUm.Contains(">="))
		         {
		             string[] partes = digitandoPainelUm.Split(">=");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor2);
	                             if(100 <= numero)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero <= 100) 
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                     }
		         } 
		         
		         else if (digitandoPainelUm.Contains("<="))
		         {
		             string[] partes = digitandoPainelUm.Split("<=");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor2);
	                             if(100 >= numero)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero >= 100)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                     }
		         }  
		         
		         else if (digitandoPainelUm.Contains(">"))
		         {
		             string[] partes = digitandoPainelUm.Split(">");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor2);
	                             if(100 < numero)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero < 100) 
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                     }
		         } 
		         
		         else if (digitandoPainelUm.Contains("<"))
		         {
		             string[] partes = digitandoPainelUm.Split("<");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor2);
	                             if(100 > numero)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero > 100)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                     }
		         
		            }        
	                }
                    }
                }         
            }   
        }
        
        
     if (idPainel == 2 && programandoPainel)
     {
         string digitandoPainelDois = inputCodPainel.text; //   int    mushroomVirus    =    25    +    50   ;    

         if(!digitandoPainelDois.Contains("mushroomVirus"))
         {
             console = "<color=#aa0003>Variável mushroomVirus não identificada.</color>";
         }
         else if (!digitandoPainelDois.Trim().StartsWith("int") && !digitandoPainelDois.Trim().StartsWith("float") &&
         !digitandoPainelDois.Trim().StartsWith("string") && !digitandoPainelDois.Trim().StartsWith("bool"))
         {
             console = "<color=#aa0003>Tipo Váriavel não identificado</color>";
         }
         else if(!digitandoPainelDois.Contains("="))
         {
             console = "<color=#aa0003>Operador não identificado</color>";
         }
         else if (!digitandoPainelDois.Contains(";"))
         {
             console = "<color=#aa0003>(;) não identificado</color>";
         }
         else if (digitandoPainelDois.Split(";").Length != 2)
         {
             console = "<color=#aa0003>Mais de um (;) identificado</color>";
         }
         else if (!digitandoPainelDois.EndsWith(";"))
         {
             console = "<color=#aa0003>(;) Esperado ao final</color>";
         }
         else
         {
             console = "<color=#aa0003>Cogumelos no Caminho</color>";
         }
         codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         
         
         digitandoPainelDois = digitandoPainelDois.Trim();
         if (digitandoPainelDois.StartsWith("float"))
         {
         	ehChamadoFloat = true;
         }
         else
         {
         	ehChamadoFloat = false;
         }
         if (digitandoPainelDois.StartsWith("int") || digitandoPainelDois.StartsWith("float"))
         {
         	if (digitandoPainelDois.StartsWith("int"))
         	{
         		digitandoPainelDois = digitandoPainelDois.Substring(3);
         	}
         	else if (digitandoPainelDois.StartsWith("float"))
         	{
         		digitandoPainelDois = digitandoPainelDois.Substring(5);
         	}
         	digitandoPainelDois = digitandoPainelDois.Trim(); //mushroomVirus    =    25    +    50   ;    
         	if (digitandoPainelDois.StartsWith("mushroomVirus"))
         	{
         		digitandoPainelDois = digitandoPainelDois.Substring(13); //    =    25    +    50   ;    
         		digitandoPainelDois = digitandoPainelDois.Trim();
         		if (digitandoPainelDois.Split("=").Length == 2) // =    25    +    50   ;
         		{
         			if (digitandoPainelDois.StartsWith("="))
         		        {
         		 		digitandoPainelDois = digitandoPainelDois.Substring(1);
         		        	digitandoPainelDois = digitandoPainelDois.Trim(); //25       +      50    ;
         		        	if (digitandoPainelDois.Split(";").Length == 2 && digitandoPainelDois.EndsWith(";"))
         		                {
         		                	digitandoPainelDois = digitandoPainelDois.Replace(";", "");
         		                	digitandoPainelDois = digitandoPainelDois.Trim();
         		                	
         		                	if(digitandoPainelDois.Contains("+"))
         		                	{
         		                            	string[] partes = digitandoPainelDois.Split("+");  
	                   			    	if (partes.Length == 2) 
	                  		            	{
	                    		                	valor1 = partes[0].Trim(); 
	                    			        	valor2 = partes[1].Trim();
	                    			        	if (ehChamadoFloat == false)
	                    			        	{
	                    			        		int valor1n = int.Parse(valor1);
	                    			        		int valor2n = int.Parse(valor2);
	                    			    
	                    			        		float numero = valor1n + valor2n;
	                    			        		if (numero < 50)
	                    			        		{
	                    			        		PainelCorreto();
	                    			        		}
	                    			        	}
	                    			        	else
	                    			        	{
	                    			        		if (ConverterFloat(valor1, out float valor1n) &&
  									ConverterFloat(valor2, out float valor2n))
				    				        {
    										float numero = valor1n + valor2n;

  								        	if (numero < 50)
 										{
   								       		 	PainelCorreto();
  						                        	}
									}
	                    			        	}
	                    				}
         		                	}
         		                	else if(digitandoPainelDois.Contains("-"))
         		                	{
         		                            	string[] partes = digitandoPainelDois.Split("-");  
	                   			    	if (partes.Length == 2) 
	                  		            	{
	                    		                	valor1 = partes[0].Trim(); 
	                    			        	valor2 = partes[1].Trim();
	                    			        	if (ehChamadoFloat == false)
	                    			        	{
	                    			        		int valor1n = int.Parse(valor1);
	                    			        		int valor2n = int.Parse(valor2);
	                    			    
	                    			        		float numero = valor1n - valor2n;
	                    			        		if (numero < 50)
	                    			        		{
	                    			        		PainelCorreto();
	                    			        		}
	                    			        	}
	                    			        	else
	                    			        	{
	                    			        		if (ConverterFloat(valor1, out float valor1n) &&
  									ConverterFloat(valor2, out float valor2n))
				    				        {
    										float numero = valor1n - valor2n;

  								        	if (numero < 50)
 										{
   								       		 	PainelCorreto();
  						                        	}
									}
	                    			        	}
	                    				}
         		                	}
         		                	else if(digitandoPainelDois.Contains("*"))
         		                	{
         		                            	string[] partes = digitandoPainelDois.Split("*");  
	                   			    	if (partes.Length == 2) 
	                  		            	{
	                    		                	valor1 = partes[0].Trim(); 
	                    			        	valor2 = partes[1].Trim();
	                    			        	if (ehChamadoFloat == false)
	                    			        	{
	                    			        		int valor1n = int.Parse(valor1);
	                    			        		int valor2n = int.Parse(valor2);
	                    			    
	                    			        		float numero = valor1n * valor2n;
	                    			        		if (numero < 50)
	                    			        		{
	                    			        		PainelCorreto();
	                    			        		}
	                    			        	}
	                    			        	else
	                    			        	{
	                    			        		if (ConverterFloat(valor1, out float valor1n) &&
  									ConverterFloat(valor2, out float valor2n))
				    				        {
    										float numero = valor1n * valor2n;

  								        	if (numero < 50)
 										{
   								       		 	PainelCorreto();
  						                        	}
									}
	                    			        	}
	                    			    
	                    				}
         		                	}
         		                	else if(digitandoPainelDois.Contains("/"))
         		                	{
         		                            	string[] partes = digitandoPainelDois.Split("/");  
	                   			    	if (partes.Length == 2) 
	                  		            	{
	                    		                	valor1 = partes[0].Trim(); 
	                    			        	valor2 = partes[1].Trim();
	                    			        	if (ehChamadoFloat == false)
	                    			        	{
	                    			        		int valor1n = int.Parse(valor1);
	                    			        		int valor2n = int.Parse(valor2);
	                    			    
	                    			        		float numero = valor1n / valor2n;
	                    			        		if (numero < 50)
	                    			        		{
	                    			        		PainelCorreto();
	                    			        		}
	                    			        	}
	                    			        	else
	                    			        	{
	                    			        		if (ConverterFloat(valor1, out float valor1n) &&
  									ConverterFloat(valor2, out float valor2n))
				    				        {
    										float numero = valor1n / valor2n;

  								        	if (numero < 50)
 										{
   								       		 	PainelCorreto();
  						                        	}
									}
	                    			        	}
	                    			    
	                    				}
         		                	}
         		                	else
         		                	{
         		                		if (ehChamadoFloat == false)
         		                		{
         		                			int digitandoPainelDoisn = int.Parse(digitandoPainelDois);
	                    			        	if (digitandoPainelDoisn < 50)
	                    			        	{
	                    			        		PainelCorreto();
	                    			        	}
	                    			        }
	                    			        else
	                    			        {
	                    			        	if (ConverterFloat(digitandoPainelDois, out float digitandoPainelDoisn))
				    				{
  								        if (digitandoPainelDoisn < 50)
 									{
   								       		 PainelCorreto();
  						                        }
								}
	                    			        }
         		                	}
         		                }
         		        }
         		}      
         	}
         }
     }
     
     if (idPainel == 3 && programandoPainel)
     {
     	string digitandoPainelTres = inputCodPainel.text; //!infection|  infection == false|infectcion != true|false == infection|true != infection
     	digitandoPainelTres = digitandoPainelTres.Trim();
     	
     	 if(!digitandoPainelTres.Trim().StartsWith("if"))
         {
             console = "<color=#aa0003>Comando não identificado</color>";
         }
         else if(!digitandoPainelTres.Contains("(") || !digitandoPainelTres.Contains(")"))
         {
             console = "<color=#aa0003>Parâmetro não identificado</color>";
         }
         else if(!digitandoPainelTres.Contains("==") && !digitandoPainelTres.Contains("!=") && !digitandoPainelTres.Contains("!"))
         {
             console = "<color=#aa0003>Operador não identificado</color>";
         }
         else if (digitandoPainelTres.Split("(").Length - 1 > 1 || digitandoPainelTres.Split(")").Length - 1 > 1)
         {
             console = "<color=#aa0003>Mais de um parâmetro identificado</color>";
         }
         else if(!digitandoPainelTres.Contains("infection"))
         {
             console = "<color=#aa0003>Variável infection não identificada.</color>";
         }
         else
         {
             console = "<color=#aa0003>Região Infectada</color>";
         }
         codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         
     	if (digitandoPainelTres.StartsWith("if"))
     	{
		digitandoPainelTres = digitandoPainelTres.Substring(2);
        	digitandoPainelTres = digitandoPainelTres.Trim();
        	if (digitandoPainelTres.StartsWith("(") && digitandoPainelTres.EndsWith(")"))
        	{
 			digitandoPainelTres = digitandoPainelTres.Trim('(', ')');
        		digitandoPainelTres = digitandoPainelTres.Trim();
        if (digitandoPainelTres == "!infection")
        {
        	PainelCorreto();
        }
        if (digitandoPainelTres.StartsWith("infection"))
        {
        	digitandoPainelTres = digitandoPainelTres.Substring(9);
        	digitandoPainelTres = digitandoPainelTres.Trim();
        	if (digitandoPainelTres.StartsWith("=="))
        	{	
        		digitandoPainelTres = digitandoPainelTres.Substring(2);
        		digitandoPainelTres = digitandoPainelTres.Trim();
        		if (digitandoPainelTres == "false")
        		{
        			PainelCorreto();
        		}
        	}
        	else if (digitandoPainelTres.StartsWith("!="))
        	{	
        		digitandoPainelTres = digitandoPainelTres.Substring(2);
        		digitandoPainelTres = digitandoPainelTres.Trim();
        		if (digitandoPainelTres == "true")
        		{
        			PainelCorreto();
        		}
        	}
        	
        }
        else if (digitandoPainelTres.StartsWith("false"))
        {
        	digitandoPainelTres = digitandoPainelTres.Substring(5);
        	digitandoPainelTres = digitandoPainelTres.Trim();
        	if (digitandoPainelTres.StartsWith("=="))
        	{	
        		digitandoPainelTres = digitandoPainelTres.Substring(2);
        		digitandoPainelTres = digitandoPainelTres.Trim();
        		if (digitandoPainelTres == "infection")
        		{
        			PainelCorreto();
        		}
        	}
        }
        else if (digitandoPainelTres.StartsWith("true"))
        {
        	digitandoPainelTres = digitandoPainelTres.Substring(4);
        	digitandoPainelTres = digitandoPainelTres.Trim();
        	if (digitandoPainelTres.StartsWith("!="))
        	{	
        		digitandoPainelTres = digitandoPainelTres.Substring(2);
        		digitandoPainelTres = digitandoPainelTres.Trim();
        		if (digitandoPainelTres == "infection")
        		{
        			PainelCorreto();
        		}
        	}
        }
        	}
        }
     }
     
     if (idPainel == 4 && programandoPainel)
     {
         string digitandoPainelUm = inputCodPainel.text;
     
     
         if(!digitandoPainelUm.Trim().StartsWith("if"))
         {
             console = "<color=#aa0003>Comando não identificado</color>";
         }
         else if(!digitandoPainelUm.Contains("(") || !digitandoPainelUm.Contains(")"))
         {
             console = "<color=#aa0003>Parâmetro não identificado</color>";
         }
         else if(!digitandoPainelUm.Contains("==") && !digitandoPainelUm.Contains("!=") && !digitandoPainelUm.Contains("<") &&
            !digitandoPainelUm.Contains(">") && !digitandoPainelUm.Contains("<=") && !digitandoPainelUm.Contains(">="))
         {
             console = "<color=#aa0003>Operador não identificado</color>";
         }
         else if (digitandoPainelUm.Split("(").Length - 1 > 1 || digitandoPainelUm.Split(")").Length - 1 > 1)
         {
             console = "<color=#aa0003>Mais de um parâmetro identificado</color>";
         }
         else if(!digitandoPainelUm.Contains("mushroomVirus"))
         {
             console = "<color=#aa0003>Variável mushroomVirus não identificada.</color>";
         }
         else
         {
             console = "<color=#aa0003>Ilha Submersa</color>";
         }
         codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         
        
         if (digitandoPainelUm.Trim().StartsWith("if"))//"     if  (  mushroomVirus   >  101  )     "
         {
            digitandoPainelUm = digitandoPainelUm.Trim();//"if  (  mushroomVirus   >  101  )"
                 digitandoPainelUm = digitandoPainelUm.Substring(2);
		 digitandoPainelUm = digitandoPainelUm.Trim(); //(  mushroomVirus   >  101  )
		 
	     if (digitandoPainelUm.Contains("(") && digitandoPainelUm.Contains(")"))
	     {
	     
		 if (digitandoPainelUm.Split("(").Length - 1 <= 1 && digitandoPainelUm.Split(")").Length - 1 <= 1)// no maximo um ( e )
	         {
		     digitandoPainelUm = digitandoPainelUm.Trim('(', ')');
		     digitandoPainelUm = digitandoPainelUm.Trim(); //mushroomVirus      >    101
		  
		     if (digitandoPainelUm.Contains("mushroomVirus")) //se tiver a variavel
		     {
		         //preciso de uma condição falsa para dar que painel está correto
		         if (digitandoPainelUm.Contains("=="))
		         {
		            string[] partes = digitandoPainelUm.Split("==");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                         int numero = int.Parse(valor2);
	                             if(numero == 100)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero == 100)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                     }
		         }
		         
		         else if (digitandoPainelUm.Contains("!="))
		         {
		             string[] partes = digitandoPainelUm.Split("!=");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                         int numero = int.Parse(valor2);
	                             if(numero != 100)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero != 100)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                     }
		         }
		         
		         else if (digitandoPainelUm.Contains(">="))
		         {
		             string[] partes = digitandoPainelUm.Split(">=");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor2);
	                             if(100 >= numero)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero >= 100) 
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                     }
		         } 
		         
		         else if (digitandoPainelUm.Contains("<="))
		         {
		             string[] partes = digitandoPainelUm.Split("<=");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor2);
	                             if(100 <= numero)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero <= 100)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                     }
		         }  
		         
		         else if (digitandoPainelUm.Contains(">"))
		         {
		             string[] partes = digitandoPainelUm.Split(">");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor2);
	                             if(100 >= numero)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero >= 100) 
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                     }
		         } 
		         
		         else if (digitandoPainelUm.Contains("<"))
		         {
		             string[] partes = digitandoPainelUm.Split("<");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor2);
	                             if(100 <= numero)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero <= 100)
	                             {
	                             PainelCorreto();
	                             }
	                         }
	                     }
		         
		            }        
	                }
                    }
                }         
            }   
        }
      
        
       if (idPainel == 5 && programandoPainel)
     {
     	string digitandoPainelTres = inputCodPainel.text; //!infection|  infection == false|infectcion != true|false == infection|true != infection
     	digitandoPainelTres = digitandoPainelTres.Trim();
     	
     	 if(!digitandoPainelTres.Trim().StartsWith("if"))
         {
             console = "<color=#aa0003>Comando não identificado</color>";
         }
         else if(!digitandoPainelTres.Contains("(") || !digitandoPainelTres.Contains(")"))
         {
             console = "<color=#aa0003>Parâmetro não identificado</color>";
         }
         else if(!digitandoPainelTres.Contains("==") && !digitandoPainelTres.Contains("!="))
         {
             console = "<color=#aa0003>Operador não identificado</color>";
         }
         else if (digitandoPainelTres.Split("(").Length - 1 > 1 || digitandoPainelTres.Split(")").Length - 1 > 1)
         {
             console = "<color=#aa0003>Mais de um parâmetro identificado</color>";
         }
         else if(!digitandoPainelTres.Contains("infection"))
         {
             console = "<color=#aa0003>Variável infection não identificada.</color>";
         }
         else
         {
             console = "<color=#aa0003>Região Infectada</color>";
         }
         codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         
     	if (digitandoPainelTres.StartsWith("if"))
     	{
		digitandoPainelTres = digitandoPainelTres.Substring(2);
        	digitandoPainelTres = digitandoPainelTres.Trim();
        	if (digitandoPainelTres.StartsWith("(") && digitandoPainelTres.EndsWith(")"))
        	{
 			digitandoPainelTres = digitandoPainelTres.Trim('(', ')');
        		digitandoPainelTres = digitandoPainelTres.Trim();
        if (digitandoPainelTres == "infection")
        {
        	PainelCorreto();
        }
        if (digitandoPainelTres.StartsWith("infection"))
        {
        	digitandoPainelTres = digitandoPainelTres.Substring(9);
        	digitandoPainelTres = digitandoPainelTres.Trim();
        	if (digitandoPainelTres.StartsWith("!="))
        	{	
        		digitandoPainelTres = digitandoPainelTres.Substring(2);
        		digitandoPainelTres = digitandoPainelTres.Trim();
        		if (digitandoPainelTres == "false")
        		{
        			PainelCorreto();
        		}
        	}
        	else if (digitandoPainelTres.StartsWith("=="))
        	{	
        		digitandoPainelTres = digitandoPainelTres.Substring(2);
        		digitandoPainelTres = digitandoPainelTres.Trim();
        		if (digitandoPainelTres == "true")
        		{
        			PainelCorreto();
        		}
        	}
        	
        }
        else if (digitandoPainelTres.StartsWith("false"))
        {
        	digitandoPainelTres = digitandoPainelTres.Substring(5);
        	digitandoPainelTres = digitandoPainelTres.Trim();
        	if (digitandoPainelTres.StartsWith("!="))
        	{	
        		digitandoPainelTres = digitandoPainelTres.Substring(2);
        		digitandoPainelTres = digitandoPainelTres.Trim();
        		if (digitandoPainelTres == "infection")
        		{
        			PainelCorreto();
        		}
        	}
        }
        else if (digitandoPainelTres.StartsWith("true"))
        {
        	digitandoPainelTres = digitandoPainelTres.Substring(4);
        	digitandoPainelTres = digitandoPainelTres.Trim();
        	if (digitandoPainelTres.StartsWith("=="))
        	{	
        		digitandoPainelTres = digitandoPainelTres.Substring(2);
        		digitandoPainelTres = digitandoPainelTres.Trim();
        		if (digitandoPainelTres == "infection")
        		{
        			PainelCorreto();
        		}
        	}
        }
        	}
        }
     }
     
     if (idPainel == 6 && programandoPainel)
     {
     string digitandoPainelSeis = inputCodPainel.text;
     digitandoPainelSeis = digitandoPainelSeis.Trim();
     
              if(!digitandoPainelSeis.Trim().StartsWith("if"))
         {
             console = "<color=#aa0003>Comando não identificado</color>";
         }
         else if(!digitandoPainelSeis.Contains("(") || !digitandoPainelSeis.Contains(")"))
         {
             console = "<color=#aa0003>Parâmetro não identificado</color>";
         }

         else if (digitandoPainelSeis.Split("(").Length - 1 > 1 || digitandoPainelSeis.Split(")").Length - 1 > 1)
         {
             console = "<color=#aa0003>Mais de um parâmetro identificado</color>";
         }
         else if(!digitandoPainelSeis.Contains("mushroomVirus"))
         {
             console = "<color=#aa0003>Variável mushroomVirus não identificada.</color>";
         }
         else if(!digitandoPainelSeis.Contains("infection"))
         {
             console = "<color=#aa0003>Variável infection não identificada.</color>";
         }
         else if(!digitandoPainelSeis.Contains("&&") && !digitandoPainelSeis.Contains("||"))
         {
             console = "<color=#aa0003>Operador lógico não identificado</color>";
         }
         else
         {
             console = "<color=#aa0003>Ilha Submersa</color>";
         }
                  codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
     
     	if (digitandoPainelSeis.StartsWith("if"))
     	{
		digitandoPainelSeis = digitandoPainelSeis.Substring(2);
        	digitandoPainelSeis = digitandoPainelSeis.Trim();
        	if (digitandoPainelSeis.Split("(").Length - 1 <= 1 && digitandoPainelSeis.Split(")").Length - 1 <= 1)// no maximo um ( e )
	        {
        		if (digitandoPainelSeis.StartsWith("(") && digitandoPainelSeis.EndsWith(")"))
        		{
 				digitandoPainelSeis = digitandoPainelSeis.Trim('(', ')');
        			digitandoPainelSeis = digitandoPainelSeis.Trim();
        			
        			if (digitandoPainelSeis.Contains("||") && digitandoPainelSeis.Split("||").Length - 1 <= 1)
        			{
        			
					bool? infectionCorreto = null;
     					bool? mushroomCorreto = null;
     					
        		         	string[] partes = digitandoPainelSeis.Split("||");  
	                         	if (partes.Length == 2) 
	                         	{
	                         		valor1 = partes[0].Trim(); 
	                         		valor2 = partes[1].Trim();

						if (valor1.Contains("mushroomVirus"))
						{

							mushroomCorreto = MushroomVirusAfirmacaoVerdadeira(valor1, 25f);

							infectionCorreto = InfectionBoolVerdadeiro(valor2);

						}
					
					
						else if (valor1.Contains("infection"))
	                         		{

							infectionCorreto = InfectionBoolVerdadeiro(valor1);


							mushroomCorreto = MushroomVirusAfirmacaoVerdadeira(valor2, 25f);


	                         		}
	                         		
	                         		if (mushroomCorreto != null && infectionCorreto != null)
	                         		{
	                         			if (mushroomCorreto == false && infectionCorreto == false)
	                         			{
	                         			PainelCorreto();
	                         			}
	                         		}
	                         		Debug.Log("mushroomCorreto: "+ mushroomCorreto);
	                         		Debug.Log("infection: "+ infectionCorreto);
	                         	
	                         	}
        			
        			}
        			
        			else if (digitandoPainelSeis.Contains("&&") && digitandoPainelSeis.Split("&&").Length - 1 <= 1)
        			{
        			
					bool? infectionCorreto = null;
     					bool? mushroomCorreto = null;
     					
        		         	string[] partes = digitandoPainelSeis.Split("&&");  
	                         	if (partes.Length == 2) 
	                         	{
	                         		valor1 = partes[0].Trim(); 
	                         		valor2 = partes[1].Trim();

						if (valor1.Contains("mushroomVirus"))
						{

							mushroomCorreto = MushroomVirusAfirmacaoVerdadeira(valor1, 25f);


							infectionCorreto = InfectionBoolVerdadeiro(valor2);

						}
					
					
						else if (valor1.Contains("infection"))
	                         		{

							infectionCorreto = InfectionBoolVerdadeiro(valor1);
	
							mushroomCorreto = MushroomVirusAfirmacaoVerdadeira(valor2, 25f);

	                         		}
	                         		if (mushroomCorreto != null && infectionCorreto != null)
	                         		{
	                         			if (mushroomCorreto == false || infectionCorreto == false)
	                         			{
	                         			PainelCorreto();
	                         			}
	                         		}
	                         		Debug.Log("mushroomCorreto: "+ mushroomCorreto);
	                         		Debug.Log("infection: "+ infectionCorreto);
	                         	
	                         	}
	                         	
        			}
        			
        		}
        	}
        }
     	
     	
     	
     }
     
    if (idPainel == 7 && (playerDentro || programandoPainel))
     {
     	if (mushroomVirus <= -1)
     	{
     	PainelCorreto();
     	return;
     	}
     	
     if (programandoPainel)
     digitandoPainelSete = inputCodPainel.text;
     
     if (!programandoPainel)
     digitandoPainelSete = PegarLinha(codigo3dPainel.text, 4);
     digitandoPainelSete = digitandoPainelSete.Trim();    
     	
     	
    float raio2 = colliderLimparArea.radius * colliderLimparArea.transform.lossyScale.x;
    Collider[] objetos = Physics.OverlapSphere(colliderLimparArea.transform.position, raio2);
    foreach(Collider objeto in objetos)
    {
    IProgramavel programavel = objeto.GetComponent<IProgramavel>();
     	
     	if (programavel != null)
    programavel.MudarCogumelos(mushroomVirus);
    }
     
         if (!funcionando)
   	 {
         timer = 0f;
   	 }
   	 
if (!digitandoPainelSete.Contains("mushroomVirus"))
{
	console = "<color=#aa0003>Variável mushroomVirus não identificada</color>";
	codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
	return;
}

     if (digitandoPainelSete.StartsWith("mushroomVirus")) //x ++; x += 1;/x -= -1; x = x + 1; x = 1 + x; //++ x;  
     {
         digitandoPainelSete = digitandoPainelSete.Substring(13);
         if (digitandoPainelSete.StartsWith("++"))
         {
         	digitandoPainelSete = digitandoPainelSete.Substring(2);
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	if (digitandoPainelSete == ";")
         	{
         	//Debug.Log("x++");
         	//x++;
         		funcionando = true;
         		
         		timer += (Time.deltaTime * 0.5f);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus++;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
 
         	}
         	else
         	ConsolePV();

         }

         
         else if (digitandoPainelSete.StartsWith("--"))
         {
         	digitandoPainelSete = digitandoPainelSete.Substring(2);
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	if (digitandoPainelSete == ";")
         	{
         	//x--;
         	//Debug.Log("x--;");
         		funcionando = true;
         		
         		timer += (Time.deltaTime * 2.5f);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus--;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         	}
         	else
         	ConsolePV();
         }

         
         else if (digitandoPainelSete.Trim().StartsWith("+="))
         {
                digitandoPainelSete = digitandoPainelSete.Trim();
         	digitandoPainelSete = digitandoPainelSete.Substring(2);
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';') == 1)
         	{
		digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
                int numero = int.Parse(digitandoPainelSete);
                //x += numero;
                //Debug.Log("x += " + numero+";");
                
                        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus += numero;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         	}
         	else
         	ConsolePV();
         }
         else if (digitandoPainelSete.Trim().StartsWith("-="))
         {
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	digitandoPainelSete = digitandoPainelSete.Substring(2);
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	
         	if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';')==1)
         	{
		digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
                int numero = int.Parse(digitandoPainelSete);
                //x -= numero;
                //Debug.Log("x -= " + numero+";");
                
                        funcionando = true;
         		
         		timer += (Time.deltaTime  * 2.5f);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus -= numero;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         	}
         	else
         	ConsolePV();
         }
         else if (digitandoPainelSete.Trim().StartsWith("="))
         {
                digitandoPainelSete = digitandoPainelSete.Trim();
         	digitandoPainelSete = digitandoPainelSete.Substring(1);
         	digitandoPainelSete = digitandoPainelSete.Trim();

         	if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';')==1) //mushroomVirus + 1/1 + mushroomVirus
         	{
         		digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
         		
         		if(digitandoPainelSete.StartsWith("mushroomVirus"))
         		{
         		    digitandoPainelSete = digitandoPainelSete.Substring(13);
                            digitandoPainelSete = digitandoPainelSete.Trim();
         		
         		    if (digitandoPainelSete.StartsWith("+"))
         		    {
         		        digitandoPainelSete = digitandoPainelSete.Substring(1);
                                digitandoPainelSete = digitandoPainelSete.Trim();
                                int numero = int.Parse(digitandoPainelSete);
                                //x = x + numero;
                                //Debug.Log("x = x + " + numero+";");
                                
                        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus = mushroomVirus + numero;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		    }
         		    
         		    else if (digitandoPainelSete.StartsWith("-"))
         		    {
         		        digitandoPainelSete = digitandoPainelSete.Substring(1);
                                digitandoPainelSete = digitandoPainelSete.Trim();
                                int numero = int.Parse(digitandoPainelSete);
                                //x = x - numero;
                                //Debug.Log("x = x - " + numero+";");
                                
                        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus = mushroomVirus - numero;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
         		    }
         		    else
         		    ConsoleInf();
         		}
         		else if (digitandoPainelSete.EndsWith("mushroomVirus"))
         		{
         		digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -13);
         		digitandoPainelSete = digitandoPainelSete.Trim();
         		
         			if (digitandoPainelSete.EndsWith("+"))
         			{
         			digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
         			digitandoPainelSete = digitandoPainelSete.Trim();
         			int numero = int.Parse(digitandoPainelSete);
         			//x = numero + x;
         			//Debug.Log("x = "+numero+" + x;");
         			
         	        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus = numero + mushroomVirus;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
         			}
         			else if (digitandoPainelSete.EndsWith("-"))
         			{
         			digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
         			digitandoPainelSete = digitandoPainelSete.Trim();
         			int numero = int.Parse(digitandoPainelSete);
         			//x = numero - x;
         			//Debug.Log("x = "+numero+" - x;");
         			
         		funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus = numero - mushroomVirus;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
         		
         			}
         			else
         			ConsoleInf();
         		}
         		else
         		ConsoleInf();
		
                
         	}
         	else
         	ConsolePV();
         }
         else
         ConsoleInf();
         
         
         
     }
     else if (digitandoPainelSete.StartsWith("++"))
     {
         digitandoPainelSete = digitandoPainelSete.Substring(2);
         if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';')==1) //mushroomVirus + 1/1 + mushroomVirus
         {
             digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
             digitandoPainelSete = digitandoPainelSete.TrimEnd();
             if (digitandoPainelSete == ("mushroomVirus"))
             {
        	     //++x;
        	     //Debug.Log("++x;");
        	     
        	              	        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		++mushroomVirus;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
             }
             else
             ConsoleInf();
         }
         else
         ConsolePV();
     }
     else if (digitandoPainelSete.StartsWith("--"))
     {
         digitandoPainelSete = digitandoPainelSete.Substring(2);
         if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';')==1) //mushroomVirus + 1/1 + mushroomVirus
         {
             digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
                          digitandoPainelSete = digitandoPainelSete.TrimEnd();
             if (digitandoPainelSete == ("mushroomVirus"))
             {
        	     //--x;
       	 	     //Debug.Log("--x;");
       	 	     
       	 	        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		--mushroomVirus;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
             }
             else
             ConsoleInf();
         }
         else
         ConsolePV();
     }
     else
     ConsoleInf();
    
    }
    
    
     if (idPainel == 8 && (playerDentro || programandoPainel))
     {
     	if (mushroomVirus <= -1)
     	{
     	PainelCorreto();
     	return;
     	}
     	
     if (programandoPainel)
     digitandoPainelSete = inputCodPainel.text;
     
     if (!programandoPainel)
     digitandoPainelSete = PegarLinha(codigo3dPainel.text, 4);
     digitandoPainelSete = digitandoPainelSete.Trim();    
     	
     	
    float raio2 = colliderLimparArea.radius * colliderLimparArea.transform.lossyScale.x;
    Collider[] objetos = Physics.OverlapSphere(colliderLimparArea.transform.position, raio2);
    foreach(Collider objeto in objetos)
    {
    IProgramavel programavel = objeto.GetComponent<IProgramavel>();
     	
     	if (programavel != null)
    programavel.MudarCogumelos(mushroomVirus);
    }
     
         if (!funcionando)
   	 {
         timer = 0f;
   	 }
   	 
if (!digitandoPainelSete.Contains("mushroomVirus"))
{
	console = "<color=#aa0003>Variável mushroomVirus não identificada</color>";
	codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
	return;
}

     if (digitandoPainelSete.StartsWith("mushroomVirus")) //x ++; x += 1;/x -= -1; x = x + 1; x = 1 + x; //++ x;  
     {
         digitandoPainelSete = digitandoPainelSete.Substring(13);
         if (digitandoPainelSete.StartsWith("++"))
         {
         	digitandoPainelSete = digitandoPainelSete.Substring(2);
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	if (digitandoPainelSete == ";")
         	{
         	//Debug.Log("x++");
         	//x++;
         		funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus++;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
 
         	}
         	else
         	ConsolePV();

         }

         
         else if (digitandoPainelSete.StartsWith("--"))
         {
         	digitandoPainelSete = digitandoPainelSete.Substring(2);
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	if (digitandoPainelSete == ";")
         	{
         	//x--;
         	//Debug.Log("x--;");
         		funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus--;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         	}
         	else
         	ConsolePV();
         }

         
         else if (digitandoPainelSete.Trim().StartsWith("+="))
         {
                digitandoPainelSete = digitandoPainelSete.Trim();
         	digitandoPainelSete = digitandoPainelSete.Substring(2);
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';') == 1)
         	{
		digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
                int numero = int.Parse(digitandoPainelSete);
                //x += numero;
                //Debug.Log("x += " + numero+";");
                
                        funcionando = true;
         		
         		timer += (Time.deltaTime * 0.5f);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus += numero;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         	}
         	else
         	ConsolePV();
         }
         else if (digitandoPainelSete.Trim().StartsWith("-="))
         {
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	digitandoPainelSete = digitandoPainelSete.Substring(2);
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	
         	if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';')==1)
         	{
		digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
                int numero = int.Parse(digitandoPainelSete);
                //x -= numero;
                //Debug.Log("x -= " + numero+";");
                
                        funcionando = true;
         		
         		timer += (Time.deltaTime  * 2.5f);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus -= numero;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         	}
         	else
         	ConsolePV();
         }
         else if (digitandoPainelSete.Trim().StartsWith("="))
         {
                digitandoPainelSete = digitandoPainelSete.Trim();
         	digitandoPainelSete = digitandoPainelSete.Substring(1);
         	digitandoPainelSete = digitandoPainelSete.Trim();

         	if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';')==1) //mushroomVirus + 1/1 + mushroomVirus
         	{
         		digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
         		
         		if(digitandoPainelSete.StartsWith("mushroomVirus"))
         		{
         		    digitandoPainelSete = digitandoPainelSete.Substring(13);
                            digitandoPainelSete = digitandoPainelSete.Trim();
         		
         		    if (digitandoPainelSete.StartsWith("+"))
         		    {
         		        digitandoPainelSete = digitandoPainelSete.Substring(1);
                                digitandoPainelSete = digitandoPainelSete.Trim();
                                int numero = int.Parse(digitandoPainelSete);
                                //x = x + numero;
                                //Debug.Log("x = x + " + numero+";");
                                
                        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus = mushroomVirus + numero;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		    }
         		    
         		    else if (digitandoPainelSete.StartsWith("-"))
         		    {
         		        digitandoPainelSete = digitandoPainelSete.Substring(1);
                                digitandoPainelSete = digitandoPainelSete.Trim();
                                int numero = int.Parse(digitandoPainelSete);
                                //x = x - numero;
                                //Debug.Log("x = x - " + numero+";");
                                
                        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus = mushroomVirus - numero;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
         		    }
         		    else
         		    ConsoleGeral();
         		}
         		else if (digitandoPainelSete.EndsWith("mushroomVirus"))
         		{
         		digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -13);
         		digitandoPainelSete = digitandoPainelSete.Trim();
         		
         			if (digitandoPainelSete.EndsWith("+"))
         			{
         			digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
         			digitandoPainelSete = digitandoPainelSete.Trim();
         			int numero = int.Parse(digitandoPainelSete);
         			//x = numero + x;
         			//Debug.Log("x = "+numero+" + x;");
         			
         	        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus = numero + mushroomVirus;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
         			}
         			else if (digitandoPainelSete.EndsWith("-"))
         			{
         			digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
         			digitandoPainelSete = digitandoPainelSete.Trim();
         			int numero = int.Parse(digitandoPainelSete);
         			//x = numero - x;
         			//Debug.Log("x = "+numero+" - x;");
         			
         		funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus = numero - mushroomVirus;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
         		
         			}
         			else
         			ConsoleGeral();
         		}
         		else
         		ConsoleGeral();
		
                
         	}
         	else
         	ConsolePV();
         }
         else
         ConsoleGeral();
         
         
         
     }
     else if (digitandoPainelSete.StartsWith("++"))
     {
         digitandoPainelSete = digitandoPainelSete.Substring(2);
         if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';')==1) //mushroomVirus + 1/1 + mushroomVirus
         {
             digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
             digitandoPainelSete = digitandoPainelSete.TrimEnd();
             if (digitandoPainelSete == ("mushroomVirus"))
             {
        	     //++x;
        	     //Debug.Log("++x;");
        	     
        	              	        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		++mushroomVirus;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
             }
             else
             ConsoleGeral();
         }
         else
         ConsolePV();
     }
     else if (digitandoPainelSete.StartsWith("--"))
     {
         digitandoPainelSete = digitandoPainelSete.Substring(2);
         if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';')==1) //mushroomVirus + 1/1 + mushroomVirus
         {
             digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
                          digitandoPainelSete = digitandoPainelSete.TrimEnd();
             if (digitandoPainelSete == ("mushroomVirus"))
             {
        	     //--x;
       	 	     //Debug.Log("--x;");
       	 	     
       	 	        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		--mushroomVirus;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
             }
             else
             ConsoleGeral();
         }
         else
         ConsolePV();
     }
     else
     ConsoleGeral();
    
    }
    
     if (idPainel == 9 && (playerDentro || programandoPainel))
     {
     	if (mushroomVirus <= -1)
     	{
     	PainelCorreto();
     	return;
     	}
     	
     if (programandoPainel)
     digitandoPainelSete = inputCodPainel.text;
     
     if (!programandoPainel)
     digitandoPainelSete = PegarLinha(codigo3dPainel.text, 2);
     digitandoPainelSete = digitandoPainelSete.Trim();    
     	
     	
     	if (mushroomVirus == 1)
     	{
     	mushroomVirus = 4;
     	}
     	
    float raio2 = colliderLimparArea.radius * colliderLimparArea.transform.lossyScale.x;
    Collider[] objetos = Physics.OverlapSphere(colliderLimparArea.transform.position, raio2);
    foreach(Collider objeto in objetos)
    {
    IProgramavel programavel = objeto.GetComponent<IProgramavel>();
     	
     	if (programavel != null)
    programavel.MudarCogumelos(mushroomVirus);
    }
     
         if (!funcionando)
   	 {
         timer = 0f;
   	 }
   	 
if (!digitandoPainelSete.Contains("mushroomVirus"))
{
	console = "<color=#aa0003>Variável mushroomVirus não identificada</color>";
	codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
	return;
}

     if (digitandoPainelSete.StartsWith("mushroomVirus")) //x ++; x += 1;/x -= -1; x = x + 1; x = 1 + x; //++ x;  
     {
         digitandoPainelSete = digitandoPainelSete.Substring(13);
         if (digitandoPainelSete.StartsWith("++"))
         {
         	digitandoPainelSete = digitandoPainelSete.Substring(2);
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	if (digitandoPainelSete == ";")
         	{
         	//Debug.Log("x++");
         	//x++;
         		funcionando = true;
         		
         		timer += (Time.deltaTime * 0.5f);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus++;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
 
         	}
         	else
         	ConsolePV();

         }

         
         else if (digitandoPainelSete.StartsWith("--"))
         {
         	digitandoPainelSete = digitandoPainelSete.Substring(2);
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	if (digitandoPainelSete == ";")
         	{
         	//x--;
         	//Debug.Log("x--;");
         		funcionando = true;
         		
         		timer += (Time.deltaTime * 2.5f);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus--;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         	}
         	else
         	ConsolePV();
         }

         
         else if (digitandoPainelSete.Trim().StartsWith("+="))
         {
                digitandoPainelSete = digitandoPainelSete.Trim();
         	digitandoPainelSete = digitandoPainelSete.Substring(2);
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';') == 1)
         	{
		digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
                int numero = int.Parse(digitandoPainelSete);
                //x += numero;
                //Debug.Log("x += " + numero+";");
                
                        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus += numero;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         	}
         	else
         	ConsolePV();
         }
         else if (digitandoPainelSete.Trim().StartsWith("-="))
         {
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	digitandoPainelSete = digitandoPainelSete.Substring(2);
         	digitandoPainelSete = digitandoPainelSete.Trim();
         	
         	if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';')==1)
         	{
		digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
                int numero = int.Parse(digitandoPainelSete);
                //x -= numero;
                //Debug.Log("x -= " + numero+";");
                
                        funcionando = true;
         		
         		timer += (Time.deltaTime * 2f);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus -= numero;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         	}
         	else
         	ConsolePV();
         }
         else if (digitandoPainelSete.Trim().StartsWith("="))
         {
                digitandoPainelSete = digitandoPainelSete.Trim();
         	digitandoPainelSete = digitandoPainelSete.Substring(1);
         	digitandoPainelSete = digitandoPainelSete.Trim();

         	if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';')==1) //mushroomVirus + 1/1 + mushroomVirus
         	{
         		digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
         		
         		if(digitandoPainelSete.StartsWith("mushroomVirus"))
         		{
         		    digitandoPainelSete = digitandoPainelSete.Substring(13);
                            digitandoPainelSete = digitandoPainelSete.Trim();
         		
         		    if (digitandoPainelSete.StartsWith("+"))
         		    {
         		        digitandoPainelSete = digitandoPainelSete.Substring(1);
                                digitandoPainelSete = digitandoPainelSete.Trim();
                                int numero = int.Parse(digitandoPainelSete);
                                //x = x + numero;
                                //Debug.Log("x = x + " + numero+";");
                                
                        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus = mushroomVirus + numero;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		    }
         		    
         		    else if (digitandoPainelSete.StartsWith("-"))
         		    {
         		        digitandoPainelSete = digitandoPainelSete.Substring(1);
                                digitandoPainelSete = digitandoPainelSete.Trim();
                                int numero = int.Parse(digitandoPainelSete);
                                //x = x - numero;
                                //Debug.Log("x = x - " + numero+";");
                                
                        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus = mushroomVirus - numero;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
         		    }
         		    else
         		    ConsoleGeral();
         		}
         		else if (digitandoPainelSete.EndsWith("mushroomVirus"))
         		{
         		digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -13);
         		digitandoPainelSete = digitandoPainelSete.Trim();
         		
         			if (digitandoPainelSete.EndsWith("+"))
         			{
         			digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
         			digitandoPainelSete = digitandoPainelSete.Trim();
         			int numero = int.Parse(digitandoPainelSete);
         			//x = numero + x;
         			//Debug.Log("x = "+numero+" + x;");
         			
         	        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus = numero + mushroomVirus;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
         			}
         			else if (digitandoPainelSete.EndsWith("-"))
         			{
         			digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
         			digitandoPainelSete = digitandoPainelSete.Trim();
         			int numero = int.Parse(digitandoPainelSete);
         			//x = numero - x;
         			//Debug.Log("x = "+numero+" - x;");
         			
         		funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		mushroomVirus = numero - mushroomVirus;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
         		
         			}
         			else
         			ConsoleGeral();
         		}
         		else
         		ConsoleGeral();
		
                
         	}
         	else
         	ConsolePV();
         }
         else
         ConsoleGeral();
         
         
         
     }
     else if (digitandoPainelSete.StartsWith("++"))
     {
         digitandoPainelSete = digitandoPainelSete.Substring(2);
         if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';')==1) //mushroomVirus + 1/1 + mushroomVirus
         {
             digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
             digitandoPainelSete = digitandoPainelSete.TrimEnd();
             if (digitandoPainelSete == ("mushroomVirus"))
             {
        	     //++x;
        	     //Debug.Log("++x;");
        	     
        	              	        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		++mushroomVirus;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
         		
             }
             else
             ConsoleGeral();
         }
         else
         ConsolePV();
     }
     else if (digitandoPainelSete.StartsWith("--"))
     {
         digitandoPainelSete = digitandoPainelSete.Substring(2);
         if (digitandoPainelSete.EndsWith(";") && digitandoPainelSete.Count(c => c == ';')==1) //mushroomVirus + 1/1 + mushroomVirus
         {
             digitandoPainelSete = digitandoPainelSete.Substring(0, digitandoPainelSete.Length -1);
                          digitandoPainelSete = digitandoPainelSete.TrimEnd();
             if (digitandoPainelSete == ("mushroomVirus"))
             {
        	     //--x;
       	 	     //Debug.Log("--x;");
       	 	     
       	 	        funcionando = true;
         		
         		timer += (Time.deltaTime);
         		if (timer >= 1f)
         		{
         		timer = 0f;
         		
         		--mushroomVirus;
         		console = "<color=#aa0003>mushroomVirus: "+mushroomVirus+"</color>";
         		codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
         		}
             }
             else
             ConsoleGeral();
         }
         else
         ConsolePV();
     }
     else
     ConsoleGeral();
    
    }


}
    
    
    

    
    
    private void EntrarProgramarPainel()
    {
    canvaPainel.DefinirPainel(this);
    
    Debug.Log("entou no painel: " + idPainel);
    programandoPainel = true;
    cameraPainel.Priority = 20;
    freeLook.Priority = 10;
        
                    if (balaoDialogoJogador != null)
        {
        balaoDialogoJogador.ResetarEstado();
        }
        
    corpoDigito.SetActive(false);
    olhoDigito.SetActive(false);
    esqueletoDigito.SetActive(false);

    
    
    jogador.controller.enabled = false;
    jogador.animator.enabled = false;
    
    Invoke(nameof(AbrirTelaCanva),1.1f);
    
    
       if (idPainel == 1)
    {
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 2);
    canvaPainelFundo.anchoredPosition = new Vector2(canvaPainelFundo.anchoredPosition.x, 112f);
    canvaPainelTexto.anchoredPosition = new Vector2(canvaPainelTexto.anchoredPosition.x, -39.9f); 
    }
    
       if (idPainel == 2)
    {
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 0);
    canvaPainelFundo.anchoredPosition = new Vector2(canvaPainelFundo.anchoredPosition.x, 175f);
    canvaPainelTexto.anchoredPosition = new Vector2(canvaPainelTexto.anchoredPosition.x, 24.5f); 
    }
    
           if (idPainel == 3)
    {
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 2);
    canvaPainelFundo.anchoredPosition = new Vector2(canvaPainelFundo.anchoredPosition.x, 112f);
    canvaPainelTexto.anchoredPosition = new Vector2(canvaPainelTexto.anchoredPosition.x, -39.9f); 
    }
    
           if (idPainel == 4)
    {
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 2);
    canvaPainelFundo.anchoredPosition = new Vector2(canvaPainelFundo.anchoredPosition.x, 112f);
    canvaPainelTexto.anchoredPosition = new Vector2(canvaPainelTexto.anchoredPosition.x, -39.9f); 
    }
    
           if (idPainel == 5)
    {
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 2);
    canvaPainelFundo.anchoredPosition = new Vector2(canvaPainelFundo.anchoredPosition.x, 112f);
    canvaPainelTexto.anchoredPosition = new Vector2(canvaPainelTexto.anchoredPosition.x, -39.9f); 
    }
    
               if (idPainel == 6)
    {
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 3);
    canvaPainelFundo.anchoredPosition = new Vector2(canvaPainelFundo.anchoredPosition.x, 81f);
    canvaPainelTexto.anchoredPosition = new Vector2(canvaPainelTexto.anchoredPosition.x, -72.1f); 
    }
    
                   if (idPainel == 7)
    {
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 4);
    canvaPainelFundo.anchoredPosition = new Vector2(canvaPainelFundo.anchoredPosition.x, 49.5f);
    canvaPainelTexto.anchoredPosition = new Vector2(canvaPainelTexto.anchoredPosition.x, -104.3f); 
    }
    
                   if (idPainel == 8)
    {
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 4);
    canvaPainelFundo.anchoredPosition = new Vector2(canvaPainelFundo.anchoredPosition.x, 49.5f);
    canvaPainelTexto.anchoredPosition = new Vector2(canvaPainelTexto.anchoredPosition.x, -104.3f); 
    }
    
               if (idPainel == 9)
    {
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 2);
    canvaPainelFundo.anchoredPosition = new Vector2(canvaPainelFundo.anchoredPosition.x, 112f);
    canvaPainelTexto.anchoredPosition = new Vector2(canvaPainelTexto.anchoredPosition.x, -39.9f); ///esse
    }
        
    }
    
    private void AbrirTelaCanva()
    {
     Debug.Log("entou no painel: " + idPainel);
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    canvaPainelHUD.SetActive(true);
   
    //inputCodPainel.MoveTextEnd(false);
    //inputCodPainel.ActivateInputField();
    }
    

    public void SairProgramarPainel()
    {
    Debug.Log("Saiu do painel: " + idPainel);
    programandoPainel = false;
    cameraPainel.Priority = 0;
    freeLook.Priority = 10;
    
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    
    canvaPainelHUD.SetActive(false);
    
    corpoDigito.SetActive(true);
    olhoDigito.SetActive(true);
    esqueletoDigito.SetActive(true);
    
    
    jogador.controller.enabled = true;
    jogador.animator.enabled = true;
    
      if (idPainel == 1)
    {
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 2, inputCodPainel.text);
    }
    
      if (idPainel == 2)
    {
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 0, inputCodPainel.text);
    }
    
      if (idPainel == 3)
    {
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 2, inputCodPainel.text);
    }
    
      if (idPainel == 4)
    {
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 2, inputCodPainel.text);
    }
    
       if (idPainel == 5)
    {
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 2, inputCodPainel.text);
    }
    
       if (idPainel == 6)
    {
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 3, inputCodPainel.text);
    }
    
           if (idPainel == 7)
    {
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 4, inputCodPainel.text);
    }
    
           if (idPainel == 8)
    {
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 4, inputCodPainel.text);
    }
    
              if (idPainel == 9)
    {
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 2, inputCodPainel.text);
    }
    
    CancelInvoke("AbrirTelaCanva");
    }
    
    private string PegarLinha(string texto, int numeroLinha)
    {
    string[] linhas = texto.Split('\n');
    if (numeroLinha < 0 || numeroLinha >= linhas.Length)
    return "";
    
    return linhas[numeroLinha];
    }
    
    private string AlterarLinha(string texto, int numeroLinha, string novaLinha)
    {
    string[] linhas = texto.Split('\n');
    if (numeroLinha < 0 || numeroLinha >= linhas.Length)
    return texto;
    
    linhas[numeroLinha] = novaLinha;
    
    return string.Join("\n", linhas);
    }
    
    	private bool ConverterFloat(string valorRecebido, out float numero)
	{
        numero = 0;
	valorRecebido = valorRecebido.Replace("F", "f"); //tranforma todos os F em f.
	if (valorRecebido.Split('f').Length - 1 > 1) //se tiver mais de um f, cancela.
	{
	return false;
	}
	if (valorRecebido.Contains(" f")) //se tiver um espaço antes do f, cancela
	{
	return false;
	}
	bool ehFloat = valorRecebido.Contains("."); //se conter ".", entao ehFloat se torna true.
	if(!valorRecebido.EndsWith("f") && ehFloat) //se o valor não acaba com f, e é float, entao cancela
	{
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
	return false;
	}
	string parteFloat2 = partesFloat[1];
	if (parteFloat2.Length == 0) //verifica se tem o valor depois da virgula, se nao houver, cancela.
	{
	return false;
	}
	}
	if (!float.TryParse(valorRecebido, //se nao conseguir transformar a string valorRecebido no float numero usando a variacao de idioma, cancela
        NumberStyles.Float,
        CultureInfo.InvariantCulture,
        out numero))
        {
	return false;
        }
        return true;
	}
    
    public void ReiniciarPainel()
    {
    
      if (idPainel == 1)
    {
    console = "<color=#aa0003>Região Infectada</color>";
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 2);
    }
    
      if (idPainel == 2)
    {
    console = "<color=#aa0003>Cogumelos no Caminho</color>";
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 0);
    }
    
      if (idPainel == 3)
    {
    console = "<color=#aa0003>Região Infectada</color>";
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 2);
    }
    
      if (idPainel == 4)
    {
    console = "<color=#aa0003>Ilha Submersa</color>";
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 2);
    }
    
      if (idPainel == 5)
    {
    console = "<color=#aa0003>Ilha Submersa</color>";
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 2);
    }
    
      if (idPainel == 6)
    {
    console = "<color=#aa0003>Ilha Submersa</color>";
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 3);
    }
    
          if (idPainel == 7)
    {
    console = "<color=#aa0003>Cogumelos no Caminho</color>";
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 4);
    }
    
              if (idPainel == 8)
    {
    console = "<color=#aa0003>Região Infectada</color>";
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 4);
    }
    
                  if (idPainel == 9)
    {
    console = "<color=#aa0003>Região Infectada</color>";
    inputCodPainel.text = PegarLinha(codigo3dPainel.text, 2);
    }
    
    codigo3dPainel.text = codigoInicio + consoleInicio;
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
    
    }
    
    private void OnTriggerEnter(Collider other) //entrou na area do painel
    {
        if (other.CompareTag("Player") )
        {
           //Debug.Log("pode ativar");
           estaNaAreaPainel = true;
        
        }   
    }
    
       private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("saiu, nao pode ativar");
            estaNaAreaPainel = false;
        }   
    }
    
    
    
    private void PainelCorreto()
    {
    if (painelResolvido)
    {
    return;
    }
    painelResolvido = true;
    
    painelUmLinhaErro.SetActive(false);
    
    painelLuzAzul.SetActive(true);
    painelLuzVermelha.SetActive(false);
    
    colliderPainelArea.enabled = false;
    
    estaNaAreaPainel = false;
    SairProgramarPainel();
    
    if (idPainel == 1)
    {
    console = "<color=#0060FF>Região Não Infectada</color>";
    }
    
    else if (idPainel == 2)
    {
    console = "<color=#0060FF>Cogumelos Fora do Caminho</color>";
    }
    
    else if (idPainel == 3)
    {
    console = "<color=#0060FF>Região Não Infectada</color>";
    }
    
    else if (idPainel == 4)
    {
    console = "<color=#0060FF>Ilha Emergida</color>";
    }
    
    else if (idPainel == 5)
    {
    console = "<color=#0060FF>Ilha Emergida</color>";
    }
    
    else if (idPainel == 6)
    {
    console = "<color=#0060FF>Ilha Emergida</color>";
    }
    
    else if (idPainel == 7)
    {
    console = "<color=#0060FF>Cogumelos Fora do Caminho</color>";
    }
    
    else if (idPainel == 8)
    {
    console = "<color=#0060FF>Região Não Infectada</color>";
    }
    
    else if (idPainel == 9)
    {
    console = "<color=#0060FF>Região Não Infectada</color>";
    }
    
    codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
    
    float raio = colliderLimparArea.radius * colliderLimparArea.transform.lossyScale.x;
    Collider[] objetos = Physics.OverlapSphere(colliderLimparArea.transform.position, raio);
    foreach(Collider objeto in objetos)
    {
    IProgramavel programavel = objeto.GetComponent<IProgramavel>();
        if(programavel != null && idPainel == 1)
        {
        programavel.RestaurarRegiao();
        }
        
        else if(programavel != null && idPainel == 2)
        {
        programavel.DesativarInfestacaoCogumelo();
        }
        
        else if(programavel != null && idPainel == 3)
        {
        programavel.RestaurarRegiao();
        }
        
        else if(programavel != null && idPainel == 4)
        {
        programavel.EmergirIlhaMet1();
        programavel.DesativarInfestacaoCogumelo();
        }
        
        else if(programavel != null && idPainel == 5)
        {
        programavel.RestaurarArvores();
        programavel.EmergirIlhaMet2();
        }
        
        else if(programavel != null && idPainel == 6)
        {
	programavel.CurarInimigos();
        programavel.EmergirIlhaMet3();
        }
        
        else if(programavel != null && idPainel == 7)
        {
	programavel.DesativarInfestacaoCogumelo();
        }
        
        else if(programavel != null && idPainel == 8)
        {
	programavel.RestaurarRegiao();
        }
        
        else if(programavel != null && idPainel == 9)
        {
	programavel.RestaurarRegiao();
        }
        
        
    }
    
    
    }
    
    private bool? MushroomVirusAfirmacaoVerdadeira(string textoRecebido, float valorVariavel)
{
     if (textoRecebido.Contains("mushroomVirus")) //se tiver a variavel
		     {
		         //preciso de uma condição falsa para dar que painel está correto
		         if (textoRecebido.Contains("=="))
		         {
		            string[] partes = textoRecebido.Split("==");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                         int numero = int.Parse(valor2);
	                             if(numero == valorVariavel)
	                             {
	                             return true;
	                             }
	                             else
	                             return false;
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero == valorVariavel)
	                             {
	                             return true;
	                             }
	                             else
	                             return false;
	                         }
	                     }
		         }
		         
		         else if (textoRecebido.Contains("!="))
		         {
		             string[] partes = textoRecebido.Split("!=");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                         int numero = int.Parse(valor2);
	                             if(numero != valorVariavel)
	                             {
	                             return true;
	                             }
	                             else
	                             return false;
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero != valorVariavel)
	                             {
	                             return true;
	                             }
	                             else
	                             return false;
	                         }
	                     }
		         }
		         
		         else if (textoRecebido.Contains(">="))
		         {
		             string[] partes = textoRecebido.Split(">=");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor2);
	                             if(valorVariavel >= numero)
	                             {
	                             return true;
	                             }
	                             else
	                             return false;
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero >= valorVariavel) 
	                             {
	                             return true;
	                             }
	                             else
	                             return false;
	                         }
	                     }
		         } 
		         
		         else if (textoRecebido.Contains("<="))
		         {
		             string[] partes = textoRecebido.Split("<=");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor2);
	                             if(valorVariavel <= numero)
	                             {
	                             return true;
	                             }
	                             else
	                             return false;
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero <= valorVariavel)
	                             {
	                             return true;
	                             }
	                             else
	                             return false;
	                         }
	                     }
		         }  
		         
		         else if (textoRecebido.Contains(">"))
		         {
		             string[] partes = textoRecebido.Split(">");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor2);
	                             if(valorVariavel > numero)
	                             {
	                             return true;
	                             }
	                             else
	                             return false;
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero > valorVariavel) 
	                             {
	                             return true;
	                             }
	                             else
	                             return false;
	                         }
	                     }
		         } 
		         
		         else if (textoRecebido.Contains("<"))
		         {
		             string[] partes = textoRecebido.Split("<");  
	                     if (partes.Length == 2) 
	                     {
	                         valor1 = partes[0].Trim(); 
	                         valor2 = partes[1].Trim();
	                         
	                         if (valor1 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor2);
	                             if(valorVariavel < numero)
	                             {
	                             return true;
	                             }
	                             else
	                             return false;
	                         }
	                         
	                          if (valor2 == "mushroomVirus")
	                         {
	                             int numero = int.Parse(valor1);
	                             if(numero < valorVariavel)
	                             {
	                             return true;
	                             }
	                             else
	                             return false;
	                         }
	                     }
		         
		            }        
	                }
return null;
}

private bool? InfectionBoolVerdadeiro(string textoRecebido)
{
if (textoRecebido == "infection")
        {
        	return true;
        }
if (textoRecebido == "!infection")
        {
        	return false;
        }
       
        if (textoRecebido.StartsWith("infection"))
        {
        	textoRecebido = textoRecebido.Substring(9);
        	textoRecebido = textoRecebido.Trim();
        	if (textoRecebido.StartsWith("!="))
        	{	
        		textoRecebido= textoRecebido.Substring(2);
        		textoRecebido = textoRecebido.Trim();
        		if (textoRecebido == "false")
        		{
        			return true;
        		}
        		else if (textoRecebido == "true")
        		{
        		return false;
        		}
        		else
        		return null;
        	}
        	else if (textoRecebido.StartsWith("=="))
        	{	
        		textoRecebido = textoRecebido.Substring(2);
        		textoRecebido = textoRecebido.Trim();
        		if (textoRecebido == "true")
        		{
        			return true;
        		}
        		else if (textoRecebido == "false")
        		{
        		return false;
        		}
        		else
        		return null;
        	}
        	
        	
        }
        else if (textoRecebido.StartsWith("false"))
        {
        	textoRecebido = textoRecebido.Substring(5);
        	textoRecebido = textoRecebido.Trim();
        	if (textoRecebido.StartsWith("!="))
        	{	
        		textoRecebido = textoRecebido.Substring(2);
        		textoRecebido = textoRecebido.Trim();
        		if (textoRecebido == "infection")
        		{
        			return true;
        		}
        		else
        		return null;
        	}
        }
        else if (textoRecebido.StartsWith("true"))
        {
        	textoRecebido = textoRecebido.Substring(4);
        	textoRecebido = textoRecebido.Trim();
        	if (textoRecebido.StartsWith("=="))
        	{	
        		textoRecebido = textoRecebido.Substring(2);
        		textoRecebido = textoRecebido.Trim();
        		if (textoRecebido == "infection")
        		{
        			return true;
        		}
        		else
        		return null;
        	}
        }
return null;
}

private void ConsolePV()
{
	if (!digitandoPainelSete.EndsWith(";"))
	{
	console = "<color=#aa0003>(;) Esperado ao final</color>";
	codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
	}
	else if (digitandoPainelSete.Count(c => c == ';')>1)
	{
	console = "<color=#aa0003>Mais de um (;) identificado</color>";
	codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
	}
	else if (digitandoPainelSete.Count(c => c == ';')<1)
	{
	console = "<color=#aa0003>(;) Não identificado</color>";
	codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
	}
}

public void ConsoleGeral()
{
	 console = "<color=#aa0003>Região Infectada</color>";
	codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
}

public void ConsoleInf()
{
	 console = "<color=#aa0003>Cogumelos no Caminho</color>";
	codigo3dPainel.text = AlterarLinha(codigo3dPainel.text, 11, console);
}

private void OnDrawGizmosSelected()
{
Gizmos.color = Color.green;
Gizmos.DrawWireSphere(transform.position, raioRender);
}


public void ResetarEstado()
{
    // flags de fluxo/programação
    estaNaAreaPainel = false;
    programandoPainel = false;
    painelResolvido = false;
    funcionando = false;
    ehChamadoFloat = false;

    // variáveis de jogo
    mushroomVirus = mushroomVirusInicial;
    timer = 0f;

    // limpa "histórico"/parsing temporário
    valor1 = null;
    valor2 = null;
    digitandoPainelSete = null;

    // textos (o texto 3D e o input voltam ao estado do Start)
    codigo3dPainel.text = codigo3dPainelInicial;
    inputCodPainel.text = inputCodPainelInicial;

    // visual (luzes, erro, collider)
    painelUmLinhaErro.SetActive(painelUmLinhaErroAtivoInicial);
    painelLuzAzul.SetActive(painelLuzAzulAtivaInicial);
    painelLuzVermelha.SetActive(painelLuzVermelhaAtivaInicial);
    colliderPainelArea.enabled = colliderPainelAreaAtivoInicial;
}


    
}
