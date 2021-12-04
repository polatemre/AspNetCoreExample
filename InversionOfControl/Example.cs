﻿
using InversionOfControl.Services;

namespace InversionOfControl
{
    public class Example
    {
        public Example()
        {
            IServiceCollection services = new ServiceCollection(); // built - in IoC
            services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog(5)));
            services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog()));

            ServiceProvider provider = services.BuildServiceProvider(); // Somut container/provider/sağlayıcı
            provider.GetService<ConsoleLog>();
            provider.GetService<TextLog>();
        }
    }
}
