#!/bin/bash
set -e

# If the Microsoft apt package was previously installed it can cause SHA1 signature errors on newer Debian.
# Remove it and any leftover sources to avoid apt failing on update.
if dpkg-query -W -f='${Status}' packages-microsoft-prod 2>/dev/null | grep -q "install ok installed"; then
  echo "Removing old packages-microsoft-prod to avoid broken Microsoft apt repo..."
  sudo dpkg -r packages-microsoft-prod || true
  sudo rm -f /etc/apt/sources.list.d/packages-microsoft-prod* /etc/apt/sources.list.d/microsoft-prod* || true
fi

# setup environment to code with C# on Ubuntu 20.04

# Quick notes:
# - .NET (dotnet) is a cross-platform runtime and SDK from Microsoft.
#   The SDK includes the command-line tools (dotnet), libraries, and the C# compiler.
#   The runtime executes compiled .NET assemblies and provides the JIT, GC, and base libraries.
# - C# compilers:
#   - Roslyn (csc): the modern open-source Microsoft compiler used by dotnet SDK. It compiles
#     C# source to Intermediate Language (IL) and emits assemblies (.dll/.exe).
#   - Mono mcs: older Mono compiler for the Mono runtime; still used in some environments.
#   - AOT/Native options: some toolchains (Mono AOT, Native AOT, or crossgen) produce native
#     binaries ahead-of-time instead of relying on JIT at runtime.
# - What happens when you compile and run C#:
#   1) Compile: source (*.cs) -> compiler (e.g., Roslyn) -> IL + metadata in assemblies.
#   2) Run: the runtime loads assemblies. By default a JIT compiler translates IL to native
#      code on demand and the program executes. With AOT/native builds, IL is precompiled to
#      native code before execution.
#   3) The runtime also provides services like garbage collection, exception handling, and
#      library loading.
#
# These notes should help understand the SDK vs runtime and basic compile/run flow.

# install prerequisites
sudo apt-get update
sudo apt-get install -y wget apt-transport-https ca-certificates gnupg lsb-release curl build-essential git unzip

# Install .NET SDK using Microsoft's dotnet-install script (works without apt repo)
curl -sSL https://dot.net/v1/dotnet-install.sh -o /tmp/dotnet-install.sh
bash /tmp/dotnet-install.sh --channel 6.0 --install-dir "$HOME/.dotnet" --no-path
rm /tmp/dotnet-install.sh

# Ensure runtime/tools are available in the user's shell (append if not already present)
if ! grep -q 'DOTNET_ROOT' "$HOME/.profile"; then
  cat >> "$HOME/.profile" <<'PROFILE_EOF'

# .NET SDK (installed by dotnet-install)

export DOTNET_ROOT="$HOME/.dotnet"
export PATH="$PATH:$HOME/.dotnet:$HOME/.dotnet/tools"
PROFILE_EOF
fi

echo "Dotnet installed to $HOME/.dotnet. Run 'source ~/.profile' or open a new shell, then 'dotnet --info'."
