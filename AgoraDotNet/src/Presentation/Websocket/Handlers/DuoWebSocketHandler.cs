using AgoraDotNet.Application.Services;

namespace AgoraDotNet.Websockets.Handlers
{
    public class DuoWebSocketHandler
    {
        private readonly DuoService _duoService;

        public DuoWebSocketHandler(DuoService duoService)
        {
            _duoService = duoService;
        }

        public void HandleDuoRequest(string requesterUsername, string targetUsername)
        {
            try
            {
                _duoService.RequestDuo(requesterUsername, targetUsername);
                // Send success message back to requester
            }
            catch (Exception ex)
            {
                // Send failure message to requester
            }
        }

        public void HandleLeaveDuo(string username)
        {
            try
            {
                _duoService.LeaveDuo(username);
                // Send success message back to user
            }
            catch (Exception ex)
            {
                // Send failure message to user
            }
        }
    }
}