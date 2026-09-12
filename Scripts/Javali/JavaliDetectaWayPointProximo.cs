using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaliDetectaWayPointProximo : MonoBehaviour
{

private Movimento_inimigo javali;
private List<Transform> waypoints = new List<Transform>();

// Start is called before the first frame update
void Start()
{
    javali = GetComponentInParent<Movimento_inimigo>(); 
}

// Update is called once per frame
void Update()
{
    Transform maisProximo = PegarWaypointMaisProximo();

    if (maisProximo != null)
    {
        javali.DefinirWaypoint(maisProximo);
    }
}


private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Waypoint"))
    {
        if (!waypoints.Contains(other.transform))
        {
            waypoints.Add(other.transform);
        }
    }
}

   private void OnTriggerExit(Collider other)
{
     if (other.CompareTag("Waypoint"))
    {


waypoints.Remove(other.transform);
}
}

private Transform PegarWaypointMaisProximo()
{
Transform maisProximo = null;

float menorDistancia = Mathf.Infinity;

foreach(Transform wp in waypoints)
{
    float distancia =
    Vector3.Distance(
    transform.position,
    wp.position);

    if(distancia < menorDistancia)
    {
        menorDistancia = distancia;
        maisProximo = wp;
    }
}

return maisProximo;


}

public void LimparWaypoints()
{
    waypoints.Clear();
}

public void RecalcularWaypoints()
{
    waypoints.Clear();

    Collider meuCollider = GetComponent<Collider>();

    if (meuCollider == null)
        return;

    Collider[] objetos = Physics.OverlapBox(
        meuCollider.bounds.center,
        meuCollider.bounds.extents,
        Quaternion.identity,
        ~0,
        QueryTriggerInteraction.Collide
    );

    foreach (Collider objeto in objetos)
    {
        if (objeto.CompareTag("Waypoint"))
        {
            if (!waypoints.Contains(objeto.transform))
            {
                waypoints.Add(objeto.transform);
            }
        }
    }
}

}
