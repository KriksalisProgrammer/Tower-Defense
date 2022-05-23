using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    private Renderer _rend;
    private Color _startColor;

    [Header("Optional")]
    public GameObject turret;
    private BuildManager _buildManager;


    public Color hoverColor;
    public Vector3 positionOffset;

    private void Start()
    {
        _rend=GetComponent<Renderer>();
        _startColor=_rend.material.color;

        _buildManager = BuildManager.instance;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!_buildManager.CanBuild)
            return;

        if(turret!=null)
        {
            Debug.Log("We Can Build!");
            return;
        }
        _buildManager.BuildTurretOn(this);
        
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (!_buildManager.CanBuild)
            return;

        _rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}
