#  Events & Forwards

FragBot3 contains an event-logging system (heavily inspired by Get5) that logs many details about what is happening in the game.

## HTTP

To receive FragBot3 events on a web server, define a [URL for event logging](../configuration#fragbot3_remote_log_url). FragBot3
will send all events to the URL as JSON over HTTP. You may add
a [custom HTTP header](../configuration#fragbot3_remote_log_header_key) to authenticate your request.

!!! warning "Simple HTTP"

    There is no deduplication or retry-logic for failed requests. It is assumed that a stable connection can be made
    between your game server and the URL at all times.

## Events

OpenAPI documentation of the events sent by FragBot3 is available [here](events.html).
