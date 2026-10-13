using UnityEngine; 
using Cinemachine; 
using System.Collections; 

public class CameraShake : MonoBehaviour 
{ 

private Coroutine rotinaTremor;
private CinemachineBasicMultiChannelPerlin noise; 

private Pausa pausa;
private Holograma holograma;

public bool reset = false;

void Start() 
{ 
noise = GetComponent<CinemachineFreeLook>() .GetRig(1) .GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); 
pausa= FindObjectOfType<Pausa>();
holograma = FindObjectOfType<Holograma>();
} 

void Update()
{
if (pausa.jogoPausado || holograma.modoProgramacao || reset)
{
StopAllCoroutines();
CancelInvoke();
noise.m_AmplitudeGain = 0f;
if (reset)
reset = false;

}
}

public void Tremer(float intensidade, float duracao) 
{ 
if (pausa.jogoPausado || holograma.modoProgramacao || reset)
{
reset = false;
return;
}

StartCoroutine(TremerRotina(intensidade, duracao)); 
} 

IEnumerator TremerRotina(float intensidade, float duracao) 
{

noise.m_AmplitudeGain = intensidade; 
yield return new WaitForSeconds(duracao); 
noise.m_AmplitudeGain = 0f; 

} 


}
