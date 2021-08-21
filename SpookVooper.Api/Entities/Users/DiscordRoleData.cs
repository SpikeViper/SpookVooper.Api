namespace SpookVooper.Api.Entities
{
    public class DiscordRoleData
    {
        public string Name { get; }

        public ulong Id { get; }

        public DiscordRoleData(string name, ulong id)
        {
            Name = name;
            Id = id;
        }
    }
}
