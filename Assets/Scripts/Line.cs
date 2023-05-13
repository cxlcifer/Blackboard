using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;
    
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out var hitInfo))
            {
                if (hitInfo.collider.GetComponentInChildren<Interaction>())
                {
                    _renderer.positionCount++;
                    _renderer.SetPosition(_renderer.positionCount - 1, mousePos);
                }
            }
        }
        
    }
}
