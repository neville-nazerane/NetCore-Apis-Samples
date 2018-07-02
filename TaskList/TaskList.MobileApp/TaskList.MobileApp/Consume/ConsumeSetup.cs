using NetCore.Apis.Consumer;
using System;
using System.Collections.Generic;
using System.Text;
using TaskList.Constants;

namespace TaskList.MobileApp.Consume
{
    public static class ConsumeSetup
    {

        static ApiConsumer consumer;
        public static ApiConsumer Consumer =>
                consumer ?? (consumer = new ApiConsumer(Urls.API));

    }
}
