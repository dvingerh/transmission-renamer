namespace transmission_renamer
{
    public static partial class Globals
    {
        public enum RequestResult
        {
            Success,
            Timeout,
            InvalidResp,
            InvalidUrl,
            Unauthorized,
            Cancelled,
            Unknown,
            Failed
        }
    }
}
