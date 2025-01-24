namespace ProjectWebUI.VMs.RapidAPIVM
{
    public class RootTastyVM
    {
        public List<ResultTastyVM> Results { get; set; }
    }

    public class ResultTastyVM
    {
        public string Name { get; set; }
        public string original_video_url { get; set; }
        public int prep_time_minutes { get; set; }
        public string thumbnail_url { get; set; }
    }
}
