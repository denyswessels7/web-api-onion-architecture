using System;
using System.Collections.Generic;
using System.Net;

namespace OA.Api.Tests
{
    public class BaseTest
    {
        private static readonly Dictionary<HttpStatusCode, int> _statusCodes =
            new Dictionary<HttpStatusCode, int>();

        public BaseTest()
        {
            if (_statusCodes.NoItems())
            {
                foreach (HttpStatusCode sc in Enum.GetValues(typeof(HttpStatusCode)))
                {
                    if (!_statusCodes.ContainsKey(sc))
                    {
                        _statusCodes.Add(sc, (int)sc);
                    }
                }
            }
        }

        public int this[HttpStatusCode code]
        {
            get { return _statusCodes[code]; }
        }
    }
}
