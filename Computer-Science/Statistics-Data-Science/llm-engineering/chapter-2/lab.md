- Follow Readme docs of [pyenv-win](https://github.com/pyenv-win/pyenv-win)
- Clone the repo [llm-engineers-handbook](https://github.com/PacktPublishing/LLM-Engineers-Handbook)
- setup path variables
```
$env:USERPROFILE = "C:\Users\karth"
$env:PATH += ";$env:USERPROFILE\.pyenv\pyenv-win\bin;$env:USERPROFILE\.pyenv\pyenv-win\shims"
pyenv --version
```

- install poetry
```powershell
(Invoke-WebRequest -Uri https://install.python-poetry.org -UseBasicParsing).Content | python -
```

```powershell
[Environment]::SetEnvironmentVariable("Path", [Environment]::GetEnvironmentVariable("Path", "User") + ";$env:APPDATA\Python\Scripts", "User")

echo 'if (-not (Get-Command poetry -ErrorAction Ignore)) { $env:Path += ";$env:APPDATA\Python\Scripts" }' | Out-File -Append $PROFILE

. $PROFILE

poetry --version
```