using UnityEngine;
using UnityEngine.UI;

public class FocusEffect : MonoBehaviour
{
    public float timeScale = 0.5f;
    public Shader grayScaleShader;
    
    public GameObject player;
    private Canvas uiCanvas;
    private Image uiImage;
    private float originalTimeScale;
    private Material grayScaleMaterial;

    private void Start()
    {
        uiCanvas = GameObject.FindObjectOfType<Canvas>();
        uiImage = uiCanvas.GetComponentInChildren<Image>();
        originalTimeScale = Time.timeScale;
        grayScaleMaterial = new Material(grayScaleShader);
    }

    void OnMouseDown(){
        uiCanvas.gameObject.SetActive(true);
        Time.timeScale = timeScale;
        ApplyGrayScaleEffect();
    }

    void OnMouseUp(){
        uiCanvas.gameObject.SetActive(false);
        Time.timeScale = originalTimeScale;
        RemoveGrayScaleEffect();
    }

    private void ApplyGrayScaleEffect()
    {
        Camera.main.SetReplacementShader(grayScaleMaterial.shader, "RenderType");
        uiCanvas.sortingLayerName = "Default";
        uiCanvas.sortingOrder = -1;
    }

    private void RemoveGrayScaleEffect()
    {
        Camera.main.SetReplacementShader(null, "");
        uiCanvas.sortingLayerName = "UI";
        uiCanvas.sortingOrder = 0;
    }
}