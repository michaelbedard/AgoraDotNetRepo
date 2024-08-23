using AgoraDotNet.Core.Interfaces;

namespace AgoraDotNet.Application.Services
{
    public class DuoService
    {
        private readonly IRuntimeUserManager _runtimeUserManager;

        public DuoService(IRuntimeUserManager runtimeUserManager)
        {
            _runtimeUserManager = runtimeUserManager;
        }

        public void RequestDuo(string requesterUsername, string targetUsername)
        {
            var requester = _runtimeUserManager.GetUserByUsername(requesterUsername);
            var target = _runtimeUserManager.GetUserByUsername(targetUsername);

            if (requester == null || target == null)
            {
                throw new InvalidOperationException("One or both users not found.");
            }

            if (requester.IsInDuo || target.IsInDuo)
            {
                throw new InvalidOperationException("One of the users is already in a duo.");
            }

            // Pair users as duo
            requester.DuoPartner = target;
            target.DuoPartner = requester;
            requester.IsInDuo = true;
            target.IsInDuo = true;
        }

        public void LeaveDuo(string username)
        {
            var user = _runtimeUserManager.GetUserByUsername(username);
            if (user == null || !user.IsInDuo)
            {
                throw new InvalidOperationException("User is not in a duo.");
            }

            var partner = user.DuoPartner;
            if (partner != null)
            {
                partner.DuoPartner = null;
                partner.IsInDuo = false;
            }

            user.DuoPartner = null;
            user.IsInDuo = false;
        }
    }
}