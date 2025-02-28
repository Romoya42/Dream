using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class S_PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public Canvas cursorCanvas;

    public Volume globalVolume;
    private DepthOfField dof;
    private bool toggleDof;
    public float focusDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toggleDof = !toggleDof;
        ToggleBackgroundUI();
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        ToggleBackgroundUI();
        pauseMenu.SetActive(true);
        cursorCanvas.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        ToggleBackgroundUI();
        cursorCanvas.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void ToggleBackgroundUI()
    {
        toggleDof = !toggleDof;
        if (globalVolume.profile.TryGet(out dof))
        {
            dof.active = toggleDof;
            dof.focusDistance.value = focusDistance;
        }
    }
}
