
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace QuizTime.Shared.UI.Composite
{
    public class CountdownBase : SettingsStateComponentBase, IDisposable
    {
        private System.Threading.Timer _timer;

        protected uint _timeLeftInSeconds;

        private bool _active;

        public CountdownBase() : base()
        {
        }

        [Parameter]
        public uint Duration {get; set;}

        [Parameter]
        public EventCallback<uint> OnTimeRemainingChanged {get;set;}

        public uint TimeRemaining => _timeLeftInSeconds;

        public bool IsActive => _active;


        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Start();
            }
        }

        protected async Task SetTimeReminingInSeconds (uint value)
        {
            _timeLeftInSeconds = value;
            await OnTimeRemainingChanged.InvokeAsync(value);
        }

        public void Start()
        {
            Stop();

            _timeLeftInSeconds = Duration;

            _timer = new System.Threading.Timer(async _ =>
            {
                if (_timeLeftInSeconds > 0)
                {
                    _active = true;
                    await SetTimeReminingInSeconds(_timeLeftInSeconds - 1);
                    await InvokeAsync(StateHasChanged);
                }
            }, null, 0, 1000);
        }

        public void Reset()
        {
            Stop();
            _timeLeftInSeconds = Duration * 60;
            InvokeAsync(StateHasChanged);
        }

        public void Stop()
        {
            _active = false;
            _timer?.Dispose();
        }

        public override void Dispose()
        {
            _timer?.Dispose();
        }
    }
}