using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> firstSet = new HashSet<string>();

        foreach (var word in words)
        {
            string wordInReverse = new string(word.Reverse().ToArray());

            // If the word in reverse is already there in firstSet then we will skip it
            if (firstSet.Contains(wordInReverse))
            {
                continue;
            }

            // Otherwise, we will add it to firstSet
            firstSet.Add(word);
        }

        HashSet<string> secondSet = new HashSet<string>();

        foreach (var word in words)
        {
            string wordInReverse = new string(word.Reverse().ToArray());

            // If the word not in reverse is already there in firstSet then we will skip it
            if (firstSet.Contains(word))
            {
                continue;
            }

            // Otherwise, we will add it to secondSet
            secondSet.Add(wordInReverse);
        }

        HashSet<string> pairOfWords = new HashSet<string>();

        // secondSet now only has words that meet our criteria

        foreach (var word in secondSet)
        {
            string wordInReverse = new string(word.Reverse().ToArray());

            pairOfWords.Add($"{wordInReverse} & {word}");
        }

        return pairOfWords.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            string degree = fields[3];

            degrees[degree] = degrees.ContainsKey(degree) ? ++degrees[degree] : 1;
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var word1Dictionary = new Dictionary<string, int>();

        foreach (char letter in word1)
        {
            if (letter == ' ')
            {
                continue;
            }

            string letterAsString = letter.ToString().ToLower();

            word1Dictionary[letterAsString] = word1Dictionary.ContainsKey(letterAsString) ? ++word1Dictionary[letterAsString] : 1;
        }

        var word2Dictionary = new Dictionary<string, int>();

        foreach (char letter in word2)
        {
            if (letter == ' ')
            {
                continue;
            }

            string letterAsString = letter.ToString().ToLower();

            word2Dictionary[letterAsString] = word2Dictionary.ContainsKey(letterAsString) ? ++word2Dictionary[letterAsString] : 1;
        }

        if (word1Dictionary.Count() != word2Dictionary.Count())
        {
            return false;
        }

        foreach (var word1FromDictioary in word1Dictionary)
        {
            var key = word1FromDictioary.Key;

            var value = word1FromDictioary.Value;

            // If there is even just one mismatch then we know these two words are not anagrams
            if (word2Dictionary.ContainsKey(key) == false || word2Dictionary[key] != value)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        List<string> items = new List<string>();

        foreach (var Feature in featureCollection.Features)
        {
            items.Add(Feature.Properties["place"] + " - Mag " + Feature.Properties["mag"]);
        }

        return items.ToArray();
    }
}