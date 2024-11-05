[CmdletBinding()]
param (
    [Parameter(Position=0, Mandatory=$true)]
    [string]$name,
    [Alias("useGit")]
    [switch]$inializeGitRepository
)

if($name.Contains(" ")){
    write-error "Name cannot contain spaces";
    return;
}

if($name[0] -ge '0' -and $name[0] -le '9') {
    write-error "Name cannot start with a number"
    return;
}

mkdir $name
Set-Location $name

dotnet new gitignore
dotnet new sln
dotnet new classlib -n "$name.Logic"
dotnet new console -n "$name.ConsoleUI"
dotnet new blazor -n "$name.WebUI" --all-interactive
dotnet new xunit -n "$name.Tests"
dotnet new classlib -n "$name.Persistence"

dotnet add "$name.Persistence" reference "$name.Logic"
dotnet add "$name.ConsoleUI" reference "$name.Logic"
dotnet add "$name.ConsoleUI" reference "$name.Persistence"
dotnet add "$name.WebUI" reference "$name.Logic"
dotnet add "$name.WebUI" reference "$name.Persistence"
dotnet add "$name.Tests" reference "$name.Logic"

if($useInterfaces) {
    dotnet add classlib -n "$name.Interfaces"
    dotnet add "$name.Logic" reference "$name.Interfaces"
    dotnet add "$name.ConsoleUI" reference "$name.Interfaces"
    dotnet add "$name.WebUI" reference "$name.Interfaces"
    dotnet add "$name.Tests" reference "$name.Interfaces"
} 

Get-ChildItem . -Directory | ForEach-Object { dotnet sln add $_ }

if($inializeGitRepository) {
    git init
    git add .
    git commit -m "Initial solution files"
}