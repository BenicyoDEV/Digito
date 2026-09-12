using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaposaAtivacao : MonoBehaviour
{

[SerializeField] GameObject raposa;
[SerializeField] Animator animator;

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
if (!ativou)
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
                
        animator.SetTrigger("Invocar");
		}
}
}

public void DesativarRaposa()
{
	ativou = false;
	raposa.SetActive(false);
	
	Debug.Log("2");
}


}
