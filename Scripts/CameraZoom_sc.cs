using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom_sc : MonoBehaviour
{

public CinemachineFreeLook freeLook;
public float velocidadeZoom = 10f;
float min = 1.5f;
float max = 14f;
float zoomAtual = 6f;
float zoomAlvo = 6f;
float suavidade = 20f;

    private Pausa pausa;

    // Start is called before the first frame update
    void Start()
    {
        freeLook = GetComponent<CinemachineFreeLook>();
        pausa = FindObjectOfType<Pausa>();
    }

    // Update is called once per frame
    void Update()
    {
    if (!pausa.jogoPausado)
        {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoomAlvo -= scroll * velocidadeZoom;
        zoomAlvo = Mathf.Clamp(zoomAlvo, min, max);

	freeLook.m_Orbits[0].m_Radius = zoomAtual;
	freeLook.m_Orbits[1].m_Radius = zoomAtual;
	freeLook.m_Orbits[2].m_Radius = zoomAtual;
	
	zoomAtual = Mathf.Lerp(zoomAtual, zoomAlvo, Time.unscaledDeltaTime * suavidade);
	}
    } 
}




