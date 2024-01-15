using RGB.NET.Core;
using StellarFx.LightFx;
using StellarFx.LightFx;

namespace StellarFx.Plugins.Artemis
{
    public class LightFxUpdateQueue : UpdateQueue
    {
        private readonly LightFxService _lightFx;
        private readonly uint deviceIdx;

        public LightFxUpdateQueue(LightFxService lightFx, uint deviceIdx, IDeviceUpdateTrigger updateTrigger) : base(updateTrigger)
        {
            _lightFx = lightFx;
            this.deviceIdx = deviceIdx;
            _lightFx.Initialize();
        }

        public override void Dispose()
        {
            _lightFx.Release();
        }

        public override void Reset()
        {
            _lightFx.Reset();
        }

        protected override bool Update(in ReadOnlySpan<(object key, Color color)> dataSet)
        {
            if (dataSet.IsEmpty)
            {
                return false;
            }

            foreach (var item in dataSet)
            {
                var ledId = item.Item1 as LedId?;
                if (!ledId.HasValue)
                {
                    continue;
                }

                if (!KeyboardIdMapping.Default.ContainsKey(ledId.Value))
                {
                    continue;
                }

                var lightIdx = KeyboardIdMapping.Default[ledId.Value];

                var colour = new LFX_Color
                {
                    red = item.Item2.GetR(),
                    green = item.Item2.GetG(),
                    blue = item.Item2.GetB(),
                    brightness = item.Item2.GetA()
                };

                _lightFx.SetLightColor(this.deviceIdx, (uint)lightIdx, colour);
            }

            _lightFx.Update();

            return true;
        }
    }
}