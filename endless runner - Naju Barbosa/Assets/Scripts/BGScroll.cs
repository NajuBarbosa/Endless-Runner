using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class BGScroll : MonoBehaviour
{

    private Renderer objRenderer;
    private Material objMaterial;
    public float offset;
    public float offsetSpeed;
    public float offsetIncrement;

    public string sortingLayer;
    public int sortingOrder;

   
    void Start()
    {
        objRenderer = GetComponent<MeshRenderer>();

        objRenderer.sortingLayerName = sortingLayer;
        objRenderer.sortingOrder = sortingOrder;

        objMaterial = objRenderer.material;

    }


    void Update()
    {
        offset += offsetIncrement;
        objMaterial.SetTextureOffset("_MainTex", new Vector2(offset * offsetSpeed, 0));
    }
}
