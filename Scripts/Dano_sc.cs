using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano_sc : MonoBehaviour
{

public bool danoForte; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        
    }
         
            private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {

        Movimento_Jogador player = other.GetComponent<Movimento_Jogador>();
        
        
        if (!danoForte && player.invencivel) return;
        
        
        Vector3 direcao = (other.transform.position - transform.position).normalized;
        
        
        if (!danoForte)
        {
        player.levarDano(direcao);
                Debug.Log("Sofreu dano fraco");
        }
        
        else {
        player.levarDanoForte();
                Debug.Log("Sofreu dano forte");
        }
        
    }
}

}
