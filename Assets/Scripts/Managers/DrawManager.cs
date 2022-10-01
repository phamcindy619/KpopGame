using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawManager : MonoBehaviour
{
    int posterLayer;
    public RectTransform posterTransform;
    public GameObject drawing;
    private Line _activeLine;
    public GameObject linePrefab;

    void Start() {
        posterLayer = LayerMask.NameToLayer("Drawing");
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse newly clicked
        if (Input.GetMouseButtonDown(0)) {
            GameObject line = Instantiate(linePrefab);
            line.transform.SetParent(drawing.transform);
            _activeLine = line.GetComponent<Line>();
        }

        // Mouse released
        if (Input.GetMouseButtonUp(0)) {
            _activeLine = null;
        }

        // Mouse still clicked
        if (_activeLine != null) {
            Draw();
        }
    }

    void Draw() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (IsOnPoster()) {
            _activeLine.UpdateLine(mousePos);
        }
    }

    bool IsOnPoster() {
        return IsOnPoster(GetEventSystemRaycastResults());
    }

    // Checkif mouse is hovering over element
    bool IsOnPoster(List<RaycastResult> eventSystemRaycastResults) {
        for (int i = 0; i < eventSystemRaycastResults.Count; i++) {
            RaycastResult currRaycastResult = eventSystemRaycastResults[i];
            if (currRaycastResult.gameObject.layer == posterLayer) {
                return true;
            }
        }
        return false;
    }

    List<RaycastResult> GetEventSystemRaycastResults() {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults;
    } 
}
