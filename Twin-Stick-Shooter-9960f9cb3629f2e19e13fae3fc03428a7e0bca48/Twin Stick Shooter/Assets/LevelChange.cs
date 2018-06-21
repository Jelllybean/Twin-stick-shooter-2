using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour {

    public void FadeOut()
    {
        PauseManager.Instance.OnFadeComplete();
    }
}
