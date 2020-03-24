namespace TelegramInterface.BaseTypes.Requests.Users
{
    public class GetUserProfilePhotos
    {
        /// <summary>
        /// Unique identifier of the target user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Sequential number of the first photo to be returned. By default, all photos are returned.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Limits the number of photos to be retrieved. Values between 1—100 are accepted. Defaults to 100.
        /// </summary>
        public int Limit { get; set; }
    }
}
