using GamePlay.LootSystem;
using StaticData;

namespace Infrastructure.Services
{
    public class LootConfigurator : ILootConfigurator
    {
        private readonly IStaticDataService _staticDataService;


        public LootConfigurator(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Configure(LootPiece lootPiece, LootId lootId)
        {
            LootData lootData = _staticDataService.GetLootData(lootId);
            InitLootPiece(lootPiece, lootData);
            InitVisual(lootPiece, lootData.InWorldLootVisual);
        }

        private static void InitLootPiece(LootPiece lootPiece, LootData lootData)
            => lootPiece.Init(lootData);

        private static void InitVisual(LootPiece lootPiece, InWorldLootVisual lootVisual)
        {
            InitFx(lootPiece, lootVisual);
            InitRotateTween(lootPiece, lootVisual);
            InitScaleTween(lootPiece, lootVisual);
            InitJumpTween(lootPiece, lootVisual);
        }

        private static void InitFx(LootPiece lootPiece, InWorldLootVisual lootVisual)
        {
            if (!lootPiece.TryGetComponent(out LootEffect lootEffect))
                return;
            
            lootEffect.Init(lootVisual.LootEffect);
            lootEffect.PlayEffect();
        }

        private static void InitRotateTween(LootPiece lootPiece, InWorldLootVisual lootVisual)
        {
            if (!lootPiece.TryGetComponent(out RotateAroundTween rotateTween)) 
                return;
            
            rotateTween.Init(lootVisual.RotateTweenData);
            rotateTween.StartTween();
        }

        private static void InitScaleTween(LootPiece lootPiece, InWorldLootVisual lootVisual)
        {
            if (!lootPiece.TryGetComponent(out ScaleTween scaleTween)) 
                return;
            
            scaleTween.Init(lootVisual.ScaleTweenData);
            scaleTween.StartTween();
        }

        private static void InitJumpTween(LootPiece lootPiece, InWorldLootVisual lootVisual)
        {
            if (!lootPiece.TryGetComponent(out JumpTween jumpTween))
                return;
            
            jumpTween.Init(lootVisual.JumpTweenData);
            jumpTween.StartTween();
        }
    }
}