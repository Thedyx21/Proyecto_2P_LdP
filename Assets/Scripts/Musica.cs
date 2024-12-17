using UnityEngine;
using UnityEngine.UI;

public class MuteButtonController : MonoBehaviour
{
    public AudioSource backgroundMusic; // Arrastra tu AudioSource aquí desde el inspector.
    public GameObject muteImage;       // Imagen que se muestra cuando el audio está muteado.
    public GameObject unmuteImage;     // Imagen que se muestra cuando el audio está activo.

    private bool isMuted = false;

    public void ToggleMute()
    {
        isMuted = !isMuted; // Cambiar el estado de mute.

        if (isMuted)
        {
            backgroundMusic.mute = true;
            muteImage.SetActive(true);
            unmuteImage.SetActive(false);
        }
        else
        {
            backgroundMusic.mute = false;
            muteImage.SetActive(false);
            unmuteImage.SetActive(true);
        }
    }
}
