namespace transmission_renamer.Classes.Rules
{
    public interface IRenameRule
    {

        public string Description { get; }
        public string Name { get;}
        public string Id { get; }

        public string DoRename(FriendlyTorrentFileInfo friendlyTorrentFileInfo, int itemIndex);
    }
}
