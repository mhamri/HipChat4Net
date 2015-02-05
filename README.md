# HipChat4Net
Log4Net Appender for HipChat APIV2

Uses the API Wrapper from [Hipchat-CS] (https://github.com/KyleGobel/Hipchat-CS)

For API v1, see [Log4NetHipChatAppender] (https://github.com/zopaUK/Log4NetHipChatAppender)

Use as you would use any other Log4Net Appender. Reference the assembly and include this in your config.

```
    <appender name="HipChatAppender" type="HipChat4Net.HipChatAppender, HipChat4Net">
      <AuthToken value=""/>
      <RoomName value="TestRoom"/>
      <Color value="yellow"/>
      <Notify value="false"/>
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%logger - %message"/>
      </layout>
    </appender>
```

The AuthToken is required and can be generated in the HipChat Admin. A Room Token is sufficient as it will only require 'room_notification' permissions.

The RoomName is required and is the Name or ID of the Target Chat Room

Color is optional. Choices are yellow, green, red, purple, gray, and random. The default is yellow.

Notify is optional. If True, will 'notify' the room. Default is false;

I don't advise using this appender for much more than emergency notifications. It is meant to be lightweight and synchronous.
