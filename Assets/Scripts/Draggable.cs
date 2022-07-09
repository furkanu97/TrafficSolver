using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool isDraggable;

    private bool _isDragged;

    public GameObject toSnap;

    private float _x;

    private float _z;

    private void Start()
    {
        isDraggable = true;
        _isDragged = false;
    }
    
    private void OnMouseDown()
    {
        if(isDraggable)
        {
            _isDragged = true;
        }
        toSnap.SetActive(true);
    }

    private void OnMouseDrag()
    {
        if (_isDragged)
        {
            _x = (Input.mousePosition.x / Screen.width * 80) - 40;
            _z = (Input.mousePosition.y / Screen.height * 140) - 70;
            transform.position = new Vector3((int)_x + 2, 5, (int)_z + 4);
            toSnap.transform.position = new Vector3((int)_x, 0 ,(int)_z);
        }
    }

    private void OnMouseUp()
    {
        _isDragged = false;
        transform.position = toSnap.transform.position;
        toSnap.SetActive(false);
    }
}
