namespace COVID19.Models.Response
{
    using System.Collections.Generic;

    public class CountriesResponse
    {
        public Dictionary<string, Country>[] Countries { get; set; }

        public string Dt { get; set; }

        public long Ts { get; set; }
    }
}
