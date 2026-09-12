using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaWPPoximo : MonoBehaviour
{
	private Movimento_passaro passaro;
	private List<Transform> waypoints = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
            passaro = GetComponentInParent<Movimento_passaro>(); 
    }

    // Update is called once per frame
      void Update()
    {
         Transform maisProximo =
    PegarWaypointMaisProximo();

    if(maisProximo != null)
    {
        passaro.DefinirWaypoint(maisProximo);
    }

    
    }
    
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("PassaroWayPoint"))
    {
        if (!waypoints.Contains(other.transform))
        {
            waypoints.Add(other.transform);
        }
    }
}
    
       private void OnTriggerExit(Collider other)
    {
         if (other.CompareTag("PassaroWayPoint"))
        {
   waypoints.Remove(other.transform);
        }
    }
    
private Transform PegarWaypointMaisProximo()
{
    Transform maisProximo = null;

    float menorDistancia = Mathf.Infinity;

foreach (Transform wp in waypoints)
{
    if (wp == null)
        continue;

    float distancia = Vector3.Distance(
        transform.position,
        wp.position
    );

    if (distancia < menorDistancia)
    {
        menorDistancia = distancia;
        maisProximo = wp;
    }
}
    return maisProximo;
}

public void RecalcularWaypoints()
{
    waypoints.Clear();

    BoxCollider box = GetComponent<BoxCollider>();

    if (box == null)
        return;

    Vector3 centro = transform.TransformPoint(box.center);
    Vector3 tamanho = Vector3.Scale(box.size, transform.lossyScale) / 2f;

    Collider[] objetos = Physics.OverlapBox(
        centro,
        tamanho,
        transform.rotation,
        ~0,
        QueryTriggerInteraction.Collide
    );

    foreach (Collider objeto in objetos)
    {
        if (objeto.CompareTag("PassaroWayPoint"))
        {
            if (!waypoints.Contains(objeto.transform))
            {
                waypoints.Add(objeto.transform);
            }
        }
    }
}

}
