using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaposaAtivacao : MonoBehaviour
{

[SerializeField] GameObject raposa;
[SerializeField] Animator animator;

public bool jaSpawna;

public bool naoVolta;
bool naoVoltarMais;

public bool ativou = false;
    // Start is called before the first frame update
    void Start()
    {
    raposa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
        
    private void OnTriggerEnter(Collider other)
{
if (!ativou && !naoVoltarMais)
{
	if (other.CompareTag("Player") )
        {
        RaposaAtivacao[] raposas = FindObjectsOfType<RaposaAtivacao>();
        foreach (RaposaAtivacao r in raposas)
        {
        r.DesativarRaposa();
        }

        raposa.SetActive(true);
        ativou = true;
                
       
        if (!jaSpawna)
        animator.SetTrigger("Invocar");
        if (naoVolta)
		naoVoltarMais = true;
		}
		

}
}

public void DesativarRaposa()
{
	ativou = false;
	raposa.SetActive(false);
}


public void ResetarEstado()
{
    naoVoltarMais = false;
    DesativarRaposa(); // ativou = false + raposa.SetActive(false)
}

}
