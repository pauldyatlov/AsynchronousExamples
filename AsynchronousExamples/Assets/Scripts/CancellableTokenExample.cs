using System.Threading;
using System.Threading.Tasks;

namespace UbisoftPresentation
{
    public class CancellableTokenExample
    {
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

        private void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        private async Task Perform()
        {
            while (true)
            {
                if (_cancellationToken.IsCancellationRequested)
                    return;

                await Task.Yield();
            }
        }

        private void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}