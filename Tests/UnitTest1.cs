namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void WithTrueData()
        {
            var client = new HttpClient();
            string url = "https://localhost:7200/api/games?genre=Sports";
            HttpResponseMessage response = client.GetAsync(url).Result;
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public void WithFalseData()
        {
            var client = new HttpClient();
            string url = "https://localhost:7200/api/games?genre=FalseData";
            HttpResponseMessage response = client.GetAsync(url).Result;
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}