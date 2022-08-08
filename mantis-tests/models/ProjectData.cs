namespace mantis_tests
{
    public class ProjectData
    {
        public ProjectData()
        {
        }

        public ProjectData(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public string Id { get; set; }
    }
}
