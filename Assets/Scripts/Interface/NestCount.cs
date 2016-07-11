﻿using Assets.Common;
using System.Collections.Generic;
using Assets.Scripts.Extensions;
using UnityEngine;
using UnityEngine.UI;
using System;
using Assets.Scripts.Ants;

public class NestCount : MonoBehaviour
{
    private Text txtAssessing;
    private Text txtNestId;
    private Text txtPassive;
    private Text txtRecruiting;
    private Text txtReversing;

    public SimulationManager Simulation { get; private set; }

    private Lazy<List<NestCountControl>> _nestCountControls;

    private int? _highlightedNestIndex = null;

    void Start()
    {
        Simulation = GameObject.FindObjectOfType<SimulationManager>() as SimulationManager;

        _nestCountControls = new Lazy<List<NestCountControl>>(() =>
        {
            var nestCountControlPrefab = Resources.Load("NestNumbers") as GameObject;
            var nestCountControls = new List<NestCountControl>();

            for (int i = 0; i < Simulation.NestInfo.Count; i++)
            {
                var ctl = GameObject.Instantiate(nestCountControlPrefab);
                ctl.transform.SetParent(transform);

                ctl.GetComponent<RectTransform>().anchoredPosition = new Vector2(80 + (50 * i), -150);
                nestCountControls.Add(ctl.GetComponent<NestCountControl>());
            }

            return nestCountControls;
        });
    }

    void Update()
    {
        int? newHighlight = null;
        for (int i = 0; i < _nestCountControls.Value.Count; i++)
        {
            _nestCountControls.Value[i].SetData(
                Simulation.NestInfo[i].NestId,
                Simulation.NestInfo[i].AntsInactive.transform.childCount,
                Simulation.NestInfo[i].AntsAssessing.transform.childCount,
                Simulation.NestInfo[i].AntsRecruiting.transform.childCount,
                Simulation.NestInfo[i].AntsReversing.transform.childCount
                );

            if (_nestCountControls.Value[i].HasPointer)
                newHighlight = i;
        }

        if (!newHighlight.HasValue && _highlightedNestIndex.HasValue)
        {
            _highlightedNestIndex = null;
            ResetAntNestHighlight();
        }
        else if (_highlightedNestIndex != newHighlight)
        {
            _highlightedNestIndex = newHighlight;
            SetAntNestHighlight(_highlightedNestIndex.Value);
        }
    }

    private void SetAntNestHighlight(int value)
    {
        var nest = Simulation.nests[value].gameObject.Nest();

        foreach (var ant in Simulation.Ants)
        {
            if (ant.myNest == nest)
            {
                ant.SetTemporaryColour(AntColours.NestHighlight.Home);
            }
            else if (ant.nestToAssess == nest)
            {
                ant.SetTemporaryColour(AntColours.NestHighlight.Assessing);
            }
            else if (ant.oldNest == nest)
            {
                ant.SetTemporaryColour(AntColours.NestHighlight.Old);
            }
            else
            {
                ant.SetTemporaryColour(AntColours.NestHighlight.None);
            }
        }
    }

    private void ResetAntNestHighlight()
    {
        foreach (var ant in Simulation.Ants)
            ant.ClearTemporaryColour();
    }
}
