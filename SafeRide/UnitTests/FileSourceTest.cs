//-----------------------------------------------------------------------
// <copyright file="FileSourceTest.cs" company="Mapbox">
//     Copyright (c) 2016 Mapbox. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
 using Mapbox.Platform;
using Xunit;

namespace SRUnitTests
{
    public class FileSourceTest
    {
        private const string _url = "https://api.mapbox.com/geocoding/v5/mapbox.places/helsinki.json";
        private FileSource _fs;


        [Fact]
        public void SetUp()
        {
            _fs = new FileSource();
        }


        [Fact]
        public void AccessTokenSet()
        {
            string key = Environment.GetEnvironmentVariable("MAPBOX_ACCESS_TOKEN".ToString());
            Assert.True(key != null,$"The Mapbox access token for the environment has been set to {key.ToString()}");
        }


        //    [Fact]
        //    public void Request()
        //    {
        //        _fs.Request(
        //            _url,
        //            (Response res) =>
        //            {
        //                Assert.IsNotNull(res.Data, "No data received from the servers.");
        //            });

        //        _fs.WaitForAllRequests();
        //    }


        //    [Fact]
        //    public void MultipleRequests()
        //    {
        //        int count = 0;

        //        _fs.Request(_url, (Response res) => ++count);
        //        _fs.Request(_url, (Response res) => ++count);
        //        _fs.Request(_url, (Response res) => ++count);

        //        _fs.WaitForAllRequests();

        //        Assert.AreEqual(count, 3, "Should have received 3 replies.");
        //    }


        //    [Fact]
        //    public void RequestCancel()
        //    {
        //        var request = _fs.Request(
        //            _url,
        //            (Response res) =>
        //            {
        //                Assert.IsTrue(res.HasError);
        //                WebException wex = res.Exceptions[0] as WebException;
        //                Assert.IsNotNull(wex);
        //                Assert.AreEqual(wex.Status, WebExceptionStatus.RequestCanceled);
        //            });

        //        request.Cancel();

        //        _fs.WaitForAllRequests();
        //    }


        //    [Fact]
        //    public void RequestDnsError()
        //    {
        //        _fs.Request(
        //            "https://dnserror.shouldnotwork",
        //            (Response res) =>
        //            {
        //                Assert.IsTrue(res.HasError);
        //            });

        //        _fs.WaitForAllRequests();
        //    }


        //    [Fact]
        //    public void RequestForbidden()
        //    {
        //        // Mapbox servers will return a forbidden when attempting
        //        // to access a page outside the API space with a token
        //        // on the query. Let's hope the behaviour stay like this.
        //        _fs.Request(
        //            "https://mapbox.com/forbidden",
        //            (Response res) =>
        //            {
        //                Assert.IsTrue(res.HasError);
        //            });

        //        _fs.WaitForAllRequests();
        //    }


        //    [Fact]
        //    public void WaitWithNoRequests()
        //    {
        //        // This should simply not block.
        //        _fs.WaitForAllRequests();
        //    }
        //}
    }
}