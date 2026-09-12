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
        
        
        if (escondendo)
        {
        colisao1.enabled = false;
     //   colisao2.enabled = false;
        }
        else
        {
        colisao1.enabled = true;
     //   colisao2.enabled = true;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, raio);
    }
}

