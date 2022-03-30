using System.Text;

var client = new System.Net.Http.HttpClient();
client.DefaultRequestHeaders.Add("Accept", "application/json");
client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ilg1ZVhrNHh5b2pORnVtMWtsMll0djhkbE5QNC1jNTdkTzZRR1RWQndhTmsifQ.eyJpc3MiOiJodHRwczovL2Nsb3Nla25pdGRldi5iMmNsb2dpbi5jb20vMWQxNjY5ZTUtMGE2ZS00ODA0LTg2NmYtMGEyNzJhZDJlYjkwL3YyLjAvIiwiZXhwIjoxNjQ4NjQ1ODkwLCJuYmYiOjE2NDg2NDIyOTAsImF1ZCI6IjU1MzU5ZGNlLThiODItNGY1Ni05MzEzLTU1MTEwYTFlODdlNCIsIm9pZCI6IjM1NzM3YzBkLWQxZGItNGQ4Zi1iMTJhLWZhMjM0NmM2YTQwYiIsInN1YiI6IjM1NzM3YzBkLWQxZGItNGQ4Zi1iMTJhLWZhMjM0NmM2YTQwYiIsImZhbWlseV9uYW1lIjoiQWJkdXJhaG1hbm5vdiIsImVtYWlscyI6WyJyYWJkdXJhaG1hbm92QHByb2R1Y3RpdmVlZGdlLmNvbSJdLCJ0ZnAiOiJCMkNfMV9XZWJBcHBTaWduSW4iLCJzY3AiOiJBcHBsaWNhdGlvbkFwaS5SZWFkV3JpdGUiLCJhenAiOiJiMDhjZWYxNy0yMjBiLTQxNmYtYjlhNC1jMDc4ZjA3MzIzZDAiLCJ2ZXIiOiIxLjAiLCJpYXQiOjE2NDg2NDIyOTB9.sqgv8bttRkFsBZEMUw_mSIxobW4DZbW305-hb3p7ET6Cl4aPlPM3EirDUV4MzXGTSLlBvlrfjGDzVSvIW8pRIalZ_lIhqgTnc8gJXWG6-vRZJCTkVS5AGbxxs33hkdquhdwIahp3q8Scl1jQKDmrwgzLCQQTKG3H9dEJiHACmd1YwBprhA14IjL41wOym2_nP8MmawkBUaFOfvL3HAukZgMeg7Q0Edm-029CA5mJJ3m-On9EKZ-1QTyIyAW1x6FVH6kTIAyGrg3Sio21MMAWNTlvL04Km3C1P_ixPiURfzpxle53xIkomF4Ji3iWi2Uh372QL1pBUwIinw_4ue7njg");

client.BaseAddress = new Uri("https://localhost:5001/app/api/");
  var apiUrl = "outside-provider";
var requestBody = @"{
  ""name"": ""test6"",
  ""phoneNumber"": ""111-111-1111"",
  ""address"": ""test "",
  ""city"": ""Kr"",
  ""state"": ""PL"",
  ""zip "": ""31637""
}";

var tasks = new List<Task<string>>();


for (int i = 0; i < 5; i++)
{
    async Task<string> func()
    {
        var response = await client.PutAsync(apiUrl, new StringContent(requestBody, Encoding.UTF8, "application/json"));
        var content = await response.Content.ReadAsStringAsync();
        return  response.StatusCode.ToString() + ": " + content;
    }

    tasks.Add(func());
}

await Task.WhenAll(tasks);

var postResponses = new List<string>();

foreach (var t in tasks)
{
    var postResponse = await t; //t.Result would be okay too.
    postResponses.Add(postResponse);
    Console.WriteLine(postResponse);
    Console.WriteLine();
}
