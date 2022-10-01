using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;
    List<Vector3> _points;
    
    public void UpdateLine(Vector3 mousePos) {
        if (_points == null) {
            _points = new List<Vector3>();
            SetPoints(mousePos);
            return;
        }
        
        if (Vector3.Distance(_points.Last(), mousePos) > 0.1f) {
            SetPoints(mousePos);
        }
    }

    void SetPoints(Vector3 point) {
        _points.Add(point);

        _lineRenderer.positionCount = _points.Count;
        _lineRenderer.SetPositions(_points.ToArray());
    }
}
