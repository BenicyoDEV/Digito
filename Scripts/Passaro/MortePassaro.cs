using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortePassaro : MonoBehaviour
{
	private Movimento_passaro passaroMorrer;

    // Start is called before the first frame update
    void Start()
    {
        passaroMorrer = GetComponentInParent<Movimento_passaro>();
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
  	player.Saltar();
  	player.GetComponent<CharacterController>().Move(Vector3.up * 0.2f);
     
     passaroMorrer.Morrer();
        }
    }

    
}
