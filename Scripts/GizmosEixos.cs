using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosEixos : MonoBehaviour
{
    [SerializeField] private Transform cameraJogador;

    void LateUpdate()
    {
        transform.rotation = Quaternion.Inverse(cameraJogador.rotation);
    }
}
