using HipchatApiV2;
using HipchatApiV2.Enums;
using log4net.Appender;
using log4net.Core;

namespace HipChat4Net
{
    public sealed class HipChatAppender : AppenderSkeleton
    {
      /// <summary>
      /// The HipChat Authorization Token
      /// </summary>
      public string AuthToken { get; set; }

      /// <summary>
      /// The id or name of the room
      /// </summary>
      public string RoomName { get; set; }

      /// <summary>
      /// Whether this message should trigger a user notification (change the tab color, play a sound, notify mobile phones, etc). Each recipient's notification preferences are taken into account.
      /// Defaults to false.
      /// </summary>
      public bool Notify { get; set; }

      /// <summary>
      /// Background color for message.
      /// Valid values: yellow, green, red, purple, gray, random.
      /// Defaults to 'yellow'.
      /// </summary>
      public string Color {
        get { return _backgroundColor.ToString(); }
        set { RoomColors.TryParse(value.ToString(), true, out _backgroundColor); }
      }

      private RoomColors _backgroundColor;
      private HipchatClient _client = null;

      protected override void Append(LoggingEvent loggingEvent)
      {
        if (_client == null)
        {
          _client = new HipchatClient(this.AuthToken);
        }

        _client.SendNotification(this.RoomName, RenderLoggingEvent(loggingEvent), _backgroundColor, this.Notify);
      }


    }
}
