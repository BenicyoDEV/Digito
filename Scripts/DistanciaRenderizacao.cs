using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanciaRenderizacao : MonoBehaviour
{
    [SerializeField] private Transform jogador;
    [SerializeField] private float distanciaMaxima = 35f;
    [SerializeField] private float intervaloVerificacao = 0.3f;

    private Renderer[] renderizadores;
    private float distanciaMaximaQuadrado;
    private float proximaVerificacao;

    private void Awake()
    {
        renderizadores = GetComponentsInChildren<Renderer>(true);
        distanciaMaximaQuadrado = distanciaMaxima * distanciaMaxima;
    }

    private void Start()
    {
        if (jogador == null && Camera.main != null)
            jogador = Camera.main.transform;
    }

    private void Update()
    {
        if (jogador == null || Time.time < proximaVerificacao)
            return;

        proximaVerificacao = Time.time + intervaloVerificacao;

        foreach (Renderer renderizador in renderizadores)
        {
            if (renderizador == null)
                continue;

            float distanciaQuadrado =
                (renderizador.bounds.center - jogador.position).sqrMagnitude;

            bool deveRenderizar =
                distanciaQuadrado <= distanciaMaximaQuadrado;

            if (renderizador.enabled != deveRenderizar)
                renderizador.enabled = deveRenderizar;
        }
    }
}
