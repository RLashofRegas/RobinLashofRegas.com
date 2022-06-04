ARG VARIANT=ubuntu-20.04
FROM mcr.microsoft.com/vscode/devcontainers/base:0-${VARIANT}

# [Option] Install zsh
ARG INSTALL_ZSH="true"
# [Option] Upgrade OS packages to their latest versions
ARG UPGRADE_PACKAGES="false"
# [Option] Enable non-root Docker access in container
ARG ENABLE_NONROOT_DOCKER="true"
# [Option] Use the OSS Moby CLI instead of the licensed Docker CLI
ARG USE_MOBY="true"

# Enable new "BUILDKIT" mode for Docker CLI
ENV DOCKER_BUILDKIT=1

# Install needed packages and setup non-root user. Use a separate RUN statement to add your
# own dependencies. A user of "automatic" attempts to reuse an user ID if one already exists.
ARG USERNAME=automatic
ARG USER_UID=1000
ARG USER_GID=$USER_UID
COPY library-scripts/*.sh /tmp/library-scripts/
RUN apt-get update \
    && /bin/bash /tmp/library-scripts/common-debian.sh "${INSTALL_ZSH}" "${USERNAME}" "${USER_UID}" "${USER_GID}" "${UPGRADE_PACKAGES}" "true" "true" \
    # Use Docker script from script library to set things up
    && /bin/bash /tmp/library-scripts/docker-debian.sh "${ENABLE_NONROOT_DOCKER}" "/var/run/docker-host.sock" "/var/run/docker.sock" "${USERNAME}" \
    # Clean up
    && apt-get autoremove -y && apt-get clean -y && rm -rf /var/lib/apt/lists/* /tmp/library-scripts/

RUN apt-get update
RUN apt-get install -y gettext npm
RUN npm install -g npm@latest-6
RUN npm install -g @angular/cli@10

# set to codespace if CODESPACE_NAME is populated, otherwise default
ENV ANGULAR_ENVIRONMENT=${CODESPACE_NAME:+codespace} 
ENV ANGULAR_ENVIRONMENT=${ANGULAR_ENVIRONMENT:-default}

# ENV BlogAPIUrl=${CODESPACE_NAME:+https://${CODESPACE_NAME}-5432.githubpreview.dev/api/v1}
# ENV BlogAPIUrl=${BlogAPIUrl:-http://localhost:5432/api/v1}

ENV WebspaUrl=${CODESPACE_NAME:+https://${CODESPACE_NAME}-5431.githubpreview.dev}
ENV WebspaUrl=${WebspaUrl:-http://localhost:5431}

# Setting the ENTRYPOINT to docker-init.sh will configure non-root access 
# to the Docker socket. The script will also execute CMD as needed.
ENTRYPOINT [ "/usr/local/share/docker-init.sh" ]
CMD [ "sleep", "infinity" ]

# [Optional] Uncomment this section to install additional OS packages.
# RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
#     && apt-get -y install --no-install-recommends <your-package-list-here>