using UnityEngine; 
using Cinemachine; 
using System.Collections; 

public class CameraShake : MonoBehaviour 
{ 

private Coroutine rotinaTremor;
private CinemachineBasicMultiChannelPerlin noise; 

void Start() 
{ 
noise = GetComponent<CinemachineFreeLook>() .GetRig(1) .GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); 
} 

public void Tremer(float intensidade, float duracao) 
{ 
StartCoroutine(TremerRotina(intensidade, duracao)); 
} 

IEnumerator TremerRotina(float intensidade, float duracao) 
{ 
noise.m_AmplitudeGain = intensidade; 
yield return new WaitForSeconds(duracao); 
noise.m_AmplitudeGain = 0f; 
} 


}
