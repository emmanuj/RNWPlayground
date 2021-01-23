using Microsoft.ReactNative.Managed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNWPlayground
{
    [ReactModule]
    class Notifications
    {

        [ReactEvent]
        public Action<int> TimedEvent { get; set; }

        [ReactMethod("getAppState")]
        public void GetAppState(ReactPromise<string> promise)
        {
            promise.Resolve(App.appState);
        }
    }
}
