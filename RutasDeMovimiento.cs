using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RutasDeMovimiento : MonoBehaviour
{
    [SerializeField]
    private Transform[] PuntosDeControl;

    private Vector2 GizmosPosicion;

    private void OnDrawGizmos()
    {
        for(float t = 0f; t <= 1; t += 0.05f)
        {
            GizmosPosicion = Mathf.Pow(1 - t, 3) * PuntosDeControl[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * PuntosDeControl[1].position +
                3 * Mathf.Pow(t, 2) * (1 - t) * PuntosDeControl[2].position +
                Mathf.Pow(t, 3) * PuntosDeControl[3].position;

            Gizmos.DrawSphere(GizmosPosicion, 0.1f);
        }

        Gizmos.DrawLine(new Vector2(PuntosDeControl[0].position.x, PuntosDeControl[0].position.y), new Vector2(PuntosDeControl[1].position.x, PuntosDeControl[1].position.y));
        Gizmos.DrawLine(new Vector2(PuntosDeControl[2].position.x, PuntosDeControl[2].position.y), new Vector2(PuntosDeControl[3].position.x, PuntosDeControl[3].position.y));
    }
}
