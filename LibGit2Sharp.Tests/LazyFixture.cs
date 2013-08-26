﻿using System;
using LibGit2Sharp.Core.Compat;
using Xunit;

namespace LibGit2Sharp.Tests
{
    public class LazyFixture
    {
        [Fact]
        public void CanReturnTheValue()
        {
            var lazy = new LibGit2Sharp.Core.Compat.Lazy<int>(() => 2);
            Assert.Equal(2, lazy.Value);
        }

        [Fact]
        public void IsLazilyEvaluated()
        {
            int i = 0;

            var evaluator = new Func<int>(() => ++i);

            var lazy = new LibGit2Sharp.Core.Compat.Lazy<int>(evaluator);
            Assert.Equal(1, lazy.Value);
        }

        [Fact]
        public void IsEvaluatedOnlyOnce()
        {
            int i = 0;

            var evaluator = new Func<int>(() => ++i);

            var lazy = new LibGit2Sharp.Core.Compat.Lazy<int>(evaluator);

            Assert.Equal(1, lazy.Value);
            Assert.Equal(1, lazy.Value);
        }
    }
}
