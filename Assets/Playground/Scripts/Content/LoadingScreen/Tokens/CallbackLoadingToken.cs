﻿using System;

namespace Playground.Content.LoadingScreen.UI
{
    public class CallbackLoadingToken : ILoadingToken
    {
        private Action onCompleted;

        public CallbackLoadingToken(Action onCompleted)
        {
            this.onCompleted = onCompleted;
        }

        public void Complete()
        {
            onCompleted?.Invoke();

            onCompleted = null;
        }
    }
}
