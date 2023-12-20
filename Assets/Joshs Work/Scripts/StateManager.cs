using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
    public enum PlayerStates {
        NULL = -1,
        MainMenu,
        Gameplay,
        LensWheel
    }

    public static PlayerStates currentState = PlayerStates.Gameplay;
}
