﻿using System;
using System.Threading.Tasks;

namespace Test
{
    internal class Class
    {
        void Method()
        {
            Notify += async (sender, e) => await Task.Yield();
            Notify -= async (sender, e) => await Task.Yield();

            EventHandler handler = async (sender, e) => await Task.Yield();

            Notify += handler;
            Notify -= handler;
        }

        event EventHandler Notify;

        void Method2()
        {
            Notify += (sender, e) => { };
            Notify -= (sender, e) => { };

            EventHandler handler = (sender, e) => { };

            Notify += handler;
            Notify -= handler;
        }

        event Func<int, Task<int>> EventHandlerWithReturnValue;

        void Method3()
        {
            EventHandlerWithReturnValue += async e =>
            {
                await Task.Yield();
                return 0;
            };
            EventHandlerWithReturnValue -= async e =>
            {
                await Task.Yield();
                return 0;
            };

            Func<int, Task<int>> handler = async e =>
            {
                await Task.Yield();
                return 0;
            };

            EventHandlerWithReturnValue += handler;
            EventHandlerWithReturnValue -= handler;
        }
    }
}