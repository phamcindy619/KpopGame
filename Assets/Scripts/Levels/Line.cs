using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;
    List<Vector3> points;
    
    public void UpdateLine(Vector3 mousePos) {
        if (points == null) {
            points = new List<Vector3>();
            SetPoints(mousePos);
            return;
        }
        
        if (Vector3.Distance(points.Last(), mousePos) > 0.1f) {
            SetPoints(mousePos);
        }
    }

    void SetPoints(Vector3 point) {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}
