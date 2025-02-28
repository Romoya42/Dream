using UnityEngine;
using System.Collections;

public class S_FadeSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] public float transitionTime = 20f; // Temps de transition en secondes

    private bool isPlayingFirst = true;

    void Start()
    {
        // Assurez-vous que les deux sources existent
        if (audioSource1 == null || audioSource2 == null)
        {
            Debug.LogError("Assign both AudioSources in the inspector!");
            return;
        }

        // Démarre avec la première musique active
        audioSource1.volume = 1f;
        audioSource2.volume = 0f;
        audioSource1.Play();
        audioSource2.Play(); // On prépare déjà la deuxième piste en arrière-plan
    }

    public void StartCrossfade()
    {
        StartCoroutine(Crossfade());
    }

    private IEnumerator Crossfade()
    {
        float timeElapsed = 0f;

        AudioSource fadeOutSource = isPlayingFirst ? audioSource1 : audioSource2;
        AudioSource fadeInSource = isPlayingFirst ? audioSource2 : audioSource1;
        isPlayingFirst = !isPlayingFirst;
        while (timeElapsed < transitionTime)
        {
            timeElapsed += Time.deltaTime;
            float fadeFactor = timeElapsed / transitionTime;

            fadeOutSource.volume = Mathf.Lerp(1f, 0f, fadeFactor);
            fadeInSource.volume = Mathf.Lerp(0f, 1f, fadeFactor);

            yield return null;
        }

        // Assurer la fin du fondu
        fadeOutSource.volume = 0f;
        fadeInSource.volume = 1f;

        
        
    }
}