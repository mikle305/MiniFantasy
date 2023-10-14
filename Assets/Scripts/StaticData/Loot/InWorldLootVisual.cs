using System;
using Infrastructure.Services;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class InWorldLootVisual
    {
        [SerializeField] private Effect _lootEffect;
        [SerializeField] private ScaleTweenData _scaleTweenData;
        [SerializeField] private RotateTweenData _rotateTweenData;
        [SerializeField] private JumpTweenData _jumpTweenData;

        
        public Effect LootEffect => _lootEffect;
        public ScaleTweenData ScaleTweenData => _scaleTweenData;
        public RotateTweenData RotateTweenData => _rotateTweenData;
        public JumpTweenData JumpTweenData => _jumpTweenData;
    }
}