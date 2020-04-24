#!/bin/bash -

dotnet ef migrations add '$1' -p /src/Persistence -s /src/API