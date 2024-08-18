using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WrongButtonHandler : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    private PostProcessVolume postProcessVolume;
    private Vignette vignette;

    public GameObject player;
    public Sprite hurtSprite;
    public float slowedSpeed = 2f;
    public float slowDuration = 2f;

    private MoveScript moveScript;
    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;

    void Start()
    {
        // Get PostProcessVolume component from the camera
        if (mainCamera.TryGetComponent(out postProcessVolume))
        {
            if (postProcessVolume.profile.TryGetSettings(out vignette))
            {
                Debug.Log("Vignette found and assigned.");
            }
            else
            {
                Debug.LogError("Vignette not found in the PostProcessing profile.");
            }
        }
        else
        {
            Debug.LogError("PostProcessVolume component not found on the camera.");
        }

        moveScript = player.GetComponent<MoveScript>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    public void OnWrongButtonPressed()
    {
        if (vignette != null)
        {
            Debug.Log("OnWrongButtonPressed called.");
            StartCoroutine(ShowVignetteEffect());
            StartCoroutine(SlowDownPlayer());
            spriteRenderer.sprite = hurtSprite;
        }
        else
        {
            Debug.LogError("Vignette is null.");
        }
    }

    private IEnumerator ShowVignetteEffect()
    {
        Debug.Log("ShowVignetteEffect started.");
        vignette.intensity.value = 0.8f;
        Debug.Log("Vignette intensity set to: " + vignette.intensity.value);

        yield return new WaitForSeconds(slowDuration);

        vignette.intensity.value = 0f;
        Debug.Log("Vignette intensity reset to: " + vignette.intensity.value);
        Debug.Log("ShowVignetteEffect ended.");
    }

    private IEnumerator SlowDownPlayer()
    {
        if (moveScript != null)
        {
            float originalSpeed = moveScript.speed;
            moveScript.speed = slowedSpeed;
            Debug.Log("Player speed set to: " + moveScript.speed);

            yield return new WaitForSeconds(slowDuration);

            moveScript.speed = originalSpeed;
            spriteRenderer.sprite = originalSprite;
            Debug.Log("Player speed reset to: " + moveScript.speed);
        }
        else
        {
            Debug.LogError("MoveScript is null.");
        }
    }
}
