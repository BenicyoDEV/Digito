using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaspberryGiro_sc : MonoBehaviour
{
    [SerializeField] private float raio = 1f;
    [SerializeField] private float velocidade = 45f;

    private float angulo;

    [System.Serializable]
    public class Slot
    {
        public Transform raspberry;
        public bool ativa = true;
        public int index;
    }

    public List<Slot> slots = new List<Slot>();
private Vector3 posInicialLocal;

    void Start()
    {
    posInicialLocal = transform.localPosition;
    
        slots.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            Slot s = new Slot();
            s.raspberry = transform.GetChild(i);
            s.index = i;
            s.ativa = true;

            slots.Add(s);
        }
    }

    void Update()
    {
    
    transform.localPosition = new Vector3(
    transform.localPosition.x,
    posInicialLocal.y + Mathf.Sin(Time.time * 2.5f) * 0.05f,
    transform.localPosition.z
);


        angulo += velocidade * Time.deltaTime;

        int total = slots.Count;

        if (total == 0) return;

        for (int i = 0; i < slots.Count; i++)
        {
            if (!slots[i].ativa || slots[i].raspberry == null) continue;

            float a = angulo + (360f / total) * slots[i].index;

            Vector3 pos = new Vector3(
                Mathf.Cos(a * Mathf.Deg2Rad),
                0,
                Mathf.Sin(a * Mathf.Deg2Rad)
            ) * raio;

		Vector3 posAtual = slots[i].raspberry.localPosition;
		posAtual.x = pos.x;
		posAtual.z = pos.z;
            slots[i].raspberry.localPosition = posAtual;
        }
    }

    public void RemoverDaOrbita(Transform r)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].raspberry == r)
            {
                slots[i].ativa = false;
                break;
            }
        }
    }
}
