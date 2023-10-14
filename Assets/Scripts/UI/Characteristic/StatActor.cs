using GamePlay.Units;

namespace UI
{
    public class StatActor
    {
        private readonly IStatBar _statBar;
        private readonly ICharacteristic _characteristic;

        public StatActor(ICharacteristic characteristic, IStatBar statBar)
        {
            _characteristic = characteristic;
            _statBar = statBar;
            _characteristic.ValueChanged += UpdateStatBar;
        }
        
        private void UpdateStatBar() 
            => _statBar.SetValue(_characteristic.CurrentValue, _characteristic.MaxValue);
    }
}