using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Services;
using Xunit;

namespace SRUnitTests
{
    public class TokenServiceUnits
    {
        [Fact]
        public void TokenGetUser_OK()
        {
            var token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYXBwbGUiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJhZG1pbiIsIkFjdGl2ZSI6Im5vbi1hY3RpdmUiLCJpc3MiOiJ3d3cuc2FmZXJpZGUubmV0In0.BPiu6-4YYhT2hAIlaW600kOaT0kTN93TfkiZLsFdhlc";

            var user = JwtDecoder.GetUser(token);

            Assert.Equal("apple", user);
        }

        [Fact]
        public void TokenGetUser_FAIL()
        {
            var token = "yJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYXBwbGUiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJhZG1pbiIsIkFjdGl2ZSI6Im5vbi1hY3RpdmUiLCJpc3MiOiJ3d3cuc2FmZXJpZGUubmV0In0.BPiu6-4YYhT2hAIlaW600kOaT0kTN93TfkiZLsFdhlc";

            var user = JwtDecoder.GetUser(token);

            Assert.NotEqual("apple", user);
        }
    }
}
