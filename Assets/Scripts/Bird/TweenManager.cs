using UnityEngine;
using DG.Tweening;

public class TweenManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer Renderer;
    public Vector3 EndPosition;
    public Vector3 EndScale;
    public float StartAlpha = 1f;
    public float EndAlpha = 0f;
    public float MoveDuration = 2f;
    public float ScaleDuration = 1f;
    public float FadeDuration = 1f;
    public Ease EasingType = Ease.OutQuad;

    void Start()
    {
       
        DOVirtual.DelayedCall(3f, () =>
        {
           
            transform.DOMove(EndPosition, MoveDuration)
                .SetEase(EasingType)
                .OnComplete(() => Debug.Log("Move Done"));

            
            transform.DOScale(EndScale, ScaleDuration)
                .SetEase(EasingType)
                .OnComplete(() => Debug.Log("Scale Well Done"));

          
            var renderer = Renderer;
            Color startColor = renderer.material.color;
            Color endColor = new (startColor.r, startColor.g, startColor.b, EndAlpha);
            renderer.material.DOColor(endColor, FadeDuration)
                .SetEase(EasingType)
                .OnComplete(() => Debug.Log("Fade Super Well Done"));
        });
    }
}


