﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KModkit;
using Rnd = UnityEngine.Random;
using System.Linq;

public class SamuelSaysModule : MonoBehaviour {

    // Add emote flash sequence to MiniScreen.cs.
    // Add play display sequence to MainScreen.cs.
    // Add button dance.

    [SerializeField] private ColouredButton[] _buttons;
    [SerializeField] private KMSelectable _submitButton;

    [HideInInspector] public KMBombInfo Bomb;
    [HideInInspector] public KMAudio Audio;
    [HideInInspector] public KMBombModule Module;

    private static int _moduleIdCounter = 1;
    private int _moduleId;
    private bool _moduleSolved = false;

    // These need to be moved to their relevant classes.
    private const float SingleMorseUnit = 0.2f;
    private const float EmoticonFlashTime = 0.3f;
    private const int EmoticonFlashCount = 3;

    private readonly string[] HappyFaces = new string[] {
        ":)",
        ": )",
        ":-)",
        "=)",
        "= )",
        "=-)",
        ":]" ,
        ": ]",
        ":-]",
        "=]",
        "= ]",
        "=-]"
    };
    private readonly string[] HackedFaces = new string[] {
        ">:(",
        ">:[",
        ">:<",
        ":'(",
        ">:x",
        ":|",
        ">:|",
        ":s",
        ":o",
        ":0",
        ":O"
    };
    private readonly string[] StrikeFaces = new string[] {
        ">:(",
        ">:[",
        ">:<",
        ":'(",
        ">:x",
        ":|",
        ">:|",
        ":s",
        ":o",
        ":0",
        ":O"
    };

    private State _state;

    public ColouredButton[] Buttons { get { return _buttons; } }

    void Awake() {
        _moduleId = _moduleIdCounter++;

        Bomb = GetComponent<KMBombInfo>();
        Audio = GetComponent<KMAudio>();
        Module = GetComponent<KMBombModule>();
    }

    void Start() {
        int count = 0;

        foreach (ColouredButton button in _buttons) {
            button.Selectable.OnInteract += delegate () { HandlePress(button); return false; };
            button.Selectable.OnInteractEnded += delegate () { HandleRelease(); };
            button.SetColour((ButtonColour)count++);
        }
    }

    public void ChangeState(State newState) {
        _state = newState;
    }

    private void HandlePress(ColouredButton button) {
        StartCoroutine(_state.HandlePress(button));
    }

    private void HandleRelease() {
        StartCoroutine(_state.HandleRelease());
    }
}
