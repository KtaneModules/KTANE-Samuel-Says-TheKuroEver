using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Rnd = UnityEngine.Random;

public class InitialState : State {

    public InitialState(SamuelSaysModule module) : base(module) { }

    public override IEnumerator HandleSubmitPress() {
        _module.SubmitButtonAnimator.SetBool("IsPressed", true);
        _module.Log("=================== Start ===================");
        _module.Log("Conditions and actions are labelled 1-5, top-to-bottom within the given color table.");

        _module.Buttons[3].AddInteractionPunch();
        _module.AdvanceStage();
        yield return null;
    }

}
