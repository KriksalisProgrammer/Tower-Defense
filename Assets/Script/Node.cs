using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    private Renderer _rend;
    private Color _startColor;

    private GameObject _turret;
    private BuildManager _buildManager;


    public Color hoverColor;
    public Vector3 positionOffset;

    private void Start()
    {
        _rend=GetComponent<Renderer>();
        _startColor=_rend.material.color;

        _buildManager = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (_buildManager.GetTurretToBuild() == null)
            return;

        if(_turret!=null)
        {
            Debug.Log("We Can Build!");
            return;
        }
        GameObject turretToBuild=_buildManager.GetTurretToBuild();
        _turret =(GameObject)Instantiate(turretToBuild, transform.position+positionOffset, Quaternion.Euler(-90,0,0));
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (_buildManager.GetTurretToBuild() == null)
            return;

        _rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}
