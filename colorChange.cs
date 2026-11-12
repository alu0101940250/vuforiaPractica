using UnityEngine;

public class colorChange : MonoBehaviour
{
    private Renderer [] renderers;

    void Start() {
        renderers = GetComponentsInChildren<Renderer>();
    }

    void OnMouseDown() {
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = Random.ColorHSV();
        }
    }
}
