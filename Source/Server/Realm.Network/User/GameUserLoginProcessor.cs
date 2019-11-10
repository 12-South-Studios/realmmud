using System;
using System.Collections.Generic;
using System.Linq;
using Realm.Library.Common;
using Realm.Library.Common.Events;

namespace Realm.Network.User
{
    /// <summary>
    /// 
    /// </summary>
    public class GameUserLoginProcessor
    {
        private readonly int _maxUsernameLength;
        private readonly int _minUsernameLength;
        private readonly string _backdoorPassword;
        private readonly GameUserLoader _loader;
        private EventCallback<RealmEventArgs> _callback;

        private string _username;
        private string _password;
        private GameUser _user;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLoader"></param>
        /// <param name="backdoorPassword"></param>
        /// <param name="maxUsernameLength"></param>
        /// <param name="minUsernameLength"></param>
        public GameUserLoginProcessor(GameUserLoader userLoader, string backdoorPassword,
            int maxUsernameLength, int minUsernameLength)
        {
            Validation.IsNotNullOrEmpty(backdoorPassword, "backdoorPassword");
            Validation.Validate<ArgumentOutOfRangeException>(minUsernameLength >= 3 && minUsernameLength <= 64);
            Validation.Validate<ArgumentOutOfRangeException>(maxUsernameLength >= 3 && maxUsernameLength <= 64);
            Validation.Validate(maxUsernameLength > minUsernameLength);

            _loader = userLoader;
            _backdoorPassword = backdoorPassword;
            _maxUsernameLength = maxUsernameLength;
            _minUsernameLength = minUsernameLength;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="user"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void Execute(GameUser user, string username, string password, EventCallback<RealmEventArgs> callback)
        {
            Validation.IsNotNull(callback, "callback");

            var table = new EventTable();
            var args = new RealmEventArgs(table);

            var errors = ValidateAndNotifyUsername(user, username, password);
            if (errors.Any())
            {
                table.Add("errors", errors);
                callback.Invoke(args);
                return;
            }

            if (password.Equals(_backdoorPassword))
            {
                table.Add("errors", errors);
                callback.Invoke(args);
                return;
            }

            _username = username;
            _password = password;
            _callback = callback;
            _loader.Load(username, user.IpAddress, OnUserLoadComplete);
        }

        private void OnUserLoadComplete(RealmEventArgs args)
        {
            // Get PreHash and PostHash
            // Validation the Password      Password.ValidatePasswordHashV1(pass, user.Password, preHash.Name, postHash.Name)
        }

        private IEnumerable<string> ValidateAndNotifyUsername(GameUser user, string username, string password)
        {
            var errors = new List<string>();

            if (username.Length > _maxUsernameLength)
                errors.Add($"Usernames cannot be longer than {_maxUsernameLength} characters.");
            
            if (username.Length < _minUsernameLength)
                errors.Add($"Usernames mmust be at least {_minUsernameLength} characters in length.");
            
            return errors;
        }
    }
}