namespace transmission_renamer.Classes.Rules
{
    public interface RenameRule
    {

        public string Description { get; }
        public string Name { get;}
        public string Id { get; }

        public string DoRename(FriendlyTorrentFileInfo friendlyTorrentFileInfo);
    }
}
