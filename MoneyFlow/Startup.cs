﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoneyFlow.Startup))]
namespace MoneyFlow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
