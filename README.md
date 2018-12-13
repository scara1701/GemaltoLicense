# GemaltoLicense
Request the licenses in use for a Gemalto Sentinel license key. Result is exported to a CSV file.

Requires 4 arguments for succesfull usage:
* Servername/IP
* TCP service port
* Key index (when multiple keys are connected to the server)
* Key license

Example:

GemaltoSentinel.exe hostname 6002 1 000001234
