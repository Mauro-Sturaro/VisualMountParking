# Astro mount visual parking
Accurately park a remote astronomical mount using a security camera

I am an astrophotographer and use a remote observatory with a sliding roof.
At the end of each evening, the telescope must be placed in a specific location before closing the roof.

There are high-end astronomical mounts (the motors that move the telescope) that have very accurate sensors on the actual position, but many people like me use less expensive ones.
My mount is accurate, but in some cases (for example, if something gets stuck and I have to restart everything) it loses the exact information about its position.

This tool uses the image from a secure camera to verify that the telescope position is the same as the reference position. The image is read from a URL or file.

You can define certain areas in the image that will be compared to identify any shifts.

There are also two buttons to turn the camera's infrared lights on and off, again via WebApi commands.
