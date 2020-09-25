using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightBehavior : MonoBehaviour
{

    [SerializeField] private string highlightableTag = "Highlightable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _highlight;

    private void Update()
    {
        if (_highlight != null)
        {
            var highlightRenderer = _highlight.GetComponent<Renderer>();
            highlightRenderer.material = defaultMaterial;
            _highlight = null;
        }
        var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(camRay, out hit))
        {
            var highlight = hit.transform;
            if (highlight.CompareTag(highlightableTag))
            {
                var highlightRenderer = highlight.GetComponent<Renderer>();
                if (highlightRenderer != null)
                {
                    highlightRenderer.material = highlightMaterial;
                }
                _highlight = highlight;
            }
            
        }
    }
}
