﻿//-----------------------------------------------------------------------
// <copyright file="EsentResourceTests.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Microsoft.Isam.Esent.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InteropApiTests
{
    /// <summary>
    /// Test the EsentResource class
    /// </summary>
    [TestClass]
    public class EsentResourceTests
    {
        /// <summary>
        /// Check that disposing the object frees the resource.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void EsentResourceDisposeReleasesResource()
        {
            MockEsesntResource saved = null;
            using (var r = new MockEsesntResource())
            {
                saved = r;
                r.Open();
            }

            Assert.IsTrue(saved.WasReleaseResourceCalled);
        }

        /// <summary>
        /// Check that disposing the object twice works.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void EsentResourceDisposeTwice()
        {
            var r = new MockEsesntResource();
            r.Open();
            r.Dispose();
            r.Dispose();
            Assert.IsTrue(r.WasReleaseResourceCalled);
        }

        /// <summary>
        /// Check that disposing the object does not free a
        /// resource that was never opened.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void EsentResourceDisposeDoesNotFreeUnopenedResource()
        {
            MockEsesntResource saved = null;
            using (var r = new MockEsesntResource())
            {
                saved = r;
            }

            Assert.IsFalse(saved.WasReleaseResourceCalled);
        }

        /// <summary>
        /// Check that disposing the object does not free a closed
        /// resource.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void EsentResourceDisposeDoesNotFreeClosedResource()
        {
            MockEsesntResource saved = null;
            using (var r = new MockEsesntResource())
            {
                saved = r;
                r.Open();
                r.Close();
            }

            Assert.IsFalse(saved.WasReleaseResourceCalled);
        }

        /// <summary>
        /// Check that using a disposed object generates an exception.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void EsentResourceDisposedObjectThrowsException()
        {
            var r = new MockEsesntResource();
            r.Open();
            r.Dispose();
            r.Open();
        }

        /// <summary>
        /// Mock object that inherits from the EsentResource class.
        /// </summary>
        private class MockEsesntResource : EsentResource
        {
            /// <summary>
            /// Gets or sets a value indicating whether the internal ReleaseResource method 
            /// was called.
            /// </summary>
            public bool WasReleaseResourceCalled { get; private set; }

            /// <summary>
            /// Performs a fake resource allocation.
            /// </summary>
            public void Open()
            {
                this.CheckObjectIsNotDisposed();
                this.ResourceWasAllocated();
            }

            /// <summary>
            /// Performs a fake resource free.
            /// </summary>
            public void Close()
            {
                this.CheckObjectIsNotDisposed();
                this.ResourceWasReleased();
            }

            /// <summary>
            /// Release the underlying resource.
            /// </summary>
            protected override void ReleaseResource()
            {
                this.WasReleaseResourceCalled = true;
                this.ResourceWasReleased();
            }
        }
    }
}