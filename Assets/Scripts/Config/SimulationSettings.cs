﻿using System;
using System.Xml.Serialization;
using UnityEngine;
using System.Collections.Generic;
using Assets.Common;

namespace Assets.Scripts.Config
{
    [Serializable]
    public class SimulationSettings
    {
        public string ArenaName { get; set; }

        public string ArenaFilename { get; set; }

        [SerializeField]
        public ExperimentName ExperimentName { get; set; }

        [SerializeField]
        public RandomSeed RandomSeed { get; set; }

        [SerializeField]
        public ColonySize ColonySize { get; set; }

        [SerializeField]
        public QuorumThreshold QuorumThreshold { get; set; }

        [SerializeField]
        public ProportionActive ProportionActive { get; set; }

        [SerializeField]
        public StartingNestQuality StartingNestQuality { get; set; }

        [SerializeField]
        public FirstNewNestQuality FirstNewNestQuality { get; set; }

        [SerializeField]
        public SecondNewNestQuality SecondNewNestQuality { get; set; }

        [SerializeField]
        public StartingTickRate StartingTickRate { get; set; }

        [SerializeField]
        public MaximumSimulationRunTime MaximumSimulationRunTime { get; set; }

        [SerializeField]
        public AntsLayPheromones AntsLayPheromones { get; set; }

        [SerializeField]
        public OutputTickRate OutputTickRate { get; set; }

        [SerializeField]
        public OutputEmigrationData OutputEmigrationData { get; set; }

        [SerializeField]
        public OutputColonyData OutputColonyData { get; set; }

        [SerializeField]
        public OutputAntDelta OutputAntDelta { get; set; }

        [SerializeField]
        public OutputAntStateDistribution OutputAntStateDistribution { get; set; }

        [SerializeField]
        public OutputAntDetail OutputAntDetail { get; set; }

        [SerializeField]
        public OutputAntDebug OutputAntDebug { get; set; }

        [XmlIgnore]
        public List<SimulationPropertyBase> AllProperties { get { return _allProperties.Value; } }

        private Lazy<List<SimulationPropertyBase>> _allProperties;

        // Sections for colony
        // Sections for ant behaviour etc
        // Sections for map

        public SimulationSettings()
        {
            ArenaName = "Equidistant";

            ExperimentName = new ExperimentName();

            RandomSeed = new RandomSeed();
            ColonySize = new ColonySize();
            QuorumThreshold = new QuorumThreshold();
            ProportionActive = new ProportionActive();
            StartingTickRate = new StartingTickRate();
            AntsLayPheromones = new AntsLayPheromones();
            MaximumSimulationRunTime = new MaximumSimulationRunTime();

            StartingNestQuality = new StartingNestQuality();
            FirstNewNestQuality = new FirstNewNestQuality();
            SecondNewNestQuality = new SecondNewNestQuality();

            OutputTickRate = new OutputTickRate();
            OutputEmigrationData = new OutputEmigrationData();
            OutputColonyData = new OutputColonyData();
            OutputAntStateDistribution = new OutputAntStateDistribution();
            OutputAntDelta = new OutputAntDelta();
            OutputAntDetail = new OutputAntDetail();
            OutputAntDebug = new OutputAntDebug();

            _allProperties = new Lazy<List<SimulationPropertyBase>>(() =>
             {
                 return new List<SimulationPropertyBase>
                {
                    ExperimentName,
                    RandomSeed,

                    StartingTickRate,
                    MaximumSimulationRunTime,

                    ColonySize,
                    QuorumThreshold,
                    ProportionActive,

                    StartingNestQuality,
                    FirstNewNestQuality,
                    SecondNewNestQuality,

                    AntsLayPheromones,

                    OutputTickRate,
                    OutputEmigrationData,
                    OutputColonyData,
                    OutputAntDelta,
                    OutputAntStateDistribution,
                    OutputAntDetail,
                    OutputAntDebug
               };
             });
        }
    }
}
