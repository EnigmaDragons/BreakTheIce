using Assets.UI;
using UnityEngine;
using UnityEngine.UI;

public sealed class LogoSceneScript : MonoBehaviour
{
    public float durationBefore;
    public float durationIn;
    public float durationBetween;
    public float durationOut;

    private void Start()
    {
        var image = GetComponent<Image>();
        new Sequence(
            new ActionItem(() => SetAlpha(image, 0)),
            new Delay(this, durationBefore),
            new CrossFade(image, 1, durationIn),
            new Delay(this, durationBetween),
            new CrossFade(image, 0, durationOut),
            new NavigateToScene(Scenes.MainMenu))
                .Go();
    }
    
    private void SetAlpha(Image img, float a)
    {
        var c = img.color;
        c.a = a;
        img.color = c;
    }
}
