using UnityEngine;

namespace JoyTeam.Game
{
    public class BaseScreen : MonoBehaviour
    {
        public void Show(bool state) => gameObject.SetActive(state);
    }
}