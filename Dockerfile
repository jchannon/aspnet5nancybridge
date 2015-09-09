FROM microsoft/aspnet:1.0.0-beta7

# Note the new setup script name for Node.js v0.12
RUN curl -sL https://deb.nodesource.com/setup_0.12 | bash -

RUN mkdir /packages

ENV DNX_PACKAGES /packages

# Then install with:
RUN apt-get install -qq nodejs

RUN npm install -g nodemon

COPY nuget /root/.config/NuGet/

ENTRYPOINT dnu restore && nodemon --verbose --ext "cs,json" --exec "dnx kestrel"
