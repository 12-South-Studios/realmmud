﻿using Realm.Library.Common.Entities;

namespace Realm.Server.Test.Helpers
{
    public class FakeEntity : IEntity
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public void Dispose()
        {
            // do nothing
        }
    }
}
