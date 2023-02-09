﻿using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShanedlerSamples
{
    public static partial class HostExtensions
    {
        public static MauiAppBuilder ConfigureShanedler(this MauiAppBuilder builder)
        {
            return builder.ConfigureShanedler(true);
        }

        public static MauiAppBuilder ConfigureShanedler(this MauiAppBuilder builder, bool addAllWorkaround)
        {
#if ANDROID

            builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler<Entry, Platforms.Android.MaterialEntryHandler>();
            });

            PageHandler.PlatformViewFactory = (h) => new NotifyingContentViewGroup(h.Context);
#endif


            if (addAllWorkaround)
            {
                builder.ConfigureShellWorkarounds();
                builder.ConfigureTabbedPageWorkarounds();
                builder.ConfigureEntryNextWorkaround();
            }

            return builder;
        }

    }
}
