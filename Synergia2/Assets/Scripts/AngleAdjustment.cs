using UnityEngine;
using UnityEngine.Rendering;

public class AngleAdjustment : MonoBehaviour
{
    public float yAngleOfsset = 90f;

    // Start is called before the first frame update
    void Start()
    {

    }

    //void OnEnable()
    //{
    //    RenderPipelineManager.endCameraRendering += RenderPipelineManager_endCameraRendering;
    //}
    //void OnDisable()
   // {
   //     RenderPipelineManager.endCameraRendering -= RenderPipelineManager_endCameraRendering;
    //}
   //private void RenderPipelineManager_endCameraRendering(ScriptableRenderContext context, Camera camera)
   //{
   //    OnPostRender();
   //}

    private void OnEndCameraRendering()
    {
        Debug.Log(transform.eulerAngles.y);
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, yAngleOfsset, 0);
    }
}
