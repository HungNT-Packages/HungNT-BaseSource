﻿using Base;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Base
{
    public abstract class UITweenBase : MonoBehaviour, ITween
    {
        #region ===== Fields =====
        [Title("Base")]
        [SerializeField] [EnumToggleButtons]
        protected ETweenRun runType = ETweenRun.Auto;

        [SerializeField]
        protected TweenSettings settings;

        [SerializeField]
        protected bool overrideEase;

        [SerializeField] [ShowIf("@overrideEase")]
        protected Ease easeIn = Ease.Linear;

        [SerializeField] [ShowIf("@overrideEase")]
        protected Ease easeOut = Ease.Linear;

        [SerializeField]
        protected bool overrideDuration;

        [SerializeField] [ShowIf("@overrideDuration")]
        protected float durationIn = 0.25f;

        [SerializeField] [ShowIf("@overrideDuration")]
        protected float durationOut = 0.25f;

        [SerializeField]
        protected bool delay;

        [SerializeField] [ShowIf("@delay")]
        protected float delayIn;

        [SerializeField] [ShowIf("@delay")]
        protected float delayOut;
        #endregion

        #region ===== Properties =====
        public bool IsAutoRun => runType == ETweenRun.Auto;
        protected Ease EaseIn => overrideEase ? easeIn : settings.easeIn;
        protected Ease EaseOut => overrideEase ? easeOut : settings.easeOut;
        protected float DurationIn => overrideDuration ? durationIn : settings.durationIn;
        protected float DurationOut => overrideDuration ? durationOut : settings.durationOut;
        protected float DelayIn => delay ? delayIn : 0f;
        protected float DelayOut => delay ? delayOut : 0f;
        #endregion

        protected abstract string SettingsPath { get; }

        private bool isInitialized;

        protected virtual void Reset()
        {
            settings = Resources.Load<TweenSettings>(SettingsPath);
        }

        public async UniTask Init()
        {
            if (isInitialized) return;
            isInitialized = true;
            await Setup();
            Inactive();
        }

        protected virtual UniTask Setup()
        {
            if (settings == null)
            {
                settings = Resources.Load<TweenSettings>(SettingsPath);

                if (settings == null)
                {
                    Debug.LogError($"Not found {SettingsPath.Color("red")} in Resources");
                    settings = AssetLoader.Instance.LoadResource<TweenSettings>("TweenBaseSettings");
                }
            }

            return UniTask.CompletedTask;
        }

        public abstract UniTask Show();

        public abstract UniTask Hide();

        protected abstract void Active();

        protected abstract void Inactive();
    }
}