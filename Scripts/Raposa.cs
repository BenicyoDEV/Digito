using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raposa : MonoBehaviour
{
[SerializeField] public Collider colisao1;
[SerializeField] public Collider colisao2;
    public Animator animator;

    public float raio = 10f;

    public bool escondendo = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Collider[] inimigos = Physics.OverlapSphere(transform.position, raio);

        bool inimigoNaArea = false;

        foreach (Collider inimigo in inimigos)
        {
            if (inimigo.CompareTag("Inimigo"))
            {
                inimigoNaArea = true;
                break;
            }
        }

        if (inimigoNaArea && !escondendo)
        {
            escondendo = true;
            animator.SetTrigger("Esconder");
        }
        else if (!inimigoNaArea && escondendo)
        {
            escondendo = false;
            animator.SetTrigger("PararEsconder");
        }
        
       

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, raio);
    }
    
    
    public void ResetarEstado()
{
    escondendo = false;

    if (animator != null)
    {
        animator.ResetTrigger("Esconder");
        animator.ResetTrigger("PararEsconder");
    }
}

}

