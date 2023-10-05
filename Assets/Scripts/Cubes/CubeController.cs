using UnityEngine;
using UnityEngine.Serialization;

public class CubeController : MonoBehaviour
{
    [SerializeField] private Renderer cubeRenderer;
    [SerializeField] private float fadeSpeed = 2f;

    private Color _currentColor;

    private void Start()
    {
        _currentColor = GetRandomColor();
        cubeRenderer.material.color = _currentColor;
    }

    private void Update()
    {
        _currentColor = Color.Lerp(_currentColor, Color.clear, fadeSpeed * Time.deltaTime);
        cubeRenderer.material.color = _currentColor;


        if (_currentColor == Color.clear)
        {
            _currentColor = GetRandomColor();
        }
    }

    private Color GetRandomColor()
    {
        Color[] colors = new Color[]
        {
            Color.red, Color.blue, Color.magenta, Color.yellow, Color.green, Color.cyan
        };

        int randomIndex = Random.Range(0, colors.Length);
        return colors[randomIndex];
    }
}